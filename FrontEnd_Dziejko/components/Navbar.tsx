import {
    Container,
    Dropdown,
    DropdownButton,
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
            <NavbarBs
                className="navbar-dark bg-dark"
                id="main-nav"
                expand="md"
                sticky="top"
            >
                <Container>
                    <NavbarBrand>Logo</NavbarBrand>
                    <NavbarBs.Toggle aria-controls="basic-navbar-nav" />
                    <NavbarBs.Collapse id="basic-navbar-nav">
                        <Nav className="ms-auto">
                            <Nav.Link to="/" as={NavLink}>
                                Home
                            </Nav.Link>
                            <DropdownButton
                                data-bs-theme="dark"
                                className="nav-link custom-dropdown-btn"
                                id="dropdown-basic-button"
                                title="Services"
                            >
                                <Dropdown.Item href="#/action-1">
                                    All 
                                </Dropdown.Item>
                                <Dropdown.Item href="#/action-2">
                                    Massage
                                </Dropdown.Item>
                                <Dropdown.Item href="#/action-3">
                                    Something else
                                </Dropdown.Item>
                            </DropdownButton>
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

export default Navbar;
