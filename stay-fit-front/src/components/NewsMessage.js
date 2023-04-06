import React, { useEffect, useState } from "react";
import ReactDOM from "react-dom";
import "./NewsMessage.css";

function NewsMessage() {
    const [newsMessage, setNewsMessage] = useState([]);

    // Function to collect data
    const getApiData = async () => {
        const response = await fetch(
            "https://localhost:44368/api/Message"
        ).then((response) => response.json());

        setNewsMessage(response);
        

    };

    useEffect(() => {
        getApiData();
        console.log(newsMessage);

    }, []);

    return (
        <div className="newsMessage">
            {newsMessage.map(message=>
                <div class='newsMessageTable'>
                    <table class='table-dark'>
                        <thead>
                        <tr>
                            <th scope="col">
                                {message.title}
                            </th>
                        </tr>
                        </thead>
                        <tbody>
                        <tr>
                            <td>
                                {message.description}
                            </td>
                        </tr>
                        </tbody>
                    </table>
                </div>
            
            )}
           {/* <div className="col-lg-3 col-lg-3 p-2 d-inline-flex product-container">

                {newsMessage.map(message=>
                    <div className="card" key={message.id}>
                        <div className="card-body">
                            <h4 className="title card-title text-center">{message.title}</h4>
                            <p className="card-text list-description">{message.description}</p>
                        </div>
                    </div>)}
            </div>*/}

        </div>
    );
}
const rootElement = document.getElementById("root");
ReactDOM.render(<NewsMessage />, rootElement);
export default NewsMessage;
