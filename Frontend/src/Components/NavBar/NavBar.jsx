import { getCookie } from "../../hooks/useCookies";
import { useState, useEffect } from "react";
import "./NavBar.Module.css";

function NavBar() {
  const [data, setData] = useState();
  const [authRole, setAuthRole] = useState();

  useEffect(() => {
    try {
      const auth = getCookie({ name: "auth" });
      setData(auth?.Player);
      setAuthRole(auth?.role);
    } catch (error) {
      setAuthRole(null);
    }
  }, []);

  return (
    <>
      <nav className="navbar navbar-expand-lg bg-body-tertiary">
        <div className="container-fluid">
          <button
            className="navbar-toggler"
            type="button"
            data-bs-toggle="collapse"
            data-bs-target="#navbarNav"
            aria-controls="navbarNav"
            aria-expanded="false"
            aria-label="Toggle navigation"
          >
            <span className="navbar-toggler-icon"></span>
          </button>
          <div className="collapse navbar-collapse" id="navbarNav">
            {authRole === "Player" && (
              <ul className="navbar-nav">
                <li className="nav-item">
                  <a className="nav-link active" aria-current="page" href="/">
                    Inicio
                  </a>
                </li>
                <li className="nav-item">
                  <a className="nav-link" href="/blog">
                    Blog
                  </a>
                </li>
                <li className="nav-item">
                  <a className="FocusItem nav-link" href="/sign-in">
                    Logros
                  </a>
                </li>
                <li className="nav-item disabled">
                  <a className="FocusItem nav-link" href="/sign-out">
                    Cerrar Sesión
                  </a>
                </li>
              </ul>
            )}
            {authRole === "Developer" && (
              <ul className="navbar-nav">
                <li className="nav-item">
                  <a className="nav-link active" aria-current="page" href="/">
                    Inicio
                  </a>
                </li>
                <li className="nav-item">
                  <a className="nav-link" href="/blog">
                    Blog
                  </a>
                </li>
                <li className="nav-item">
                  <a className="FocusItem nav-link" href="/sign-in">
                    Administrar posts
                  </a>
                </li>
                <li className="nav-item disabled">
                  <a className="FocusItem nav-link" href="/sign-out">
                    Cerrar Sesión
                  </a>
                </li>
              </ul>
            )}
            {!authRole && (
              <ul className="navbar-nav">
                <li className="nav-item">
                  <a className="nav-link active" aria-current="page" href="/">
                    Inicio
                  </a>
                </li>
                <li className="nav-item">
                  <a className="nav-link" href="/blog">
                    Blog
                  </a>
                </li>
                <li className="nav-item">
                  <a className="FocusItem nav-link" href="/sign-in">
                    Iniciar Sesión
                  </a>
                </li>
                <li className="nav-item">
                  <a className="FocusItem nav-link" href="/sign-up">
                    Registrarse
                  </a>
                </li>
              </ul>
            )}
          </div>
        </div>
      </nav>
    </>
  );
}

export default NavBar;
