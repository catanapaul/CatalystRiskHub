import React, { useEffect, useState } from 'react';
import logo from './logo.svg';
import './App.css';
import api from './api';
import { Product } from './api/client';

function App() {

  const [product, setProduct] = useState<Product>();

  useEffect(() => {
    const fetchProduct = async () => {
      const product = await api.getProduct(1);
      console.log('Product:', product);
      setProduct(product);
    };

    fetchProduct();
  }, []);

  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/App.tsx</code> and save to reload.
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
      </header>
    </div>
  );
}

export default App;
