import {
    Container,
    Nav,
    NavbarBrand,
    Navbar as NavbarBs,
} from "react-bootstrap";
import { NavLink } from "react-router-dom";
import SetNavVisibility from "./other/SetNavVisibility";

function Navbar() {
    return (
        <>
            <SetNavVisibility />
            <NavbarBs id="main-nav" expand="md" sticky="top">
                <Container>
                    <NavbarBrand>Logo</NavbarBrand>
                    <NavbarBs.Toggle aria-controls="basic-navbar-nav" />
                    <NavbarBs.Collapse id="basic-navbar-nav">
                        <Nav className="ms-auto">
                            <Nav.Link to="/" as={NavLink}>
                                Homepage
                            </Nav.Link>
                            <Nav.Link to="/services" as={NavLink}>
                                Devices
                            </Nav.Link>
                            <Nav.Link to="/about" as={NavLink}>
                                Devices
                            </Nav.Link>
                            <Nav.Link to="/contact" as={NavLink}>
                                Devices
                            </Nav.Link>
                        </Nav>
                    </NavbarBs.Collapse>
                </Container>
            </NavbarBs>
        </>
    );
}

export default Navbar;
