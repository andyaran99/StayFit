import React, {useEffect, useState} from "react";
import { Button, Form, Card } from "react-bootstrap";
import { setJwtToken,setButtonLogOut ,getJwtToken} from "./lib/auth"
import {useNavigate} from "react-router-dom";
import axios from "axios";
import ReactDOM from "react-dom";



function Register() {
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const [email,setEmail]=useState("");
    const navigate=useNavigate();
    

    // Function to collect data
    

    const handleSubmit=(e)=>{e.preventDefault()
        tokenData();
    }


    const tokenData = async () => {
        try{
            const response = await axios.post(`https://localhost:44368/api/Users`,
                {username, password, email}
            ).then(r=>r.data);
            if (response != null) {
                alert("User was succesfuly created");
                const login=await axios.post(
                    "https://localhost:44368/api/Users/BearerToken",
                    {username,password})
                    .then(r=>r.data);
                setJwtToken(login);
                setButtonLogOut();
                alert("Connected Succefuly!")
                navigate('/Payments');
            }
        }
        catch (error) {
           alert("Register failled!");
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
                    <Form.Group className="mb-3">
                        <Form.Label>Email</Form.Label>
                        <Form.Control type="text" id="Email" name="Email" onInput={e => setEmail(e.target.value)} required />
                    </Form.Group>
                    <Button variant="primary" type="submit" >Register</Button>
                </Form>

            </Card.Body>
        </Card>
    );
}

export default Register;