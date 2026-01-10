import { Box, Button, Grid, TextField, Typography } from "@mui/material";
import { useActionState, useState } from "react";
import { postAsync } from "../common/ApiHandler";

interface LoginFormData {
  email: string;
  password: string;
}
const initialData: LoginFormData = {
  email: "",
  password: "",
};
const Login = () => {
  const [formData, setFormData] = useState<LoginFormData>(initialData);
  const [, submitAction, isPending] = useActionState(
    async (_: any, formData: FormData) => {
      const payload = {
        email: formData.get("email") as string,
        password: formData.get("password") as string,
      }
      await postAsync("/api/ehostels/Identity/Login", payload)
        .then((response) => {
            console.log("response", response);
          localStorage.setItem("token", response.data.accessToken);
          localStorage.setItem("refreshToken", response.data.refreshToken);
        })
        .catch((error) => {
          console.error("Login failed:", error);
          alert("Login failed. Please check your credentials and try again.");
        });
    },
    null
  );
  const handleChange = (key: keyof LoginFormData, value: string) => {
    setFormData((prev) => ({
      ...prev,
      [key]: value,
    }));
  };
  return (
    <Box>
      <Typography variant="h4">Login Page</Typography>
      <form action={submitAction}>
        <Grid container spacing={2} display={"flex"} flexDirection={"column"}>
          <Grid>
            <TextField
              label="Email"
              value={formData.email}
              type="email"
              name="email"
              fullWidth
              onChange={(e) => handleChange("email", e.target.value)}
            />
          </Grid>
          <Grid>
            <TextField
              label="Password"
              name="password"
              type="password"
              value={formData.password}
              fullWidth
              onChange={(e) => handleChange("password", e.target.value)}
            />
          </Grid>
          <Grid>
            <Button variant="contained" type="submit" disabled={isPending}>
              Login
            </Button>
          </Grid>
        </Grid>
      </form>
    </Box>
  );
};

export default Login;
