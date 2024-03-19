import { TenantSetting } from "./TenantSetting";

export interface TenantSettingsResponse {
  settingType: string;
  settings: TenantSetting[];
}
