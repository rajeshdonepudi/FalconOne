import { getAnalytics } from "firebase/analytics";
import { initializeApp } from "firebase/app";
import i18n from "i18next";
import React from "react";
import ReactDOM from "react-dom/client";
import { initReactI18next } from "react-i18next";
import { Provider } from "react-redux";
import { persistStore } from "redux-persist";
import { PersistGate } from "redux-persist/integration/react";
import App from "./App";
import "./css/common.module.css";
import localeResources from "./locales/locale-resources";
import { store } from "./store/Store";
import { ToastContainer } from "react-toastify";
const firebaseConfig = {
  apiKey: "AIzaSyBLgkLolGtXHlYxwA_HboFDArDT4Y8s1wo",
  authDomain: "falconone-b50e5.firebaseapp.com",
  projectId: "falconone-b50e5",
  storageBucket: "falconone-b50e5.appspot.com",
  messagingSenderId: "168523004670",
  appId: "1:168523004670:web:bab5ce51ebd2e2f08183af",
  measurementId: "G-JNHESQSTF2",
};

//const app = initializeApp(firebaseConfig);
const persistor = persistStore(store);

i18n.use(initReactI18next).init({
  resources: localeResources,
  lng: "en",
  fallbackLng: "en",
  interpolation: {
    escapeValue: false,
  },
});

//getAnalytics(app);
ReactDOM.createRoot(document.getElementById("root") as HTMLElement).render(
  <React.StrictMode>
    <Provider store={store}>
      <PersistGate persistor={persistor}>
        <App />
      </PersistGate>
    </Provider>
  </React.StrictMode>
);
