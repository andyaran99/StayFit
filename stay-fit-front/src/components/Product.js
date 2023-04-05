import React, { useEffect, useState } from "react";
import ReactDOM from "react-dom";



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
            <table>
                <thead>
                <tr>
                    <th>Id</th>
                    <th>Name</th>
                    <th>Description</th>
                    <th>Price</th>
                </tr>
                </thead>
                <tbody>

                { products.map(product =>
                    <tr key={product.id}>
                        <td>{product.id} </td>
                        <td>{product.name} </td>
                        <td>{product.description}</td>
                        <td>{product.price}</td>
                        <td><button>To Checkout Page</button></td>
                    </tr>

                )}
                </tbody>
            </table>
        </div>
    );
}
const rootElement = document.getElementById("root");
ReactDOM.render(<Product />, rootElement);
export default Product;



/*
import React, {useEffect, useState} from 'react';


function Product() {
    const [products, setProducts] = useState();
    useEffect(() => {
        async function getData() {
            const response  = await fetch('https://localhost:44368/api/Product')
                .then(response => { return response.json() })
                .catch(error => { console.log(error) });
            console.log(response);
            setProducts(response);
            
            
        }
        getData();
       
    }, []);
    console.log(products);
    



    return (
        <div className="Product">
            <table>
                <thead>
                <tr>
                    <th>Id</th>
                    <th>Title</th>
                    <th>Description</th>
                    <th>Price</th>
                </tr>
                </thead>
                <tbody>

                { products.map(products =>
                    <tr key={products.id}>
                        <td>{products.id} </td>
                        <td>{products.title} </td>
                        <td><b>{products.description}</b></td>
                        <td>{products.price} </td>
                        <td><button>To Checkout Page</button></td>
                    </tr>

                )}
                </tbody>
            </table>
        </div>
    );
}

export default Product;*/
