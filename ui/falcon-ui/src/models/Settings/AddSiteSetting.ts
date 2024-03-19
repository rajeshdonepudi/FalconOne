import { SettingTypeEnum } from "../../enumerations/SettingTypeEnum";

export interface AddSiteSetting {
  name: string;
  value: string;
  displayName: string;
  description: string | null;
  settingType: SettingTypeEnum;
}
