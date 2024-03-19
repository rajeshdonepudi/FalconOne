import {
  Button,
  Grid,
  Paper,
  Stack,
  Tab,
  Tabs,
  Typography,
} from "@mui/material";
import AppTabPanel from "../../ui-components/AppTabPanel";
import { useState } from "react";
import AppPaper from "../../ui-components/AppPaper";

const About = () => {
  const [selectedTab, setSelectedTab] = useState(0);
  const handleTabChange = (event: React.SyntheticEvent, newValue: number) => {
    setSelectedTab(newValue);
  };
  return (
    <Grid container spacing={1}>
      <Grid item md={12} xs={12} sm={12}>
        <Tabs
          value={selectedTab}
          onChange={handleTabChange}
          variant="scrollable"
          scrollButtons="auto"
          aria-label="scrollable auto tabs example"
        >
          <Tab label="Summary" />
          <Tab label="Timeline" />
          <Tab label="Wall Activity" />
        </Tabs>
      </Grid>
      <Grid item md={12} xs={10} sm={12}>
        <AppTabPanel value={selectedTab} index={0}>
          <Grid container spacing={0.8}>
            <Grid item md={6} xs={12} sm={12}>
              <AppPaper>
                <Grid container>
                  <Grid item md={12} xs={12} sm={12}>
                    <Stack>
                      <Typography variant="h6">About</Typography>
                      <Button variant="outlined">Add your response</Button>
                    </Stack>
                  </Grid>
                  <Grid item md={12} xs={12} sm={12}>
                    <Stack>
                      <Typography variant="h6">
                        What i love about my job?
                      </Typography>
                      <Button variant="outlined">Add your response</Button>
                    </Stack>
                  </Grid>
                  <Grid item md={12} xs={12} sm={12}>
                    <Stack>
                      <Typography variant="h6">
                        My interests and hobbies?
                      </Typography>
                      <Button variant="outlined">Add your response</Button>
                    </Stack>
                  </Grid>
                </Grid>
              </AppPaper>
            </Grid>
            <Grid item md={6} xs={12} sm={12}>
              <Paper variant="outlined" square>
                <Grid container spacing={0.8} sx={{ padding: "1rem" }}>
                  <Grid item md={12} xs={12}>
                    <Stack gap={2}>
                      <Typography variant="h6">Primary Details</Typography>
                      <Grid container>
                        <Grid item xs={12} md={6}>
                          <Stack>
                            <Typography variant="subtitle2">
                              FIRST NAME
                            </Typography>
                            <Typography variant="body2">Rajesh</Typography>
                          </Stack>
                        </Grid>
                        <Grid item xs={12} md={6}>
                          <Stack>
                            <Typography variant="subtitle2">
                              LAST NAME
                            </Typography>
                            <Typography variant="body2">Donepudi</Typography>
                          </Stack>
                        </Grid>
                        <Grid item xs={12} md={6}>
                          <Stack>
                            <Typography variant="subtitle2">GENDER</Typography>
                            <Typography variant="body2">Male</Typography>
                          </Stack>
                        </Grid>
                        <Grid item xs={12} md={6}>
                          <Stack>
                            <Typography variant="subtitle2">
                              DATE OF BIRTH
                            </Typography>
                            <Typography variant="body2">16 Mar 1998</Typography>
                          </Stack>
                        </Grid>
                        <Grid item xs={12} md={6}>
                          <Stack>
                            <Typography variant="subtitle2">
                              MARITAL STATUS
                            </Typography>
                            <Typography variant="body2">Single</Typography>
                          </Stack>
                        </Grid>
                        <Grid item xs={12} md={6}>
                          <Stack>
                            <Typography variant="subtitle2">
                              BLOOD GROUP
                            </Typography>
                            <Typography variant="body2">
                              B+ (B positive)
                            </Typography>
                          </Stack>
                        </Grid>
                        <Grid item xs={12} md={6}>
                          <Stack>
                            <Typography variant="subtitle2">
                              PHYSICALLY CHALLENGED
                            </Typography>
                            <Typography variant="body2">No</Typography>
                          </Stack>
                        </Grid>
                      </Grid>
                    </Stack>
                  </Grid>
                  <Grid item md={12} xs={12}>
                    <Stack gap={2}>
                      <Typography variant="h6">Contact Details</Typography>
                      <Grid container>
                        <Grid item xs={12} md={6}>
                          <Stack flexWrap="wrap">
                            <Typography variant="subtitle2">
                              PERSONAL EMAIL
                            </Typography>
                            <Typography variant="body2">
                              rajeshdnp.tech@gmail.com
                            </Typography>
                          </Stack>
                        </Grid>
                        <Grid item xs={12} md={6}>
                          <Stack>
                            <Typography variant="subtitle2">
                              WHATSAPP NO
                            </Typography>
                            <Typography variant="body2">8886014996</Typography>
                          </Stack>
                        </Grid>
                      </Grid>
                    </Stack>
                  </Grid>
                  <Grid item md={12} xs={12}>
                    <Stack gap={2}>
                      <Typography variant="h6">Addresses</Typography>
                      <Grid container>
                        <Grid item xs={12} md={6}>
                          <Stack>
                            <Typography variant="subtitle2">
                              CURRENT ADDRESS
                            </Typography>
                            <Typography variant="body2">HYDERABAD</Typography>
                          </Stack>
                        </Grid>
                        <Grid item xs={12} md={6}>
                          <Stack>
                            <Typography variant="subtitle2">
                              PERMANENT ADDRESS
                            </Typography>
                            <Typography variant="body2">DONEPUDI</Typography>
                          </Stack>
                        </Grid>
                      </Grid>
                    </Stack>
                  </Grid>
                </Grid>
              </Paper>
            </Grid>
          </Grid>
        </AppTabPanel>
      </Grid>
    </Grid>
  );
};

export default About;
