import {
  Box,
  Divider,
  Grid,
  Paper,
  Stack,
  Tab,
  Tabs,
  Typography,
} from "@mui/material";
import AppPaper from "../../ui-components/AppPaper";
import InfoOutlinedIcon from "@mui/icons-material/InfoOutlined";
import PersonOutlineOutlinedIcon from "@mui/icons-material/PersonOutlineOutlined";
import PeopleAltOutlinedIcon from "@mui/icons-material/PeopleAltOutlined";
import PolicyOutlinedIcon from "@mui/icons-material/PolicyOutlined";
import FingerprintOutlinedIcon from "@mui/icons-material/FingerprintOutlined";
import AppLiveClock from "@ui-components/AppLiveClock";
import AppTabPanel from "@ui-components/AppTabPanel";
import { useState } from "react";
const UserAttendanceInfo = () => {
  const [value, setValue] = useState(0);

  const handleChange = (event: React.SyntheticEvent, newValue: number) => {
    setValue(newValue);
  };
  const meIconStyle = {
    backgroundColor: "#fbc02d",
    borderRadius: "50%",
    padding: "0.3rem",
    color: "#fff",
  };

  const myTeamIconStyle = {
    backgroundColor: "#5d9ed3",
    borderRadius: "50%",
    padding: "0.3rem",
    color: "#fff",
  };

  const dotStyle = {
    backgroundColor: "#64c3d1",
    borderRadius: "50%",
    display: "flex",
    alignItems: "center",
    justifyContent: "center",
    width: "24px",
    fontSize: "10px",
    color: "#fff",
    height: "24px",
  };

  const normalDotStyle = {
    backgroundColor: "#FFF",
    borderRadius: "50%",
    display: "flex",
    alignItems: "center",
    justifyContent: "center",
    width: "24px",
    fontSize: "10px",
    height: "24px",
    border: "1px solid #dee2e6",
  };

  const disabledDotStyle = {
    backgroundColor: "#EBEEF2",
    borderRadius: "50%",
    display: "flex",
    alignItems: "center",
    justifyContent: "center",
    width: "24px",
    fontSize: "10px",
    height: "24px",
    border: "1px solid #dee2e6",
  };

  return (
    <Grid container spacing={0.8}>
      <Grid item md={4} xs={12} sm={12}>
        <Stack>
          <Typography variant="h6">Attendance Stats</Typography>
          <AppPaper>
            <Grid container spacing={0.8}>
              <Grid item md={12} xs={12} sm={12}>
                <Stack flexDirection="row" justifyContent="space-between">
                  <Typography variant="body2">Last Week</Typography>
                  <InfoOutlinedIcon />
                </Stack>
              </Grid>
              <Grid item md={12} xs={12} sm={12}>
                <Grid container spacing={0.8}>
                  <Grid item md={4} sm={12} xs={12}>
                    <Stack flexDirection="row" gap={1}>
                      <PersonOutlineOutlinedIcon style={meIconStyle} />
                      <Typography variant="body1">Me</Typography>
                    </Stack>
                  </Grid>
                  <Grid item md={4} sm={12} xs={12}>
                    <Stack flexDirection="column">
                      <Typography variant="subtitle2">AVG HRS / DAY</Typography>
                      <Typography variant="body1">5h 42m</Typography>
                    </Stack>
                  </Grid>
                  <Grid item md={4} sm={12} xs={12}>
                    <Stack flexDirection="column">
                      <Typography variant="subtitle2">
                        ON TIME ARRIVAL
                      </Typography>
                      <Typography variant="body1">100%</Typography>
                    </Stack>
                  </Grid>
                </Grid>
              </Grid>
              <Grid item md={12} xs={12} sm={12}>
                <Divider />
              </Grid>
              <Grid item md={12} xs={12} sm={12}>
                <Grid container spacing={0.8}>
                  <Grid item md={4} sm={12} xs={12}>
                    <Stack flexDirection="row" gap={1}>
                      <PeopleAltOutlinedIcon style={myTeamIconStyle} />
                      <Typography variant="body1">My Team</Typography>
                    </Stack>
                  </Grid>
                  <Grid item md={4} sm={12} xs={12}>
                    <Stack flexDirection="column">
                      <Typography variant="subtitle2">AVG HRS / DAY</Typography>
                      <Typography variant="body1">5h 42m</Typography>
                    </Stack>
                  </Grid>
                  <Grid item md={4} sm={12} xs={12}>
                    <Stack flexDirection="column">
                      <Typography variant="subtitle2">
                        ON TIME ARRIVAL
                      </Typography>
                      <Typography variant="body1">100%</Typography>
                    </Stack>
                  </Grid>
                </Grid>
              </Grid>
            </Grid>
          </AppPaper>
        </Stack>
      </Grid>
      <Grid item md={4} xs={12} sm={12}>
        <Stack height={"100%"}>
          <Typography variant="h6">Timings</Typography>
          <AppPaper>
            <Grid container spacing={0.8} height={"100%"}>
              <Grid item md={12} xs={12} sm={12}>
                <Grid container spacing={0.8}>
                  <Grid item md={8} xs={12} sm={12}>
                    <Grid container spacing={0.8}>
                      <Grid item md={1}>
                        <Typography style={normalDotStyle}>M</Typography>
                      </Grid>
                      <Grid item md={1}>
                        <Typography style={normalDotStyle}>T</Typography>
                      </Grid>
                      <Grid item md={1}>
                        <Typography style={normalDotStyle}>W</Typography>
                      </Grid>
                      <Grid item md={1}>
                        <Typography style={dotStyle}>T</Typography>
                      </Grid>
                      <Grid item md={1}>
                        <Typography style={normalDotStyle}>F</Typography>
                      </Grid>
                      <Grid item md={1}>
                        <Typography style={disabledDotStyle}>S</Typography>
                      </Grid>
                      <Grid item md={1}>
                        <Typography style={disabledDotStyle}>S</Typography>
                      </Grid>
                    </Grid>
                  </Grid>
                  <Grid item md={4}>
                    <Grid container justifyContent={"flex-end"}>
                      <Grid md={2} item>
                        <PolicyOutlinedIcon />
                      </Grid>
                      <Grid md={2} item>
                        <FingerprintOutlinedIcon />
                      </Grid>
                    </Grid>
                  </Grid>
                </Grid>
              </Grid>
              <Grid item md={12} xs={12} sm={12}></Grid>
              <Grid item md={12} xs={12} sm={12} alignSelf="flex-end">
                <Typography variant="caption">
                  Today (Flexible Timings)
                </Typography>
                <Stack flexDirection="row">
                  <Box
                    sx={{
                      height: "10px",
                      width: "100%",
                      background: "#64c3d1",
                    }}
                  ></Box>
                  <Box
                    sx={{
                      height: "10px",
                      width: "30%",
                      background: "rgba(100,195,209,.2)",
                    }}
                  ></Box>
                  <Box
                    sx={{
                      height: "10px",
                      width: "100%",
                      background: "#64c3d1",
                    }}
                  ></Box>
                </Stack>
                <Stack flexDirection="row" justifyContent="space-between">
                  <Typography variant="caption">Duration: 23h 59m</Typography>
                  <Typography variant="caption">Break: 30 Min</Typography>
                </Stack>
              </Grid>
            </Grid>
          </AppPaper>
        </Stack>
      </Grid>
      <Grid item md={4} xs={12} sm={12}>
        <Stack height={"100%"}>
          <Typography variant="h6">Actions</Typography>
          <AppPaper>
            <Grid container spacing={0.8} height={"100%"}>
              <Grid item md={4} xs={12} sm={12}>
                <Stack>
                  <AppPaper>
                    <AppLiveClock />
                  </AppPaper>
                  <Typography variant="caption">Thu 01, Jun 2023</Typography>
                </Stack>
              </Grid>
              <Grid item md={8} xs={12} sm={12}>
                <Stack gap={0.8}>
                  <Typography variant="caption">Forgot ID Card</Typography>
                  <Typography variant="caption">Work From Home</Typography>
                  <Typography variant="caption">On Duty</Typography>
                  <Typography variant="caption">Partial Day</Typography>
                </Stack>
              </Grid>
            </Grid>
          </AppPaper>
        </Stack>
      </Grid>
      <Grid item md={12}>
        <Stack>
          <Typography variant="h6">Logs & Requests</Typography>
          <AppPaper>
            <Tabs
              value={value}
              onChange={handleChange}
              variant="scrollable"
              scrollButtons="auto"
              aria-label="scrollable auto tabs example"
            >
              <Tab label="Attendance Log" />
              <Tab label="Shift Schedule" />
              <Tab label="Attendance Requests" />
            </Tabs>
          </AppPaper>
        </Stack>
      </Grid>
      <Grid item md={12}>
        <AppTabPanel value={value} index={0}>
          Attendance Log
        </AppTabPanel>
        <AppTabPanel value={value} index={1}>
          Shift Schedule
        </AppTabPanel>
        <AppTabPanel value={value} index={2}>
          Attendance Requests
        </AppTabPanel>
      </Grid>
    </Grid>
  );
};

export default UserAttendanceInfo;
