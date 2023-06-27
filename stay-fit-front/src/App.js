import ReactDOM from "react-dom/client";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Layout from "./components/Layout";
import Home from "./components/Home";
import Products from "./components/Products";
import NewsMessages from "./components/NewsMessages";
import Login from "./components/Login";
import Register from "./components/Register";
import Payments from "./components/Payments";



export default function App() {
    return (
        <BrowserRouter>
            <Routes>
                <Route path="/" element={<Layout />}>
                    <Route index element={<Home />} />
                    <Route path="Products" element={<Products />} />
                    <Route path="NewsMessages" element={<NewsMessages />} />
                    <Route path="Login" element={<Login />}/>
                    <Route path="Register" element={<Register />}/>
                    <Route path="Payments" element={<Payments />}/>
                </Route>
            </Routes>
        </BrowserRouter>
    );
}

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(<App />);
