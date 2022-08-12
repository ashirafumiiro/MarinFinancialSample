import { Button, ButtonToolbar } from "react-bootstrap";
import { useNavigate } from "react-router-dom";

const Book = ({ book, books }) => {
    const navigate = useNavigate();


    return (
        <div>
            <h4>Book #{book.id}</h4>
            <hr />
            <dl className="row">
                <dt className="col-sm-2"> Title </dt>
                <dd className="col-sm-10">{book.title} </dd>
                <dt className="col-sm-2">Summary</dt>
                <dd className="col-sm-10">{book.summary}</dd>
                <dt className="col-sm-2">Isbn</dt>
                <dd className="col-sm-10">{book.isbn}</dd>
                <dt className="col-sm-2">Author</dt>
                <dd className="col-sm-10">{book.author.fullName}</dd>
                <dt className="col-sm-2">Genre</dt>
                <dd className="col-sm-10">{book.genre.name} </dd>
            </dl>
            <ButtonToolbar>
                <Button variant='primary'
                    onClick={() => navigate('../')}>
                    Back </Button>
            </ButtonToolbar>
        </div>
    )

}

export default Book;