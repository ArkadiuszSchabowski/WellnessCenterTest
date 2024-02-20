import { Button, Container, Stack } from "react-bootstrap";
import HeroImg from "../../assets/images/hero.jpg";
import HomeNav from "./HomeNav";

function Hero() {
    return (
        <>
            <header className="hero-container">
                <HomeNav />
                <div className="hero-img-opacity"></div>
                <img className="hero-img" src={HeroImg} />

                <Container>
                    <Stack className="hero-group align-items-center" gap={5}>
                        <h1 className="hero-title">
                            Let us help you find your favourite place on earth
                        </h1>
                        <div className="hero-btns">
                            <Button className="hero-btn1">GET IN TOUCH</Button>
                            <Button className="hero-btn2">BOOK NOW</Button>
                        </div>
                    </Stack>
                </Container>
            </header>
        </>
    );
}

export default Hero;
