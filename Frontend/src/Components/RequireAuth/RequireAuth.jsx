/* eslint-disable react/jsx-key */
import { Navigate, Outlet } from "react-router-dom";
import { getCookie } from "../../hooks/useCookies";

export function RequireRole({ authRol }) {
  try {
    const role = getCookie({ name: "role" });
    const flagAuth = authRol?.map((rol) => {
      if (role == rol) return true;
    });
    if (flagAuth) return <Outlet />;
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
