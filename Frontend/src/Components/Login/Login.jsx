import "./Login.Module.css";
import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { setCookie } from "../../hooks/useCookies";
import Loading from "../Loading/Loading";
import { requestApi } from "../../hooks/useApi";
import toast from "react-hot-toast";

function Login() {
  const [EmailUser, setUsername] = useState("");
  const [PasswordUser, setPassword] = useState("");
  const [wait, setWait] = useState(false);
  const [showPassword, setShowPassword] = useState(false);
  const navigate = useNavigate();
  const Login = async () => {
    setWait(true);
    try {
      const { data } = await requestApi({
        typeRequest: "post",
        endPoint: "/sign-in",
        bodyData: { EmailUser, PasswordUser },
      });
      setCookie({
        name: "role",
        value: data?.idAdmin ? "Admin" : "Farmer",
      });
      sessionStorage.setItem("auth", JSON.stringify(data));
      toast.success(`Sesión iniciada correctamente`);
      navigate(data?.idAdmin ? "/" : "/blog");
    } catch (error) {
      setWait(false);
      setUsername("");
      setPassword("");
      toast.error(`Error al iniciar sesión, verifica tus datos`);
    }
  };

  const handleSubmit = (event) => {
    event.preventDefault();
  };

  return (
    <>
      {!wait ? (
        <div className="login card">
          <div className="card-header">Iniciar Sesion</div>
          <div className="card-body">
            <form onSubmit={handleSubmit}>
              <div>
                <h3>Usuario</h3>
                <input
                  type="text"
                  value={EmailUser}
                  onChange={(e) => setUsername(e.target.value)}
                />
              </div>
              <br />
              <div>
                <h3>Contraseña</h3>
                <input
                  type={showPassword ? "text" : "password"}
                  value={PasswordUser}
                  onChange={(e) => setPassword(e.target.value)}
                />
                <button
                  type="button"
                  onClick={() => setShowPassword(!showPassword)}
                  className="eye"
                >
                  {showPassword ? (
                    <i className="bi bi-eye-slash-fill"></i>
                  ) : (
                    <i className="bi bi-eye-fill"></i>
                  )}
                </button>
              </div>
              <button type="button" className="btn" onClick={Login}>
                Login
              </button>
              <br />
              <br />
              <a href="/sign-up">¿No tienes cuenta? Registrate</a>
            </form>
          </div>
        </div>
      ) : (
        <Loading />
      )}
    </>
  );
}

export default Login;
