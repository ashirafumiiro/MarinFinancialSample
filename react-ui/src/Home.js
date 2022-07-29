import React,{Component} from 'react';
import Badge from 'react-bootstrap/Badge';
import ListGroup from 'react-bootstrap/ListGroup';

export class Home extends Component{
    constructor(props){
        super(props);
        this.state={count:{}}
    }

    refreshCount(){
        fetch(process.env.REACT_APP_BASE_URL)
        .then(response=> response.json())
        .then(data=>{
            this.setState({count:data});
        });
    }

    componentDidMount(){
        this.refreshCount();
    }

    componentDidUpdate(){
        this.refreshCount();
    }


    render(){
        return(
            <div className="mt-2 text-center justify-content-center">
                <h3 className="m-3 justify-content-center">
                    Welcome to the Local Library </h3>
                    <p>The Library has the following Content</p>
                    <div>
                    <ListGroup as="ul">
                        <ListGroup.Item as="li"
                            className="list-group-item d-flex justify-content-between align-items-center">
                            <span className="fw-bold">Books:</span>
                            <Badge bg="primary" pill> {this.state.count.bookCount} </Badge>
                        </ListGroup.Item>
                        <ListGroup.Item as="li"
                            className="list-group-item d-flex justify-content-between align-items-center">
                            <span className="fw-bold">Authors:</span>
                            <Badge bg="primary" pill>{this.state.count.authorCount}</Badge>
                        </ListGroup.Item>
                        <ListGroup.Item as="li"
                            className="list-group-item d-flex justify-content-between align-items-center">
                            <span className="fw-bold">Genres:</span>
                            <Badge bg="primary" pill>{this.state.count.genreCount}</Badge>
                        </ListGroup.Item>
                    </ListGroup>
                    </div>          
            </div>
        )
    }
}