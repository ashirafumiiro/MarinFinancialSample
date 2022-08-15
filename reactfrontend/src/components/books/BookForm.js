import { Button, Form, Container, Col } from 'react-bootstrap';

const BookForm = (props) => {
  console.log('initial:', props)
  const {authors, genres} = props
  const handleSubmit = (event) => {
    event.preventDefault();
    const book = {
      id: event.target.Id ? event.target.Id.value || 0 : 0,
      title: event.target.Title.value,
      summary: event.target.Summary.value,
      isbn: event.target.Isbn.value,
      authorId: event.target.AuthorId.value,
      genreId: event.target.GenreId.value
    }
    props.handleSubmit(book)
  }

  return (
    <Container>
      <Col sm={6}>
        <Form onSubmit={handleSubmit}>
          {props.id ? <Form.Group controlId="Id">
            <Form.Label>Id</Form.Label>
            <Form.Control type="text" name="Id" required
              placeholder="Id"
              disabled
              defaultValue={props.id} />
          </Form.Group> : <h4>Create New</h4>}
          

          <Form.Group controlId="Title">
            <Form.Label>Title</Form.Label>
            <Form.Control type="text" name="Title" required
              defaultValue={props.title}
              placeholder="Title" />
          </Form.Group>

          <Form.Group controlId="Summary">
            <Form.Label>Summary</Form.Label>
            <Form.Control as="textarea" rows={3} name="Summary" required
              defaultValue={props.summary}
              placeholder="Summary" />
          </Form.Group>

          <Form.Group controlId="Isbn">
            <Form.Label>Isbn</Form.Label>
            <Form.Control type="text" name="Isbn" required
              defaultValue={props.isbn}
              placeholder="Isbn" />
          </Form.Group>

          <Form.Group controlId="AuthorId">
            <Form.Label>Author </Form.Label>
            <Form.Control as="select" defaultValue={props.authorId}>
              {authors.map(author =>
                <option key={author.id} value={author.id}>{author.firstName + " " + author.lastName}</option>)}
            </Form.Control>
          </Form.Group>

          <Form.Group controlId="GenreId">
            <Form.Label>Genre</Form.Label>
            <Form.Control as="select" defaultValue={props.genreId}>
              {genres.map(genre =>
                <option key={genre.id} value={genre.id}>{genre.name}</option>)}
            </Form.Control>
          </Form.Group>

          <Form.Group className="pt-3">
            <Button variant="primary" type="submit" id='save-button'>
              Save
            </Button>
          </Form.Group>
        </Form>
      </Col>
    </Container>
  )
}

export default BookForm;