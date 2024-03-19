import {
  Box,
  CssBaseline,
  ThemeProvider,
  createTheme,
  responsiveFontSizes,
  useMediaQuery,
} from "@mui/material";
import { useEffect, useMemo, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { BrowserRouter } from "react-router-dom";
import { SettingTypeEnum } from "@/enumerations/SettingTypeEnum";
import { ApiResponse } from "@models/Common/ApiResponse";
import { ApplicationSetting } from "@models/Settings/ApplicationSetting";
import AppRoutes from "@/routes/AppRoutes";
import { updateTheme } from "@slices/themeSlice";
import ThemeUtilities from "./utilities/ThemeUtilities";
import { ToastContainer } from "react-toastify";
import { useLazyGetSettingsByTypeQuery } from "@services/Settings/SettingService";

const App = () => {
  const prefersDarkMode = useMediaQuery("(prefers-color-scheme: dark)");
  const prefersLightMode = useMediaQuery("(prefers-color-scheme: light)");
  const themeStore = useSelector((state: any) => state.theme.siteTheme);
  const dispatchTheme = useDispatch();

  const [getSiteTheme] = useLazyGetSettingsByTypeQuery();

  const primaryColor = themeStore?.primary;
  const secondaryColor = themeStore?.secondary;
  const theme = themeStore?.theme;

  const [siteThemeInfo, setSiteThemeInfo] = useState({
    primary: primaryColor,
    secondary: secondaryColor,
    theme: theme,
  });

  useEffect(() => {
    if (
      primaryColor === undefined ||
      secondaryColor === undefined ||
      theme === undefined
    ) {
      getSiteTheme(SettingTypeEnum.Theme)
        .unwrap()
        .then((res: ApiResponse<ApplicationSetting[]>) => {
          dispatchTheme(
            updateTheme({
              primary: ThemeUtilities.getTheme2(res.data)?.primaryColor,
              secondary: ThemeUtilities.getTheme2(res.data)?.secondaryColor,
              theme: ThemeUtilities.getTheme2(res.data)?.theme,
            })
          );
        });
    } else {
      setSiteThemeInfo({
        primary: primaryColor,
        secondary: secondaryColor,
        theme: theme,
      });
    }
  }, [themeStore]);

  const getColorPreference = () => {
    if (siteThemeInfo?.theme === "systemDefault") {
      if (prefersDarkMode) {
        return "dark";
      }
      if (prefersLightMode) {
        return "light";
      }
    } else {
      return siteThemeInfo?.theme;
    }
  };

  let systemTheme = useMemo(
    () =>
      createTheme({
        components: {
          MuiCssBaseline: {
            styleOverrides: (themeParam) => ({
              body:
                themeParam.palette.mode === "light" &&
                (themeParam.palette.background.default = "#f3f4f7"),
            }),
          },
          MuiTab: {
            styleOverrides: {
              root: {
                fontSize: "11px",
                fontWeight: "bold",
              },
            },
          },
          MuiButton: {
            styleOverrides: {
              root: {
                fontSize: "10px",
              },
            },
          },
          MuiInputLabel: {
            styleOverrides: {
              asterisk: {
                color: "red",
              },
            },
          },
        },
        typography: {
          fontFamily: "Work Sans, sans-serif",
          subtitle2: {
            textTransform: "uppercase",
            fontSize: "10px",
          },
          body2: {
            fontSize: "14px",
          },
        },
        palette: {
          mode: getColorPreference() as any,
          primary: { main: siteThemeInfo?.primary ?? "#393E46" },
          secondary: {
            main: siteThemeInfo?.secondary ?? "#00ADB5",
          },
        },
      }),
    [prefersDarkMode, siteThemeInfo]
  );

  return (
    <>
      <ThemeProvider theme={responsiveFontSizes(systemTheme)}>
        <CssBaseline />

        <Box
          sx={{
            width: "100vw",
            height: "100vh",
            padding: "1.5rem",
          }}
          className="root-container"
        >
          <BrowserRouter>
            <AppRoutes />
          </BrowserRouter>
        </Box>
      </ThemeProvider>
    </>
  );
};

export default App;
