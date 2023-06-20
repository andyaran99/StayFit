import React, {useEffect, useState} from "react";
import { Button, Form, Card } from "react-bootstrap";
import { getJwtToken } from "./lib/auth"
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
    
    
    
    
    const navigate=useNavigate();
    

    const handleSubmit=(e)=>{e.preventDefault()
        tokenData();
    }
    
    const handleCancel = async() =>{ 
        
        alert("Addying payment was canceled ")
        navigate('/');
    }


    const tokenData = async () => {
        try{
            debugger
            const response = await axios.post(`https://localhost:44368/api/Stripe/customer/add`,
                {name, email,creditCard}
            ).then(r=>r.data);
            const customerId=response.customerId;
            

            if (response!= null) {
                alert("Payment was succesfuly added");
                const saveUserByStripeCustomerKey=await axios.post(
                    "https://localhost:44368/api/Users/saveUserByStripeCustomerKey",
                    {"customerId":customerId,"jwtToken":getJwtToken()})
                    .then(s=>s.data);
                console.log(saveUserByStripeCustomerKey);
                navigate('/');
            }
        }
        catch (error) {
            alert("Adding Payment  failled");
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
                    <Button variant="primary" onClick={handleCancel}>Cancel</Button>
                </Form>
            </Card.Body>
        </Card>
    );
}

export default Payment;