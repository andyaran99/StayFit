import { Outlet, Link } from "react-router-dom";
import 'bootstrap/dist/css/bootstrap.css';

const Layout = () => {
    return (
        <div>
            <nav class="navbar navbar-expand-lg navbar-light bg-light">
                <Link class="navbar-brand" to="/">StayFit</Link>
                <div className="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul className="navbar-nav mr-auto">
                        <li className="nav-item active">
                            <Link class="nav-link" to="/">Home</Link>
                        </li>
                        <li className="nav-item">
                            <Link class="nav-link" to="Product">Product</Link>
                        </li>
                    </ul>
                </div>
                
            </nav>

            <Outlet />
        </div>
    )
};

export default Layout;