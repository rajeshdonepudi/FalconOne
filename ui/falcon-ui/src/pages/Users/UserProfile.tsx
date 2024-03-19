import BadgeOutlinedIcon from "@mui/icons-material/BadgeOutlined";
import KeyboardArrowDownIcon from "@mui/icons-material/KeyboardArrowDown";
import LocalPhoneOutlinedIcon from "@mui/icons-material/LocalPhoneOutlined";
import MailOutlinedIcon from "@mui/icons-material/MailOutlined";
import PlaceOutlinedIcon from "@mui/icons-material/PlaceOutlined";
import {
  Box,
  Button,
  Divider,
  Grid,
  Menu,
  MenuItem,
  MenuProps,
  Stack,
  Tab,
  Tabs,
  Typography,
  alpha,
  styled,
} from "@mui/material";
import React from "react";
import About from "@feature-components/Profile/About";
import ViewAssets from "@feature-components/Profile/ViewAssets";
import ViewDocuments from "@feature-components/Profile/ViewDocuments";
import ViewJobInfo from "@feature-components/Profile/ViewJobInfo";
import ViewProfile from "@feature-components/Profile/ViewProfile";
import AppCard from "@ui-components/AppCard";
import AppTabPanel from "@ui-components/AppTabPanel";

const StyledMenu = styled((props: MenuProps) => (
  <Menu
    elevation={0}
    anchorOrigin={{
      vertical: "bottom",
      horizontal: "right",
    }}
    transformOrigin={{
      vertical: "top",
      horizontal: "right",
    }}
    {...props}
  />
))(({ theme }) => ({
  "& .MuiPaper-root": {
    borderRadius: 6,
    marginTop: theme.spacing(1),
    minWidth: 180,
    color:
      theme.palette.mode === "light"
        ? "rgb(55, 65, 81)"
        : theme.palette.grey[300],
    boxShadow:
      "rgb(255, 255, 255) 0px 0px 0px 0px, rgba(0, 0, 0, 0.05) 0px 0px 0px 1px, rgba(0, 0, 0, 0.1) 0px 10px 15px -3px, rgba(0, 0, 0, 0.05) 0px 4px 6px -2px",
    "& .MuiMenu-list": {
      padding: "4px 0",
    },
    "& .MuiMenuItem-root": {
      "& .MuiSvgIcon-root": {
        fontSize: 18,
        color: theme.palette.text.secondary,
        marginRight: theme.spacing(1.5),
      },
      "&:active": {
        backgroundColor: alpha(
          theme.palette.primary.main,
          theme.palette.action.selectedOpacity
        ),
      },
    },
  },
}));

interface TabPanelProps {
  children?: React.ReactNode;
  index: number;
  value: number;
}

