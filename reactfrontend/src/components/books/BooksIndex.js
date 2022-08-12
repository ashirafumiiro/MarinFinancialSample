import { useNavigate } from "react-router-dom"
import { Table } from 'react-bootstrap';
import { Button, ButtonToolbar } from 'react-bootstrap';

const BooksIndex = ({ books, handleDelete }) => {

    const navigate = useNavigate()

    const goToEdit = (id) => {
        navigate('/books/edit/' + id)
    }

    return (
        <div>
            <h4>Books</h4>
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
                    {books.map(book =>
                        <tr key={book.id}>
                            <td>{book.id}</td>
                            <td>{book.title}</td>
                            <td>{book.summary}</td>
                            <td>{book.isbn}</td>
                            <td>{book.author.firstName + " " + book.author.lastName}</td>
                            <td>{book.genre.name}</td>
                            <td>
                                <ButtonToolbar>
                                    <Button className="m-1" variant="info" size="sm"
                                        onClick={() => goToEdit(book.id)}>
                                        Edit
                                    </Button>
                                    <Button className="m-1" variant="danger" size="sm"
                                        onClick={() => handleDelete(book.id)}>
                                        Delete
                                    </Button>
                                </ButtonToolbar>
                            </td>

                        </tr>)}
                </tbody>

            </Table>

            <ButtonToolbar>
                <Button variant='primary'
                    onClick={() => navigate('/books/create')}>
                    Add New</Button>
            </ButtonToolbar>

        </div>
    )

}

export default BooksIndex;