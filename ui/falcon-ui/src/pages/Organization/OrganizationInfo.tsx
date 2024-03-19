import { Grid, Tab, Tabs } from "@mui/material";
import { useState } from "react";
import AppCard from "@ui-components/AppCard";
import AppTabPanel from "@ui-components/AppTabPanel";
import EmployeeInfoTab from "@feature-components/employees/EmployeeInfoTab";

const OrganizationInfo = () => {
  const [value, setValue] = useState(0);
  const handleChange = (event: React.SyntheticEvent, newValue: number) => {
    setValue(newValue);
  };
  return (
    <Grid container>
      <Grid item xs={12} md={12}>
        <Tabs
          value={value}
          onChange={handleChange}
          variant="scrollable"
          scrollButtons="auto"
          aria-label="scrollable auto tabs example"
        >
          <Tab label="EMPLOYEES" />
          <Tab label="DOCUMENTS" />
          <Tab label="ENGAGE" />
        </Tabs>
      </Grid>
      <Grid item md={12}>
        <AppCard>
          <AppTabPanel value={value} index={0}>
            <EmployeeInfoTab />
          </AppTabPanel>
          <AppTabPanel value={value} index={1}>
            Documents
          </AppTabPanel>
          <AppTabPanel value={value} index={2}>
            Engage
          </AppTabPanel>
        </AppCard>
      </Grid>
    </Grid>
  );
};

export default OrganizationInfo;
