import React, { useEffect, useState } from "react";
import ReactDOM from "react-dom";
import "./css/Product.css";
import {getJwtToken} from "./lib/auth"
import axios from "axios";
import {Link} from "react-router-dom";
import {useNavigate} from "react-router-dom";





function Products() {
    const [products, setProduct] = useState([]);
    const navigate=useNavigate();
    
    


    // Function to collect data
    const getApiData = async () => {
        
        
        const responce= axios.get('https://localhost:44368/api/Products', )
            .catch((error) => {
                console.error(error)
            });
        
        const prod=(await responce).data;
        setProduct(prod);
    }
    
    
    async function handlePayment(product){
        const token=localStorage.getItem("jwt");
        const responcePayment=axios.post("https://localhost:44368/api/Users/CheckPayment",
            {"jwtToken":getJwtToken()},
            {headers: {
                    'Authorization': `Bearer ${token}`
                }
            });
            
        //console.log((await responcePayment).data);
        let paymentCustomer=(await responcePayment).data
        console.log(paymentCustomer);
        
        if(paymentCustomer!=null){
            console.log(paymentCustomer.stripeId);
            console.log(paymentCustomer.clientEmail);
            console.log(product.description);
            console.log(product.price);
            const makePayment=axios.post(`https://localhost:44368/api/Stripe/payment/add`,
                {"customerId":paymentCustomer.stripeId,
                "receiptEmail": paymentCustomer.clientEmail,
                "description":product.description, 
                "currency": "USD",
                "amount":product.price*100});
            
            console.log(makePayment);
            navigate('/');
        }
        else{
            console.log("insert a payment method")
            navigate('/Payments');
        }
    }
    
    
       

    useEffect(() => {
        getApiData();
        
    }, []);

    return (
        <div className="Products">
            <div className="col-lg-3 col-md-2 col-sm-1 p-2 d-inline-flex product-container">
                 
            {products.map(product=>
                <div className="card" key={product.id}>
                    <div className="card-body">
                        <h2 className="title card-title text-center" >{product.name}</h2>
                        <p className="card-text list-description" >{product.description}</p>
                        <div className="d-flex flex-row justify-content-between">
                            <h3 className="card-text text-center" ><strong>Price: {product.price} USD</strong></h3>
                        </div>
                        <div className="card-footer">
                            <a type="button" className="btn btn-primary btn-checkout" id="btn-checkout" onClick={()=>handlePayment(product)} >Buy Now</a>
                        </div>
                        
                    </div>
                </div>
            )}
            </div>
        </div>
    );
}

export default Products;



