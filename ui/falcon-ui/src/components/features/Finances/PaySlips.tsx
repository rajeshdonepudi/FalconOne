import {
  Box,
  Button,
  Divider,
  FormControl,
  Grid,
  InputLabel,
  List,
  ListItem,
  ListItemText,
  MenuItem,
  Select,
  SelectChangeEvent,
  Stack,
  Typography,
} from "@mui/material";
import FileDownloadOutlinedIcon from "@mui/icons-material/FileDownloadOutlined";
import { useRef, useState } from "react";
import AppPaper from "@ui-components/AppPaper";
import PaySlipView from "../payments/PaySlipView";
import ReactToPrint from "react-to-print";
const PaySlips = () => {
  const [age, setAge] = useState("");

  const handleChange = (event: SelectChangeEvent) => {
    setAge(event.target.value as string);
  };

  const paySlipView = useRef<any>(null);

  return (
    <Grid container spacing={2}>
      <Grid item md={12} sm={12} xs={12}>
        <Stack>
          <Stack flexDirection="row" alignItems="center">
            <Typography variant="h6">Pay Slips</Typography>
            <FileDownloadOutlinedIcon />
          </Stack>
          <Typography variant="caption">
            Here you can manage all keka generated payslips for applicable
            years.
          </Typography>
        </Stack>
      </Grid>
      <Grid item md={12} sm={12} xs={12}>
        <Grid container spacing={2}>
          <Grid item md={2} sm={12} xs={12}>
            <Stack
              flexDirection="column"
              gap={1}
              justifyContent="space-between"
            >
              <FormControl fullWidth>
                <InputLabel id="demo-simple-select-label">Year</InputLabel>
                <Select
                  labelId="demo-simple-select-label"
                  id="demo-simple-select"
                  value={age}
                  label="Year"
                  onChange={handleChange}
                >
                  <MenuItem value={10}>Year 2023</MenuItem>
                  <MenuItem value={20}>Year 2022</MenuItem>
                  <MenuItem value={30}>Year 2021</MenuItem>
                </Select>
              </FormControl>
              <Grid container>
                <Grid item md={12} xs={12} sm={12}>
                  <AppPaper noPadding={true}>
                    <Stack
                      alignItems="center"
                      sx={{
                        background: "#f3f4f7",
                        height: "100%",
                        padding: "0.4rem",
                      }}
                    >
                      <Typography variant="subtitle2">Pay slips</Typography>
                    </Stack>
                  </AppPaper>
                </Grid>
                <Grid item md={12} xs={12} sm={12}>
                  <AppPaper noTopBorder={true} padding="0.3px">
                    <List
                      sx={{
                        width: "100%",
                        maxWidth: 360,
                        bgcolor: "background.paper",
                      }}
                    >
                      {[...Array(5).keys()].map((index) => (
                        <>
                          <ListItem alignItems="flex-start">
                            <ListItemText primary={`Year 202${index}`} />
                          </ListItem>
                          {index != 5 - 1 && <Divider />}
                        </>
                      ))}
                    </List>
                  </AppPaper>
                </Grid>
              </Grid>
            </Stack>
          </Grid>
          <Grid item md={10} xs={12} sm={12}>
            <Stack sx={{ height: "100%" }} flexWrap="wrap">
              <Stack alignItems="flex-end" sx={{ paddingBottom: "2rem" }}>
                <ReactToPrint
                  trigger={() => {
                    return (
                      <Button
                        variant="outlined"
                        endIcon={<FileDownloadOutlinedIcon />}
                      >
                        May 2023 Pay Slip
                      </Button>
                    );
                  }}
                  content={() => paySlipView.current}
                />
              </Stack>
              <Box
                sx={{
                  backgroundColor: "#4a5363",
                  padding: "16px",
                  color: "#fff",
                }}
              >
                <Typography variant="subtitle2">January 2023</Typography>
              </Box>
              <Stack
                sx={{
                  backgroundColor: "#343a40",
                  height: "1200px",
                  alignItems: "center",
                  justifyContent: "center",
                }}
              >
                <Box ref={paySlipView}>
                  <PaySlipView />
                </Box>
              </Stack>
            </Stack>
          </Grid>
        </Grid>
      </Grid>
    </Grid>
  );
};

export default PaySlips;
