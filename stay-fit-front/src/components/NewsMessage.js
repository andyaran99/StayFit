import React, { useEffect, useState } from "react";
import ReactDOM from "react-dom";

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
            <div className="col-lg-3 col-lg-3 p-2 d-inline-flex product-container">

                {newsMessage.map(message=>
                    <div className="card" key={message.id}>
                        <div className="card-body">
                            <h4 className="title card-title text-center">{message.title}</h4>
                            <p className="card-text list-description">{message.description}</p>
                        </div>
                    </div>)}
            </div>

        </div>
    );
}
const rootElement = document.getElementById("root");
ReactDOM.render(<NewsMessage />, rootElement);
export default NewsMessage;
