
import { useContext } from "react";
import "./App.css";
import Login from "./Authenticate/Login";
import { RootContext } from "./common/context/RootProvider";
import FullLayout from "./common/layout/FullLayout";

function App() {
  const context = useContext(RootContext);
  console.log("cntext", context);
  return (
    <>
    {
      context.isAuthorize ? <FullLayout /> : <Login />
    }
    </>
  );
}

export default App;
