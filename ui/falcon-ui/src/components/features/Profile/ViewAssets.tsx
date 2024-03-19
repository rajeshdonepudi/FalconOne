import {
  Box,
  Button,
  Grid,
  Paper,
  Stack,
  Tab,
  Tabs,
  Typography,
} from "@mui/material";
import AppTabPanel from "@ui-components/AppTabPanel";
import { useState } from "react";

const ViewAssets = () => {
  const [selectedTab, setSelectedTab] = useState(0);
  const handleTabChange = (event: React.SyntheticEvent, newValue: number) => {
    setSelectedTab(newValue);
  };
  return (
    <Grid container spacing={0.8}>
      <Grid item md={12} xs={12}>
        <Box>
          <Tabs
            value={selectedTab}
            onChange={handleTabChange}
            variant="scrollable"
            scrollButtons="auto"
            aria-label="scrollable auto tabs example"
          >
            <Tab label="Assigned assets" />
            <Tab label="Asset requests" />
          </Tabs>
        </Box>
      </Grid>
      <Grid item md={12} xs={12}>
        <AppTabPanel value={selectedTab} index={0}>
          <Grid container>
            <Grid item xs={12} md={12}>
              <Stack>
                <Stack>
                  <Typography variant="h6">Assigned Assets</Typography>
                  <Typography variant="caption">
                    Assets that are currently assigned to you.
                  </Typography>
                </Stack>
                <Grid container>
                  <Grid item xs={12} md={12}>
                    <Stack
                      alignItems="center"
                      justifyContent="center"
                      sx={{ height: "200px", padding: "1rem" }}
                    >
                      <lottie-player
                        src={
                          "https://assets8.lottiefiles.com/packages/lf20_lwnuxmxm.json"
                        }
                        background="transparent"
                        speed="1"
                        loop
                        autoplay
                      ></lottie-player>
                      <Stack alignItems="center">
                        <Typography variant="h6">
                          No Assets are present yet
                        </Typography>
                        <Typography variant="caption">
                          Your assets will be shown here once they have been
                          assigned to you.
                        </Typography>
                      </Stack>
                    </Stack>
                  </Grid>
                </Grid>
              </Stack>
            </Grid>
          </Grid>
        </AppTabPanel>
        <AppTabPanel value={selectedTab} index={1}>
          <Grid container>
            <Grid item xs={12} md={12}>
              <Stack>
                <Stack>
                  <Typography variant="h6">Asset requests</Typography>
                  <Typography variant="caption">
                    You can raise asset requests supported by your organization.
                  </Typography>
                </Stack>
                <Grid container>
                  <Grid item xs={12} md={12}>
                    <Stack
                      alignItems="center"
                      justifyContent="center"
                      sx={{ height: "200px", padding: "1rem" }}
                    >
                      <lottie-player
                        src={
                          "https://assets8.lottiefiles.com/packages/lf20_hnm1chvh.json"
                        }
                        background="transparent"
                        speed="1"
                        loop
                        autoplay
                      ></lottie-player>
                      <Stack alignItems="center">
                        <Typography variant="h6">
                          Looks like this feature is disabled.
                        </Typography>
                        <Typography variant="caption">
                          Get in touch with your HR.
                        </Typography>
                      </Stack>
                    </Stack>
                  </Grid>
                </Grid>
              </Stack>
            </Grid>
          </Grid>
        </AppTabPanel>
      </Grid>
    </Grid>
  );
};

export default ViewAssets;
