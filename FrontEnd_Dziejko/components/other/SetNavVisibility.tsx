import { useEffect } from "react";
import { useLocation } from "react-router-dom";



function isInViewport(element:HTMLElement) {
    const rect = element.getBoundingClientRect();
    return (
        rect.top >= 0 &&
        rect.left >= 0 &&
        rect.bottom <= (window.innerHeight || document.documentElement.clientHeight) &&
        rect.right <= (window.innerWidth || document.documentElement.clientWidth)
    );
}

export default function SetNavVisibility() {
    const location = useLocation();
    useEffect(() => {
        const mainNav = document.getElementById("main-nav");
        if (location.pathname === "/") {
            mainNav?.classList.add("hide-main-nav");
        }
        if (location.pathname !== "/") {
            mainNav?.classList.remove("hide-main-nav");
        }
        // const heroImg=document.getElementById("hero-img")
        // if(heroImg){
        //     console.log(isInViewport(heroImg))
        // }
      
    }, [location]);
    return null;
}
