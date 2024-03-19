import { createApi } from "@reduxjs/toolkit/query/react";
import AuthorizedBaseQuery from "../AuthorizedBaseQuery";
import { ApplicationSetting } from "@models/Settings/ApplicationSetting";
import { ApiResponse } from "@models/Common/ApiResponse";
import { SettingTypeEnum } from "@/enumerations/SettingTypeEnum";
import { TenantSettingsResponse } from "@models/Settings/TenantSettingsResponse";
import { KeyValuePair } from "@models/Common/KeyValuePair";
import { AddSiteSetting } from "@models/Settings/AddSiteSetting";
import SettingsEndpoints from "@/endpoints/Settings/SettingsEndpoints";

export const settingsAPI = createApi({
  reducerPath: "settingsAPI",
  tagTypes: ["settings-by-type", "tenant-settings", "types"],
  baseQuery: AuthorizedBaseQuery,

  endpoints: (builder) => ({
    getSettingsByType: builder.query<
      ApiResponse<ApplicationSetting[]>,
      SettingTypeEnum
    >({
      query: (type: SettingTypeEnum) => ({
        url: SettingsEndpoints.getSettingsByType(type),
      }),
      providesTags: ["settings-by-type"],
    }),
    updateSetting: builder.mutation<null, ApplicationSetting[]>({
      query: (payload: ApplicationSetting[]) => ({
        url: SettingsEndpoints.updateSetting,
        method: "PATCH",
        body: payload,
      }),
    }),
    getTenantSettings: builder.query<
      ApiResponse<TenantSettingsResponse[]>,
      null
    >({
      query: () => ({
        url: SettingsEndpoints.tenantSettings,
      }),
      providesTags: ["tenant-settings"],
    }),
    getSettingsTypes: builder.query<
      ApiResponse<KeyValuePair<string, number>[]>,
      null
    >({
      query: () => ({
        url: SettingsEndpoints.types,
      }),
      providesTags: ["types"],
    }),
    addNewSetting: builder.mutation<ApiResponse<any>, AddSiteSetting>({
      query: (payload: AddSiteSetting) => ({
        url: SettingsEndpoints.addNew,
        method: "POST",
        body: payload,
      }),
    }),
  }),
});

export const {
  useUpdateSettingMutation,
  useLazyGetSettingsByTypeQuery,
  useGetTenantSettingsQuery,
  useAddNewSettingMutation,
  useGetSettingsTypesQuery,
} = settingsAPI;
