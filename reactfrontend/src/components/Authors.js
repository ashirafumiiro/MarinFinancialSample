import { Table } from "react-bootstrap"

const Authors = ({authors}) => {

    return(
        <div className="container">
            <Table className="mt-2" striped bordered hover responsive size="sm">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>First Name</th>
                        <th>Last Name</th>
                        <th>dateOfBirth</th>
                    </tr>
                </thead>
                <tbody>
                    {authors.map(author =>
                        <tr key={author.id}>
                            <td>{author.id}</td>
                            <td>{author.firstName}</td>
                            <td>{author.lastName}</td>
                            <td>{author.dateOfBirth}</td>
                            {/* <td>
                                <ButtonToolbar>
                                    <Button className="m-1" variant="info" size="sm"
                                        onClick={() => goToEdit(author.id)}>
                                        Edit
                                    </Button>
                                    <Button className="m-1" variant="danger" size="sm"
                                        onClick={() => handleDelete(author.id)}>
                                        Delete
                                    </Button>
                                </ButtonToolbar>
                            </td> */}

                        </tr>)}
                </tbody>

            </Table>

        </div>
    )
} 

export default Authors