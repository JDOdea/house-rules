import { useEffect, useState } from "react";
import { Form, useNavigate, useParams } from "react-router-dom"
import { assignChore, getChore, unassignChore, updateChore } from "../../managers/choreManager";
import { Button, FormGroup, Input, Label, Table } from "reactstrap";
import { getUserProfiles } from "../../managers/userProfileManager";

export const ChoreDetails = () => {
    const { choreId } = useParams();

    const [chore, setChore] = useState(null);
    const [users, setUsers] = useState([]);
    const [name, setName] = useState("");
    const [difficulty, setDifficulty] = useState(0);
    const [frequencyDays, setFrequencyDays] = useState(0);
    const [errors, setErrors] = useState("");

    const navigate = useNavigate();

    const handleAssignmentCheck = (e, u) => {
        const { checked } = e.target;
        let promise;
        if (checked) {
            promise = assignChore(chore.id, u.id);
        } else {
            promise = unassignChore(chore.id, u.id);
        }
        promise.then(() => {
            getChore(chore.id).then(setChore);
        })
    }

    const handleAssignedCheck = (u) => {
        for (const assignment of chore.choreAssignments) {
            if (assignment.userProfileId === u.id) {
                return true;
            }
        }

        return false;
    }

    const handleFormChange = (e) => {
        e.preventDefault();
        const updatedChore = {
            id: choreId,
            name,
            difficulty,
            choreFrequencyDays: frequencyDays
        };

        updateChore(choreId, updatedChore).then((res) => {
            if (res.errors) {
                setErrors(res.errors);
            } else {
                navigate("/chores");
            }
        })
    }

    useEffect(() => {
        getChore(choreId).then(setChore);
        getUserProfiles().then(setUsers);
    }, [])

    useEffect(() => {
        if (chore) {
            setName(chore.name);
            setDifficulty(chore.difficulty);
            setFrequencyDays(chore.choreFrequencyDays);
        }
    }, [chore]);

    if (!chore) {
        return null;
    }

    return (
        <div className="container">
            <div style={{ color: "red" }}>
                {Object.keys(errors).map((key) => (
                    <p key={key}>
                        {key}: {errors[key].join(",")}
                    </p>
                ))}
            </div>
            <h2>{chore.name}</h2>
            <Table>
                <tbody>
                    <tr>
                        <th scope="row">Difficulty</th>
                        <td>
                            <Input 
                                type="select"
                                defaultValue={chore.difficulty}
                                onChange={(e) => {
                                    setDifficulty(parseInt(e.target.value));
                                }}
                            >
                                <option value={1}>1</option>
                                <option value={2}>2</option>
                                <option value={3}>3</option>
                                <option value={4}>4</option>
                                <option value={5}>5</option>
                            </Input>
                        </td>
                    </tr>
                    <tr>
                        <th scope="row">Frequency in days</th>
                        {/* <td>Every {chore.choreFrequencyDays} days</td> */}
                        <td>
                            <Input 
                                list="frequency-numbers"
                                name="frequency"
                                defaultValue={chore.choreFrequencyDays}
                                onChange={(e) => {
                                    setFrequencyDays(parseInt(e.target.value));
                                }}
                            />
                            <datalist id="frequency-numbers">
                                <option value={1}></option>
                                <option value={3}></option>
                                <option value={7}></option>
                                <option value={10}></option>
                                <option value={14}></option>
                            </datalist>
                        </td>
                    </tr>
                </tbody>
            </Table>
            <Button 
                color="primary"
                onClick={handleFormChange}
                >
                Update
            </Button>
            <h5>Assignments</h5>
            {
                users.map((up) => (
                    <div key={`assignmentCheck--${up.id}`}>
                        <Label>{up.firstName} {up.lastName}</Label>
                        <Input 
                            type="checkbox"
                            checked={handleAssignedCheck(up)}
                            onChange={(e) => {
                                handleAssignmentCheck(e, up);
                            }}
                        />
                    </div>
                ))
            }
            <h5>Latest Completion</h5>
            <Table>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Date Completed</th>
                    </tr>
                </thead>
                <tbody>
                    {chore.choreCompletions.map((cc) => (
                        <tr key={`choreCompletion--${cc.id}`}>
                            <td>{cc?.userProfile?.firstName} {cc?.userProfile?.lastName}</td>
                            <td>{new Date(cc.completedOn).toString().slice(0, 15)}</td>
                        </tr>
                    ))}
                </tbody>
            </Table>
        </div>
    )
}