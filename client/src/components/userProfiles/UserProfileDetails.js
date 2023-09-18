import { useEffect, useState } from "react";
import { useParams } from "react-router-dom"
import { getUserProfile } from "../../managers/userProfileManager";
import { Table } from "reactstrap";

export const UserProfileDetails = () => {
    const { userId } = useParams();

    const [userProfile, setUserProfile] = useState(null);

    useEffect(() => {
        getUserProfile(userId).then(setUserProfile);
    }, [])

    if (!userProfile) {
        return null;
    }

    return (
        <div className="container">
            <h2>{userProfile.firstName} {userProfile.lastName}</h2>
            <Table>
                <tbody>
                    <tr>
                        <th scope="row">First Name</th>
                        <td>{userProfile.firstName}</td>
                    </tr>
                    <tr>
                        <th scope="row">Last Name</th>
                        <td>{userProfile.lastName}</td>
                    </tr>
                    <tr>
                        <th scope="row">Address</th>
                        <td>{userProfile.address}</td>
                    </tr>
                </tbody>
            </Table>
            <h5>Assigned Chores</h5>
            <Table>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Difficulty</th>
                        <th>Frequency</th>
                    </tr>
                </thead>
                <tbody>
                    {userProfile.choreAssignments.map((ca) => (
                        <tr key={`choreAssignment--${ca.id}`}>
                            <td>{ca.chore.name}</td>
                            <td>{ca.chore.difficulty}</td>
                            <td>Every {ca.chore.choreFrequencyDays} days</td>
                        </tr>
                    ))}
                </tbody>
            </Table>
            <h5>Completed Chores</h5>
            <Table>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Date Completed</th>
                    </tr>
                </thead>
                <tbody>
                    {userProfile.choreCompletions.map((cc) => (
                        <tr key={`choreCompletion--${cc.id}`}>
                            <td>{cc.chore.name}</td>
                            <td>{new Date(cc.completedOn).toString().slice(0, 15)}</td>
                        </tr>
                    ))}
                </tbody>
            </Table>
        </div>
    )
}