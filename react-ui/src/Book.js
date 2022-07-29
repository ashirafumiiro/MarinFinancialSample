import React,{Component} from 'react';
import {Table} from 'react-bootstrap';

import {Button,ButtonToolbar} from 'react-bootstrap';
import {AddBookModal} from './AddBookModel';
import {EditBookModal} from './EditBookModal';

export class Book extends Component{

    constructor(props){
        super(props);
        this.state={books:[], addModalShow:false, editModalShow:false}
    }

    refreshList(){
        fetch(process.env.REACT_APP_BASE_URL+'books')
        .then(response=>response.json())
        .then(data=>{
            console.log("Books Data:", data)
            this.setState({books:data});
        });
    }

    componentDidMount(){
        this.refreshList();
    }

    // componentDidUpdate(){
    //     this.refreshList();
    // }

    deleteBook(bookId){
        if(window.confirm('Are you sure?')){
            fetch(process.env.API_URL_BASE+'books/'+bookId,{
                method:'DELETE',
                header:{'Accept':'application/json',
            'Content-Type':'application/json'}
            });
        }
    }
    render(){
        const {books, id, title, summary, isbn, genreId, authorId}=this.state;
        let addModalClose=()=>this.setState({addModalShow:false});
        let editModalClose=()=>this.setState({editModalShow:false});
        return(
            <div>
                <Table className="mt-2" striped bordered hover responsive size="sm">
                    <thead>
                        <tr>
                            <th>Id</th>
                            <th>Title</th>
                            <th>Summary</th>
                            <th>Isbn</th>
                            <th>Author</th>
                            <th>GenreId</th>
                            <th>Options</th> 
                        </tr>        
                    </thead>
                    <tbody>
                        {books.map(book=>
                            <tr key={book.id}>
                                <td>{book.id}</td>
                                <td>{book.title}</td>
                                <td>{book.summary}</td>
                                <td>{book.isbn}</td>
                                <td>{book.author.firstName + " " +book.author.lastName}</td>
                                <td>{book.genre.name}</td>
                                <td>
                                    <ButtonToolbar>
                                        <Button className="mr-2" variant="info"
                                        onClick={()=>this.setState({editModalShow:true,
                                            id:book.id,title:book.title, summary: book.summary,
                                            isbn: book.isbn, genreId: book.genre.id, authorId: book.author.id})}>
                                                Edit
                                            </Button>
                                            <Button className="mr-2" variant="danger"
                                                    onClick={()=>this.deleteBook(book.id)}>
                                                Delete
                                            </Button>

                                            <EditBookModal show={this.state.editModalShow} onHide={editModalClose}
                                                id={id}
                                                title={title}
                                                summary={summary}
                                                isbn={isbn}
                                                genre_id={genreId}
                                                author_id={authorId}
                                                />
                                                
                                    </ButtonToolbar>
                                </td>

                            </tr>)}
                    </tbody>

                </Table>

                <ButtonToolbar>
                    <Button variant='primary'
                    onClick={()=>this.setState({addModalShow:true})}>
                    Add Book</Button>

                    <AddBookModal show={this.state.addModalShow}
                    onHide={addModalClose}/>
                </ButtonToolbar>
            </div>
        )
    }
}