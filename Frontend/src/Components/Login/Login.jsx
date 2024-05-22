import "./Login.Module.css";
import { useState } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";
import { setCookie } from "../../hooks/useCookies";
import Loading from "../Loading/Loading";
import toast from "react-hot-toast";

function Login() {
  const [EmailUser, setUsername] = useState("");
  const [PasswordUser, setPassword] = useState("");
  const [wait, setWait] = useState(false);
  const [showPassword, setShowPassword] = useState(false);
  const navigate = useNavigate();
  const Login = () => {
    setWait(true);
    axios
      .post(`${import.meta.env.VITE_API_URL}/sign-in`, {
        EmailUser,
        PasswordUser,
      })
      .then(function (response) {
        if (response?.data?.idDeveloper) {
          setCookie({
            name: "auth",
            value: {
              DeveloperData: {
                idCookie: response?.data?.idDeveloper,
                Name: response?.data?.nameDeveloper,
                Surname: response?.data?.surnameDeveloper,
              },
              role: "Developer",
            },
          });
          toast.success(
            `Bienvenido developer ${response?.data?.nameDeveloper}`
          );
          navigate("/");
        } else if (response?.data?.idPlayer) {
          setCookie({
            name: "auth",
            value: {
              Player: {
                idCookie: response?.data?.idPlayer,
                NickName: response?.data?.nickNamePlayer,
              },
              role: "Player",
            },
          });
          toast.success(
            `Has iniciado sesión correctamente, Bienvenido ${response?.data?.nickNamePlayer}`
          );
          navigate("/blog");
        }
      })
      .catch(function (error) {
        console.log(error);
      });
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
