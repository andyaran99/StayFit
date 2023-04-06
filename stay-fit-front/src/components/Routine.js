import React, { useEffect, useState } from "react";
import ReactDOM from "react-dom";
import {Await} from "react-router-dom";

function Routine() {
    const [routines, setRoutine] = useState([]);

    // Function to collect data
    const getApiData = async () => {
        const response = await fetch("https://localhost:44368/api/Routine")
            .then((response) => response.json());
            

        setRoutine(response);
        console.log(response)


    };

    useEffect(() => {
        getApiData();
        console.log(routines);

    }, []);

    return (
        <div className="Routine">
            <div className="col-lg-3 col-lg-3 p-2 d-inline-flex product-container">

                {routines.map(routine=>
                    <div className="card" key={routine.id}>
                        <div className="card-body">
                            <p className="card-text list-description">{routine.bodyType}</p>
                            <p className="card-text list-description">{routine.routineType}</p>
                            <p className="card-text list-description"> {routine.datetime}</p>
                            <p className="card-text list-description">{routine.exerciceList[0]}</p>
                        </div>
                    </div>)}
            </div>

        </div>
    );
}
const rootElement = document.getElementById("root");
ReactDOM.render(<Routine />, rootElement);
export default Routine;