import validator from "validator";
const validation = ({ newPost }) => {
  let errors = {};
  for (let index = 0; index < Object.keys(newPost).length; index++) {
    if (Object.keys(newPost)[index] === "titlePost") {
      validateName({ newPost, errors });
    }
    if (Object.keys(newPost)[index] === "descriptionPost") {
      validateDescription({ newPost, errors });
    }
    if (Object.keys(newPost)[index] === "imgUrl") {
      validateImage({ newPost, errors });
    }
  }

  return errors;
};

const validateName = ({ newPost, errors }) => {
  if (newPost.titlePost.length < 5) {
    errors.titlePost = "El titulo debe ser de minimo 5 caracteres.";
  }

  if (newPost.titlePost.length > 25) {
    errors.titlePost = "El titulo no puede exceder los 25 caracteres.";
  }
};

const validateDescription = ({ newPost, errors }) => {
  if (newPost.descriptionPost.length < 5) {
    errors.descriptionPost = "La descripcion debe ser de minimo 5 caracteres.";
  }

  if (newPost.descriptionPost.length > 1000) {
    errors.descriptionPost =
      "La descripcion no puede exceder los 25 caracteres.";
  }
};

const validateImage = ({ newPost, errors }) => {
  if (!validator.isURL(newPost.imgUrl)) {
    errors.imgUrl = "Ingrese una URL válida.";
  }
};

export default validation;
