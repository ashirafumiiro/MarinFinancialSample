import React from 'react';
import { Navbar, Nav } from 'react-bootstrap'
import { Link } from 'react-router-dom'

function Navigation() {
    const remoteStyling = {
        padding: 5,
        textDecoration: 'none'
    }
  return (
      <Navbar collapseOnSelect expand="lg" bg="dark" variant="dark">
          <Navbar.Toggle aria-controls="responsive-navbar-nav" />
          <Navbar.Collapse id="responsive-navbar-nav">
              <Navbar.Brand href="">Local Library</Navbar.Brand>
              <Nav className="mr-auto">
                  <Nav.Link href="#" as="span">
                      <Link style={remoteStyling} to="/" className="nav-link">Home</Link>
                  </Nav.Link>
                  <Nav.Link href="#" as="span">
                      <Link style={remoteStyling} to="/books" className="nav-link">Books</Link>
                  </Nav.Link>
                  <Nav.Link href="#" as="span">
                       <Link to="/genres" className="nav-link">Genres</Link>
                  </Nav.Link>
                  <Nav.Link href="#" as="span">
                      <Link style={remoteStyling} to="/authors" className="nav-link">Authors</Link>
                  </Nav.Link>
              </Nav>
          </Navbar.Collapse>
      </Navbar>
  );
}

export default Navigation;