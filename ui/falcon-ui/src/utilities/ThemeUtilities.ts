import { ApplicationSetting } from "@models/Settings/ApplicationSetting";

const LOCAL_STORAGE_THEME_SETTINGS_KEY = "FALCONONE_THEME_SETTINGS";

const getPrimaryColor = (settings: ApplicationSetting[]) => {
  return settings.length > 0
    ? settings?.filter((x: ApplicationSetting) => x.name === "primaryColor")[0]
        ?.value
    : undefined;
};

const getThemeSettingsInfoFromLocalStorage = () => {
  return localStorage.getItem(LOCAL_STORAGE_THEME_SETTINGS_KEY);
};

const setThemeSettingsInfoToLocalStorage = (settingInfo: string) => {
  localStorage.setItem(LOCAL_STORAGE_THEME_SETTINGS_KEY, settingInfo);
};

const getThemeFromLocalStorage = () => {
  const storedSettings = getThemeSettingsInfoFromLocalStorage();

  if (storedSettings) {
    const parsedSettings = JSON.parse(storedSettings);
    const settings = parsedSettings as ApplicationSetting[];

    return {
      primaryColor: getPrimaryColor(settings),
      secondaryColor: getSecondaryColor(settings),
      theme: getTheme(settings),
    };
  }
};

const getTheme2 = (store: any) => {
  if (store) {
    const settings = store as ApplicationSetting[];

    return {
      primaryColor: getPrimaryColor(settings),
      secondaryColor: getSecondaryColor(settings),
      theme: getTheme(settings),
    };
  }
};

const getSecondaryColor = (settings: ApplicationSetting[]) => {
  return settings.length > 0
    ? settings?.filter(
        (x: ApplicationSetting) => x.name === "secondaryColor"
      )[0]?.value
    : undefined;
};

const getTheme = (settings: ApplicationSetting[]) => {
  return settings.length > 0
    ? settings?.filter((x: ApplicationSetting) => x.name === "theme")[0]?.value
    : undefined;
};

export default {
  getThemeFromLocalStorage,
  setThemeSettingsInfoToLocalStorage,
  getSecondaryColor,
  getPrimaryColor,
  getTheme,
  getTheme2,
};
