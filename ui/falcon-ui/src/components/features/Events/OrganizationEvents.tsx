import Typography from "@mui/material/Typography";
import { useState } from "react";
import { Box } from "@mui/system";
import Tab from "@mui/material/Tab";
import Tabs from "@mui/material/Tabs";
import { Avatar, Grid, Stack } from "@mui/material";
import CelebrationOutlinedIcon from "@mui/icons-material/CelebrationOutlined";
import CakeOutlinedIcon from "@mui/icons-material/CakeOutlined";
import PeopleOutlineOutlinedIcon from "@mui/icons-material/PeopleOutlineOutlined";
import AppCard from "@ui-components/AppCard";

const OrganizationEvents = () => {
  const [value, setValue] = useState(0);
  const handleChange = (event: any, newValue: any) => {
    setValue(newValue);
  };
  return (
    <>
      <AppCard>
        <Typography variant="body2">TODAY</Typography>
        <Box sx={{ width: "100%" }}>
          <Box sx={{ borderBottom: 1, borderColor: "divider" }}>
            <Tabs
              value={value}
              onChange={handleChange}
              variant="scrollable"
              scrollButtons="auto"
              aria-label="scrollable auto tabs example"
            >
              <Tab
                icon={<CakeOutlinedIcon />}
                iconPosition="start"
                label="Birthdays"
                {...a11yProps(0)}
              />
              <Tab
                icon={<CelebrationOutlinedIcon />}
                iconPosition="start"
                label="Work Anniversaries"
                {...a11yProps(1)}
              />
              <Tab
                icon={<PeopleOutlineOutlinedIcon />}
                iconPosition="start"
                label="New joinees"
                {...a11yProps(2)}
              />
            </Tabs>
          </Box>
          <TabPanel value={value} index={0}>
            <Grid container spacing={5}>
              <Grid item md={12}>
                <Stack gap={2}>
                  <Typography variant="body2">Birthdays Today</Typography>
                  <Stack direction="row" gap={2} flexWrap="wrap">
                    {[...Array(2).keys()].map((index: number) => (
                      <Stack alignItems="center">
                        <Avatar
                          alt="Remy Sharp"
                          src={`https://xsgames.co/randomusers/assets/avatars/male/${
                            index + 8
                          }.jpg`}
                        />
                        <Typography variant="caption">
                          Rajesh Donepudi{index}
                        </Typography>
                        <Typography sx={{ color: "grey" }} variant="caption">
                          Tomorrow
                        </Typography>
                      </Stack>
                    ))}
                  </Stack>
                </Stack>
              </Grid>
              <Grid item md={12}>
                <Stack gap={2}>
                  <Typography variant="body2">Next 7 Days</Typography>
                  <Stack direction="row" gap={2} flexWrap="wrap">
                    {[...Array(5).keys()].map((index: number) => (
                      <Stack alignItems="center">
                        <Avatar
                          alt="Remy Sharp"
                          src={`https://xsgames.co/randomusers/assets/avatars/male/${
                            index + 8
                          }.jpg`}
                        />
                        <Typography variant="caption">
                          Rajesh Donepudi{index}
                        </Typography>
                        <Typography sx={{ color: "grey" }} variant="caption">
                          Tomorrow
                        </Typography>
                      </Stack>
                    ))}
                  </Stack>
                </Stack>
              </Grid>
            </Grid>
          </TabPanel>
          <TabPanel value={value} index={1}>
            <Grid container spacing={5}>
              <Grid item md={12}>
                <Stack gap={2}>
                  <Typography variant="body2">
                    Work Anniversaries Today
                  </Typography>
                  <Stack direction="row" gap={2} flexWrap="wrap">
                    {[...Array(2).keys()].map((index: number) => (
                      <Stack alignItems="center">
                        <Avatar
                          alt="Remy Sharp"
                          src={`https://xsgames.co/randomusers/assets/avatars/male/${
                            index + 8
                          }.jpg`}
                        />
                        <Typography variant="caption">
                          Rajesh Donepudi{index}
                        </Typography>
                        <Typography sx={{ color: "grey" }} variant="caption">
                          Tomorrow
                        </Typography>
                      </Stack>
                    ))}
                  </Stack>
                </Stack>
              </Grid>
              <Grid item md={12}>
                <Stack gap={2}>
                  <Typography variant="body2">Next 30 Days</Typography>
                  <Stack direction="row" gap={2} flexWrap="wrap">
                    {[...Array(8).keys()].map((index: number) => (
                      <Stack alignItems="center">
                        <Avatar
                          alt="Remy Sharp"
                          src={`https://xsgames.co/randomusers/assets/avatars/male/${
                            index + 8
                          }.jpg`}
                        />
                        <Typography noWrap variant="caption">
                          Rajesh Donepudi{index}
                        </Typography>
                        <Typography sx={{ color: "grey" }} variant="caption">
                          Tomorrow
                        </Typography>
                      </Stack>
                    ))}
                  </Stack>
                </Stack>
              </Grid>
            </Grid>
          </TabPanel>
          <TabPanel value={value} index={2}>
            <Grid container spacing={5}>
              <Grid item md={12}>
                <Stack gap={2}>
                  <Typography variant="body2">New Joinees Today</Typography>
                  <Stack direction="row" gap={2} flexWrap="wrap">
                    {[...Array(2).keys()].map((index: number) => (
                      <Stack alignItems="center">
                        <Avatar
                          alt="Remy Sharp"
                          src={`https://xsgames.co/randomusers/assets/avatars/male/${
                            index + 8
                          }.jpg`}
                        />
                        <Typography variant="caption">
                          Rajesh Donepudi{index}
                        </Typography>
                        <Typography sx={{ color: "grey" }} variant="caption">
                          Tomorrow
                        </Typography>
                      </Stack>
                    ))}
                  </Stack>
                </Stack>
              </Grid>
              <Grid item md={12}>
                <Stack gap={2}>
                  <Typography variant="body2">Last 7 Days</Typography>
                  <Stack direction="row" gap={2} flexWrap="wrap">
                    {[...Array(5).keys()].map((index: number) => (
                      <Stack alignItems="center">
                        <Avatar
                          alt="Remy Sharp"
                          src={`https://xsgames.co/randomusers/assets/avatars/male/${
                            index + 8
                          }.jpg`}
                        />
                        <Typography variant="caption">
                          Rajesh Donepudi{index}
                        </Typography>
                        <Typography sx={{ color: "grey" }} variant="caption">
                          Tomorrow
                        </Typography>
                      </Stack>
                    ))}
                  </Stack>
                </Stack>
              </Grid>
            </Grid>
          </TabPanel>
        </Box>
      </AppCard>
    </>
  );
};

function a11yProps(index: any) {
  return {
    id: `simple-tab-${index}`,
    "aria-controls": `simple-tabpanel-${index}`,
  };
}

function TabPanel(props: any) {
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
}

export default OrganizationEvents;
