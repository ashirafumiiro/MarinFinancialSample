import { Container } from 'react-bootstrap';
import BookForm from './BookForm';


const BookEdit = ({ book, handleUpdate, authors, genres, books }) => {
  const handleSubmit = (book) => {
    handleUpdate(book);
  }

  return (
    <div>
      <Container>
        <h4>Edit Book</h4>
        <BookForm handleSubmit={handleSubmit} {...book} authors={authors} genres={genres} />
      </Container>
    </div>
  )
}

export default BookEdit