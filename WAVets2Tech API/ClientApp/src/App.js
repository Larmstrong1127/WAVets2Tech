import React, { useState, useEffect } from 'react';

const App = () => {

    const [students, setStudents] = useState([]);
    const [admins, setAdmins] = useState([]);

    useEffect(() => {
        fetch("api/company")
            .then((response) => {
                return response.json();
            })
            .then(data => {
                setStudents(data);
                })
    }, []);



    return (<main>
        
        <h1> THIS IS TEST CODE </h1>
        <h1> THIS IS TEST CODE </h1>
        <h1> THIS IS TEST CODE </h1>
        {
            (students != null) ?
                students.map((index, id) => (
                    <h3 key={id}>
                        Id: {index.internalId}, Company Name: {index.companyName} Email: {index.email}
                    </h3>
                ))
                :
                <div>Loading</div>
        }
        {
            (admins != null) ?
                admins.map((index, id) => (
                    <h3 key={id}>
                        Id: {index.internalId}, First Name: {index.firstName} Email: {index.email}
                    </h3>
                ))
                :
                <div>Loading</div>
        }
    </main>
    )
}

export default App;
