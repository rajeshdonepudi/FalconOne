import TextField from "@mui/material/TextField";
import Stack from "@mui/material/Stack";
import Button from "@mui/material/Button";
import Link from "@mui/material/Link";
import InputLabel from "@mui/material/InputLabel";
import InputAdornment from "@mui/material/InputAdornment";
import FormControl from "@mui/material/FormControl";
import Visibility from "@mui/icons-material/Visibility";
import VisibilityOff from "@mui/icons-material/VisibilityOff";
import OutlinedInput from "@mui/material/OutlinedInput";
import IconButton from "@mui/material/IconButton";
import { useState } from "react";
import Typography from "@mui/material/Typography";
import FormHelperText from "@mui/material/FormHelperText";
import { CircularProgress } from "@mui/material";
import AppCard from "@ui-components/AppCard";

const LoginForm = (props: any) => {
  const [showPassword, setShowPassword] = useState({
    showPassword: false,
  });

  const handleClickShowPassword = () => {
    setShowPassword({
      ...showPassword,
      showPassword: !showPassword.showPassword,
    });
  };

  const handleMouseDownPassword = (event: any) => {
    event.preventDefault();
  };

  return (
    <>
      <Stack direction="row" justifyContent="center">
        <AppCard sx={{ padding: "1rem" }}>
          <form onSubmit={props.formik.handleSubmit}>
            <Stack spacing={2}>
              <Typography variant="button" display="block" gutterBottom>
                Login
              </Typography>
              <TextField
                id="email"
                name="email"
                label="Email"
                variant="outlined"
                value={props.formik.values.email}
                onChange={props.formik.handleChange}
                error={
                  props.formik.touched.email &&
                  Boolean(props.formik.errors.email)
                }
                helperText={
                  props.formik.touched.email && props.formik.errors.email
                }
              />
              <FormControl sx={{ m: 1 }} variant="outlined">
                <InputLabel htmlFor="outlined-adornment-password">
                  Password
                </InputLabel>
                <OutlinedInput
                  id="password"
                  name="password"
                  type={showPassword.showPassword ? "text" : "password"}
                  value={props.formik.values.password}
                  onChange={props.formik.handleChange}
                  error={
                    props.formik.touched.password &&
                    Boolean(props.formik.errors.password)
                  }
                  endAdornment={
                    <InputAdornment position="end">
                      <IconButton
                        aria-label="toggle password visibility"
                        onClick={handleClickShowPassword}
                        onMouseDown={handleMouseDownPassword}
                        edge="end"
                      >
                        {showPassword.showPassword ? (
                          <VisibilityOff />
                        ) : (
                          <Visibility />
                        )}
                      </IconButton>
                    </InputAdornment>
                  }
                  label="Password"
                />
                <FormHelperText>
                  {props.formik.touched.password &&
                    props.formik.errors.password}
                </FormHelperText>
              </FormControl>
              <Stack direction="row" justifyContent="flex-end">
                <Link sx={{ fontSize: "12px" }} href="forgot-password">
                  Forgot password ?
                </Link>
              </Stack>
              {true ? (
                <Button type="submit" variant="contained">
                  Login
                </Button>
              ) : (
                <Stack alignItems="center" justifyContent="center">
                  <CircularProgress />
                </Stack>
              )}
              <Stack direction="row" justifyContent="center">
                <Link sx={{ fontSize: "12px" }} href="signup">
                  Doesn't have an Account ? Signup here
                </Link>
              </Stack>
            </Stack>
          </form>
        </AppCard>
      </Stack>
    </>
  );
};

export default LoginForm;
