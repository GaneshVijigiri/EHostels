import { useRoutes } from "react-router-dom"
import ComponentA from "../../pages/ComponentA"
import ComponentB from "../../pages/ComponentB"
import Login from "../../Authenticate/Login"

export const authRoutes = () => {
    const elements = useRoutes([
        {
            path: "/",
            element: <ComponentA />
        },
        {
            path: "/component-a",
            element: <ComponentA />
        },
        {
            path: "/component-b",
            element: <ComponentB />
        },
        {
            path: "*",
            element: <Login />
        }
    ])
    return elements;
}