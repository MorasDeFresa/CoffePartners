import axios from "axios";

export const requestApi = async ({
  typeRequest,
  endPoint,
  bodyData = null,
}) => {
  return await axios[typeRequest](
    `${import.meta.env.VITE_API_URL}${endPoint}`,
    bodyData
  );
};
