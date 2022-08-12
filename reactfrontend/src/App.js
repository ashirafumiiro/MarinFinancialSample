import React, { useState, useEffect } from 'react';
import Navigation from './components/Navigation'
import { Alert } from 'react-bootstrap';
import { Route, Routes, useNavigate } from 'react-router-dom'
import Home from './components/Home'
import Books from './components/books/Books'
import Genres from './components/Genres'
import Authors from './components/Authors';
import authorService from './services/authors'
import genreService from './services/genres'
import bookService from "./services/books";

const App = () => {
    const [authors, setAuthors] = useState([])
    const [genres, setGenres] = useState([])
    const [books, setBooks] = useState([])
    const [message, setMessage] = useState(null)
    const navigate = useNavigate()

    useEffect(() => {
        genreService
            .getAll()
            .then(initialGenre => {
                setGenres(initialGenre)
            })
    }, [])

    useEffect(() => {
        authorService
            .getAll()
            .then(initialAuthors => {
                setAuthors(initialAuthors)
            })
    }, [])

    useEffect(() => {
        bookService
            .getAll()
            .then(initialBooks => {
                setBooks(initialBooks)
            })
    }, [])

    const handleSubmitBook = (book) => {
        console.log("book to save:", book)
        bookService
            .create(book)
            .then(returnedBook => {
                setBooks(books.concat(returnedBook))
                showNotification("book added successfully")
                navigate('/books');
            })
            .catch(error => {
                console.log(error);
                showNotification('An error occured while adding book')
            });
    }

    const handleUpdateBook = (book) => {
        console.log('book to update:', book)
        const id = Number(book.id);
        bookService
            .update(id, book)
            .then(returnedBook => {
                console.log('returned:', returnedBook)
                setBooks(books.map(book => book.id !== id ? book : returnedBook))
                showNotification('Updated: ' + book.title)
                navigate('/books');
            })
            .catch(error => {
                showNotification("An error occured while updating books");
                console.log(error);
            })

    }

    const handleDeleteBook = async (id) => {
        try {
            let bookToDelete = books.find(b => b.id === id)
            await bookService.deleteBook(id);
            setBooks(books.filter(book => book.id !== id));
            showNotification(`Deleted ${bookToDelete.title}`);
        } catch (error) {

        }

    }

    const showNotification = (message) => {
        setMessage(message)
        setTimeout(() => {
            setMessage(null)
        }, 5000)
    }

    const handleSubmitGenre = (genre) => {
        // event.preventDefault();
        // const id = Number (event.target.id ? event.target.id.value || 0 : 0)
        // const genre = {
        //   id: id,
        //   name: event.target.name.value,
        // }
        if(genre.id === 0){
          return genreService
          .create(genre)
          .then(genre => {
            console.log('returned:', genre)
            setGenres(genres.concat(genre))
          })
        }
        else{
          return genreService
          .update(genre.id, genre)
          .then(genre => {
            console.log('returned:', genre)
            setGenres(genres.map(g => g.id !== genre.id ? g : genre))
          })
        }
        
      }
    
      const handleDeleteGenre = id =>{
        return genreService
          .deleteGenre(id)
          .then(gen => {
            setGenres(genres.filter(g => g.id !== id));
          })
      }

    return (
        <div className='container'>
            {(message &&
                <Alert variant="success">
                    {message}
                </Alert>
            )}
            <Navigation />
            <Routes>
                <Route path="books/*" element={<Books books={books} genres={genres} authors={authors}
                    handleDelete={handleDeleteBook} handleSubmit={handleSubmitBook} 
                    handleUpdate={handleUpdateBook} />} />
                <Route path='genres' element={<Genres genres={genres} handleSubmitGenre={handleSubmitGenre} handleDeleteGenre={handleDeleteGenre}/>} />
                <Route path='authors' element={<Authors authors={authors} />} />
                <Route path="/" element={<Home />} />
            </Routes>
            {/* <footer class="border-top footer text-muted">
        <div class="container">
            &copy; 2022 - MarinFinancialSample - Privacy
        </div>
    </footer> */}
        </div>
    )
}

export default App;
