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
                    <table class='table'>
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
           

        </div>
    );
}
const rootElement = document.getElementById("root");
ReactDOM.render(<NewsMessage />, rootElement);
export default NewsMessage;
