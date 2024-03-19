import { Box, Button, ButtonGroup, Grid } from "@mui/material";
import Avatar from "@mui/material/Avatar";
import Divider from "@mui/material/Divider";
import List from "@mui/material/List";
import ListItem from "@mui/material/ListItem";
import ListItemAvatar from "@mui/material/ListItemAvatar";
import ListItemText from "@mui/material/ListItemText";
import Stack from "@mui/material/Stack";
import Typography from "@mui/material/Typography";
import moment from "moment";
import Test from "../../TestComponent/Test";
import OrganizationEvents from "@feature-components/Events/OrganizationEvents";
import HolidaysList from "@feature-components/Holidays/HolidaysList";
import LeaveBalance from "@feature-components/Leaves/LeaveBalanceSummary";
import LeaveToday from "@feature-components/Leaves/LeaveToday";
import WorkingRemotely from "@feature-components/Leaves/WorkingRemotely";
import NewPost from "@feature-components/Posts/NewPost";
import ClockIn from "@feature-components/time/ClockIn";
import AppCard from "@ui-components/AppCard";
import AppLiveClock from "@ui-components/AppLiveClock";

const Dashboard = () => {
  return (
    <Grid container spacing={0.8}>
      <Grid item lg={3} xs={12} md={3}>
        <Grid container spacing={0.8}>
          <Grid item xs={12} md={12}>
            <AppCard>
              <Stack className="clock-section">
                <Typography variant="subtitle2">TIME</Typography>
                <AppLiveClock />
              </Stack>
            </AppCard>
          </Grid>
          <Grid item xs={12} md={12}>
            <AppCard>
              <Stack className="clock-section">
                <Stack className="date-section">
                  <Typography variant="subtitle2">TODAY</Typography>
                  <Typography variant="body2">
                    {moment().format("ll")}
                  </Typography>
                </Stack>
              </Stack>
            </AppCard>
          </Grid>
          <Grid item xs={12} md={12}>
            <ClockIn />
          </Grid>
          <Grid item xs={12} md={12}>
            <LeaveBalance />
          </Grid>
          <Grid item xs={12} md={12}>
            <HolidaysList />
          </Grid>
          <Grid item xs={12} md={12}>
            <WorkingRemotely />
          </Grid>
          <Grid item xs={12} md={12}>
            <LeaveToday />
          </Grid>
        </Grid>
      </Grid>
      <Grid item lg={4} xs={12} md={4}>
        <Grid container spacing={0.8}>
          <Grid item xs={12} md={12}>
            <ButtonGroup fullWidth size="small" aria-label="small button group">
              <Button variant="contained" key="one">
                ORGANIZATION
              </Button>
              <Button key="two">.NET</Button>
            </ButtonGroup>
          </Grid>
          <Grid item xs={12} md={12}>
            <NewPost />
          </Grid>
          <Grid item xs={12} md={12}>
            <OrganizationEvents />
          </Grid>
          <Grid item xs={12} md={12}>
            <Grid container spacing={0.8}>
              {[...Array(1).keys()].map((i, index) => (
                <Grid item md={12} xs={12}>
                  <Test />
                </Grid>
              ))}
            </Grid>
            <Test />
          </Grid>
        </Grid>
      </Grid>
      <Grid item lg={4} xs={12} md={3}>
        <Grid container spacing={0.8}>
          <Grid item xs={12} md={12}>
            <AppCard>
              <Stack gap={1}>
                <Typography variant="body2">INBOX (30)</Typography>
                <Divider />
                <Box>
                  <List
                    sx={{
                      width: "100%",
                      height: "100%",
                      maxHeight: "380px",
                      overflowY: "auto",
                      bgcolor: "background.paper",
                    }}
                  >
                    {[...Array(30).keys()].map((index: number) => (
                      <>
                        <ListItem alignItems="flex-start">
                          <ListItemAvatar>
                            <Avatar
                              alt="Remy Sharp"
                              src="/static/images/avatar/1.jpg"
                            />
                          </ListItemAvatar>
                          <ListItemText
                            primary="Brunch this weekend?"
                            secondary={
                              <>
                                <Typography
                                  sx={{ display: "inline" }}
                                  component="span"
                                  variant="body2"
                                  color="text.primary"
                                >
                                  Ali Connors
                                </Typography>
                                {
                                  " — I'll be in your neighborhood doing errands this…"
                                }
                              </>
                            }
                          />
                        </ListItem>
                        {index !== 30 - 1 && (
                          <Divider variant="inset" component="li" />
                        )}
                      </>
                    ))}
                  </List>
                </Box>
              </Stack>
            </AppCard>
          </Grid>
        </Grid>
      </Grid>
    </Grid>
  );
};

export default Dashboard;
