import { getCookie } from "../../hooks/useCookies";
import { useState, useEffect } from "react";
import "./NavBar.Module.css";

function NavBar() {
  const [authRole, setAuthRole] = useState();

  useEffect(() => {
    try {
      const auth = getCookie({ name: "role" });
      setAuthRole(auth);
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
            {authRole === "Farmer" && (
              <ul className="navbar-nav">
                <li className="nav-item">
                  <a className="nav-link" aria-current="page" href="/">
                    Inicio
                  </a>
                </li>
                <li className="nav-item">
                  <a className="nav-link" href="/blog">
                    Blog
                  </a>
                </li>
                <li className="nav-item dropdown">
                  <a
                    className="nav-link dropdown-toggle"
                    href="#"
                    role="button"
                    data-bs-toggle="dropdown"
                    aria-expanded="false"
                  >
                    Reportes
                  </a>
                  <ul className="dropdown-menu">
                    <li>
                      <a className="dropdown-item" href="/farmer/report/plant">
                        Plantas
                      </a>
                    </li>
                    <li>
                      <a
                        className="dropdown-item"
                        href="/farmer/report/harvest"
                      >
                        Cosecha
                      </a>
                    </li>
                  </ul>
                </li>
                <li className="nav-item dropdown">
                  <a
                    className="nav-link dropdown-toggle"
                    href="#"
                    role="button"
                    data-bs-toggle="dropdown"
                    aria-expanded="false"
                  >
                    Perfil
                  </a>
                  <ul className="dropdown-menu">
                    <li>
                      <a className="dropdown-item" href="/developer">
                        Tarjeta de usuario
                      </a>
                    </li>
                    <li>
                      <a className="dropdown-item" href="#">
                        Mis logros
                      </a>
                    </li>
                    <li>
                      <a className="dropdown-item" href="#">
                        Mis puntuaciones
                      </a>
                    </li>
                  </ul>
                </li>
                <li className="nav-item disabled">
                  <a className="FocusItem nav-link" href="/sign-out">
                    Cerrar Sesión
                  </a>
                </li>
              </ul>
            )}
            {authRole === "Admin" && (
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
                <li className="nav-item dropdown">
                  <a
                    className="nav-link dropdown-toggle"
                    href="#"
                    role="button"
                    data-bs-toggle="dropdown"
                    aria-expanded="false"
                  >
                    Administrar
                  </a>
                  <ul className="dropdown-menu">
                    <li>
                      <a className="dropdown-item" href="#">
                        Calidad del cafe
                      </a>
                    </li>
                    <li>
                      <a className="dropdown-item" href="#">
                        Estados de las plantas
                      </a>
                    </li>
                    <li>
                      <hr className="dropdown-divider" />
                    </li>
                    <li>
                      <a className="dropdown-item" href="#">
                        Logros
                      </a>
                    </li>
                    <li>
                      <a className="dropdown-item" href="#">
                        Puntuaciones
                      </a>
                    </li>
                  </ul>
                </li>
                <li className="nav-item dropdown">
                  <a
                    className="nav-link dropdown-toggle"
                    href="#"
                    role="button"
                    data-bs-toggle="dropdown"
                    aria-expanded="false"
                  >
                    Usuarios
                  </a>
                  <ul className="dropdown-menu">
                    <li>
                      <a className="dropdown-item" href="#">
                        Cafeteros
                      </a>
                    </li>
                    <li>
                      <a className="dropdown-item" href="#">
                        Administradores
                      </a>
                    </li>
                  </ul>
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
