import React, {useEffect, useState} from "react";
import "./Home.css"
import Link from "react-router-dom";
// importing Link from react-router-dom to navigate to 
// different end points.


function Routine() {
    const [routines, setRoutine] = useState([]);

    // Function to collect data
    const getApiData = async () => {
        const response = await fetch(
            "https://localhost:44368/api/Routine"
        ).then((response) => response.json());

        setRoutine(response);
        console.log(response);

    };

    useEffect(() => {
        getApiData();
        console.log(routines);

    }, []);

    return (
        <div className="Product">
            <div className="col-lg-3 col-lg-3 p-2 d-inline-flex product-container">

                {routines.map(routine =>
                    <div className="card" key={routine.id}>
                        <div className="card-body">
                            <h2 className="title card-title text-center">{routine.name}</h2>
                            <p className="card-text list-description">{routine.description}</p>
                            <div className="d-flex flex-row justify-content-between">
                                <h3 className="card-text text-center"><strong>Price: {} Eur</strong></h3>
                            </div>
                        </div>
                        <div className="card-footer">
                            <a type="button" className="btn btn-primary btn-checkout" id="btn-checkout">Buy Now</a>
                        </div>
                    </div>)}
            </div>

        </div>
    );

}  


export default Home;