const UserProfile = () => {
  const [anchorEl, setAnchorEl] = React.useState<null | HTMLElement>(null);
  const open = Boolean(anchorEl);
  const handleClick = (event: React.MouseEvent<HTMLElement>) => {
    setAnchorEl(event.currentTarget);
  };
  const handleClose = () => {
    setAnchorEl(null);
  };

  const [value, setValue] = React.useState(0);
  const [value2, setValue2] = React.useState(0);

  const handleChange = (event: React.SyntheticEvent, newValue: number) => {
    setValue(newValue);
  };

  const handleChange2 = (event: React.SyntheticEvent, newValue: number) => {
    setValue2(newValue);
  };

  const TabPanel = (props: TabPanelProps) => {
    const { children, value, index, ...other } = props;

    return (
      <div
        role="tabpanel"
        hidden={value !== index}
        id={`simple-tabpanel-${index}`}
        aria-labelledby={`simple-tab-${index}`}
        {...other}
      >
        {value === index && (
          <Box sx={{ p: 3 }}>
            <Typography>{children}</Typography>
          </Box>
        )}
      </div>
    );
  };

  return (
    <Grid container spacing={0.8}>
      <Grid item md={12} xs={12}>
        <Grid container spacing={0.8}>
          <Grid item md={2} xs={12}>
            <AppCard>
              <Stack
                height={"100%"}
                justifyContent="center"
                alignItems="center"
              >
                <Typography variant="h1" component="h1">
                  RD
                </Typography>
              </Stack>
            </AppCard>
          </Grid>
          <Grid item md={10} xs={12}>
            <AppCard>
              <Stack gap={0.9}>
                <Typography variant="h6" component="h6">
                  Rajesh Donepudi
                </Typography>
                <Grid container>
                  <Grid item md={3} xs={12}>
                    <Stack flexDirection="row" alignItems="center" gap={0.2}>
                      <PlaceOutlinedIcon />
                      <Typography variant="body2">Rajesh SEZ</Typography>
                    </Stack>
                  </Grid>
                  <Grid item md={3} xs={12}>
                    <Stack flexDirection="row" alignItems="center" gap={0.2}>
                      <MailOutlinedIcon />
                      <Typography variant="body2">
                        rajeshdnp.tech@gmail.com
                      </Typography>
                    </Stack>
                  </Grid>
                  <Grid item md={3} xs={12}>
                    <Stack flexDirection="row" alignItems="center" gap={0.2}>
                      <LocalPhoneOutlinedIcon />
                      <Typography variant="body2">8886014996</Typography>
                    </Stack>
                  </Grid>
                  <Grid item md={3} xs={12}>
                    <Stack flexDirection="row" alignItems="center" gap={0.2}>
                      <BadgeOutlinedIcon />
                      <Typography variant="body2">ID Card</Typography>
                    </Stack>
                  </Grid>
                </Grid>
                <Divider sx={{ margin: 1 }} />
                <Grid container>
                  <Grid item md={10} xs={12}>
                    <Grid container>
                      <Grid item md={2.4} xs={12}>
                        <Stack>
                          <Typography variant="subtitle2">JOB TITLE</Typography>
                          <Typography variant="body2">
                            Software Engineer
                          </Typography>
                        </Stack>
                      </Grid>
                      <Grid item md={2.4} xs={12}>
                        <Stack>
                          <Typography variant="subtitle2">
                            DEPARTMENT
                          </Typography>
                          <Typography variant="body2">.NET</Typography>
                        </Stack>
                      </Grid>
                      <Grid item md={2.4} xs={12}>
                        <Stack>
                          <Typography variant="subtitle2">
                            BUSINESS UNIT
                          </Typography>
                          <Typography variant="body2">RAJESH TECH</Typography>
                        </Stack>
                      </Grid>
                      <Grid item md={2.4} xs={12}>
                        <Stack>
                          <Typography variant="subtitle2">
                            REPORTING TO
                          </Typography>
                          <Typography variant="body2">RAJESH</Typography>
                        </Stack>
                      </Grid>
                      <Grid item md={2.4} xs={12}>
                        <Stack>
                          <Typography variant="subtitle2">EMP NO</Typography>
                          <Typography variant="body2">403</Typography>
                        </Stack>
                      </Grid>
                    </Grid>
                  </Grid>
                  <Grid item md={2} xs={12}>
                    <Button
                      id="demo-customized-button"
                      aria-controls={open ? "demo-customized-menu" : undefined}
                      aria-haspopup="true"
                      aria-expanded={open ? "true" : undefined}
                      variant="contained"
                      disableElevation
                      onClick={handleClick}
                      endIcon={<KeyboardArrowDownIcon />}
                    >
                      Actions
                    </Button>
                    <StyledMenu
                      id="demo-customized-menu"
                      MenuListProps={{
                        "aria-labelledby": "demo-customized-button",
                      }}
                      anchorEl={anchorEl}
                      open={open}
                      onClose={handleClose}
                    >
                      <MenuItem onClick={handleClose} disableRipple>
                        Resign
                      </MenuItem>
                    </StyledMenu>
                  </Grid>
                </Grid>
                <Divider />
                <Grid container>
                  <Grid item md={12} xs={12}>
                    <Tabs
                      value={value}
                      onChange={handleChange}
                      variant="scrollable"
                      scrollButtons="auto"
                      aria-label="scrollable auto tabs example"
                    >
                      <Tab label="About" />
                      <Tab label="Profile" />
                      <Tab label="Job" />
                      <Tab label="Documents" />
                      <Tab label="Assets" />
                    </Tabs>
                  </Grid>
                </Grid>
              </Stack>
            </AppCard>
          </Grid>
        </Grid>
      </Grid>
      <Grid item md={12}>
        <AppCard>
          <AppTabPanel value={value} index={0}>
            <About />
          </AppTabPanel>
          <AppTabPanel value={value} index={1}>
            <ViewProfile />
          </AppTabPanel>
          <AppTabPanel value={value} index={2}>
            <ViewJobInfo />
          </AppTabPanel>
          <AppTabPanel value={value} index={3}>
            <ViewDocuments />
          </AppTabPanel>
          <AppTabPanel value={value} index={4}>
            <ViewAssets />
          </AppTabPanel>
        </AppCard>
      </Grid>
    </Grid>
  );
};

export default UserProfile;
