import { useEffect, useState } from "react";
import { deleteChore, getChores } from "../../managers/choreManager";
import { Button, Table } from "reactstrap";
import { Link, useNavigate } from "react-router-dom";

export const ChoresList = ({ loggedInUser }) => {
    const [chores, setChores] = useState([]);

    const navigate = useNavigate();

    const handleDelete = (id) => {
        deleteChore(id).then(() => {
            getChores().then(setChores);
        })
    }

    useEffect(() => {
        getChores().then(setChores);
    }, [])

    return (
        <div className="container">
            <div className="sub-menu bg-light">
                <h4>Chores</h4>
            </div>
            <Table>
                <thead>
                    <tr>
                        <th>#</th>
                        <th>Name</th>
                        <th>Difficulty</th>
                        <th>Frequency</th>
                        <th></th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    {chores.map((c) => (
                        <tr key={`chores-${c.id}`}>
                            <th scope="row">{c.id}</th>
                            <td>{c.name}</td>
                            <td>{c.difficulty}</td>
                            <td>Every {c.choreFrequencyDays} Days</td>
                            {loggedInUser.roles.includes("Admin") ? (
                                <>
                                    <td>
                                        <Button
                                            onClick={() => {
                                                navigate(`${c.id}`);
                                            }}
                                        >
                                            Details
                                        </Button>
                                    </td>
                                    <td>
                                        <Button
                                            color="danger"
                                            onClick={() => {
                                                handleDelete(c.id);
                                            }}
                                            >
                                                Delete
                                            </Button>
                                    </td>
                                </>
                            ) : (
                                ""
                            )}
                        </tr>
                    ))}
                </tbody>
            </Table>
            {loggedInUser.roles.includes("Admin") && (
                <Link to="/chores/create">New Chore</Link>
            )}
        </div>
    )
}