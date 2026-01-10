import { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import "./index.css";
import App from "./App.tsx";
import { ThemeProvider } from "@mui/material";
import { theme } from "./theme.ts";
import { BrowserRouter } from "react-router-dom";
import RootProvider from "./common/context/RootProvider.tsx";

createRoot(document.getElementById("root")!).render(
  <StrictMode>
    <ThemeProvider theme={theme}>
      <RootProvider>
        <BrowserRouter>
          <App />
        </BrowserRouter>
      </RootProvider>
    </ThemeProvider>
  </StrictMode>
);
