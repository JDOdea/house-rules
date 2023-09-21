const _apiUrl = "/api/chore";

export const getChores = () => {
    return fetch(_apiUrl).then((res) => res.json());
};

export const getChore = (id) => {
    return fetch(`${_apiUrl}/${id}`).then((res) => res.json());
};

export const createChore = (chore) => {
    return fetch(_apiUrl, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(chore),
    }).then((res) => res.json());
};

export const completeChore = (choreId, userId) => {
    return fetch(`${_apiUrl}/${choreId}/complete?userId=${userId}`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
    }).then((res) => res.json());
};

export const updateChore = (choreId, updatedChore) => {
    return fetch(`${_apiUrl}/${choreId}`, {
        method: "PUT",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(updatedChore),
    }).then((res) => res.json());
};

export const assignChore = (choreId, userId) => {
    return fetch(`${_apiUrl}/${choreId}/assign?userId=${userId}`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
    }).then((res) => res.json());
};

export const unassignChore = (choreId, userId) => {
    return fetch(`${_apiUrl}/${choreId}/unassign?userId=${userId}`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
    }).then((res) => res.json());
};

export const deleteChore = (id) => {
    return fetch(`${_apiUrl}/${id}`, {
        method: "DELETE"
    });
};