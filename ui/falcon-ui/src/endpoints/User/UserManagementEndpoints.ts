const UserManagementEndpoints = {
  allUsers: "UserManagement/all-users",
  addUser: "UserManagement/add-user",
  userCreatedByYear: "UserManagement/user-created-year",
  deleteUser: (resourceAlias: string) =>
    `UserManagement/delete-user/${resourceAlias}`,
  dashboardInfo: "UserManagement/dashboard-info",
};

export default UserManagementEndpoints;
