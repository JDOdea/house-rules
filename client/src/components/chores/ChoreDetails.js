import { useEffect, useState } from "react";
import { useParams } from "react-router-dom"
import { getChore } from "../../managers/choreManager";
import { Table } from "reactstrap";

export const ChoreDetails = () => {
    const { choreId } = useParams();

    const [chore, setChore] = useState(null);

    useEffect(() => {
        getChore(choreId).then(setChore);
    }, [])

    if (!chore) {
        return null;
    }

    return (
        <div className="container">
            <h2>{chore.name}</h2>
            <Table>
                <tbody>
                    <tr>
                        <th scope="row">Difficulty</th>
                        <td>{chore.difficulty}</td>
                    </tr>
                    <tr>
                        <th scope="row">Frequency</th>
                        <td>Every {chore.choreFrequencyDays} days</td>
                    </tr>
                </tbody>
            </Table>
            <h5>Current Assignees</h5>
            <Table>
                <tbody>
                    {chore.choreAssignments.map((ca) => (
                        <tr key={`choreAssignment--${ca.id}`}>
                            <td>{ca.userProfile.firstName} {ca.userProfile.lastName}</td>
                        </tr>
                    ))}
                </tbody>
            </Table>
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
                            <td>{cc.userProfile.firstName} {cc.userProfile.lastName}</td>
                            <td>{new Date(cc.completedOn).toString().slice(0, 15)}</td>
                        </tr>
                    ))}
                </tbody>
            </Table>
        </div>
    )
}