import React, {useEffect, useState} from 'react';


function Product() {
    const [products, setProducts] = useState(null);
    useEffect(() => {
        async function getData() {
            const response  = await fetch('https://localhost:44368/api/Product')
                .then(response => { return response.json() })
                .catch(error => { console.log(error) });

            setProducts(response);
            console.log(response);
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

export default Product;