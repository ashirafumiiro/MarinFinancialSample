import { Route, Routes, useMatch } from "react-router-dom"
import Book from './Book';
import BookForm from './BookForm';
import BooksIndex from './BooksIndex';
import BookEdit from "./BookEdit";

const Books = ({ books, authors, genres, handleSubmit, handleUpdate, handleDelete }) => {

  const match = useMatch('/books/:id')
  const book = match ? books.find(book => book.id === Number(match.params.id)) : null

  const editMatch = useMatch('/books/edit/:id')
  const bookToEdit = editMatch ? books.find(book => book.id === Number(editMatch.params.id)) : null

  return (
    <div>
      <Routes>
        <Route index element={<BooksIndex books={books} handleUpdate={handleUpdate} authors={authors} genres={genres} handleDelete={handleDelete} />} />
        <Route path='create' element={<BookForm handleSubmit={handleSubmit} authors={authors} genres={genres} />} />
        <Route path='edit/:bookId' element={<BookEdit handleUpdate={handleUpdate} authors={authors} genres={genres} book={bookToEdit} />} />
        <Route path=':bookId' element={<Book book={book} />} />
      </Routes>
    </div>
  )

}

export default Books;