import { useState } from "react";
import SignupForm from "@feature-components/Account/SignupForm";
import { SignupRequest } from "@models/Account/SignupRequest";
import { useSignupMutation } from "@services/Auth/AccountService";

const Signup = () => {
  const [signup] = useSignupMutation();
  const [showLoader, setShowLoader] = useState<boolean>(false);

  const handleFormSubmit = (request: SignupRequest, { resetForm }: any) => {
    setShowLoader(true);
    signup(request)
      .unwrap()
      .then((res) => {
        setShowLoader(false);
        resetForm();
      });
  };

  return (
    <SignupForm
      submissionState={showLoader}
      handleFormSubmit={handleFormSubmit}
    />
  );
};

export default Signup;
