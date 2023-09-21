import { useEffect, useState } from "react";
import { getUserProfile } from "../../managers/userProfileManager";
import { completeChore, getChore } from "../../managers/choreManager";
import { Button, Table } from "reactstrap";

export const UserChoresList = ({ loggedInUser }) => {
    const [user, setUser] = useState({});
    const [assignments, setAssignments] = useState([]);
    const [chores, setChores] = useState([]);

    const getProfileWithChores = () => {
        getUserProfile(loggedInUser.id).then(setUser);
    }

    const handleComplete = (id) => {
        completeChore(id, loggedInUser.id)
            .then(getProfileWithChores);
    }

    useEffect(() => {
        getProfileWithChores();
    }, []);

    useEffect(() => {
        if (user) {
            setAssignments(user.choreAssignments);
            if (assignments) {
                const userChores = [];
                for (const ca of assignments) {
                    userChores.push(ca.chore);
                }
                setChores(userChores);
            }
        }
    }, [user]);

    if (!chores) {
        return
    }

    return (
        <div className="container">
            <div className="sub-menu bg-light">
                <h4>Chores Assignments</h4>
            </div>
            <Table>
                <thead>
                    <tr>
                        <th>#</th>
                        <th>Name</th>
                        <th>Difficulty</th>
                        <th>Frequency</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    {chores.map((c) => {
                        if (c.choreOverdue) {
                            return (
                                <tr key={`chores-${c.id}`}>
                                    <th scope="row">{c.id}</th>
                                    <td style={{ color: "red" }}>{c.name}</td>
                                    <td>{c.difficulty}</td>
                                    <td>Every {c.choreFrequencyDays} Days</td>
                                    <td>
                                        <Button
                                            color="success"
                                            onClick={() => {
                                                handleComplete(c.id);
                                            }}
                                        >
                                            Complete
                                        </Button>
                                    </td>
                                </tr>
                            )
                        }
                    })}
                </tbody>
            </Table>
        </div>
    )
}