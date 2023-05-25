import React, {useEffect, useState} from "react";
import { Button, Form, Card } from "react-bootstrap";
import { setJwtToken, setRefreshToken,setButtonLogOut ,getJwtToken} from "./lib/auth"
import {useNavigate} from "react-router-dom";
import axios from "axios";
import ReactDOM from "react-dom";


function Login() {
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const navigate=useNavigate();


    const handleSubmit=(e)=>{e.preventDefault()
        tokenData();
    }
    
    
    const tokenData = async () => {
        try{
            const response = await axios.post(`https://localhost:44368/api/Users/BearerToken`,
                {username, password}
            ).then(r=>r.data);
             
            if (response != null) {
                setJwtToken(response);
                setButtonLogOut();
                navigate('/Payment');
            }
        }
        catch (error) {
            console.log("Token failled");
            navigate('/');
        }
    }

    
    return (
        <Card>
            <Card.Body>
               <Form onSubmit={handleSubmit}>
                    <Form.Group className="mb-3">
                        <Form.Label>Username</Form.Label>
                        <Form.Control type="text" id="Username" name="Username" onInput={e => setUsername(e.target.value)} required />
                    </Form.Group>
                    <Form.Group className="mb-3">
                        <Form.Label>Password</Form.Label>
                        <Form.Control type="password" id="Password" name="Password" onInput={e => setPassword(e.target.value)} required />
                    </Form.Group>
                    <Button variant="primary" type="submit" >Login</Button>
                </Form>
            </Card.Body>
        </Card>
    );
}

export default Login;