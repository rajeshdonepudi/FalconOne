import { formatPhoneNumberIntl } from "react-phone-number-input";

const getDisplayNameForBoolean = (val: boolean): string => {
  switch (val) {
    case true:
      return "Yes";
    case false:
      return "No";
  }
};

const getFormattedNumber = (num: number) => {
  if (num >= 1000000000) {
    return (num / 1000000000).toFixed(1).replace(/\.0$/, "") + "G";
  }
  if (num >= 1000000) {
    return (num / 1000000).toFixed(1).replace(/\.0$/, "") + "M";
  }
  if (num >= 1000) {
    return (num / 1000).toFixed(1).replace(/\.0$/, "") + "K";
  }
  return num;
};

const formatPhoneNumber = (number: string) => {
  return formatPhoneNumberIntl(number);
};

export default {
  formatBoolean: getDisplayNameForBoolean,
  formatPhone: formatPhoneNumber,
  formatNumber: getFormattedNumber,
};
