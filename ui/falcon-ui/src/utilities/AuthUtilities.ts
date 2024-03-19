import jwtDecode from "jwt-decode";
import { LoginResponse } from "@models/Account/LoginResponse";

const USER_SESSION_KEY: string = "FALCON_ONE_USER";
const USER_AVATAR_KEY: string = "FALCON_ONE_USER";

const getLoggedInUser = (): LoginResponse | null => {
  const user = localStorage.getItem(USER_SESSION_KEY);
  if (user === null || user === undefined || user === "") {
    return null;
  }
  var currentUser = JSON.parse(user) as LoginResponse;
  return currentUser;
};

const getProfilePicture = () => {
  const currentUser = getLoggedInUser();
  return currentUser?.profilePicture;
};

const isTokenExpired = (token: string) => {
  const decodedToken: { exp?: number } = jwtDecode(token);
  if (decodedToken.exp === undefined) {
    return true;
  }
  const expirationTime = decodedToken.exp * 1000;
  const currentTime = Date.now();
  return currentTime > expirationTime;
};

const isLoggedIn = (): boolean => {
  const currentUser = getLoggedInUser();
  if (currentUser === null) {
    return false;
  }
  // return currentUser &&
  //   currentUser.accessToken &&
  //   !isTokenExpired(currentUser.accessToken)
  //   ? true
  //   : false;

  return currentUser && currentUser.accessToken ? true : false;
};

const getJWTToken = () => {
  const currentUser = getLoggedInUser();
  return currentUser?.accessToken;
};

const getRefreshToken = () => {
  const currentUser = getLoggedInUser();
  return currentUser?.refreshToken;
};

const loginUser = (authResponse: LoginResponse) => {
  localStorage.setItem(USER_SESSION_KEY, JSON.stringify(authResponse));
};

const logoutUser = () => {
  localStorage.removeItem(USER_SESSION_KEY);
};

const updateLoggedInUser = (accessToken: string, refreshToken: string) => {
  const currentUser = getLoggedInUser() as any;
  currentUser.accessToken = accessToken;
  currentUser.refreshToken = refreshToken;
  localStorage.setItem(USER_SESSION_KEY, JSON.stringify(currentUser));
};

export default {
  loginUser,
  logoutUser,
  isLoggedIn,
  getJWTToken,
  getRefreshToken,
  updateLoggedInUser,
  getProfilePicture,
};
