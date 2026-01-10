import { useEffect } from "react";
import "./App.css";
import Login from "./Authenticate/Login";
import { getAsync } from "./common/ApiHandler";

function App() {
  useEffect(() => {
     getAsync("/api/ehostels/User")
      .then((response) => {
        console.log(response.data);
      })
      .catch((error) => {
        console.error("There was an error fetching the data!", error);
      });
  }, []);
  console.log("import.meta.env.VITE_API_BASE_URL", import.meta.env.VITE_API_BASE_URL)

  return (
    <>
      <Login />
    </>
  );
}

export default App;
