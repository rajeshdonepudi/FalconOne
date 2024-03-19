import * as yup from "yup";

const ForgotPasswordValidationScheme = () => {
  return yup.object({
    email: yup
      .string()
      .email("Enter a valid email")
      .required("Email is required"),
  });
};

export default ForgotPasswordValidationScheme;
