import {
  createContext,
  useEffect,
  useState,
  type PropsWithChildren,
} from "react";
import { getAsync } from "../ApiHandler";

export const RootContext = createContext({
  isAuthorize: false,
  setIsAuthorize: (_: boolean) => {},
  userId: 0,
  setUserId: (_: number) => {},
  name: "",
  setName: (_: string) => {},
  email: "",
  setEmail: (_: string) => {},
});
const RootProvider = (props: PropsWithChildren) => {
    console.log("Rot provieder called");
  const [isAuthorize, setIsAuthorize] = useState(false);
  const [userId, setUserId] = useState(0);
  const [name, setName] = useState("");
  const [email, setEmail] = useState("");
  const getUserData = () => {
    getAsync("/api/ehostels/Identity/me")
      .then((response) => {
        setUserId(response.data.data.userId);
        setName(response.data.data.fullName);
        setIsAuthorize(response.data.data.isAuthenticated);
      })
      .catch((_) => {
        setIsAuthorize(false);
      });
  };
  useEffect(() => {
    getUserData();
  }, [isAuthorize]);
  return (
    <RootContext.Provider
      value={{
        isAuthorize,
        setIsAuthorize,
        userId,
        setUserId,
        name,
        setName,
        email,
        setEmail,
      }}
    >
      {props.children}
    </RootContext.Provider>
  );
};
export default RootProvider;
