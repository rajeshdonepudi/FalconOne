import { configureStore } from "@reduxjs/toolkit";
import rootReducer from "./RootReducer";
import { accountAPI } from "@services/Auth/AccountService";
import { userManagementAPI } from "@services/User/UserManagementService";
import { settingsAPI } from "@services/Settings/SettingService";
import {
  persistReducer,
  FLUSH,
  REHYDRATE,
  PAUSE,
  PERSIST,
  PURGE,
  REGISTER,
} from "redux-persist";
import storage from "redux-persist/lib/storage";
import { securityAPI } from "@services/Security/SecurityService";

const persistConfig = {
  key: "falcon-one",
  storage,
};

const persistedReducer = persistReducer(persistConfig, rootReducer);

export const store = configureStore({
  reducer: persistedReducer,
  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware({
      serializableCheck: {
        ignoredActions: [FLUSH, REHYDRATE, PAUSE, PERSIST, PURGE, REGISTER],
      },
    })
      .concat(userManagementAPI.middleware)
      .concat(accountAPI.middleware)
      .concat(settingsAPI.middleware)
      .concat(securityAPI.middleware),
  devTools: true,
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;
