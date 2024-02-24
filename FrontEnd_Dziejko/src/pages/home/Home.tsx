import { useState } from "react";
import Hero from "./Hero";
import { Button } from "react-bootstrap";

function Home() {
    const [data, setData] = useState(null);

    const fetchData = async () => {
      try {
        const response = await fetch('https://localhost:7004/api/massage');
        const jsonData = await response.json();
        setData(jsonData);
      } catch (error) {
        console.error('Error fetching data: ', error);
      }
    };
    return (
        <>
            <Hero />
            <div style={{ minHeight: "50vh" }}>Home</div>
            {data&& JSON.stringify(data)}
            <Button onClick={fetchData}>Kliknij se</Button>
        </>
    );
}

export default Home;
