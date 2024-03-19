import { combineReducers } from "@reduxjs/toolkit";
import { accountAPI } from "@services/Auth/AccountService";
import { userManagementAPI } from "@/services/User/UserManagementService";
import themeReducer from "@slices/themeSlice";
import { securityAPI } from "@/services/Security/SecurityService";
import { authSlice } from "@slices/authSlice";
import { settingsAPI } from "@/services/Settings/SettingService";

const rootReducer = combineReducers({
  theme: themeReducer,
  [accountAPI.reducerPath]: accountAPI.reducer,
  [userManagementAPI.reducerPath]: userManagementAPI.reducer,
  [settingsAPI.reducerPath]: settingsAPI.reducer,
  [securityAPI.reducerPath]: securityAPI.reducer,
  auth: authSlice.reducer,
});

export default rootReducer;
