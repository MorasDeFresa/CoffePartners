import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import validation from "./Validation";
import Loading from "../Loading/Loading";
import { setCookie } from "../../hooks/useCookies";
import toast from "react-hot-toast";
import { requestApi } from "../../hooks/useApi";
import "./Register.Module.css";

function Register() {
  const [newFarmer, setNewFarmer] = useState({});
  const [showPassword, setShowPassword] = useState(false);
  const [wait, setWait] = useState(false);
  const navigate = useNavigate();
  const [errors, setErrors] = useState({});
  const handleChangePost = (event) => {
    setNewFarmer({
      ...newFarmer,
      [event.target.name]: event.target.value,
    });
  };

  const handleSubmit = (event) => {
    event.preventDefault();
  };

  useEffect(() => {
    setErrors(validation({ newFarmer }));
  }, [newFarmer]);

  const CreateFarmer = async () => {
    if (errors != {}) {
      setWait(true);
      try {
        const responseUser = await requestApi({
          typeRequest: "post",
          endPoint: "/api/User",
          bodyData: {
            emailUser: newFarmer?.emailUser,
            passwordUser: newFarmer?.passwordUser,
            nameUser: newFarmer?.nameFarmer,
            surnameUser: newFarmer?.surnameFarmer,
            dateBorn: newFarmer?.dateBornFarmer,
          },
        });
        const { data } = await requestApi({
          typeRequest: "post",
          endPoint: "/api/Farmer",
          bodyData: {
            nickNameFarmer: newFarmer?.nickNameFarmer,
            idUser: responseUser?.data?.idUser,
          },
        });
        setCookie({
          name: "role",
          value: "Farmer",
        });
        sessionStorage.setItem("auth", JSON.stringify(data));
        toast.success(`Sesión iniciada correctamente`);
        navigate(data?.idAdmin ? "/" : "/blog");
      } catch (error) {
        setWait(false);
        setNewFarmer({});
        toast.error(`Error al iniciar sesión, verifica tus datos`);
      }
    }
  };

  return (
    <div>
      {!wait ? (
        <div className="register card">
          <div className="card-header">Crear una nueva cuenta</div>
          <div className="bodyForm card-body">
            <form onSubmit={handleSubmit}>
              <div>
                <h3>Email</h3>
                <input
                  type="email"
                  value={newFarmer.emailUser}
                  onChange={handleChangePost}
                  name="emailUser"
                />
                {errors.emailUser != "" && (
                  <p className="error">{errors.emailUser}</p>
                )}
              </div>
              <div>
                <h3>Contraseña</h3>
                <input
                  type={showPassword ? "text" : "password"}
                  value={newFarmer.passwordUser}
                  onChange={handleChangePost}
                  name="passwordUser"
                />
                <button
                  type="button"
                  onClick={() => setShowPassword(!showPassword)}
                  className="eyeRegister"
                >
                  {showPassword ? (
                    <i className="bi bi-eye-slash-fill"></i>
                  ) : (
                    <i className="bi bi-eye-fill"></i>
                  )}
                </button>
                {errors.passwordUser != "" && (
                  <p className="error">{errors.passwordUser}</p>
                )}
              </div>
              <div>
                <h3>Nickname</h3>
                <input
                  type="text"
                  value={newFarmer.nickNameFarmer}
                  onChange={handleChangePost}
                  name="nickNameFarmer"
                />
                {errors.nickNameFarmer != "" && (
                  <p className="error">{errors.nickNameFarmer}</p>
                )}
              </div>
              <div>
                <h3>Nombres</h3>
                <input
                  type="text"
                  value={newFarmer.nameFarmer}
                  onChange={handleChangePost}
                  name="nameFarmer"
                />
                {errors.nameFarmer != "" && (
                  <p className="error">{errors.nameFarmer}</p>
                )}
              </div>
              <div>
                <h3>Apellidos</h3>
                <input
                  type="text"
                  value={newFarmer.surnameFarmer}
                  onChange={handleChangePost}
                  name="surnameFarmer"
                />
                {errors.surnameFarmer != "" && (
                  <p className="error">{errors.surnameFarmer}</p>
                )}
              </div>
              <div>
                <h3>Fecha de nacimiento</h3>
                <input
                  type="date"
                  value={newFarmer.dateBornFarmer}
                  onChange={handleChangePost}
                  name="dateBornFarmer"
                />
                {errors.dateBornFarmer != "" && (
                  <p className="error">{errors.dateBornFarmer}</p>
                )}
              </div>
              <button
                type="button"
                className="btn"
                onClick={CreateFarmer}
                disabled={Object.keys(errors).length > 0 ? true : false}
              >
                {Object.keys(errors).length > 0
                  ? "Tienes errores"
                  : "Crear Cuenta"}
              </button>
            </form>
          </div>
        </div>
      ) : (
        <Loading />
      )}
    </div>
  );
}

export default Register;
