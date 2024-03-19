import { createApi } from "@reduxjs/toolkit/query/react";
import AuthorizedBaseQuery from "../AuthorizedBaseQuery";

export const postsAPI = createApi({
  reducerPath: "userManagementAPI",
  baseQuery: AuthorizedBaseQuery,
  endpoints: (builder) => ({}),
});

export const {} = postsAPI;
