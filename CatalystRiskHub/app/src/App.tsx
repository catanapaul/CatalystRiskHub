import logo from "./logo.svg";
import "./App.css";
import api from "./api";
import { Product } from "./api/client";
import { UseQueryResult, useQuery } from "react-query";

function App() {

  const { data, isLoading, isError }: UseQueryResult<Product> = useQuery(
    "product", () => api.getProduct(1)
  );

  if (isLoading) return <div>Loading...</div>;
  if (isError) return <div>Error fetching data</div>;

  return (
      <div className="App">
        <header className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
          {data && (
          <>
            <p>{data.name}</p>
            <p>{data.price}</p>
          </>
          )}
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
