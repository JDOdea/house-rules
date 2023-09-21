import { Route, Routes } from "react-router-dom";
import { AuthorizedRoute } from "./auth/AuthorizedRoute";
import Login from "./auth/Login";
import Register from "./auth/Register";
import { Home } from "./Home";
import { UserProfileList } from "./userProfiles/UserProfileList";
import { UserProfileDetails } from "./userProfiles/UserProfileDetails";
import { ChoresList } from "./chores/ChoresList";
import { ChoreDetails } from "./chores/ChoreDetails";
import { CreateChore } from "./chores/CreateChore";
import { UserChoresList } from "./chores/UserChoresList";


export default function ApplicationViews({ loggedInUser, setLoggedInUser }) {
  return (
    <Routes>
      <Route path="/">
        <Route
          index
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <Home />
            </AuthorizedRoute>
          }
        />
        <Route path="chores">
          <Route 
            index
            element={
              <AuthorizedRoute loggedInUser={loggedInUser}>
                <ChoresList loggedInUser={loggedInUser}/>
              </AuthorizedRoute>
            }
          />
          <Route 
            path=":choreId"
            element={
              <AuthorizedRoute loggedInUser={loggedInUser}>
                <ChoreDetails />
              </AuthorizedRoute>
            }
          />
          <Route
            path="create"
            element={
              <AuthorizedRoute roles={["Admin"]} loggedInUser={loggedInUser}>
                <CreateChore />
              </AuthorizedRoute>
            }
          />
        </Route>
        <Route path="mychores">
          <Route 
            index
            element={
              <AuthorizedRoute loggedInUser={loggedInUser}>
                <UserChoresList loggedInUser={loggedInUser}/>
              </AuthorizedRoute>
            }
          />
        </Route>
        <Route path="users">
          <Route 
            index
            element={
              <AuthorizedRoute roles={["Admin"]} loggedInUser={loggedInUser}>
                <UserProfileList />
              </AuthorizedRoute>
            }
          />
          <Route 
            path=":userId"
            element={
              <AuthorizedRoute roles={["Admin"]} loggedInUser={loggedInUser}>
                <UserProfileDetails />
              </AuthorizedRoute>
            }
          />
        </Route>
        <Route
          path="login"
          element={<Login setLoggedInUser={setLoggedInUser} />}
        />
        <Route
          path="register"
          element={<Register setLoggedInUser={setLoggedInUser} />}
        />
      </Route>
      <Route path="*" element={<p>Whoops, nothing here...</p>} />
    </Routes>
  );
}
