import { Box, Grid, Tab, Tabs } from "@mui/material";
import { useState } from "react";
import AppCard from "@ui-components/AppCard";
import AppTabPanel from "@ui-components/AppTabPanel";
import MySalary from "./MySalary";
import PaySlips from "./PaySlips";
import IncomeTax from "./IncomeTax";
import FlexibleBenefitPlan from "./FlexibleBenefitPlan";

const MyPay = () => {
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
            <Tab label="My Salary" />
            <Tab label="Pay Slips" />
            <Tab label="Income Tax" />
            <Tab label="Flexible Benefit Plan (FBP)" />
          </Tabs>
        </Box>
      </Grid>
      <Grid item md={12} xs={12}>
        <AppCard>
          <AppTabPanel value={value} index={0}>
            <MySalary />
          </AppTabPanel>
          <AppTabPanel value={value} index={1}>
            <PaySlips />
          </AppTabPanel>
          <AppTabPanel value={value} index={2}>
            <IncomeTax />
          </AppTabPanel>
          <AppTabPanel value={value} index={3}>
            <FlexibleBenefitPlan />
          </AppTabPanel>
        </AppCard>
      </Grid>
    </Grid>
  );
};

export default MyPay;
