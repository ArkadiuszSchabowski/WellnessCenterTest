import React from 'react'
import ReactDOM from 'react-dom/client'
import App from './App.tsx'
import "./assets/index.css"
import "bootstrap/dist/css/bootstrap.min.css";
import ScrollToTop from "./components/other/ScrollToTop.tsx";
import { BrowserRouter } from 'react-router-dom';


ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <BrowserRouter>
    <ScrollToTop />
    <App />
    </BrowserRouter>
  </React.StrictMode>,
  
)
