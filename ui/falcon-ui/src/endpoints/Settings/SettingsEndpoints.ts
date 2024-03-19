import { SettingTypeEnum } from "../../enumerations/SettingTypeEnum";

export default {
  updateSetting: "",
  getSettingsByType: (settingType: SettingTypeEnum) => `type/${settingType}`,
  tenantSettings: "tenant-settings",
  types: "types",
  addNew: "add-new",
};
