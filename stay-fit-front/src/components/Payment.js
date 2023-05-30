import React, {useEffect, useState} from "react";
import { Button, Form, Card } from "react-bootstrap";
import { setJwtToken, setRefreshToken,setButtonLogOut ,getJwtToken} from "./lib/auth"
import {useNavigate} from "react-router-dom";
import axios from "axios";
import ReactDOM from "react-dom";


function Payment() {
    const [name, setName] = useState("");
    const [email, setEmail] = useState("");
    const [cardNumber, setCardNumber]=useState("");
    const [expirationYear,setExpirationYear]=useState("");
    const [expirationMonth,setExpirationMonth]=useState("");
    const [cvc,setCvc]=useState("");
    const creditCard={name,cardNumber,expirationYear,expirationMonth,cvc}
    const [responceName,setResponceName]=useState("");
    const[responceEmail,setResponceEmail]=useState("");
    const[responceCustomerId,setResponceCustomerId]=useState("");
    
    
    const navigate=useNavigate();
    

    const handleSubmit=(e)=>{e.preventDefault()
        tokenData();
    }


    const tokenData = async () => {
        try{
            const response = await axios.post(`https://localhost:44368/api/Stripe/customer/add`,
                {name, email,creditCard}
            ).then(r=>r.data);
            console.log(response);
            if (response != null) {
                alert("Payment was succesfuly added");
               /* setResponceName(response.data.name);
                setResponceEmail(response.data.email);
                setResponceCustomerId(response.data.customerId)
                const saveUserByStripeCustomerKey=await axios.post("https://localhost:44368/api/Users/saveUserByStripeCustomerKey",{responceName,responceEmail,responceCustomerId})*/
                navigate('/');
            }
        }
        catch (error) {
            alert("it failled");
            navigate('/');
        }
    }


    return (
        <Card>
            <Card.Body>
                <Form onSubmit={handleSubmit}>
                    <Form.Group className="mb-3">
                        <Form.Label>Name</Form.Label>
                        <Form.Control type="text" id="Username" name="Username" onInput={e => setName(e.target.value)} required />
                    </Form.Group>
                    <Form.Group className="mb-3">
                        <Form.Label>Email</Form.Label>
                        <Form.Control type="text" id="Email" name="Email" onInput={e => setEmail(e.target.value)} required />
                    </Form.Group>
                    <Form.Group className="mb-3">
                        <Form.Label>Card Number</Form.Label>
                        <Form.Control type="text" id="CardNumber" name="CardNumber" onInput={e => setCardNumber(e.target.value)} required />
                    </Form.Group>
                    <Form.Group className="mb-3">
                        <Form.Label>ExpirationYear</Form.Label>
                        <Form.Control type="text" id="ExpirationYear" name="ExpirationYear" onInput={e => setExpirationYear(e.target.value)} required />
                    </Form.Group>
                    <Form.Group className="mb-3">
                        <Form.Label>ExpirationMonth</Form.Label>
                        <Form.Control type="text" id="ExpirationMonth" name="ExpirationMonth" onInput={e => setExpirationMonth(e.target.value)} required />
                    </Form.Group>
                    <Form.Group className="mb-3">
                        <Form.Label>CVC</Form.Label>
                        <Form.Control type="text" id="CVC" name="CVC" onInput={e => setCvc(e.target.value)} required />
                    </Form.Group>
                    
                    <Button variant="primary" type="submit" >Add pay</Button>
                </Form>
            </Card.Body>
        </Card>
    );
}

export default Payment;