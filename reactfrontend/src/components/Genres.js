import { useState } from "react"
import { ListGroup, Col, Container, Button, Modal, Form, ButtonToolbar } from 'react-bootstrap';

const Genres = ({genres, handleDeleteGenre, handleSubmitGenre}) => {
  const [showEdit, setShowEdit] = useState(false);
  const [editGenre, setEditGenre] = useState({})

  const handleClose = () => {
    setShowEdit(false)
  }
  
  const handleSubmit = (event) => {
    event.preventDefault();
    const id = Number (event.target.id ? event.target.id.value || 0 : 0)
    const genre = {
      id: id,
      name: event.target.name.value,
    }

    handleSubmitGenre(genre)
    .then(() => {
      handleClose()
    })
    
  }

  const handleDelete= id =>{
    handleDeleteGenre(id);
  }

  const displayForEdit = id => {
    const genre = genres.find(g => g.id === id);
    setEditGenre(genre)
    setShowEdit(true);
  }

  const displayForNew = () => {
    const genre = { id: 0, name: '' };
    setEditGenre(genre)
    setShowEdit(true);
  }


  return (
    <div>
      <h4>Genres</h4>
      <Container>
        <Col sm={6}>
          <ListGroup as="ul">
            {
              genres.map(genre =>
                <ListGroup.Item as="li" className="d-flex justify-content-between align-items-start" key={genre.id} >
                  <div className="ms-2 me-auto">
                    <div className="fw-bold">{genre.id}. {genre.name}</div>
                  </div>
                  <div>
                    <Button variant="primary" size="sm" onClick={() => displayForEdit(genre.id)}>
                      Edit
                    </Button>{' '}
                    <Button variant="danger" size="sm" onClick={() => handleDelete(genre.id)}>
                      Delete
                    </Button>
                  </div>
                </ListGroup.Item>
              )
            }

          </ListGroup>
          <ButtonToolbar>
            <Button variant='primary' className="mt-3"
              onClick={() => displayForNew()}>
              Add New</Button>
          </ButtonToolbar>

          <Modal show={showEdit} onHide={handleClose}>
            <Modal.Header closeButton>
              <Modal.Title>Modal heading</Modal.Title>
            </Modal.Header>

            <Modal.Body>
              <Form onSubmit={handleSubmit}>
                <input type='hidden' name="id" value={editGenre.id} />
                <Form.Group className="mb-3" controlId="name">
                  <Form.Label>Genre Name</Form.Label>
                  <Form.Control type="text" placeholder="Enter Genre Name" name="name" defaultValue={editGenre.name} />
                  <Form.Text className="text-muted">
                    Type name above
                  </Form.Text>
                </Form.Group>
                <Button variant="primary" type="submit">
                  Save
                </Button>
              </Form>
            </Modal.Body>
            <Modal.Footer>
              <Button variant="secondary" onClick={handleClose}>
                Close
              </Button>
            </Modal.Footer>
          </Modal>
        </Col>
      </Container>

    </div>
  )
}

export default Genres