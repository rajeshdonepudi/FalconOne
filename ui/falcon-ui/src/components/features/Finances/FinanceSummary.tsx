import { Button, Divider, Grid, Stack, Typography } from "@mui/material";
import AppPaper from "@ui-components/AppPaper";

const FinanceSummary = () => {
  return (
    <Grid container spacing={0.8}>
      <Grid item md={12} xs={12} sm={12}>
        <AppPaper>
          <Grid container>
            <Grid item md={4} xs={12} sm={12}>
              <Stack
                sx={{ height: "100%" }}
                justifyContent="center"
                alignItems="center"
              >
                <Typography variant="h6">Payroll summary</Typography>
              </Stack>
            </Grid>
            <Grid item md={2} xs={12} sm={12}>
              <Stack>
                <Typography variant="subtitle2">
                  LAST PROCESSED CYCLE
                </Typography>
                <Typography variant="body2">
                  May 2023 (May 01 - May 31)
                </Typography>
              </Stack>
            </Grid>
            <Grid item md={2} xs={12} sm={12}>
              <Stack>
                <Typography variant="subtitle2">WORKING DAYS</Typography>
                <Typography variant="body2">31</Typography>
              </Stack>
            </Grid>
            <Grid item md={2} xs={12} sm={12}>
              <Stack>
                <Typography variant="subtitle2">LOSS OF PAY</Typography>
                <Typography variant="body2">0</Typography>
              </Stack>
            </Grid>
            <Grid item md={2} xs={12} sm={12}>
              <Stack>
                <Typography variant="subtitle2">PAYSLIP</Typography>
                <Typography variant="body2">View payslip</Typography>
              </Stack>
            </Grid>
          </Grid>
        </AppPaper>
      </Grid>
      <Grid item md={12} xs={12} sm={12}>
        <Grid container spacing={0.8}>
          <Grid item md={6} xs={12}>
            <AppPaper noPadding={true} variant="outlined" square>
              <Stack sx={{ width: "100%" }}>
                <Stack
                  sx={{ padding: "0.6rem" }}
                  flexDirection="row"
                  justifyContent="space-between"
                >
                  <Stack flexDirection="row" alignItems="center">
                    <Typography variant="h6">PAN Information</Typography>
                  </Stack>
                  <Button variant="text">Edit</Button>
                </Stack>
                <Divider />
                <Grid sx={{ padding: "1rem" }} container spacing={0.8}>
                  <Grid item md={2} xs={12}>
                    <Stack>
                      <Typography variant="subtitle2">
                        NAME ON PAN CARD
                      </Typography>
                      <Typography variant="body2">Donepudi Rajesh</Typography>
                    </Stack>
                  </Grid>
                  <Grid item md={2} xs={12}>
                    <Stack>
                      <Typography variant="subtitle2">MIDDLE NAME</Typography>
                      <Typography variant="body2">-Not set-</Typography>
                    </Stack>
                  </Grid>
                  <Grid item md={2} xs={12}>
                    <Stack>
                      <Typography variant="subtitle2">PAN NUMBER</Typography>
                      <Typography variant="body2">RTYUG382</Typography>
                    </Stack>
                  </Grid>
                  <Grid item md={2} xs={12}>
                    <Stack>
                      <Typography variant="subtitle2">DATE OF BIRTH</Typography>
                      <Typography variant="body2">Mar 16, 1998</Typography>
                    </Stack>
                  </Grid>
                  <Grid item md={2} xs={12}>
                    <Stack>
                      <Typography variant="subtitle2">
                        PARENT'S / SPOUSE'S NAME
                      </Typography>
                      <Typography variant="body2">V Rao Donepudi</Typography>
                    </Stack>
                  </Grid>
                </Grid>
              </Stack>
            </AppPaper>
          </Grid>
          <Grid item md={6} xs={12}>
            <AppPaper noPadding={true} variant="outlined" square>
              <Stack>
                <Stack
                  sx={{ padding: "0.6rem" }}
                  flexDirection="row"
                  justifyContent="space-between"
                >
                  <Stack flexDirection="row" alignItems="center">
                    <Typography variant="h6">Payment Information</Typography>
                  </Stack>
                  <Button variant="text">Edit</Button>
                </Stack>
                <Divider />
                <Grid sx={{ padding: "1rem" }} container spacing={0.8}>
                  <Grid item md={6} xs={12}>
                    <Stack>
                      <Typography variant="subtitle2">
                        SALARY PAYMENT MODE
                      </Typography>
                      <Typography variant="body2">Bank Transfer</Typography>
                    </Stack>
                  </Grid>
                  <Grid item md={12} xs={12}>
                    <Stack gap={1}>
                      <Typography
                        sx={{ fontWeight: "bold" }}
                        variant="subtitle1"
                      >
                        Bank Information
                      </Typography>
                      <Grid container>
                        <Grid item md={6} xs={12}>
                          <Stack>
                            <Typography variant="subtitle2">BANK</Typography>
                            <Typography variant="body2">HDFC Bank</Typography>
                          </Stack>
                        </Grid>
                        <Grid item md={6} xs={12}>
                          <Stack>
                            <Typography variant="subtitle2">
                              ACCOUNT NUMBER
                            </Typography>
                            <Typography variant="body2">8886014996</Typography>
                          </Stack>
                        </Grid>
                        <Grid item md={6} xs={12}>
                          <Stack>
                            <Typography variant="subtitle2">
                              IFSC CODE
                            </Typography>
                            <Typography variant="body2">HDFC1234</Typography>
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
                            <Typography variant="subtitle2">
                              NAME ON THE ACCOUNT
                            </Typography>
                            <Typography variant="body2">
                              Donepudi Rajesh
                            </Typography>
                          </Stack>
                        </Grid>
                      </Grid>
                    </Stack>
                  </Grid>
                </Grid>
              </Stack>
            </AppPaper>
          </Grid>
          <Grid item md={6} xs={12}>
            <AppPaper noPadding={true} variant="outlined" square>
              <Stack>
                <Stack
                  sx={{ padding: "0.6rem" }}
                  flexDirection="row"
                  justifyContent="space-between"
                >
                  <Stack flexDirection="row" alignItems="center">
                    <Typography variant="h6">Statutory Information</Typography>
                  </Stack>
                  <Button variant="text">Edit</Button>
                </Stack>
                <Divider />
                <Grid sx={{ padding: "1rem" }} container spacing={0.8}>
                  <Grid item md={12} xs={12}>
                    <Stack gap={1}>
                      <Typography
                        sx={{ fontWeight: "bold" }}
                        variant="subtitle1"
                      >
                        PF Account Information
                      </Typography>
                      <Grid container>
                        <Grid item md={6} xs={12}>
                          <Stack>
                            <Typography variant="subtitle2">BANK</Typography>
                            <Typography variant="body2">HDFC Bank</Typography>
                          </Stack>
                        </Grid>
                        <Grid item md={6} xs={12}>
                          <Stack>
                            <Typography variant="subtitle2">
                              ACCOUNT NUMBER
                            </Typography>
                            <Typography variant="body2">8886014996</Typography>
                          </Stack>
                        </Grid>
                        <Grid item md={6} xs={12}>
                          <Stack>
                            <Typography variant="subtitle2">
                              IFSC CODE
                            </Typography>
                            <Typography variant="body2">HDFC1234</Typography>
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
                            <Typography variant="subtitle2">
                              NAME ON THE ACCOUNT
                            </Typography>
                            <Typography variant="body2">
                              Donepudi Rajesh
                            </Typography>
                          </Stack>
                        </Grid>
                      </Grid>
                    </Stack>
                  </Grid>
                  <Grid item md={12} xs={12}>
                    <Stack gap={1}>
                      <Typography
                        sx={{ fontWeight: "bold" }}
                        variant="subtitle1"
                      >
                        ESI Account Information
                      </Typography>
                      <Grid container>
                        <Grid item md={6} xs={12}>
                          <Stack>
                            <Typography variant="subtitle2">BANK</Typography>
                            <Typography variant="body2">HDFC Bank</Typography>
                          </Stack>
                        </Grid>
                        <Grid item md={6} xs={12}>
                          <Stack>
                            <Typography variant="subtitle2">
                              ACCOUNT NUMBER
                            </Typography>
                            <Typography variant="body2">8886014996</Typography>
                          </Stack>
                        </Grid>
                        <Grid item md={6} xs={12}>
                          <Stack>
                            <Typography variant="subtitle2">
                              IFSC CODE
                            </Typography>
                            <Typography variant="body2">HDFC1234</Typography>
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
                            <Typography variant="subtitle2">
                              NAME ON THE ACCOUNT
                            </Typography>
                            <Typography variant="body2">
                              Donepudi Rajesh
                            </Typography>
                          </Stack>
                        </Grid>
                      </Grid>
                    </Stack>
                  </Grid>
                </Grid>
              </Stack>
            </AppPaper>
          </Grid>
          <Grid item md={6} xs={12}>
            <AppPaper noPadding={true} variant="outlined" square>
              <Stack>
                <Stack
                  sx={{ padding: "0.6rem" }}
                  flexDirection="row"
                  justifyContent="space-between"
                >
                  <Stack flexDirection="row" alignItems="center">
                    <Typography variant="h6">Payment Information</Typography>
                  </Stack>
                  <Button variant="text">Edit</Button>
                </Stack>
                <Divider />
                <Grid sx={{ padding: "1rem" }} container spacing={0.8}>
                  <Grid item md={12} xs={12}>
                    <Stack gap={1}>
                      <Typography
                        sx={{ fontWeight: "bold" }}
                        variant="subtitle1"
                      >
                        Identity Information
                      </Typography>
                      <Grid container>
                        <Grid item md={6} xs={12}>
                          <Stack>
                            <Typography variant="subtitle2">
                              NAME ON AADHAAR CARD
                            </Typography>
                            <Typography variant="body2">
                              Donepudi Rajesh
                            </Typography>
                          </Stack>
                        </Grid>
                        <Grid item md={6} xs={12}>
                          <Stack>
                            <Typography variant="subtitle2">
                              AADHAAR NUMBER
                            </Typography>
                            <Typography variant="body2">
                              63773242577695
                            </Typography>
                          </Stack>
                        </Grid>
                        <Grid item md={6} xs={12}>
                          <Stack>
                            <Typography variant="subtitle2">
                              ENROLLMENT NUMBER
                            </Typography>
                            <Typography variant="body2">N/A</Typography>
                          </Stack>
                        </Grid>
                        <Grid item md={6} xs={12}>
                          <Stack>
                            <Typography variant="subtitle2">Gender</Typography>
                            <Typography variant="body2">Male</Typography>
                          </Stack>
                        </Grid>
                      </Grid>
                    </Stack>
                  </Grid>
                </Grid>
              </Stack>
            </AppPaper>
          </Grid>
        </Grid>
      </Grid>
    </Grid>
  );
};

export default FinanceSummary;
