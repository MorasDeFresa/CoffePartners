/* eslint-disable no-undef */
// src/hooks/useCookies.js
import Cookies from "universal-cookie";

const cookies = new Cookies();

export const setCookie = ({ name, value, options = {} }) => {
  const defaultOptions = {
    path: "/",
    secure: true,
    // secure: process.env.NODE_ENV === "production",
    sameSite: "strict",
    ...options,
  };
  cookies.set(name, value, defaultOptions);
};

export const getCookie = ({ name }) => {
  return cookies.get(name);
};

export const removeCookie = ({ name, options = {} }) => {
  cookies.remove(name, { path: "/", ...options });
};
