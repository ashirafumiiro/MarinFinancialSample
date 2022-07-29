import React,{Component} from 'react';
import {Modal,Button, Row, Col, Form} from 'react-bootstrap';


export class EditBookModal extends Component{
    constructor(props){
        super(props);
        this.state={authors:[], genres:[]};
        this.handleSubmit=this.handleSubmit.bind(this);
    }

    componentDidMount(){
        fetch(process.env.REACT_APP_BASE_URL+'authors')
        .then(response=>response.json())
        .then(data=>{
            console.log("authors:", data)
            this.setState({authors:data});
        });

        fetch(process.env.REACT_APP_BASE_URL+'genres')
        .then(response=>response.json())
        .then(data=>{
            console.log('genres',data)
            this.setState({genres:data});
        });
    }

    handleSubmit(event){
        event.preventDefault();
        console.log('body:',{
            Id: event.target.Id.value,
            Title: event.target.Title.value,
            Summary: event.target.Summary.value,
            Isbn: event.target.Isbn.value,
            GenreId: event.target.GenreId.value,
            AuthorId: event.target.AuthorId.value,
        });
        fetch(process.env.REACT_APP_BASE_URL+'books/'+event.target.Id.value,{
            method:'PUT',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify({
                Id: event.target.Id.value,
                Title: event.target.Title.value,
                Summary: event.target.Summary.value,
                Isbn: event.target.Isbn.value,
                GenreId: event.target.GenreId.value,
                AuthorId: event.target.AuthorId.value,
            })
        })
        .then(res=>res.json())
        .then((result)=>{
            alert("Success");
        },
        (error)=>{
            alert('Failed');
        })
    }

    render(){
        return (
            <div className="container">

                <Modal {...this.props} size="lg" aria-labelledby="contained-modal-title-vcenter"
                    centered>
                    <Modal.Header clooseButton>
                        <Modal.Title id="contained-modal-title-vcenter">
                            Edit Book
                        </Modal.Title>
                    </Modal.Header>
                    <Modal.Body>

                        <Row>
                            <Col sm={6}>
                                <Form onSubmit={this.handleSubmit}>
                                <Form.Group controlId="Id">
                                        <Form.Label>Id</Form.Label>
                                        <Form.Control type="text" name="Id" required 
                                        placeholder="Id"
                                        disabled
                                        defaultValue={this.props.id}/>
                                    </Form.Group>

                                    <Form.Group controlId="Title">
                                        <Form.Label>Title</Form.Label>
                                        <Form.Control type="text" name="Title" required 
                                        defaultValue={this.props.title}
                                        placeholder="Title"/>
                                    </Form.Group>

                                    <Form.Group controlId="Summary">
                                        <Form.Label>Summary</Form.Label>
                                        <Form.Control type="text" name="Summary" required 
                                        defaultValue={this.props.summary}
                                        placeholder="Summary"/>
                                    </Form.Group>

                                    <Form.Group controlId="Isbn">
                                        <Form.Label>Isbn</Form.Label>
                                        <Form.Control type="text" name="Isbn" required 
                                        defaultValue={this.props.isbn}
                                        placeholder="Isbn"/>
                                    </Form.Group>

                                    <Form.Group controlId="AuthorId">
                                        <Form.Label>Author </Form.Label>
                                        <Form.Control as="select" defaultValue={this.props.author_id}>
                                        {this.state.authors.map(author=>
                                            <option key={author.id} value={author.id}>{author.firstName + " " + author.lastName}</option>)}
                                        </Form.Control>
                                    </Form.Group>

                                    <Form.Group controlId="GenreId">
                                        <Form.Label>Genre</Form.Label>
                                        <Form.Control as="select" defaultValue={this.props.genre_id}>
                                        {this.state.genres.map(genre=>
                                            <option key={genre.id} value={genre.id}>{genre.name}</option>)}
                                        </Form.Control>
                                    </Form.Group>

                                    <Form.Group>
                                        <Button variant="primary" type="submit">
                                            Update Book
                                        </Button>
                                    </Form.Group>
                                </Form>
                            </Col>
                        </Row>
                    </Modal.Body>
                    
                    <Modal.Footer>
                        <Button variant="danger" onClick={this.props.onHide}>Close</Button>
                    </Modal.Footer>

                </Modal>

            </div>
        )
    }
}