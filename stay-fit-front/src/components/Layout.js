import { Outlet, Link } from "react-router-dom";
import 'bootstrap/dist/css/bootstrap.css';
import './Layout.css';



const Layout = () => {
    return (
        <div>
            <nav class="navbar navbar-expand-md  navbar-dark bg-dark">
                <button className="navbar-toggler " type="button" data-toggle="collapse"
                        data-target="#navbarToggleExternalContent" aria-controls="navbarToggleExternalContent"
                        aria-expanded="false" aria-label="Toggle navigation">
                    <span className="navbar-toggler-icon"></span>
                </button>
                <Link class="navbar-brand" to="/">StayFit</Link>
                
                <div className="collapse navbar-collapse justify-content-start" id="navbarSupportedContent">
                    <ul className="navbar-nav ml-auto">
                        <li className="nav-item">
                            <Link class="nav-link" to="/">Home</Link>
                        </li>
                        <li className="nav-item">
                            <Link class="nav-link" to="Products">Products</Link>
                        </li>
                        <li className="nav-item">
                            <Link class="nav-link" to="NewsMessages">News</Link>
                        </li>
                        <li className="nav-item">
                            <Link class="nav-link" id="login" to="Login">Login</Link>
                        </li>
                        <li className="nav-item">
                            <Link class="nav-link" to="Register">Register</Link>
                        </li>
                        
                    </ul>
                </div>
            </nav>

            <Outlet />
        </div>
    )
};

export default Layout;