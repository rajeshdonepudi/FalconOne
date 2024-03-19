import { SettingTypeEnum } from "../../enumerations/SettingTypeEnum";

export interface ApplicationSetting {
  id?: string;
  name: string;
  value: string;
  description?: string;
  settingType: SettingTypeEnum;
}
