import { createSlice } from "@reduxjs/toolkit";

export const authSlice = createSlice({
  name: "auth",
  initialState: {
    id: "",
    email: "",
    firstName: "",
    lastName: "",
    accessToken: "",
    tenants: "",
    refreshToken: "",
    profilePicture: "",
    isAuthenticated: false,
  },
  reducers: {
    login: (state, action) => {
      state.isAuthenticated = true;
      state.accessToken = action.payload.accessToken;
      state.refreshToken = action.payload.refreshToken;
    },
    logout: (state) => {
      state.isAuthenticated = false;
      state.accessToken = "";
    },
    tokenReceived: (state, action) => {
      console.log("ss", action);
      state.accessToken = action.payload.jwtToken;
      state.refreshToken = action.payload.refreshToken;
    },
  },
});

export const { login, logout, tokenReceived } = authSlice.actions;
export default authSlice.reducer;
export const selectAuth = (state: { auth: any }) => state.auth;
