import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import axios from "axios";
import validation from "./Validation";
import "./FormCreatePost.Module.css";
import { getCookie } from "../../hooks/useCookies";
import Loading from "../Loading/Loading";

function FormCreatePost() {
  const [newPost, setNewPost] = useState({
    idDeveloper: getCookie({ name: "auth" })?.DeveloperData?.idCookie,
  });

  const [wait, setWait] = useState(false);
  const navigate = useNavigate();
  const [errors, setErrors] = useState({});

  const handleChangePost = (event) => {
    switch (event.target.name) {
      case "titlePost":
        setNewPost({
          ...newPost,
          [event.target.name]: event.target.value,
        });
        break;
      case "descriptionPost":
        setNewPost({
          ...newPost,
          [event.target.name]: event.target.value,
        });
        break;
      case "imgUrl":
        setNewPost({
          ...newPost,
          [event.target.name]: event.target.value,
        });
        break;
    }
  };

  const handleSubmit = (event) => {
    event.preventDefault();
  };

  useEffect(() => {
    setErrors(validation({ newPost }));
  }, [newPost]);

  const CreatePost = () => {
    if (errors != {}) {
      setWait(true);
      axios
        .post(`${import.meta.env.VITE_API_URL}/api/Posts`, newPost)
        .then(function (response) {
          setWait(false);
          setNewPost({
            idDeveloper: getCookie({ name: "auth" })?.DeveloperData?.idCookie,
          });
          navigate("/blog");
        })
        .catch(function (error) {
          setWait(false);
          console.log(error);
        });
    }
  };

  return (
    <div>
      {!wait ? (
        <div className="form card">
          <div className="card-header">Crear un nuevo post</div>
          <div className="bodyForm card-body">
            <form onSubmit={handleSubmit}>
              <div>
                <h3>Titulo del post</h3>
                <input
                  type="text"
                  value={newPost.titlePost}
                  onChange={handleChangePost}
                  name="titlePost"
                />
                {errors.titlePost != "" && (
                  <p className="error">{errors.titlePost}</p>
                )}
              </div>
              <div>
                <h3>Descripcion del post</h3>
                <textarea
                  value={newPost.descriptionPost}
                  onChange={handleChangePost}
                  name="descriptionPost"
                />
                {errors.descriptionPost != "" && (
                  <p className="error">{errors.descriptionPost}</p>
                )}
              </div>
              <div>
                <h3>Url de la imagen</h3>
                <input
                  type="text"
                  value={newPost.imgUrl}
                  onChange={handleChangePost}
                  name="imgUrl"
                />
                {errors.imgUrl != "" && (
                  <p className="error">{errors.imgUrl}</p>
                )}
              </div>
              <button
                type="button"
                className="btn"
                onClick={CreatePost}
                disabled={Object.keys(errors).length > 0 ? true : false}
              >
                {Object.keys(errors).length > 0
                  ? "Tienes errores"
                  : "Crear Post"}
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

export default FormCreatePost;
