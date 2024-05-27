/* eslint-disable react/jsx-key */
import { Navigate, Outlet } from "react-router-dom";
import { getCookie } from "../../hooks/useCookies";

export function RequireRole({ authRol }) {
  try {
    const role = getCookie({ name: "role" });

    let flagAuth = false;
    authRol?.map((rol) => {
      if (role == rol) flagAuth = true;
    });
    if (flagAuth == true) return <Outlet />;
    else return <Navigate to="/" replace />;
  } catch (error) {
    return <Navigate to="/" replace />;
  }
}

export function WithoutRole() {
  try {
    const role = getCookie({ name: "role" });
    if (role == undefined) return <Outlet />;
    return <Navigate to="/" replace />;
  } catch (error) {
    return <Outlet />;
  }
}
