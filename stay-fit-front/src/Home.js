
import {useEffect, useState} from 'react';







function App() {
  const [products, setProducts] = useState();
  useEffect(() => {
    async function getData() {
      const products  = await fetch('https://localhost:44368/api/Product')
          .then(products => { return products.json() })
          .catch(error => { console.log(error) });
      setProducts(products);
    }
    getData();
  }, []);
  
  console.log(products);


  return (
      <div className="App">
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
              </tr>
          )}
          </tbody>

        </table>

      </div>
  );
}

export default App;
