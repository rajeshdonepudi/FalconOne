import { Navigate, Outlet, useLocation } from "react-router-dom";
import { useSelector } from "react-redux";
import { selectAuth } from "../store/Slices/authSlice";

const AuthCheck = () => {
  const location = useLocation();
  const { isAuthenticated } = useSelector(selectAuth);

  if (isAuthenticated) {
    return (
      <Navigate to="/secure/dashboard" replace state={{ from: location }} />
    );
  }
  return <Outlet />;
};

export default AuthCheck;
