import { useState } from "react";
import { Button, Form, Card } from "react-bootstrap";
import useAuth from "../hooks/useAuth";
import {useNavigate} from "react-router-dom";

function Login() {
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const [auth, setAuth] = useState(JSON.parse(localStorage.getItem("auth")));
    const navigate = useNavigate();
    

    const handleSubmit = async () => {

        navigate("/");
        await login(username, password);
       
    }

    const login = async (username, password) => {}
        
    return (
        <Card>
            <Card.Body>
                <Form onSubmit={handleSubmit}>
                    <Form.Group className="mb-3">
                        <Form.Label>Username</Form.Label>
                        <Form.Control type="text" onInput={e => setUsername(e.target.value)} required />
                    </Form.Group>
                    <Form.Group className="mb-3">
                        <Form.Label>Password</Form.Label>
                        <Form.Control type="password" onInput={e => setPassword(e.target.value)} required />
                    </Form.Group>
                    <Button variant="primary" type="submit" >Login</Button>
                </Form>
            </Card.Body>
        </Card>
    );
}

export default Login;