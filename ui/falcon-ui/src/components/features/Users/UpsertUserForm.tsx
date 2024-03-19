import { MuiTelInput } from "mui-tel-input";
import { lazy, useState } from "react";
import { useTranslation } from "react-i18next";
const Visibility = lazy(() => import("@mui/icons-material/Visibility"));
const VisibilityOff = lazy(() => import("@mui/icons-material/VisibilityOff"));
const FormControlLabel = lazy(() => import("@mui/material/FormControlLabel"));
const FormGroup = lazy(() => import("@mui/material/FormGroup"));
const Switch = lazy(() => import("@mui/material/Switch"));
const FormControl = lazy(() => import("@mui/material/FormControl"));
const FormHelperText = lazy(() => import("@mui/material/FormHelperText"));
const IconButton = lazy(() => import("@mui/material/IconButton"));
const InputAdornment = lazy(() => import("@mui/material/InputAdornment"));
const InputLabel = lazy(() => import("@mui/material/InputLabel"));
const OutlinedInput = lazy(() => import("@mui/material/OutlinedInput"));
const Stack = lazy(() => import("@mui/material/Stack"));
const TextField = lazy(() => import("@mui/material/TextField"));

const UpsertUserForm = (props: any) => {
  const { t: commonLocale } = useTranslation("common");
  const [showPassword, setShowPassword] = useState<boolean>(false);
  const [showConfirmPassword, setShowConfirmPassword] =
    useState<boolean>(false);

  /***
   * Event handler's
   */
  const onClickShowPassword = () => {
    setShowPassword((old) => !old);
  };

  const onClickShowConfirmPassword = (e: any) => {
    setShowConfirmPassword((old) => !old);
  };

  const handleMouseDownPassword = (event: any) => {
    event.preventDefault();
  };

  return (
    <>
      <Stack direction="row" justifyContent="center">
        <form
          ref={props?.formRef}
          autoComplete="off"
          onSubmit={props?.formik.handleSubmit}
        >
          <Stack spacing={2}>
            <Stack direction="row" spacing={2}>
              <TextField
                id="firstName"
                name="firstName"
                size="small"
                required={true}
                label={commonLocale("firstName")}
                variant="outlined"
                fullWidth
                value={props?.formik?.values?.firstName}
                onChange={props?.formik?.handleChange}
                error={
                  props?.formik?.touched?.firstName &&
                  Boolean(props?.formik?.errors.firstName)
                }
                helperText={
                  props?.formik?.touched?.firstName &&
                  props?.formik?.errors.firstName
                }
              />
              <TextField
                id="lastName"
                name="lastName"
                size="small"
                required={true}
                label={commonLocale("lastName")}
                variant="outlined"
                fullWidth
                value={props?.formik?.values?.lastName}
                onChange={props?.formik?.handleChange}
                error={
                  props?.formik?.touched?.lastName &&
                  Boolean(props?.formik?.errors.lastName)
                }
                helperText={
                  props?.formik?.touched?.lastName &&
                  props?.formik?.errors.lastName
                }
              />
            </Stack>
            <TextField
              id="email"
              name="email"
              size="small"
              required={true}
              label={commonLocale("email")}
              variant="outlined"
              value={props?.formik?.values?.email}
              onChange={props?.formik?.handleChange}
              error={
                props?.formik?.touched?.email &&
                Boolean(props?.formik?.errors.email)
              }
              helperText={
                props?.formik?.touched?.email && props?.formik?.errors.email
              }
            />
            <Stack direction="row" spacing={2}>
              <MuiTelInput
                name="phone"
                id="phone"
                size="small"
                error={
                  props?.formik?.touched?.phone &&
                  Boolean(props?.formik?.errors.phone)
                }
                helperText={
                  props?.formik?.touched?.phone && props?.formik?.errors.phone
                }
                label={commonLocale("phone")}
                fullWidth
                variant="outlined"
                value={props?.formik?.values?.phone}
                onChange={(e) => {
                  props?.formik.setValues((prev: any) => {
                    return { ...prev, phone: e };
                  });
                }}
              />
            </Stack>
            <Stack direction="row" spacing={2}>
              <FormControl fullWidth variant="outlined">
                <InputLabel required={true} htmlFor="password">
                  {commonLocale("password")}
                </InputLabel>
                <OutlinedInput
                  id="password"
                  name="password"
                  autoComplete="one-time-code"
                  type={showPassword ? "text" : "password"}
                  value={props?.formik?.values?.password}
                  onChange={props?.formik?.handleChange}
                  error={
                    props?.formik?.touched?.password &&
                    Boolean(props?.formik?.errors.password)
                  }
                  endAdornment={
                    <InputAdornment position="end">
                      <IconButton
                        aria-label="toggle password visibility"
                        onClick={onClickShowPassword}
                        onMouseDown={handleMouseDownPassword}
                        edge="end"
                      >
                        {showPassword ? <VisibilityOff /> : <Visibility />}
                      </IconButton>
                    </InputAdornment>
                  }
                  label={commonLocale("password")}
                />
                <FormHelperText sx={{ color: "red" }}>
                  {props?.formik?.touched?.password &&
                    props?.formik?.errors.password}
                </FormHelperText>
              </FormControl>
              <FormControl fullWidth variant="outlined">
                <InputLabel
                  required={true}
                  sx={{ width: "inherit" }}
                  htmlFor={`${commonLocale("confirm")} ${commonLocale(
                    "password"
                  )}`}
                >
                  {`${commonLocale("confirm")} ${commonLocale("password")}`}
                </InputLabel>
                <OutlinedInput
                  id="confirmPassword"
                  name="confirmPassword"
                  autoComplete="one-time-code"
                  type={showConfirmPassword ? "text" : "password"}
                  value={props?.formik?.values?.confirmPassword}
                  onChange={props?.formik?.handleChange}
                  error={
                    props?.formik?.touched?.confirmPassword &&
                    Boolean(props?.formik?.errors.confirmPassword)
                  }
                  endAdornment={
                    <InputAdornment position="end">
                      <IconButton
                        aria-label="toggle password visibility"
                        onClick={onClickShowConfirmPassword}
                        onMouseDown={handleMouseDownPassword}
                        edge="end"
                      >
                        {showConfirmPassword ? (
                          <VisibilityOff />
                        ) : (
                          <Visibility />
                        )}
                      </IconButton>
                    </InputAdornment>
                  }
                  label={`${commonLocale("confirm")} ${commonLocale(
                    "password"
                  )}`}
                />
                <FormHelperText sx={{ color: "red" }}>
                  {props?.formik?.touched?.confirmPassword &&
                    props?.formik?.errors.confirmPassword}
                </FormHelperText>
              </FormControl>
            </Stack>
            <Stack direction="row">
              <FormGroup>
                <FormControlLabel
                  control={
                    <Switch
                      id="emailConfirmed"
                      name="emailConfirmed"
                      size="small"
                      value={props?.formik?.values?.emailConfirmed}
                      checked={props?.formik?.values?.emailConfirmed}
                      onChange={props?.formik?.handleChange}
                    />
                  }
                  label={`${commonLocale("email")} ${commonLocale(
                    "confirmed"
                  )}`}
                />
              </FormGroup>
              <FormGroup>
                <FormControlLabel
                  control={
                    <Switch
                      id="phoneNumberConfirmed"
                      name="phoneNumberConfirmed"
                      size="small"
                      value={props?.formik?.values?.phoneNumberConfirmed}
                      onChange={props?.formik?.handleChange}
                    />
                  }
                  label={`${commonLocale("phone")} ${commonLocale(
                    "confirmed"
                  )}`}
                />
              </FormGroup>
              <FormGroup>
                <FormControlLabel
                  control={
                    <Switch
                      id="lockoutEnabled"
                      name="lockoutEnabled"
                      size="small"
                      value={props?.formik?.values?.lockoutEnabled}
                      onChange={props?.formik?.handleChange}
                    />
                  }
                  label={`${commonLocale("lockout")} ${commonLocale(
                    "enabled"
                  )}`}
                />
              </FormGroup>
              <FormGroup>
                <FormControlLabel
                  control={
                    <Switch
                      id="twoFactorEnabled"
                      name="twoFactorEnabled"
                      size="small"
                      value={props?.formik?.values?.twoFactorEnabled}
                      onChange={props?.formik?.handleChange}
                    />
                  }
                  label={`${commonLocale("lockout")} ${commonLocale(
                    "enabled"
                  )}`}
                />
              </FormGroup>
            </Stack>
          </Stack>
        </form>
      </Stack>
    </>
  );
};

export default UpsertUserForm;
