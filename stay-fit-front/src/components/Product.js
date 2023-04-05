import React, { useEffect, useState } from "react";
import ReactDOM from "react-dom";
import "./Product.css"



function Product() {
    const [products, setProduct] = useState([]);

    // Function to collect data
    const getApiData = async () => {
        const response = await fetch(
            "https://localhost:44368/api/Product"
        ).then((response) => response.json());

        setProduct(response);
        console.log(response);
        
    };

    useEffect(() => {
        getApiData();
        console.log(products);
        
    }, []);

    return (
        <div className="Product">
            <div className="col-lg-3 col-lg-3 p-2 d-inline-flex product-container">
                 
            {products.map(product=>
                <div className="card" key={product.id}>
                    <div className="card-body">
                        <h4 className="title card-title text-center">{product.name}</h4>
                        <p className="card-text list-description">{product.description}</p>
                        <div className="d-flex flex-row justify-content-between">
                            <p className="card-text text-center"><strong>Price: {product.price} Eur</strong></p>
                            <a type="button" className="btn btn-primary">Buy Now</a>
                        </div>
                    </div>
                </div>)}
            </div>
            
        </div>
    );
}
const rootElement = document.getElementById("root");
ReactDOM.render(<Product />, rootElement);
export default Product;




