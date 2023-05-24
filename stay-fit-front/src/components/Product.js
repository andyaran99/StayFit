import React, { useEffect, useState } from "react";
import ReactDOM from "react-dom";
import "./Product.css"
import {getJwtToken} from "./lib/auth"
import axios from "axios";
import {Link} from "react-router-dom";




function Products() {
    const [products, setProduct] = useState([]);
    
    


    // Function to collect data
    const getApiData = async () => {
        
        
        const responce= axios.get('https://localhost:44368/api/Products', )
            .catch((error) => {
                console.error(error)
            });
        
        const prod=(await responce).data;
        setProduct(prod);
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
                            <Link className="btn btn-primary btn-checkout" to="/Payment">BuyNow</Link>
                            {/*<a type="button" className="btn btn-primary btn-checkout" id="btn-checkout">Buy Now</a>*/}
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





