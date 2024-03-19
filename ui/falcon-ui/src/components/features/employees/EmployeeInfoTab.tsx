import { Grid, Tab, Tabs } from "@mui/material";
import AppTabPanel from "../../ui-components/AppTabPanel";
import { useState } from "react";
import EmployeeDirectory from "./EmployeeDirectory";

const EmployeeInfoTab = () => {
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
          <Tab label="EMPLOYEE DIRECTORY" />
          <Tab label="ORGANIZATION TREE" />
        </Tabs>
      </Grid>
      <Grid item md={12}>
        <AppTabPanel value={value} index={0}>
          <EmployeeDirectory />
        </AppTabPanel>
        <AppTabPanel value={value} index={1}>
          Documents
        </AppTabPanel>
      </Grid>
    </Grid>
  );
};

export default EmployeeInfoTab;
