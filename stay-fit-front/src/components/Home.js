import React, {useEffect, useState} from "react";

import Link from "react-router-dom";
import ReactDOM from "react-dom";


// importing Link from react-router-dom to navigate to 
// different end points.


function Home() {
    const [routines, setRoutine] = useState([]);
    console.log(localStorage);


    // Function to collect data
    const getApiData = async () => {
        const response = await fetch(
            "https://localhost:44368/api/Routines"
        ).then((response) => response.json());

        setRoutine(response);
    };

    

    useEffect(() => {
        getApiData();
        
    }, []);

    return (
        <div className="Product">
            <div className="col-lg-3 col-lg-3 p-2 d-inline-flex product-container">
                {routines.map(routine=>
                <div className="card" key={routine.id}>
                    <div className="card-body">
                        <h2 className="title card-title text-center">{routine.name}</h2>
                        <p className="card-text list-description">{routine.bodyType}</p>
                        <p className="card-text list-description">{routine.routineType}</p>
                        <p className="card-text list-description">{routine.dateTime}</p>
                        {routine.exercices.map(exercice=>
                        <div>
                            <h2 className="title card-title text-center">{exercice.name}</h2>
                            <p className="card-text list-description">{exercice.description}</p>
                            <p className="card-text list-description">{exercice.dateTime}</p>
                        </div>
                        )}
                    </div>
                    
                </div>)}
            </div>
        </div>
    );

}

const rootElement = document.getElementById("root");
ReactDOM.render(<Home />, rootElement);
export default Home;