import { createTheme } from "@mui/material";

export const theme = createTheme({
    components: {
        MuiFormHelperText: {
            styleOverrides: {
                root: {
                    color: 'red',
                }
            }
        },
    }
})