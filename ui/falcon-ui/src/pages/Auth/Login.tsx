import { useFormik } from "formik";
import LoginValidationScheme from "@/validation-schemes/Account/LoginValidationScheme";
import { useLoginMutation } from "@services/Auth/AccountService";
import { LoginResponse } from "../../models/Account/LoginResponse";
import { useLocation, useNavigate } from "react-router-dom";
import LoginForm from "@feature-components/Account/LoginForm";
import { selectAuth, login as loginUser } from "../../store/Slices/authSlice";
import { useDispatch, useSelector } from "react-redux";
import AuthUtilities from "@/utilities/AuthUtilities";

const Login = () => {
  const [login] = useLoginMutation();
  const navigator = useNavigate();
  const location = useLocation();
  const { isAuthenticated } = useSelector(selectAuth);
  const dispatch = useDispatch();

  const handleForm = useFormik({
    initialValues: {
      email: "Susan_Lesch10@yahoo.com",
      password: "@Raj@123",
    },
    validationSchema: LoginValidationScheme,
    onSubmit: (payload) => {
      login(payload)
        .unwrap()
        .then((res) => {
          AuthUtilities.loginUser(res.data as LoginResponse);
          dispatch(loginUser(res.data as LoginResponse));
          navigator("/secure/dashboard", {
            replace: true,
            state: {
              from: location,
            },
          });
        });
    },
  });
  return <LoginForm formik={handleForm} />;
};

export default Login;
