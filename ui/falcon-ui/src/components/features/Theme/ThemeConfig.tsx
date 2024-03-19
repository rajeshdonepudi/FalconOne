import {
  Button,
  Divider,
  FormControl,
  FormHelperText,
  FormLabel,
  Grid,
  Radio,
  RadioGroup,
  Stack,
  TextField,
  Typography,
} from "@mui/material";
import AppCard from "../../ui-components/AppCard";
import FormControlLabel from "@mui/material/FormControlLabel";
import { useFormik } from "formik";
import AddThemeValidationScheme from "@/validation-schemes/Site-settings/AddThemeValidationScheme";
import { ApplicationSetting } from "@models/Settings/ApplicationSetting";
import {
  useLazyGetSettingsByTypeQuery,
  useUpdateSettingMutation,
} from "@services/Settings/SettingService";
import { SettingTypeEnum } from "../../../enumerations/SettingTypeEnum";
import { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { updateTheme } from "../../../store/Slices/themeSlice";
import ThemeUtilities from "../../../utilities/ThemeUtilities";

const ThemeConfig = () => {
  const [updateSettings] = useUpdateSettingMutation();
  const [getThemeSettings] = useLazyGetSettingsByTypeQuery();
  const data = useSelector((state: any) => state.theme.siteTheme);

  const dispatchTheme = useDispatch();

  const formik = useFormik({
    initialValues: {
      primaryColor: " ",
      secondaryColor: " ",
      theme: " ",
    },
    validationSchema: AddThemeValidationScheme,
    onSubmit: (payload) => {
      buildThemeSetting(payload);
    },
  });

  useEffect(() => {
    if (data) {
      formik.setValues({
        primaryColor: data?.primary,
        secondaryColor: data?.secondary,
        theme: data?.theme,
      });
    }
  }, []);

  const buildThemeSetting = async (config: any) => {
    const themeSettings: ApplicationSetting[] = [
      {
        name: "primaryColor",
        value: config.primaryColor,
        settingType: SettingTypeEnum.Theme,
      },
      {
        name: "secondaryColor",
        value: config.secondaryColor,
        settingType: SettingTypeEnum.Theme,
      },
      {
        name: "theme",
        value: config.theme,
        settingType: SettingTypeEnum.Theme,
      },
    ];
    updateSettings(themeSettings.filter((x) => x.value != null || undefined))
      .unwrap()
      .then(() => {
        getThemeSettings(SettingTypeEnum.Theme)
          .unwrap()
          .then((res) => {
            dispatchTheme(
              updateTheme({
                primary: ThemeUtilities.getTheme2(res.response)?.primaryColor,
                secondary: ThemeUtilities.getTheme2(res.response)
                  ?.secondaryColor,
                theme: ThemeUtilities.getTheme2(res.response)?.theme,
              })
            );
          });
      });
  };

  return (
    <Grid container spacing={0.8}>
      <Grid item md={2} xs={12} sm={12}>
        <AppCard>
          <Stack sx={{ width: "100%" }}>
            <TextField
              fullWidth
              id="outlined-basic"
              label="Site name"
              variant="outlined"
            />
          </Stack>
        </AppCard>
      </Grid>
      <Grid item md={2} xs={12} sm={12}>
        <form onSubmit={formik.handleSubmit}>
          <AppCard>
            <Stack gap={1}>
              <Stack>
                <Typography variant="subtitle2">Primary Color</Typography>
                <TextField
                  size="small"
                  type="color"
                  id="primaryColor"
                  name="primaryColor"
                  variant="outlined"
                  value={formik.values.primaryColor}
                  error={formik.touched.primaryColor}
                  helperText={
                    formik.touched.primaryColor && formik.errors.primaryColor
                  }
                  onChange={formik.handleChange}
                />
              </Stack>
              <Stack>
                <Typography variant="subtitle2">Secondary Color</Typography>
                <TextField
                  size="small"
                  type="color"
                  id="secondaryColor"
                  name="secondaryColor"
                  variant="outlined"
                  value={formik.values.secondaryColor}
                  helperText={
                    formik.touched.secondaryColor &&
                    formik.errors.secondaryColor
                  }
                  onChange={formik.handleChange}
                />
              </Stack>
              <Divider />
              <Stack>
                <FormControl>
                  <FormLabel id="demo-radio-buttons-group-label">
                    Theme
                  </FormLabel>
                  <RadioGroup
                    aria-labelledby="demo-radio-buttons-group-label"
                    defaultValue="light"
                    name="theme"
                    value={formik.values.theme ?? ""}
                    onChange={formik.handleChange}
                  >
                    <Stack>
                      <FormControlLabel
                        value="systemDefault"
                        control={<Radio />}
                        label="System default"
                      />
                      <FormHelperText>
                        {
                          "Turn on dark theme when your device's dark theme is on"
                        }
                      </FormHelperText>
                    </Stack>
                    <Divider />
                    <FormControlLabel
                      value="light"
                      control={<Radio />}
                      label="Light"
                    />
                    <FormControlLabel
                      value="dark"
                      control={<Radio />}
                      label="Dark"
                    />
                  </RadioGroup>
                </FormControl>
              </Stack>
              <Button type="submit" variant="contained">
                Save
              </Button>
            </Stack>
          </AppCard>
        </form>
      </Grid>
    </Grid>
  );
};

export default ThemeConfig;
