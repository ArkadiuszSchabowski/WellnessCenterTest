import { Button } from "react-bootstrap";
import Hero from "./Hero";
import { useState } from "react";

function Home() {
    const [data,setData]=useState(null)

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
            <div style={{ minHeight: "200vh" }}>Home</div>
            <Button className="mt-top" onClick={fetchData}>Kliknij se</Button>
            {JSON.stringify(data)}
        </>
    );
}

export default Home;
