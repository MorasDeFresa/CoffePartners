import { removeCookie } from "../../hooks/useCookies";
import { Navigate } from "react-router-dom";
function LogOut() {
  try {
    removeCookie({ name: "role" });
    sessionStorage.removeItem("auth");
    return <Navigate to="/" replace />;
  } catch (error) {
    return <Navigate to="/" replace />;
  }
}

export default LogOut;
