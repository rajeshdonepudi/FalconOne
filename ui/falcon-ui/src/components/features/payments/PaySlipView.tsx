import { Divider, Grid, Stack, Typography } from "@mui/material";
import AppPaper from "@ui-components/AppPaper";

const PaySlipView = () => {
  return (
    <Grid
      container
      width="793.7px"
      spacing={1}
      maxHeight={"1122.5197"}
      sx={{
        backgroundColor: "#FFF",
        padding: "2rem",
      }}
    >
      <Grid item md={12}>
        <Stack flexDirection="row" gap={1}>
          <Typography variant="h5" sx={{ fontWeight: "bold" }}>
            PAYSLIP
          </Typography>
          <Typography variant="h5">JANUARY 2023</Typography>
        </Stack>
      </Grid>
      <Grid item md={6}>
        <Stack gap={0.2} sx={{ height: "100%", justifyContent: "center" }}>
          <Typography variant="overline">R TECH PRIVATE LIMITED</Typography>
          <Typography variant="overline">
            PLOT NO. 111, HITECH CITY, HYDERABAD TELANGANA 500075
          </Typography>
        </Stack>
      </Grid>
      <Grid item md={6}>
        <Stack sx={{ height: "100%", alignItems: "center" }}>
          {/* <Typography variant="h1">RD</Typography> */}
          <img
            width="50%"
            height="100%"
            src="https://cdn3.f-cdn.com//files/download/144571748/professional%20logo.jpg?fit=crop"
          />
        </Stack>
      </Grid>
      <Grid item md={12}>
        <Stack
          sx={{
            height: "100%",
            alignItems: "flex-start",
            justifyContent: "center",
          }}
        >
          <Typography sx={{ textTransform: "uppercase" }} variant="h6">
            Rajesh Donepudi
          </Typography>
        </Stack>
      </Grid>
      <Grid item md={12}>
        <Divider />
      </Grid>
      <Grid item md={12}>
        <Grid container spacing={0.8}>
          <Grid item md={3}>
            <Stack sx={{ paddingTop: "0.3rem", paddingBottom: "0.3rem" }}>
              <Typography variant="subtitle2">EMPLOYEE NUMBER</Typography>
              <Typography variant="body2">403</Typography>
            </Stack>
          </Grid>
          <Grid item md={3}>
            <Stack sx={{ paddingTop: "0.3rem", paddingBottom: "0.3rem" }}>
              <Typography variant="subtitle2">DATE JOINED</Typography>
              <Typography variant="body2">01 Jun 2022</Typography>
            </Stack>
          </Grid>
          <Grid item md={3}>
            <Stack sx={{ paddingTop: "0.3rem", paddingBottom: "0.3rem" }}>
              <Typography variant="subtitle2">DEPARTMENT</Typography>
              <Typography variant="body2">NET</Typography>
            </Stack>
          </Grid>
          <Grid item md={3}>
            <Stack sx={{ paddingTop: "0.3rem", paddingBottom: "0.3rem" }}>
              <Typography variant="subtitle2">DESIGNATION</Typography>
              <Typography variant="body2">Software Engineer</Typography>
            </Stack>
          </Grid>
          <Grid item md={12}>
            <Divider />
          </Grid>
          <Grid item md={3}>
            <Stack sx={{ paddingTop: "0.3rem", paddingBottom: "0.3rem" }}>
              <Typography variant="subtitle2">PAYMENT MODE</Typography>
              <Typography variant="body2">403</Typography>
            </Stack>
          </Grid>
          <Grid item md={3}>
            <Stack sx={{ paddingTop: "0.3rem", paddingBottom: "0.3rem" }}>
              <Typography variant="subtitle2">BANK</Typography>
              <Typography variant="body2">403</Typography>
            </Stack>
          </Grid>
          <Grid item md={3}>
            <Stack sx={{ paddingTop: "0.3rem", paddingBottom: "0.3rem" }}>
              <Typography variant="subtitle2">BANK IFSC</Typography>
              <Typography variant="body2">403</Typography>
            </Stack>
          </Grid>
          <Grid item md={3}>
            <Stack sx={{ paddingTop: "0.3rem", paddingBottom: "0.3rem" }}>
              <Typography variant="subtitle2">BANK ACCOUNT</Typography>
              <Typography variant="body2">403</Typography>
            </Stack>
          </Grid>
          <Grid item md={12}>
            <Divider />
          </Grid>
          <Grid item md={3}>
            <Stack sx={{ paddingTop: "0.3rem", paddingBottom: "0.3rem" }}>
              <Typography variant="subtitle2">PAN</Typography>
              <Typography variant="body2">DV2383E</Typography>
            </Stack>
          </Grid>
          <Grid item md={3}>
            <Stack sx={{ paddingTop: "0.3rem", paddingBottom: "0.3rem" }}>
              <Typography variant="subtitle2">UAN</Typography>
              <Typography variant="body2">101654825356</Typography>
            </Stack>
          </Grid>
          <Grid item md={3}>
            <Stack sx={{ paddingTop: "0.3rem", paddingBottom: "0.3rem" }}>
              <Typography variant="subtitle2">DATE OF BIRTH</Typography>
              <Typography variant="body2">16 Mar 2051</Typography>
            </Stack>
          </Grid>
        </Grid>
      </Grid>
      <Grid item md={12}>
        <Divider />
      </Grid>
      <Grid item md={12}>
        <Stack sx={{ height: "100%", alignItems: "flex-start" }}>
          <Typography sx={{ textTransform: "uppercase" }} variant="subtitle1">
            SALARY DETAILS
          </Typography>
        </Stack>
      </Grid>
      <Grid item md={12}>
        <Divider />
      </Grid>
      <Grid item md={12}>
        <Grid container>
          <Grid item md={3}>
            <Stack sx={{ paddingTop: "0.3rem", paddingBottom: "0.3rem" }}>
              <Typography variant="subtitle2">ACTUAL PAYABLE DAYS</Typography>
              <Typography variant="subtitle2">31</Typography>
            </Stack>
          </Grid>
          <Grid item md={3}>
            <Stack sx={{ paddingTop: "0.3rem", paddingBottom: "0.3rem" }}>
              <Typography variant="subtitle2">TOTAL WORKING DAYS</Typography>
              <Typography variant="subtitle2">31</Typography>
            </Stack>
          </Grid>
          <Grid item md={3}>
            <Stack sx={{ paddingTop: "0.3rem", paddingBottom: "0.3rem" }}>
              <Typography variant="subtitle2">LOSS OF PAY DAYS</Typography>
              <Typography variant="subtitle2">0</Typography>
            </Stack>
          </Grid>
          <Grid item md={3}>
            <Stack sx={{ paddingTop: "0.3rem", paddingBottom: "0.3rem" }}>
              <Typography variant="subtitle2">DAYS PAYABLE</Typography>
              <Typography variant="subtitle2">31</Typography>
            </Stack>
          </Grid>
        </Grid>
      </Grid>
      <Grid item md={12}>
        <Divider />
      </Grid>
      <Grid item md={12}>
        <Grid container>
          <Grid item md={6}>
            <AppPaper padding="0.8rem" noTopBorder={true} noLeftBorder={true}>
              <Grid container>
                <Grid item md={4}>
                  <Stack>
                    <Typography sx={{ fontWeight: "bold" }} variant="subtitle2">
                      EARNINGS
                    </Typography>
                  </Stack>
                </Grid>
                <Grid item md={4}>
                  <Stack>
                    <Typography sx={{ fontWeight: "bold" }} variant="subtitle2">
                      AMOUNT
                    </Typography>
                  </Stack>
                </Grid>
                <Grid item md={4}>
                  <Stack>
                    <Typography sx={{ fontWeight: "bold" }} variant="subtitle2">
                      YTD
                    </Typography>
                  </Stack>
                </Grid>
              </Grid>
              <Grid container>
                <Grid item md={4}>
                  <Stack>
                    <Typography variant="caption">Basic</Typography>
                  </Stack>
                </Grid>
                <Grid item md={4}>
                  <Stack>
                    <Typography variant="caption">135,850.00</Typography>
                  </Stack>
                </Grid>
                <Grid item md={4}>
                  <Stack>
                    <Typography variant="caption">12,86,800.00</Typography>
                  </Stack>
                </Grid>
              </Grid>
              <Grid container>
                <Grid item md={4}>
                  <Stack>
                    <Typography variant="caption">HRA</Typography>
                  </Stack>
                </Grid>
                <Grid item md={4}>
                  <Stack>
                    <Typography variant="caption">114,340.00</Typography>
                  </Stack>
                </Grid>
                <Grid item md={4}>
                  <Stack>
                    <Typography variant="caption">11,14,710.00</Typography>
                  </Stack>
                </Grid>
              </Grid>
              <Grid container>
                <Grid item md={4}>
                  <Stack>
                    <Typography variant="caption">Special Allowance</Typography>
                  </Stack>
                </Grid>
                <Grid item md={4}>
                  <Stack>
                    <Typography variant="caption">121,510.00</Typography>
                  </Stack>
                </Grid>
                <Grid item md={4}>
                  <Stack>
                    <Typography variant="caption">121,72,080.00</Typography>
                  </Stack>
                </Grid>
              </Grid>
              <Grid container>
                <Grid item md={4}>
                  <Stack>
                    <Typography variant="caption">Basic</Typography>
                  </Stack>
                </Grid>
                <Grid item md={4}>
                  <Stack>
                    <Typography variant="caption">315,850.00</Typography>
                  </Stack>
                </Grid>
                <Grid item md={4}>
                  <Stack>
                    <Typography variant="caption">2,816,800.00</Typography>
                  </Stack>
                </Grid>
              </Grid>
              <Grid container>
                <Grid item md={4}>
                  <Stack>
                    <Typography sx={{ fontWeight: "bold" }} variant="caption">
                      Total Earnings (A)
                    </Typography>
                  </Stack>
                </Grid>
                <Grid item md={4}>
                  <Stack>
                    <Typography variant="caption">735,850.00</Typography>
                  </Stack>
                </Grid>
                <Grid item md={4}>
                  <Stack>
                    <Typography variant="caption">28,86,800.00</Typography>
                  </Stack>
                </Grid>
              </Grid>
            </AppPaper>
          </Grid>
          <Grid item md={6}>
            <AppPaper padding="0.8rem" noTopBorder={true} noLeftBorder={true}>
              <Grid container>
                <Grid item md={4}>
                  <Stack>
                    <Typography sx={{ fontWeight: "bold" }} variant="subtitle2">
                      CONTRIBUTION
                    </Typography>
                  </Stack>
                </Grid>
                <Grid item md={4}>
                  <Stack>
                    <Typography sx={{ fontWeight: "bold" }} variant="subtitle2">
                      AMOUNT
                    </Typography>
                  </Stack>
                </Grid>
                <Grid item md={4}>
                  <Stack>
                    <Typography sx={{ fontWeight: "bold" }} variant="subtitle2">
                      YTD
                    </Typography>
                  </Stack>
                </Grid>
              </Grid>
              <Grid container>
                <Grid item md={4}>
                  <Stack>
                    <Typography variant="caption">Basic</Typography>
                  </Stack>
                </Grid>
                <Grid item md={4}>
                  <Stack>
                    <Typography variant="caption">35,8550.00</Typography>
                  </Stack>
                </Grid>
                <Grid item md={4}>
                  <Stack>
                    <Typography variant="caption">2,856,800.00</Typography>
                  </Stack>
                </Grid>
              </Grid>
              <Grid container>
                <Grid item md={4}>
                  <Stack>
                    <Typography sx={{ fontWeight: "bold" }} variant="caption">
                      Total Earnings (A)
                    </Typography>
                  </Stack>
                </Grid>
                <Grid item md={4}>
                  <Stack>
                    <Typography variant="caption">435,850.00</Typography>
                  </Stack>
                </Grid>
                <Grid item md={4}>
                  <Stack>
                    <Typography variant="caption">42,86,800.00</Typography>
                  </Stack>
                </Grid>
              </Grid>
              <Grid container>
                <Grid item md={4}>
                  <Stack>
                    <Typography sx={{ fontWeight: "bold" }} variant="subtitle2">
                      TAXES & DEDUCTIONS
                    </Typography>
                  </Stack>
                </Grid>
                <Grid item md={4}>
                  <Stack>
                    <Typography sx={{ fontWeight: "bold" }} variant="subtitle2">
                      AMOUNT
                    </Typography>
                  </Stack>
                </Grid>
                <Grid item md={4}>
                  <Stack>
                    <Typography sx={{ fontWeight: "bold" }} variant="subtitle2">
                      YTD
                    </Typography>
                  </Stack>
                </Grid>
              </Grid>
              <Grid container>
                <Grid item md={4}>
                  <Stack>
                    <Typography variant="caption">
                      Dependent Insurance
                    </Typography>
                  </Stack>
                </Grid>
                <Grid item md={4}>
                  <Stack>
                    <Typography variant="caption">41,230.00</Typography>
                  </Stack>
                </Grid>
                <Grid item md={4}>
                  <Stack>
                    <Typography variant="caption">97,380.00</Typography>
                  </Stack>
                </Grid>
              </Grid>
              <Grid container>
                <Grid item md={4}>
                  <Stack>
                    <Typography sx={{ fontWeight: "bold" }} variant="caption">
                      Professional Tax
                    </Typography>
                  </Stack>
                </Grid>
                <Grid item md={4}>
                  <Stack>
                    <Typography variant="caption">2300.00</Typography>
                  </Stack>
                </Grid>
                <Grid item md={4}>
                  <Stack>
                    <Typography variant="caption">31,600.00</Typography>
                  </Stack>
                </Grid>
              </Grid>
              <Grid container>
                <Grid item md={4}>
                  <Stack>
                    <Typography sx={{ fontWeight: "bold" }} variant="caption">
                      Total Deductions (C)
                    </Typography>
                  </Stack>
                </Grid>
                <Grid item md={4}>
                  <Stack>
                    <Typography variant="caption">1,4330.00</Typography>
                  </Stack>
                </Grid>
                <Grid item md={4}>
                  <Stack>
                    <Typography variant="caption">38,980.00</Typography>
                  </Stack>
                </Grid>
              </Grid>
            </AppPaper>
          </Grid>
        </Grid>
      </Grid>
      <Grid item md={12}>
        <Grid container>
          <Grid item md={6}>
            <Typography fontWeight="bold" variant="subtitle2">
              Net Salary Payable ( A - B - C )
            </Typography>
          </Grid>
          <Grid item md={6}>
            <Typography variant="body2">88,99,98,170.00</Typography>
          </Grid>
        </Grid>
        <Grid container>
          <Grid item md={6}>
            <Typography fontWeight="bold" variant="subtitle2">
              Net Salary in words
            </Typography>
          </Grid>
          <Grid item md={6}>
            <Typography variant="body2">
              Sixty Core thousand Thousand Four Hundred and Seventy Crores Only
            </Typography>
          </Grid>
        </Grid>
        <Grid container>
          <Grid item md={12}>
            <Typography variant="caption" sx={{ fontStyle: "italic" }}>
              **Note : All amounts displayed in this payslip are in INR
            </Typography>
          </Grid>
        </Grid>
      </Grid>
    </Grid>
  );
};

export default PaySlipView;
