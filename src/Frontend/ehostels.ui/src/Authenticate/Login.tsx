import { Box, Button, Grid, TextField, Typography } from "@mui/material";
import { useActionState, useContext, useState } from "react";
import { postAsync } from "../common/ApiHandler";
import * as Yup from "yup";
import { RootContext } from "../common/context/RootProvider";

interface LoginFormData {
  email: string | undefined;
  password: string | undefined;
}
const initialData: LoginFormData = {
  email: undefined,
  password: undefined,
};
const loginSchema = Yup.object().shape({
  email: Yup.string().required("Email is required").email("Invalid email"),
  password: Yup.string()
    .required("Password is required")
    .min(6, "Password must be at least 6 characters"),
});
const Login = () => {
  const {setIsAuthorize} = useContext(RootContext);
  const [formData, setFormData] = useState<LoginFormData>(initialData);
  const [error, setError] = useState<Partial<LoginFormData>>();
  const [, submitAction, isPending] = useActionState(async (_: any) => {
    try {
      await loginSchema.validate(formData, {abortEarly: false, strict: true});
      setError({});
      await postAsync("/api/ehostels/Identity/Login", formData)
        .then((response) => {
          setIsAuthorize(true);
          localStorage.setItem("token", response.data.accessToken);
          localStorage.setItem("refreshToken", response.data.refreshToken);
        })
        .catch((error) => {
          console.error("Login failed:", error);
          alert("Login failed. Please check your credentials and try again.");
        });
    } catch (error) {
      if (error instanceof Yup.ValidationError) {
        const validationErrors: Partial<LoginFormData> = {};
        error.inner.forEach((err) => {
          if (err.path) {
            validationErrors[err.path as keyof LoginFormData] = err.message;
          }
        })
        console.log("validationErrors", validationErrors);
        setError(validationErrors);
      }
    }
  }, null);
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
              name="email"
              fullWidth
              onChange={(e) => handleChange("email", e.target.value)}
              helperText={error?.email}
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
              helperText={error?.password}
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
