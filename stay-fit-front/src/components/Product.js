import React, { useEffect, useState } from "react";
import ReactDOM from "react-dom";
import "./css/Product.css";
import {getJwtToken} from "./lib/auth"
import axios from "axios";
import {Link, useNavigate} from "react-router-dom";





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
    const handlePayment =async () =>{
        console.log(getJwtToken())
        if(getJwtToken()!=null){
            const responcePayment=axios.post("https://localhost:44368/api/Users/checkPayment",{"jwt":getJwtToken()});
        }
        navigate('/');
    }
    
    
       

    useEffect(() => {
        getApiData();
        
    }, []);

    return (
        <div className="Product">
            <div className="col-lg-3 col-md-2 col-sm-1 p-2 d-inline-flex product-container">
                 
            {products.map(product=>
                <div className="card" key={product.id}>
                    <div className="card-body">
                        <h2 className="title card-title text-center">{product.name}</h2>
                        <p className="card-text list-description">{product.description}</p>
                        <div className="d-flex flex-row justify-content-between">
                            <h3 className="card-text text-center"><strong>Price: {product.price} Eur</strong></h3>
                        </div>
                        <div className="card-footer">
                            <a type="button" className="btn btn-primary btn-checkout" id="btn-checkout" onClick={handlePayment} >Buy Now</a>
                        </div>
                        
                    </div>
                </div>
            )}
            </div>
        </div>
    );
}
const rootElement = document.getElementById("root");
ReactDOM.render(<Products />, rootElement);
export default Products;





