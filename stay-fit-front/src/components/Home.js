import React, {useEffect, useState} from "react";
import "./Home.css"
import Link from "react-router-dom";
import ReactDOM from "react-dom";


// importing Link from react-router-dom to navigate to 
// different end points.


function Home() {
    const [routines1, setRoutine1] = useState([]);
    const [routines2, setRoutine2] = useState([]);
    const [routines3, setRoutine3] = useState([]);
    const [exercices1,setExercices1]=useState([]);
    const [exercices2,setExercices2]=useState([]);
    const [exercices3,setExercices3]=useState([]);
    const [exercices4,setExercices4]=useState([]);

    // Function to collect data
    const getApiData = async () => {
        const response = await fetch(
            "https://localhost:44368/api/Routine/1"
        ).then((response) => response.json());

        setRoutine1(response);
        console.log(response);
    };
    const getApiDataR2 = async () => {
        const response = await fetch(
            "https://localhost:44368/api/Routine/2"
        ).then((response) => response.json());

        setRoutine2(response);
        console.log(response);
    };
    const getApiDataR3 = async () => {
        const response = await fetch(
            "https://localhost:44368/api/Routine/3"
        ).then((response) => response.json());

        setRoutine3(response);
        console.log(response);
    };
    
    const getApiData1 = async () => {
        const response = await fetch(
            "https://localhost:44368/api/Exercice/1"
        ).then((response) => response.json());

        setExercices1(response);
        console.log(response);
    };
    const getApiData2 = async () => {
        const response = await fetch(
            "https://localhost:44368/api/Exercice/2"
        ).then((response) => response.json());

        setExercices2(response);
        console.log(response);
    };
    const getApiData3 = async () => {
        const response = await fetch(
            "https://localhost:44368/api/Exercice/3"
        ).then((response) => response.json());

        setExercices3(response);
        console.log(response);
    };
    const getApiData4 = async () => {
        const response = await fetch(
            "https://localhost:44368/api/Exercice/4"
        ).then((response) => response.json());

        setExercices4(response);
        console.log(response);
    };

    useEffect(() => {
        getApiData();
        getApiData1();
        getApiData2();
        getApiData3();
        getApiData4();
        getApiDataR2();
        getApiDataR3();


    }, []);

    return (
        <div className="Product">
            <div className="col-lg-3 col-lg-3 p-2 d-inline-flex product-container">
                <div className="card" key={routines1.id}>
                    <div className="card-body">
                        <h2 className="title card-title text-center">{routines1.name}</h2>
                        <p className="card-text list-description">{routines1.bodyType}</p>
                        <p className="card-text list-description">{routines1.routineType}</p>
                        <p className="card-text list-description">{routines1.dateTime}</p>
                        <div>
                            <h2 className="title card-title text-center">{exercices1.name}</h2>
                            <p className="card-text list-description">{exercices1.description}</p>
                            <p className="card-text list-description">{exercices1.dateTime}</p>
                        </div>
                        <div>
                            <h2 className="title card-title text-center">{exercices2.name}</h2>
                            <p className="card-text list-description">{exercices2.description}</p>
                            <p className="card-text list-description">{exercices2.dateTime}</p>
                        </div>
                    </div>
                    <div className="card-footer">
                        <a type="button" className="btn btn-primary btn-checkout" id="btn-checkout">Buy Now</a>
                    </div>
                </div>
                
                
                <div className="card" key={routines2.id}>
                    <div className="card-body">
                        <h2 className="title card-title text-center">{routines2.name}</h2>
                        <p className="card-text list-description">{routines2.bodyType}</p>
                        <p className="card-text list-description">{routines2.routineType}</p>
                        <p className="card-text list-description">{routines2.dateTime}</p>
                        <div>
                            <h2 className="title card-title text-center">{exercices1.name}</h2>
                            <p className="card-text list-description">{exercices1.description}</p>
                            <p className="card-text list-description">{exercices1.dateTime}</p>
                        </div>
                    </div>
                    <div className="card-footer">
                        <a type="button" className="btn btn-primary btn-checkout" id="btn-checkout">Buy Now</a>
                    </div>
                </div>

                <div className="card" key={routines3.id}>
                    <div className="card-body">
                        <h2 className="title card-title text-center">{routines3.name}</h2>
                        <p className="card-text list-description">{routines3.bodyType}</p>
                        <p className="card-text list-description">{routines3.routineType}</p>
                        <p className="card-text list-description">{routines3.dateTime}</p>
                        <div>
                            <h2 className="title card-title text-center">{exercices3.name}</h2>
                            <p className="card-text list-description">{exercices3.description}</p>
                            <p className="card-text list-description">{exercices3.dateTime}</p>
                        </div>
                        <div>
                            <h2 className="title card-title text-center">{exercices4.name}</h2>
                            <p className="card-text list-description">{exercices4.description}</p>
                            <p className="card-text list-description">{exercices4.dateTime}</p>
                        </div>
                    </div>
                    <div className="card-footer">
                        <a type="button" className="btn btn-primary btn-checkout" id="btn-checkout">Buy Now</a>
                    </div>
                </div>
            </div>
        </div>
    );

}

const rootElement = document.getElementById("root");
ReactDOM.render(<Home />, rootElement);
export default Home;