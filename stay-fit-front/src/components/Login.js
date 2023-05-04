import {useEffect, useState} from "react";
import { Button, Form, Card } from "react-bootstrap";

import { setJwtToken, setRefreshToken } from "./lib/auth"
import {useNavigate} from "react-router-dom";

function Login() {
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    
    const navigate=useNavigate();
    
    const handleSubmit = async () => {
        try{
            const response = await fetch(`https://localhost:44368/api/User/BearerToken`, {
                method: 'POST',
                body: JSON.stringify({ username, password })
            });
            const { jwt_token } = await response.json();
            console.log(jwt_token);
            
            if (jwt_token != null) {
                setJwtToken(jwt_token);
                navigate('/Product');
            }
        }
        catch (error) {
            console.log("Token failled");
            navigate('/');
            
        }
    }

    useEffect(() => {
        handleSubmit();

    }, []);
    
    return (
        <Card>
            <Card.Body>
                <Form >
                    <Form.Group className="mb-3">
                        <Form.Label>Username</Form.Label>
                        <Form.Control type="text" id="Username" name="Username" onInput={e => setUsername(e.target.value)} required />
                    </Form.Group>
                    <Form.Group className="mb-3">
                        <Form.Label>Password</Form.Label>
                        <Form.Control type="password" id="Password" name="Password" onInput={e => setPassword(e.target.value)} required />
                    </Form.Group>
                    <Button variant="primary" type="submit" onSubmit={handleSubmit}>Login</Button>
                </Form>
                
            </Card.Body>
        </Card>
    );
}

export default Login;