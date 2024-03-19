import { Button, Divider, Grid, Paper, Stack, Typography } from "@mui/material";

const ViewJobInfo = () => {
  return (
    <Grid container spacing={0.8}>
      <Grid item md={7}>
        <Grid container spacing={0.8}>
          <Grid item md={12} xs={12}>
            <Paper variant="outlined" square>
              <Stack>
                <Stack
                  sx={{ padding: "0.6rem" }}
                  flexDirection="row"
                  justifyContent="space-between"
                >
                  <Stack flexDirection="row" alignItems="center">
                    <Typography variant="h6">Job Details</Typography>
                  </Stack>
                  <Button variant="text">Edit</Button>
                </Stack>
                <Divider />
                <Grid sx={{ padding: "1rem" }} container spacing={0.8}>
                  <Grid item md={6} xs={12}>
                    <Stack>
                      <Typography variant="subtitle2">FIRST NAME</Typography>
                      <Typography variant="body2">Rajesh</Typography>
                    </Stack>
                  </Grid>
                  <Grid item md={6} xs={12}>
                    <Stack>
                      <Typography variant="subtitle2">MIDDLE NAME</Typography>
                      <Typography variant="body2">-Not set-</Typography>
                    </Stack>
                  </Grid>
                  <Grid item md={6} xs={12}>
                    <Stack>
                      <Typography variant="subtitle2">LAST NAME</Typography>
                      <Typography variant="body2">Donepudi</Typography>
                    </Stack>
                  </Grid>
                  <Grid item md={6} xs={12}>
                    <Stack>
                      <Typography variant="subtitle2">DISPLAY NAME</Typography>
                      <Typography variant="body2">Rajesh Donepudi</Typography>
                    </Stack>
                  </Grid>
                  <Grid item md={6} xs={12}>
                    <Stack>
                      <Typography variant="subtitle2">Gender</Typography>
                      <Typography variant="body2">Male</Typography>
                    </Stack>
                  </Grid>
                  <Grid item md={6} xs={12}>
                    <Stack>
                      <Typography variant="subtitle2">DATE OF BIRTH</Typography>
                      <Typography variant="body2">16 Mar 1998</Typography>
                    </Stack>
                  </Grid>
                  <Grid item md={6} xs={12}>
                    <Stack>
                      <Typography variant="subtitle2">
                        MARITAL STATUS
                      </Typography>
                      <Typography variant="body2">Single</Typography>
                    </Stack>
                  </Grid>
                  <Grid item md={6} xs={12}>
                    <Stack>
                      <Typography variant="subtitle2">BLOOD GROUP</Typography>
                      <Typography variant="body2">B+ (B Positive)</Typography>
                    </Stack>
                  </Grid>
                  <Grid item md={6} xs={12}>
                    <Stack>
                      <Typography variant="subtitle2">
                        PHYSICALLY CHALLENGED
                      </Typography>
                      <Typography variant="body2">No</Typography>
                    </Stack>
                  </Grid>
                </Grid>
              </Stack>
            </Paper>
          </Grid>
          <Grid item md={12} xs={12}>
            <Paper variant="outlined" square>
              <Stack>
                <Stack
                  sx={{ padding: "0.6rem" }}
                  flexDirection="row"
                  justifyContent="space-between"
                >
                  <Stack flexDirection="row" alignItems="center">
                    <Typography variant="h6">Employee Time</Typography>
                  </Stack>
                  <Button variant="text">Edit</Button>
                </Stack>
                <Divider />
                <Grid sx={{ padding: "1rem" }} container spacing={0.8}>
                  <Grid item md={6} xs={12}>
                    <Stack>
                      <Typography variant="subtitle2">FIRST NAME</Typography>
                      <Typography variant="body2">Rajesh</Typography>
                    </Stack>
                  </Grid>
                  <Grid item md={6} xs={12}>
                    <Stack>
                      <Typography variant="subtitle2">MIDDLE NAME</Typography>
                      <Typography variant="body2">-Not set-</Typography>
                    </Stack>
                  </Grid>
                  <Grid item md={6} xs={12}>
                    <Stack>
                      <Typography variant="subtitle2">LAST NAME</Typography>
                      <Typography variant="body2">Donepudi</Typography>
                    </Stack>
                  </Grid>
                  <Grid item md={6} xs={12}>
                    <Stack>
                      <Typography variant="subtitle2">DISPLAY NAME</Typography>
                      <Typography variant="body2">Rajesh Donepudi</Typography>
                    </Stack>
                  </Grid>
                  <Grid item md={6} xs={12}>
                    <Stack>
                      <Typography variant="subtitle2">Gender</Typography>
                      <Typography variant="body2">Male</Typography>
                    </Stack>
                  </Grid>
                  <Grid item md={6} xs={12}>
                    <Stack>
                      <Typography variant="subtitle2">DATE OF BIRTH</Typography>
                      <Typography variant="body2">16 Mar 1998</Typography>
                    </Stack>
                  </Grid>
                  <Grid item md={6} xs={12}>
                    <Stack>
                      <Typography variant="subtitle2">
                        MARITAL STATUS
                      </Typography>
                      <Typography variant="body2">Single</Typography>
                    </Stack>
                  </Grid>
                  <Grid item md={6} xs={12}>
                    <Stack>
                      <Typography variant="subtitle2">BLOOD GROUP</Typography>
                      <Typography variant="body2">B+ (B Positive)</Typography>
                    </Stack>
                  </Grid>
                  <Grid item md={6} xs={12}>
                    <Stack>
                      <Typography variant="subtitle2">
                        PHYSICALLY CHALLENGED
                      </Typography>
                      <Typography variant="body2">No</Typography>
                    </Stack>
                  </Grid>
                </Grid>
              </Stack>
            </Paper>
          </Grid>
        </Grid>
      </Grid>
      <Grid item md={3}>
        <Grid item md={12} xs={12}>
          <Paper variant="outlined" square>
            <Stack>
              <Stack
                sx={{ padding: "0.6rem" }}
                flexDirection="row"
                justifyContent="space-between"
              >
                <Stack flexDirection="row" alignItems="center">
                  <Typography variant="h6">Organization</Typography>
                </Stack>
                <Button variant="text">Edit</Button>
              </Stack>
              <Divider />
              <Grid sx={{ padding: "1rem" }} container spacing={0.8}>
                <Grid item md={6} xs={12}>
                  <Stack>
                    <Typography variant="subtitle2">FIRST NAME</Typography>
                    <Typography variant="body2">Rajesh</Typography>
                  </Stack>
                </Grid>
                <Grid item md={6} xs={12}>
                  <Stack>
                    <Typography variant="subtitle2">MIDDLE NAME</Typography>
                    <Typography variant="body2">-Not set-</Typography>
                  </Stack>
                </Grid>
                <Grid item md={6} xs={12}>
                  <Stack>
                    <Typography variant="subtitle2">LAST NAME</Typography>
                    <Typography variant="body2">Donepudi</Typography>
                  </Stack>
                </Grid>
                <Grid item md={6} xs={12}>
                  <Stack>
                    <Typography variant="subtitle2">DISPLAY NAME</Typography>
                    <Typography variant="body2">Rajesh Donepudi</Typography>
                  </Stack>
                </Grid>
                <Grid item md={6} xs={12}>
                  <Stack>
                    <Typography variant="subtitle2">Gender</Typography>
                    <Typography variant="body2">Male</Typography>
                  </Stack>
                </Grid>
                <Grid item md={6} xs={12}>
                  <Stack>
                    <Typography variant="subtitle2">DATE OF BIRTH</Typography>
                    <Typography variant="body2">16 Mar 1998</Typography>
                  </Stack>
                </Grid>
                <Grid item md={6} xs={12}>
                  <Stack>
                    <Typography variant="subtitle2">MARITAL STATUS</Typography>
                    <Typography variant="body2">Single</Typography>
                  </Stack>
                </Grid>
                <Grid item md={6} xs={12}>
                  <Stack>
                    <Typography variant="subtitle2">BLOOD GROUP</Typography>
                    <Typography variant="body2">B+ (B Positive)</Typography>
                  </Stack>
                </Grid>
                <Grid item md={6} xs={12}>
                  <Stack>
                    <Typography variant="subtitle2">
                      PHYSICALLY CHALLENGED
                    </Typography>
                    <Typography variant="body2">No</Typography>
                  </Stack>
                </Grid>
              </Grid>
            </Stack>
          </Paper>
        </Grid>
      </Grid>
    </Grid>
  );
};

export default ViewJobInfo;
