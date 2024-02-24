import {
    Container,
    Nav,
    NavbarBrand,
    Navbar as NavbarBs,
} from "react-bootstrap";
import { NavLink } from "react-router-dom";

function HomeNav() {
    return (
        <>
            <NavbarBs expand="md" className="home-nav">
                <Container>
                    <NavbarBrand>Logo</NavbarBrand>
                    <NavbarBs.Toggle aria-controls="basic-navbar-nav" />
                    <NavbarBs.Collapse id="basic-navbar-nav">
                        <Nav className="ms-auto">
                            <Nav.Link to="/" as={NavLink}>
                                Home
                            </Nav.Link>
                            <Nav.Link to="/services" as={NavLink}>
                                Services
                            </Nav.Link>
                            <Nav.Link to="/about" as={NavLink}>
                                About
                            </Nav.Link>
                            <Nav.Link to="/contact" as={NavLink}>
                                Contact
                            </Nav.Link>
                        </Nav>
                    </NavbarBs.Collapse>
                </Container>
            </NavbarBs>
        </>
    );
}

export default HomeNav;
