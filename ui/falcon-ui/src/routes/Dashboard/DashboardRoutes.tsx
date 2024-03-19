import { Route } from "react-router-dom";
import Dashboard from "@/pages/Dashboard/Dashboard";
import DashboardLayout from "@/layouts/DashboardLayout";
import PageNotFound from "@/pages/Common/PageNotFound";
import ManageUsers from "@/pages/Users/ManageUsers";
import ManageTheme from "@/pages/Site-Settings/SiteSettings";
import UserProfile from "@/pages/Users/UserProfile";
import UserInfo from "@/pages/Users/UserInfo";
import OrganizationInfo from "@/pages/Organization/OrganizationInfo";
import MyFinances from "@/pages/Finances/MyFinances";
import RouteGuard from "@/guards/RouteGuard";

const DashboardRoutes = () => {
  return (
    <Route element={(<RouteGuard />) as any}>
      <Route path="secure" element={<DashboardLayout />}>
        <Route path="dashboard" element={<Dashboard />}></Route>
        <Route
          path="*"
          element={
            <PageNotFound url="https://assets8.lottiefiles.com/packages/lf20_xiebbQE7S1.json" />
          }
        ></Route>
        <Route path="manage-users">
          <Route index element={<ManageUsers />} />
        </Route>
        <Route path="manage-theme" element={<ManageTheme />}></Route>
        <Route path="profile" element={<UserProfile />}></Route>
        <Route path="me" element={<UserInfo />}></Route>
        <Route path="org" element={<OrganizationInfo />}></Route>
        <Route path="finances" element={<MyFinances />}></Route>
      </Route>
    </Route>
  );
};

export default DashboardRoutes;
