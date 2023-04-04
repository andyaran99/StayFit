import ReactDOM from "react-dom/client";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Layout from "./components/Layout";
import Home from "./components/Home";
import Product from "./components/Product";


export default function App() {
    return (
        <BrowserRouter>
            <Routes>
                <Route path="/" component={<Layout />}>
                    <Route index element={<Home />} />
                    <Route path="/product" element={<Product />} />
                </Route>
            </Routes>
        </BrowserRouter>
    );
}

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(<App />);
