import axios from 'axios';
import { useState, useEffect } from 'react';
import Badge from 'react-bootstrap/Badge';
import ListGroup from 'react-bootstrap/ListGroup';

const Home = () => {
    const [count, setCount] = useState({ bookCount: 0, authorCount: 0, genreCount: 0 })

    useEffect(() => {
        axios.get('/api').then(response => {
            console.log(response.data);
            setCount(response.data)
        })
    }, [])

    return (<div className="mt-2 text-center justify-content-center">
        <h3 className="m-3 justify-content-center">
            Welcome to the Local Library </h3>
        <p>The Library has the following Content</p>
        <div>
            <ListGroup as="ul">
                <ListGroup.Item as="li"
                    className="list-group-item d-flex justify-content-between align-items-center">
                    <span className="fw-bold">Books:</span>
                    <Badge bg="primary" pill> {count.bookCount} </Badge>
                </ListGroup.Item>
                <ListGroup.Item as="li"
                    className="list-group-item d-flex justify-content-between align-items-center">
                    <span className="fw-bold">Authors:</span>
                    <Badge bg="primary" pill>{count.authorCount}</Badge>
                </ListGroup.Item>
                <ListGroup.Item as="li"
                    className="list-group-item d-flex justify-content-between align-items-center">
                    <span className="fw-bold">Genres:</span>
                    <Badge bg="primary" pill>{count.genreCount}</Badge>
                </ListGroup.Item>
            </ListGroup>
        </div>
    </div>)
}

export default Home;