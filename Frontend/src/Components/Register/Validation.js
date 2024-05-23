import validator from "validator";
const validation = ({ newFarmer }) => {
  let errors = {};
  for (let index = 0; index < Object.keys(newFarmer).length; index++) {
    if (Object.keys(newFarmer)[index] === "nickNameFarmer") {
      validateNickName({ newFarmer, errors });
    }
    if (Object.keys(newFarmer)[index] === "emailUser") {
      validateEmail({ newFarmer, errors });
    }
    if (Object.keys(newFarmer)[index] === "passwordUser") {
      validatePassword({ newFarmer, errors });
    }
    if (Object.keys(newFarmer)[index] === "nameFarmer") {
      validateName({ newFarmer, errors });
    }
    if (Object.keys(newFarmer)[index] === "surnameFarmer") {
      validateSurname({ newFarmer, errors });
    }
    if (Object.keys(newFarmer)[index] === "dateBornFarmer") {
      validateDateBorn({ newFarmer, errors });
    }
  }

  return errors;
};

const validateNickName = ({ newFarmer, errors }) => {
  if (newFarmer.nickNameFarmer.length < 3) {
    errors.nickNameFarmer = "El nickname debe ser de minimo 3 caracteres.";
  }

  if (newFarmer.nickNameFarmer.length > 25) {
    errors.nickNameFarmer = "El nickname no puede exceder los 25 caracteres.";
  }
};

const validateName = ({ newFarmer, errors }) => {
  if (newFarmer.nameFarmer.length < 10) {
    errors.nameFarmer = "Los nombres debe ser de minimo 10 caracteres.";
  }
  if (newFarmer.nameFarmer.length > 50) {
    errors.nameFarmer = "Los nombres no puede exceder los 50 caracteres.";
  }
  // if (!validator.isAlpha(newFarmer.nameFarmer))
  //   errors.nameFarmer = "Los nombres solo deben contener letras";
};

const validateSurname = ({ newFarmer, errors }) => {
  if (newFarmer.surnameFarmer.length < 10) {
    errors.surnameFarmer = "Los apellidos ser de minimo 10 caracteres.";
  }

  if (newFarmer.surnameFarmer.length > 50) {
    errors.surnameFarmer = "Los apellidos no puede exceder los 50 caracteres.";
  }

  // if (!validator.isAlpha(newFarmer.nameFarmer))
  //   errors.nameFarmer = "Los apellidos solo deben contener letras";
};

const validateEmail = ({ newFarmer, errors }) => {
  if (!validator.isEmail(newFarmer.emailUser)) {
    errors.emailUser = "Ingrese un correo válido.";
  }
};

const validatePassword = ({ newFarmer, errors }) => {
  if (!validator.isStrongPassword(newFarmer.passwordUser)) {
    errors.passwordUser =
      "La contraseña debe contener minusculas, mayusculas, números y simbolos";
  }
};

const validateDateBorn = ({ newFarmer, errors }) => {
  if (!validator.isDate(newFarmer.dateBornFarmer))
    errors.dateBornFarmer = "Ingresa una fecha valida";
};

export default validation;
