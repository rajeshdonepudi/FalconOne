import * as yup from "yup";

const AddNewSettingValidationScheme = () => {
  return yup.object({
    name: yup.string().required("Setting name is required"),
    value: yup.string().required("Setting value is required"),
    description: yup.string(),
    settingType: yup.number().required("Setting type is required"),
    displayName: yup.string().required("Display name is required"),
  });
};

export default AddNewSettingValidationScheme;
