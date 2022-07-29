import React,{Component} from 'react';
import {NavLink} from 'react-router-dom';
import {Navbar,Nav} from 'react-bootstrap';
// import { Link } from "react-router-dom";


export class Navigation extends Component{

    render(){
        return(
            <Navbar bg="dark" expand="lg">
                <Navbar.Toggle aria-controls="basic-navbar-nav"/>
                <Navbar.Collapse id="basic-navbar-nav">
                <Nav>
                <NavLink className="d-inline p-2 bg-dark text-white" to="/">
                    Home
                </NavLink>
                <NavLink className="d-inline p-2 bg-dark text-white" to="/books">
                    Books
                </NavLink>
                <NavLink className="d-inline p-2 bg-dark text-white" to="/authors">
                    Authors
                </NavLink>

                </Nav>
                </Navbar.Collapse>
            </Navbar>
        )
    }
}