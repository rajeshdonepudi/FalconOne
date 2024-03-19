import { Navigate, Outlet, useLocation } from "react-router-dom";
import { selectAuth } from "../store/Slices/authSlice";
import { useSelector } from "react-redux";

const RouteGuard = (): any => {
  const location = useLocation();
  const { isAuthenticated } = useSelector(selectAuth);

  if (isAuthenticated) {
    return <Outlet />;
  }
  return <Navigate to="/login" replace state={{ from: location }} />;
};

export default RouteGuard;
