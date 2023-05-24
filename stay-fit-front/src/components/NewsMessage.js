import React, { useEffect, useState } from "react";
import ReactDOM from "react-dom";
import "./NewsMessage.css";
import axios from "axios";

function NewsMessages() {
    const [newsMessage, setNewsMessage] = useState([]);

    // Function to collect data
    const getApiData = async () => {
        const token=localStorage.getItem("jwt");
        const response = axios.get("https://localhost:44368/api/Messages",{
            headers: {
                'Authorization': `Bearer ${token}`
            }
        });
        var message=(await response).data
        setNewsMessage(message);
    };

    useEffect(() => {
        getApiData();

    }, []);

    return (
        <div className="newsMessage">
            {newsMessage.map(message=>
                <div className='newsMessageTable'>
                    <table className='table'>
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
ReactDOM.render(<NewsMessages />, rootElement);
export default NewsMessages;
