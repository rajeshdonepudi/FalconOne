import { createApi } from "@reduxjs/toolkit/query/react";
import { ApiResponse } from "@models/Common/ApiResponse";
import { PageParams } from "@models/Common/PageParams";
import { PagedList } from "@models/Common/PagedResponse";
import { UserManagementDashboardInfoModel } from "@models/Users/DashboardInfoModel";
import { UpsertUserModel, UserModel } from "@models/Users/UserModel";
import AuthorizedBaseQuery from "../AuthorizedBaseQuery";
import UserManagementEndpoints from "@/endpoints/User/UserManagementEndpoints";

const userManagementTags = {
  manageUserList: "USER_MANAGEMENT_USERS_LIST",
  userManagementDashboardInfo: "USER_MANAGEMENT_DASHBOARD_INFO",
};

export const userManagementAPI = createApi({
  reducerPath: "userManagementAPI",
  baseQuery: AuthorizedBaseQuery,
  tagTypes: [
    userManagementTags.manageUserList,
    userManagementTags.userManagementDashboardInfo,
  ],
  endpoints: (builder) => ({
    getAllUsers: builder.query<ApiResponse<PagedList<UserModel[]>>, PageParams>(
      {
        query: (payload: PageParams) => ({
          url: UserManagementEndpoints.allUsers,
          method: "POST",
          body: payload,
        }),
        providesTags: [userManagementTags.manageUserList],
      }
    ),
    getUserManagementDashboardInfo: builder.query<
      ApiResponse<UserManagementDashboardInfoModel>,
      null
    >({
      query: () => ({
        url: UserManagementEndpoints.dashboardInfo,
        method: "GET",
        providesTags: [userManagementTags.userManagementDashboardInfo],
      }),
      providesTags: [userManagementTags.userManagementDashboardInfo],
    }),
    upsertUser: builder.mutation<ApiResponse<null>, UpsertUserModel>({
      query: (payload: UpsertUserModel) => ({
        url: UserManagementEndpoints.addUser,
        method: "POST",
        body: payload,
      }),
      invalidatesTags: [
        userManagementTags.manageUserList,
        userManagementTags.userManagementDashboardInfo,
      ],
    }),
  }),
});

export const {
  useGetAllUsersQuery,
  useUpsertUserMutation,
  useGetUserManagementDashboardInfoQuery,
} = userManagementAPI;
