import moment from "moment";

const getRelativeTime = (date: string) => {
  return moment(convertUTCDateToLocalDate(date)).fromNow();
};

const formatDate = (format: string) => {
  return moment().format(format);
};

const GetTodayDate = () => {
  return moment().format("ll");
};

export default {
  GetRelativeTime: getRelativeTime,
  TodayDate: GetTodayDate,
  FormatDate: formatDate,
};

//#region Helper functions
function convertUTCDateToLocalDate(date: string) {
  var newDate = new Date(date);
  newDate.setMinutes(
    new Date(date).getMinutes() - new Date(date).getTimezoneOffset()
  );
  return newDate;
}

//#endregion
