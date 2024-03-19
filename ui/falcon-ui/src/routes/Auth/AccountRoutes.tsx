import { Route } from "react-router-dom";
import Login from "@/pages/Auth/Login";
import Signup from "@/pages/Auth/Signup";
import ForgotPassword from "@/pages/Auth/ForgotPassword";
import ResetPassword from "@/pages/Auth/ResetPassword";
import LandingLayout from "../../layouts/LandingLayout";
import PageNotFound from "@/pages/Common/PageNotFound";
import WelcomePage from "@/pages/landing/WelcomePage";
import AuthCheck from "../../guards/AuthCheck";

const AccountRoutes = () => {
  return (
    <Route element={<LandingLayout />}>
      <Route path="/" element={<WelcomePage />}></Route>
      <Route element={(<AuthCheck />) as any}>
        <Route index path="login" element={<Login />}></Route>
        <Route path="signup" element={<Signup />}></Route>
        <Route path="forgot-password" element={<ForgotPassword />}></Route>
      </Route>
      <Route path="reset-password" element={<ResetPassword />}></Route>
      <Route
        path="*"
        element={
          <PageNotFound url="https://assets8.lottiefiles.com/packages/lf20_aaesnvcw.json" />
        }
      ></Route>
    </Route>
  );
};

export default AccountRoutes;
