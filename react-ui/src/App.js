import './App.css';
import {BrowserRouter, Route, Routes} from 'react-router-dom';
import {Home} from './Home';
import {Navigation} from './Navigation'
import {Book } from './Book'
import {Author} from './Author';

function App() {
  return (
    <BrowserRouter>
    <div className="container">
     <Navigation/>

     <Routes>
       <Route path='/' element={<Home/>}/>
       <Route path='/books' element={<Book />}/>
       <Route path='/authors' element={<Author />}/>
     </Routes>
    </div>
    </BrowserRouter>
  );
}

export default App;
