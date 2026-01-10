import { Button, Typography } from "@mui/material"
import { useNavigate } from "react-router-dom"
import { authRoutes } from "../routes/authRoutes";
import { useContext } from "react";
import { RootContext } from "../context/RootProvider";

const FullLayout = () => {
    const { setIsAuthorize } = useContext(RootContext);
    const navigate = useNavigate();
    const handleLogout = () => {
        localStorage.removeItem("token");
        localStorage.removeItem("refreshToken");
        setIsAuthorize(false);
    }
  return (
    <div>
        <Typography variant="h4">Welcome to EHostels</Typography>
      <Button variant="contained" color="primary" onClick={() => navigate('/component-a')}>
        Component A
      </Button>
      <Button variant="contained" color="primary" onClick={() => navigate('/component-b')}>
        Component B
      </Button>
      <Button variant="contained" color="primary" onClick={handleLogout} >
        Logout
      </Button>
      {
        authRoutes()
      }
    </div>
  )
}

export default FullLayout
