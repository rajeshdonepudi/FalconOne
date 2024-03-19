import { Box, Grid, Tab, Tabs } from "@mui/material";
import { useState } from "react";
import UserAttendanceInfo from "@feature-components/Attendance/UserAttendanceInfo";
import LeaveSummary from "@feature-components/Leaves/LeaveSummary";
import AppCard from "@ui-components/AppCard";
import AppTabPanel from "@ui-components/AppTabPanel";

const UserInfo = () => {
  const [value, setValue] = useState(0);

  const handleChange = (event: React.SyntheticEvent, newValue: number) => {
    setValue(newValue);
  };

  return (
    <Grid container>
      <Grid item md={12} xs={12}>
        <Box>
          <Tabs
            value={value}
            onChange={handleChange}
            variant="scrollable"
            scrollButtons="auto"
            aria-label="scrollable auto tabs example"
          >
            <Tab label="Leave" />
            <Tab label="Attendance" />
            <Tab label="Performance" />
            <Tab label="Expenses & Travel" />
            <Tab label="Apps" />
          </Tabs>
        </Box>
      </Grid>
      <Grid item md={12} xs={12}>
        <AppCard>
          <AppTabPanel value={value} index={0}>
            <LeaveSummary />
          </AppTabPanel>
          <AppTabPanel value={value} index={1}>
            <UserAttendanceInfo />
          </AppTabPanel>
          <AppTabPanel value={value} index={2}>
            Leave Summary
          </AppTabPanel>
          <AppTabPanel value={value} index={3}>
            Leave Summary
          </AppTabPanel>
          <AppTabPanel value={value} index={4}>
            Leave Summary
          </AppTabPanel>
        </AppCard>
      </Grid>
    </Grid>
  );
};

export default UserInfo;
