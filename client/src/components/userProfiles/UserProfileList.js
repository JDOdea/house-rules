import { useEffect, useState } from "react";
import { getUserProfilesWithRoles } from "../../managers/userProfileManager";
import { Button, Table } from "reactstrap";
import { useNavigate } from "react-router-dom";

export const UserProfileList = ({ loggedInUser }) => {
    const [userProfiles, setUserProfiles] = useState([]);

    const navigate = useNavigate();

    useEffect(() => {
        getUserProfilesWithRoles().then(setUserProfiles);
    }, []);

    return (
        <>
            <Table>
                <thead>
                <tr>
                    <th>Name</th>
                    <th>Address</th>
                    <th>Email</th>
                    <th>Username</th>
                    <th>Actions</th>
                </tr>
                </thead>
                <tbody>
                {userProfiles.map((up) => (
                    <tr key={up.id}>
                    <th scope="row">{`${up.firstName} ${up.lastName}`}</th>
                    <td>{up.address}</td>
                    <td>{up.email}</td>
                    <td>{up.userName}</td>
                    <td>
                    
                        {
                            up.roles.includes("Admin") ? (
                                <Button
                                    onClick={() => {
                                        navigate(`${up.id}`)
                                    }}>
                                    Details
                                </Button>
                            ) : (
                                ""
                            )
                        }
                    </td>
                    </tr>
                ))}
                </tbody>
        </Table>
        </>
    )
}