import * as yup from "yup";

const AddThemeValidationScheme = () => {
  return yup.object({
    primaryColor: yup.string().required("Primary color is rquired."),
    secondaryColor: yup.string().required("Secondary color is required."),
  });
};
export default AddThemeValidationScheme;
