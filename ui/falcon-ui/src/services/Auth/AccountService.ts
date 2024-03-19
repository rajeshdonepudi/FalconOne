import { createApi } from "@reduxjs/toolkit/query/react";
import BaseQuery from "../BaseQuery";
import { SignupResponse } from "@models/Account/SignupResponse";
import { LoginResponse } from "@models/Account/LoginResponse";
import { ApiResponse } from "@models/Common/ApiResponse";
import { SignupRequest } from "@models/Account/SignupRequest";
import { LoginRequest } from "@models/Account/LoginRequest";
import AccountEndpoints from "@/endpoints/Account/AccountEndpoints";

export const accountAPI = createApi({
  reducerPath: "accountAPI",
  baseQuery: BaseQuery,
  endpoints: (builder) => ({
    login: builder.mutation<ApiResponse<LoginResponse>, LoginRequest>({
      query: (payload: LoginRequest) => ({
        url: AccountEndpoints.login,
        method: "POST",
        body: payload,
      }),
    }),
    signup: builder.mutation<ApiResponse<SignupResponse>, SignupRequest>({
      query: (payload: SignupRequest) => ({
        url: AccountEndpoints.signup,
        method: "POST",
        body: payload,
      }),
    }),
  }),
});

export const { useLoginMutation, useSignupMutation } = accountAPI;
