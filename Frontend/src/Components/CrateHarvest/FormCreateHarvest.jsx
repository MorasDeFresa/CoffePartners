import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import validation from "./Validation";
import "./FormCreatePost.Module.css";
import { getCookie } from "../../hooks/useCookies";
import { requestApi } from "../../hooks/useApi";
import Loading from "../Loading/Loading";

function FormCreatePost() {
  const [newHarvest, setNewHarvest] = useState({
    idDeveloper: getCookie({ name: "auth" })?.DeveloperData?.idCookie,
  });
  const [plantList, setPlantList] = useState([]);
  const [typeQuality, settypeQuality] = useState([]);
  const [loading, setLoading] = useState(true);
  const navigate = useNavigate();
  const [errors, setErrors] = useState({});

  const GetReports = async () => {
    try {
      const plant = await requestApi({
        typeRequest: "post",
        endPoint: "/api/Plant",
      });
      const typeQuality = await requestApi({
        typeRequest: "post",
        endPoint: "/api/TypeQuality",
      });
      setPlantList(plant?.data);
      settypeQuality(typeQuality?.data);
      setLoading(false);
    } catch (error) {
      setLoading(false);
      console.error(error);
    }
  };

  useEffect(() => {
    GetReports();
  }, [plantList]);

  const handleChangePost = (event) => {
    setNewHarvest({
      ...newHarvest,
      [event.target.name]: event.target.value,
    });
  };

  const handleSubmit = (event) => {
    event.preventDefault();
  };

  useEffect(() => {
    setErrors(validation({ newHarvest }));
  }, [newHarvest]);

  if (loading) {
    return <Loading />;
  }

  return (
    <div className="register card">
      <div className="card-header">Crear un nuevo reporte</div>
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
            {Object.keys(errors).length > 0 ? "Tienes errores" : "Crear Cuenta"}
          </button>
        </form>
      </div>
    </div>
  );
}
