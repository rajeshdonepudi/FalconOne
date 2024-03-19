import { createApi } from "@reduxjs/toolkit/query/react";
import AuthorizedBaseQuery from "../AuthorizedBaseQuery";
import { ApiResponse } from "@models/Common/ApiResponse";
import { KeyValuePair } from "@models/Common/KeyValuePair";
import SecurityEndpoints from "@/endpoints/Security/SecurityEndpoints";

export const securityAPI = createApi({
  reducerPath: "securityAPI",
  tagTypes: ["security-claims", "security-roles"],
  baseQuery: AuthorizedBaseQuery,
  endpoints: (builder) => ({
    getSecurityClaims: builder.query<
      ApiResponse<KeyValuePair<string, string>[]>,
      null
    >({
      query: () => ({
        url: SecurityEndpoints.getSecurityClaims,
      }),
      providesTags: ["security-claims"],
    }),
    getSecurityRoles: builder.query<
      ApiResponse<KeyValuePair<string, string>[]>,
      null
    >({
      query: () => ({
        url: SecurityEndpoints.getSecurityRoles,
      }),
      providesTags: ["security-roles"],
    }),
  }),
});

export const { useGetSecurityRolesQuery, useGetSecurityClaimsQuery } =
  securityAPI;
