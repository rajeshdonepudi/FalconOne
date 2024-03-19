import { Box, Grid, Tab, Tabs } from "@mui/material";
import AppCard from "../../components/ui-components/AppCard";
import AppTabPanel from "../../components/ui-components/AppTabPanel";
import FinanceSummary from "@feature-components/Finances/FinanceSummary";
import MyPay from "@feature-components/Finances/MyPay";
import ManageTax from "@feature-components/Finances/ManageTax";
import { useState } from "react";

const MyFinances = () => {
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
            <Tab label="Summary" />
            <Tab label="My Pay" />
            <Tab label="Manage Tax" />
          </Tabs>
        </Box>
      </Grid>
      <Grid item md={12} xs={12}>
        <AppCard>
          <AppTabPanel value={value} index={0}>
            <FinanceSummary />
          </AppTabPanel>
          <AppTabPanel value={value} index={1}>
            <MyPay />
          </AppTabPanel>
          <AppTabPanel value={value} index={2}>
            <ManageTax />
          </AppTabPanel>
        </AppCard>
      </Grid>
    </Grid>
  );
};

export default MyFinances;
