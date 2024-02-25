import { useState } from "react";
import Hero from "./Hero";
import { Button } from "react-bootstrap";
import { useNavigate } from "react-router-dom";

function Home() {
    const [data, setData] = useState(null);
    

    const fetchData = async () => {
      try {
        const response = await fetch('http://localhost:5267/api/massage');
        const jsonData = await response.json();
        setData(jsonData);
      } catch (error) {
        console.error('Error fetching data: ', error);
      }
    };
    return (
        <>
            <Hero />
            <Button variant="dark" className="m-5"><a target="_blank" href="http://localhost:5267/swagger/index.html">ApiDocs</a></Button>
            <div style={{ minHeight: "50vh" }}>Home</div>
            {data&& JSON.stringify(data)}
            <Button onClick={fetchData}>Kliknij se</Button>
        </>
    );
}

export default Home;
