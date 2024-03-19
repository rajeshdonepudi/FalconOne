import { Box, Grid, Stack, Typography } from "@mui/material";
import AppPaper from "@ui-components/AppPaper";
import TrendingUpOutlinedIcon from "@mui/icons-material/TrendingUpOutlined";
import Accordion from "@mui/material/Accordion";
import AccordionSummary from "@mui/material/AccordionSummary";
import AccordionDetails from "@mui/material/AccordionDetails";
import ExpandMoreIcon from "@mui/icons-material/ExpandMore";
const MySalary = () => {
  return (
    <Grid container spacing={0.8}>
      <Grid item md={12} xs={12} sm={12}>
        <Grid container spacing={0.8}>
          <Grid item md={6} xs={12} sm={12}>
            <AppPaper>
              <Stack>
                <Typography variant="subtitle2">
                  CURRENT COMPENSATION
                </Typography>
                <Typography variant="body2">
                  INR 679,00,000.00 / Annum
                </Typography>
              </Stack>
            </AppPaper>
          </Grid>
          <Grid item md={6} xs={12} sm={12}>
            <AppPaper>
              <Grid container spacing={0.8}>
                <Grid item md={2} xs={12} sm={12}>
                  <Stack sx={{ height: "100%" }} justifyContent="center">
                    <Typography variant="h6">Payroll</Typography>
                  </Stack>
                </Grid>
                <Grid item md={5} xs={12} sm={12}>
                  <Stack sx={{ height: "100%" }} justifyContent="center">
                    <Typography variant="subtitle2">REMUNERATION</Typography>
                    <Typography variant="body2">Monthly</Typography>
                  </Stack>
                </Grid>
                <Grid item md={5} xs={12} sm={12}>
                  <Stack sx={{ height: "100%" }} justifyContent="center">
                    <Typography variant="subtitle2">PAY CYCLE</Typography>
                    <Typography variant="body2">Monthly</Typography>
                  </Stack>
                </Grid>
              </Grid>
            </AppPaper>
          </Grid>
        </Grid>
      </Grid>
      <Grid item md={12} xs={12} sm={12}>
        <AppPaper>
          <Stack gap={1}>
            <Typography variant="h6">Salary Timeline</Typography>
            <Box
              sx={{ backgroundColor: "rgba(255,174,0,.2)", padding: "0.6rem" }}
            >
              <Typography variant="caption">
                Your Income and tax liability is being computed as per Old Tax
                Regime. To learn more and switch to New Tax Regime, click here.
              </Typography>
            </Box>
            <Stack flexDirection="row" flexWrap="wrap" gap={1}>
              <TrendingUpOutlinedIcon />
              <Stack
                gap={1}
                flexDirection="row"
                alignItems="center"
                flexWrap="wrap"
              >
                <Typography variant="subtitle1" sx={{ fontWeight: "bold" }}>
                  Salary Revision
                </Typography>
                <Typography variant="subtitle2">
                  Effective Jun 01, 2022
                </Typography>
                <Typography
                  variant="caption"
                  sx={{
                    backgroundColor: "#64c3d1",
                    padding: "0.3rem",
                    borderRadius: "3px",
                    color: "#fff",
                    fontSize: "8px",
                  }}
                >
                  CURRENT
                </Typography>
              </Stack>
            </Stack>
            <Stack>
              <Accordion>
                <AccordionSummary
                  expandIcon={<ExpandMoreIcon />}
                  aria-controls="panel1a-content"
                  id="panel1a-header"
                >
                  <Grid container spacing={0.8}>
                    <Grid item sm={12} xs={12} md={1}>
                      <Stack justifyContent="center">
                        <Typography variant="subtitle2">
                          REGULAR SALARY
                        </Typography>
                        <Typography>INR 239,00,000</Typography>
                      </Stack>
                    </Grid>
                    <Grid item sm={12} xs={12} md={1}>
                      <Stack sx={{ height: "100%" }} justifyContent="center">
                        +
                      </Stack>
                    </Grid>
                    <Grid item sm={12} xs={12} md={1}>
                      <Stack>
                        <Typography variant="subtitle2">BONUS</Typography>
                        <Typography>INR 0</Typography>
                      </Stack>
                    </Grid>
                    <Grid item sm={12} xs={12} md={1}>
                      <Stack sx={{ height: "100%" }} justifyContent="center">
                        =
                      </Stack>
                    </Grid>
                    <Grid item sm={12} xs={12} md={1}>
                      <Stack>
                        <Typography variant="subtitle2">TOTAL</Typography>
                        <Typography>INR 2329,00,000</Typography>
                      </Stack>
                    </Grid>
                  </Grid>
                </AccordionSummary>
                <AccordionDetails>
                  <Stack gap={1}>
                    <AppPaper>
                      <Stack
                        flexDirection="row"
                        alignItems="center"
                        gap={2}
                        flexWrap="wrap"
                      >
                        <Typography variant="caption">
                          REGULAR SALARY
                        </Typography>
                        <Typography variant="caption">
                          INR 9232,00,000.00 / Annum
                        </Typography>
                        <Typography variant="caption">
                          Salary breakup
                        </Typography>
                      </Stack>
                    </AppPaper>
                    <Grid container spacing={2}>
                      <Grid item md={6} sm={12} xs={12}>
                        <Stack>
                          <Typography variant="subtitle2">
                            SALARY PER MONTH
                          </Typography>
                          <Typography variant="body2">
                            INR 7231,700.00
                          </Typography>
                        </Stack>
                      </Grid>
                      <Grid item md={6} sm={12} xs={12}>
                        <Stack>
                          <Typography variant="subtitle2">
                            EFFECTIVE FROM
                          </Typography>
                          <Typography variant="body2">Jun 01, 2022</Typography>
                        </Stack>
                      </Grid>
                      <Grid item md={6} sm={12} xs={12}>
                        <Stack>
                          <Typography variant="subtitle2">
                            PF - EMPLOYER / MONTH
                          </Typography>
                          <Typography variant="body2">INR 1,23800</Typography>
                        </Stack>
                      </Grid>
                      <Grid item md={6} sm={12} xs={12}>
                        <Stack>
                          <Typography variant="subtitle2">
                            EMPLOYEE GRATUITY CONTRIBUTION / MONTH
                          </Typography>
                          <Typography variant="body2">INR 123,500</Typography>
                        </Stack>
                      </Grid>
                    </Grid>
                  </Stack>
                </AccordionDetails>
              </Accordion>
            </Stack>
          </Stack>
        </AppPaper>
      </Grid>
    </Grid>
  );
};

export default MySalary;
