import { Route, Routes } from "react-router-dom";
import AccountRoutes from "@/routes/Auth/AccountRoutes";
import DashboardRoutes from "@/routes/Dashboard/DashboardRoutes";
import Test from "../TestComponent/Test";

const AppRoutes = () => {
  return (
    <Routes>
      {AccountRoutes()}
      {DashboardRoutes()}
      <Route path="/t" element={<Test />}></Route>
    </Routes>
  );
};

export default AppRoutes;
