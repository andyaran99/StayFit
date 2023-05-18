import ReactDOM from "react-dom/client";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Layout from "./components/Layout";
import Home from "./components/Home";
import Products from "./components/Product";
import NewsMessages from "./components/NewsMessage";
import Login from "./components/Login";
import Register from "./components/Register";


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
                </Route>
            </Routes>
        </BrowserRouter>
    );
}

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(<App />);
