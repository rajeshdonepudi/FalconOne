import commonLocaleEN from "./Common/common.en";
import commonLocaleFR from "./Common/common.fr";
import commonLocaleTE from "./Common/common.te";
import userLocaleEN from "./User/user.en";
import userLocaleFR from "./User/user.fr";

const localeResources = {
  en: {
    common: commonLocaleEN,
    user: userLocaleEN,
  },
  fr: {
    common: commonLocaleFR,
    user: userLocaleFR,
  },
  te: {
    common: commonLocaleTE,
  },
};

export default localeResources;
