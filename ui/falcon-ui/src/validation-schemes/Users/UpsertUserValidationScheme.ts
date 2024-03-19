import * as yup from "yup";
import { UpsertUserModel } from "@/models/Users/UserModel";

const UpsertUserValidationScheme = () => {
  return yup.object<UpsertUserModel>({
    firstName: yup.string().required("First name is required"),
    lastName: yup.string().required("Last name is required"),
    email: yup
      .string()
      .email("Enter a valid email")
      .required("Email is required"),
    password: yup.string().required("Password is required"),
    confirmPassword: yup
      .string()
      .required("Confirm password is required")
      .oneOf([yup.ref("password")], "Passwords must match"),
    lockoutEnabled: yup.boolean(),
    twoFactorEnabled: yup.boolean(),
    phoneNumberConfirmed: yup.boolean(),
    emailConfirmed: yup.boolean(),
    phone: yup.string(),
  });
};

export default UpsertUserValidationScheme;
