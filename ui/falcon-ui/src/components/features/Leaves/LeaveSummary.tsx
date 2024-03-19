import {
  Box,
  Button,
  Checkbox,
  FormControl,
  Grid,
  InputBase,
  InputLabel,
  ListItemText,
  Menu,
  MenuItem,
  OutlinedInput,
  Stack,
  Tab,
  Tabs,
  Typography,
  alpha,
  styled,
} from "@mui/material";
import Select, { SelectChangeEvent } from "@mui/material/Select";

import { useState } from "react";
import AppTabPanel from "@ui-components/AppTabPanel";
import KeyboardArrowDownIcon from "@mui/icons-material/KeyboardArrowDown";
import AppPaper from "@ui-components/AppPaper";
import InfoOutlinedIcon from "@mui/icons-material/InfoOutlined";
import { PieChart, Pie } from "recharts";
import SearchIcon from "@mui/icons-material/Search";

import { BarChart, Bar, Cell, XAxis, ResponsiveContainer } from "recharts";
const ITEM_HEIGHT = 48;
const ITEM_PADDING_TOP = 8;

const MenuProps = {
  PaperProps: {
    style: {
      maxHeight: ITEM_HEIGHT * 4.5 + ITEM_PADDING_TOP,
      width: 250,
    },
  },
};

const LeaveSummary = () => {
  const [personName, setPersonName] = useState<string[]>([]);

  const names = [
    "Oliver Hansen",
    "Van Henry",
    "April Tucker",
    "Ralph Hubbard",
    "Omar Alexander",
    "Carlos Abbott",
    "Miriam Wagner",
    "Bradley Wilkerson",
    "Virginia Andrews",
    "Kelly Snyder",
  ];

  const Search = styled("div")(({ theme }) => ({
    position: "relative",
    borderRadius: theme.shape.borderRadius,
    backgroundColor: alpha(theme.palette.common.white, 0.15),
    "&:hover": {
      backgroundColor: alpha(theme.palette.common.white, 0.25),
    },
    marginRight: theme.spacing(2),
    marginLeft: 0,
    width: "100%",
    [theme.breakpoints.up("sm")]: {
      marginLeft: theme.spacing(3),
      width: "auto",
    },
  }));

  const SearchIconWrapper = styled("div")(({ theme }) => ({
    padding: theme.spacing(0, 2),
    height: "100%",
    position: "absolute",
    pointerEvents: "none",
    display: "flex",
    alignItems: "center",
    justifyContent: "center",
  }));

  const StyledInputBase = styled(InputBase)(({ theme }) => ({
    color: "inherit",
    "& .MuiInputBase-input": {
      padding: theme.spacing(1, 1, 1, 0),
      // vertical padding + font size from searchIcon
      paddingLeft: `calc(1em + ${theme.spacing(4)})`,
      transition: theme.transitions.create("width"),
      width: "100%",
      [theme.breakpoints.up("md")]: {
        width: "20ch",
      },
    },
  }));

  const StyledMenu = styled((props: any) => (
    <Menu
      elevation={0}
      anchorOrigin={{
        vertical: "bottom",
        horizontal: "right",
      }}
      transformOrigin={{
        vertical: "top",
        horizontal: "right",
      }}
      {...props}
    />
  ))(({ theme }) => ({
    "& .MuiPaper-root": {
      borderRadius: 6,
      marginTop: theme.spacing(1),
      minWidth: 180,
      color:
        theme.palette.mode === "light"
          ? "rgb(55, 65, 81)"
          : theme.palette.grey[300],
      boxShadow:
        "rgb(255, 255, 255) 0px 0px 0px 0px, rgba(0, 0, 0, 0.05) 0px 0px 0px 1px, rgba(0, 0, 0, 0.1) 0px 10px 15px -3px, rgba(0, 0, 0, 0.05) 0px 4px 6px -2px",
      "& .MuiMenu-list": {
        padding: "4px 0",
      },
      "& .MuiMenuItem-root": {
        "& .MuiSvgIcon-root": {
          fontSize: 18,
          color: theme.palette.text.secondary,
          marginRight: theme.spacing(1.5),
        },
        "&:active": {
          backgroundColor: alpha(
            theme.palette.primary.main,
            theme.palette.action.selectedOpacity
          ),
        },
      },
    },
  }));

  const [value, setValue] = useState(0);

  const handleChange = (event: React.SyntheticEvent, newValue: number) => {
    setValue(newValue);
  };

  const handleChange2 = (event: SelectChangeEvent<typeof personName>) => {
    const {
      target: { value },
    } = event;
    setPersonName(
      // On autofill we get a stringified value.
      typeof value === "string" ? value.split(",") : value
    );
  };
  const [anchorEl, setAnchorEl] = useState<null | HTMLElement>(null);

  const open = Boolean(anchorEl);
  const handleClick = (event: React.MouseEvent<HTMLElement>) => {
    setAnchorEl(event.currentTarget);
  };
  const handleClose = () => {
    setAnchorEl(null);
  };

  const data = [
    {
      name: "Mon",
      total: 0,
    },
    {
      name: "Tue",
      total: 10,
    },
    {
      name: "Wed",
      total: 20,
    },
    {
      name: "Thu",
      total: 10,
    },
    {
      name: "Fri",
      total: 0,
    },
    {
      name: "Sat",
      total: 0,
    },
    {
      name: "Sun",
      total: 0,
    },
  ];

  const data2 = [
    { name: "Group A", value: 100 },
    { name: "Group B", value: 300 },
  ];

  const data3 = [
    {
      name: "Jan",
      total: 0,
    },
    {
      name: "Feb",
      total: 10,
    },
    {
      name: "Mar",
      total: 20,
    },
    {
      name: "Apr",
      total: 10,
    },
    {
      name: "May",
      total: 0,
    },
    {
      name: "Jun",
      total: 0,
    },
    {
      name: "Jul",
      total: 0,
    },
    {
      name: "Aug",
      total: 0,
    },
    {
      name: "Sep",
      total: 0,
    },
    {
      name: "Oct",
      total: 0,
    },
    {
      name: "Dec",
      total: 0,
    },
  ];
  const COLORS = ["#0088FE", "#00C49F", "#FFBB28", "#FF8042"];

  return (
    <Grid container spacing={0.8}>
      <Grid item xs={12} md={12}>
        <Box>
          <Tabs
            value={value}
            onChange={handleChange}
            variant="scrollable"
            scrollButtons="auto"
            aria-label="scrollable auto tabs example"
          >
            <Tab label="Summary" />
          </Tabs>
        </Box>
      </Grid>
      <Grid item md={12} xs={12}>
        <AppTabPanel value={value} index={0}>
          <Grid container spacing={2}>
            <Grid item md={12} xs={12}>
              <Stack gap={0.8}>
                <Stack justifyContent="space-between" flexDirection="row">
                  <Typography variant="h6">Pending leave requests</Typography>
                  <Button
                    id="demo-customized-button"
                    aria-controls={open ? "demo-customized-menu" : undefined}
                    aria-haspopup="true"
                    aria-expanded={open ? "true" : undefined}
                    variant="contained"
                    disableElevation
                    onClick={handleClick}
                    endIcon={<KeyboardArrowDownIcon />}
                  >
                    Actions
                  </Button>
                  <StyledMenu
                    id="demo-customized-menu"
                    MenuListProps={{
                      "aria-labelledby": "demo-customized-button",
                    }}
                    anchorEl={anchorEl}
                    open={open}
                    onClose={handleClose}
                  >
                    <MenuItem onClick={handleClose} disableRipple>
                      Resign
                    </MenuItem>
                  </StyledMenu>
                </Stack>
                <Grid container spacing={0.8}>
                  <Grid item md={9} xs={12}>
                    <AppPaper>
                      <Stack>
                        <Box sx={{ width: "100px" }}>
                          <lottie-player
                            src={
                              "https://assets3.lottiefiles.com/private_files/lf30_e3pteeho.json"
                            }
                            background="transparent"
                            speed="1"
                            loop
                            autoplay
                          ></lottie-player>
                        </Box>
                        <Typography variant="h6">Nothing here.</Typography>
                        <Typography variant="caption">
                          Working hard yeah?? Request time off on the right.
                        </Typography>
                      </Stack>
                    </AppPaper>
                  </Grid>
                  <Grid item md={3} xs={12}>
                    <AppPaper>
                      <Stack sx={{ alignItems: "flex-start", padding: "1rem" }}>
                        <Button variant="contained">Apply Leave</Button>
                        <Button variant="text">Request Leave Encashment</Button>
                        <Button variant="text">
                          Request Credit for Compensatory Off
                        </Button>
                        <Button variant="text">Leave Policy Explanation</Button>
                      </Stack>
                    </AppPaper>
                  </Grid>
                </Grid>
              </Stack>
            </Grid>
            <Grid item md={12} xs={12}>
              <Stack gap={0.8}>
                <Typography variant="h6">My Leave Stats</Typography>
                <Grid container spacing={0.8}>
                  <Grid item md={3} xs={12}>
                    <AppPaper padding="0.3rem">
                      <Stack
                        sx={{
                          padding: "4px 0px 0px 8px",
                          height: "140px",
                        }}
                      >
                        <Stack
                          flexDirection="row"
                          justifyItems="center"
                          justifyContent="space-between"
                          alignItems="center"
                        >
                          <Typography variant="subtitle2">
                            Weekly pattern
                          </Typography>
                          <InfoOutlinedIcon />
                        </Stack>
                        <ResponsiveContainer width="100%" height="100%">
                          <BarChart data={data}>
                            <XAxis dataKey="name" />
                            <Bar dataKey="total" fill="#8884d8" />
                          </BarChart>
                        </ResponsiveContainer>
                      </Stack>
                    </AppPaper>
                  </Grid>
                  <Grid item md={3} xs={12}>
                    <AppPaper padding="0.3rem">
                      <Stack
                        sx={{ padding: "4px 0px 0px 8px", height: "160px" }}
                      >
                        <Stack
                          flexDirection="row"
                          justifyItems="center"
                          justifyContent="space-between"
                          alignItems="center"
                        >
                          <Typography variant="subtitle2">
                            Consumed Leave Types
                          </Typography>
                          <InfoOutlinedIcon />
                        </Stack>
                        <ResponsiveContainer width="100%" height="100%">
                          <PieChart>
                            <Pie
                              data={data2}
                              innerRadius={30}
                              outerRadius={40}
                              fill="#8884d8"
                              paddingAngle={5}
                              dataKey="value"
                            >
                              {data.map((entry, index) => (
                                <Cell
                                  key={`cell-${index}`}
                                  fill={COLORS[index % COLORS.length]}
                                />
                              ))}
                            </Pie>
                          </PieChart>
                        </ResponsiveContainer>
                      </Stack>
                    </AppPaper>
                  </Grid>
                  <Grid item md={6} xs={12}>
                    <AppPaper padding="0.3rem">
                      <Stack
                        sx={{ padding: "4px 0px 0px 8px", height: "140px" }}
                      >
                        <Stack
                          flexDirection="row"
                          justifyItems="center"
                          justifyContent="space-between"
                          alignItems="center"
                        >
                          <Typography variant="subtitle2">
                            Monthly stats
                          </Typography>
                          <InfoOutlinedIcon />
                        </Stack>
                        <ResponsiveContainer width="100%" height="100%">
                          <BarChart data={data3}>
                            <XAxis dataKey="name" />
                            <Bar dataKey="total" fill="#8884d8" />
                          </BarChart>
                        </ResponsiveContainer>
                      </Stack>
                    </AppPaper>
                  </Grid>
                </Grid>
              </Stack>
            </Grid>
            <Grid item md={12} xs={12}>
              <Stack gap={0.8}>
                <Typography variant="h6">Leave Balances</Typography>
                <Grid container spacing={0.8}>
                  <Grid item md={3} xs={12}>
                    <AppPaper noPadding={true}>
                      <Stack sx={{ height: "100%" }}>
                        <Stack
                          sx={{
                            alignItems: "center",
                            padding: "8px 0px 0px 0px",
                          }}
                        >
                          <Typography variant="caption">Comp Offs</Typography>
                        </Stack>
                        <Box sx={{ height: "120px" }}>
                          <ResponsiveContainer width="100%" height="100%">
                            <PieChart>
                              <Pie
                                data={data2}
                                innerRadius={30}
                                outerRadius={40}
                                fill="#8884d8"
                                paddingAngle={5}
                                dataKey="value"
                              >
                                {data.map((entry, index) => (
                                  <Cell
                                    key={`cell-${index}`}
                                    fill={COLORS[index % COLORS.length]}
                                  />
                                ))}
                              </Pie>
                            </PieChart>
                          </ResponsiveContainer>
                        </Box>
                        <Grid container>
                          <Grid item md={6} xs={12} sm={12}>
                            <AppPaper
                              noLeftBorder={true}
                              noBottomBorder={true}
                              padding="4px 0px 0 8px"
                            >
                              <Stack>
                                <Typography variant="subtitle2">
                                  Available
                                </Typography>
                                <Typography variant="body2">0</Typography>
                              </Stack>
                            </AppPaper>
                          </Grid>
                          <Grid item md={6} xs={12} sm={12}>
                            <AppPaper
                              noLeftBorder={true}
                              noBottomBorder={true}
                              noRightBorder={true}
                              padding="4px 0px 0 8px"
                            >
                              <Stack>
                                <Typography variant="subtitle2">
                                  consumed
                                </Typography>
                                <Typography variant="body2">0</Typography>
                              </Stack>
                            </AppPaper>
                          </Grid>
                          <Grid item md={12} xs={12} sm={12}>
                            <AppPaper
                              noRightBorder={true}
                              noLeftBorder={true}
                              noBottomBorder={true}
                              padding="4px 0px 0 8px"
                            >
                              <Stack>
                                <Typography variant="subtitle2">
                                  annual quota
                                </Typography>
                                <Typography variant="body2">0</Typography>
                              </Stack>
                            </AppPaper>
                          </Grid>
                        </Grid>
                      </Stack>
                    </AppPaper>
                  </Grid>
                  <Grid item md={3} xs={12}>
                    <AppPaper noPadding={true}>
                      <Stack sx={{ height: "100%" }}>
                        <Stack
                          sx={{
                            alignItems: "center",
                            padding: "8px 0px 0px 0px",
                          }}
                        >
                          <Typography variant="caption">
                            Earned Leave
                          </Typography>
                        </Stack>
                        <Box sx={{ height: "120px" }}>
                          <ResponsiveContainer width="100%" height="100%">
                            <PieChart>
                              <Pie
                                data={data2}
                                innerRadius={30}
                                outerRadius={40}
                                fill="#8884d8"
                                paddingAngle={5}
                                dataKey="value"
                              >
                                {data.map((entry, index) => (
                                  <Cell
                                    key={`cell-${index}`}
                                    fill={COLORS[index % COLORS.length]}
                                  />
                                ))}
                              </Pie>
                            </PieChart>
                          </ResponsiveContainer>
                        </Box>
                        <Grid container>
                          <Grid item md={6} xs={12} sm={12}>
                            <AppPaper
                              noLeftBorder={true}
                              noBottomBorder={true}
                              padding="4px 0px 0 8px"
                            >
                              <Stack>
                                <Typography variant="subtitle2">
                                  Available
                                </Typography>
                                <Typography variant="body2">0</Typography>
                              </Stack>
                            </AppPaper>
                          </Grid>
                          <Grid item md={6} xs={12} sm={12}>
                            <AppPaper
                              noRightBorder={true}
                              noLeftBorder={true}
                              noBottomBorder={true}
                              padding="4px 0px 0 8px"
                            >
                              <Stack>
                                <Typography variant="subtitle2">
                                  consumed
                                </Typography>
                                <Typography variant="body2">0</Typography>
                              </Stack>
                            </AppPaper>
                          </Grid>
                          <Grid item md={4} xs={12} sm={12}>
                            <AppPaper
                              noLeftBorder={true}
                              noBottomBorder={true}
                              padding="4px 0px 0 8px"
                            >
                              <Stack>
                                <Typography variant="subtitle2">
                                  accured so far
                                </Typography>
                                <Typography variant="body2">0</Typography>
                              </Stack>
                            </AppPaper>
                          </Grid>
                          <Grid item md={4} xs={12} sm={12}>
                            <AppPaper
                              noLeftBorder={true}
                              noBottomBorder={true}
                              padding="4px 0px 0 8px"
                            >
                              <Stack>
                                <Typography variant="subtitle2">
                                  carry over
                                </Typography>
                                <Typography variant="body2">0</Typography>
                              </Stack>
                            </AppPaper>
                          </Grid>
                          <Grid item md={4} xs={12} sm={12}>
                            <AppPaper
                              noRightBorder={true}
                              noLeftBorder={true}
                              noBottomBorder={true}
                              padding="4px 0px 0 8px"
                            >
                              <Stack>
                                <Typography variant="subtitle2">
                                  annual quota
                                </Typography>
                                <Typography variant="body2">0</Typography>
                              </Stack>
                            </AppPaper>
                          </Grid>
                        </Grid>
                      </Stack>
                    </AppPaper>
                  </Grid>
                  <Grid item md={3} xs={12}>
                    <AppPaper noPadding={true}>
                      <Stack sx={{ height: "100%" }}>
                        <Stack
                          sx={{
                            alignItems: "center",
                            padding: "8px 0px 0px 0px",
                          }}
                        >
                          <Typography variant="caption">Loss of pay</Typography>
                        </Stack>
                        <Box sx={{ height: "120px" }}>
                          <ResponsiveContainer width="100%" height="100%">
                            <PieChart>
                              <Pie
                                data={data2}
                                innerRadius={30}
                                outerRadius={40}
                                fill="#8884d8"
                                paddingAngle={5}
                                dataKey="value"
                              >
                                {data.map((entry, index) => (
                                  <Cell
                                    key={`cell-${index}`}
                                    fill={COLORS[index % COLORS.length]}
                                  />
                                ))}
                              </Pie>
                            </PieChart>
                          </ResponsiveContainer>
                        </Box>
                        <Grid container>
                          <Grid item md={6} xs={12} sm={12}>
                            <AppPaper
                              noBottomBorder={true}
                              noLeftBorder={true}
                              padding="4px 0px 0 8px"
                            >
                              <Stack>
                                <Typography variant="subtitle2">
                                  Available
                                </Typography>
                                <Typography variant="body2">0</Typography>
                              </Stack>
                            </AppPaper>
                          </Grid>
                          <Grid item md={6} xs={12} sm={12}>
                            <AppPaper
                              noBottomBorder={true}
                              noLeftBorder={true}
                              noRightBorder={true}
                              padding="4px 0px 0 8px"
                            >
                              <Stack>
                                <Typography variant="subtitle2">
                                  consumed
                                </Typography>
                                <Typography variant="body2">0</Typography>
                              </Stack>
                            </AppPaper>
                          </Grid>
                          <Grid item md={12} xs={12} sm={12}>
                            <AppPaper
                              noLeftBorder={true}
                              noBottomBorder={true}
                              noRightBorder={true}
                              padding="4px 0px 0 8px"
                            >
                              <Stack>
                                <Typography variant="subtitle2">
                                  annual quota
                                </Typography>
                                <Typography variant="body2">0</Typography>
                              </Stack>
                            </AppPaper>
                          </Grid>
                        </Grid>
                      </Stack>
                    </AppPaper>
                  </Grid>
                  <Grid item md={3} xs={12}>
                    <AppPaper noPadding={true}>
                      <Stack sx={{ height: "100%" }}>
                        <Stack
                          sx={{
                            alignItems: "center",
                            padding: "8px 0px 0px 0px",
                          }}
                        >
                          <Typography variant="caption">
                            Optional Holiday
                          </Typography>
                        </Stack>
                        <Box sx={{ height: "120px" }}>
                          <ResponsiveContainer width="100%" height="100%">
                            <PieChart>
                              <Pie
                                data={data2}
                                innerRadius={30}
                                outerRadius={40}
                                fill="#8884d8"
                                paddingAngle={5}
                                dataKey="value"
                              >
                                {data.map((entry, index) => (
                                  <Cell
                                    key={`cell-${index}`}
                                    fill={COLORS[index % COLORS.length]}
                                  />
                                ))}
                              </Pie>
                            </PieChart>
                          </ResponsiveContainer>
                        </Box>
                        <Grid container>
                          <Grid item md={6} xs={12} sm={12}>
                            <AppPaper
                              noLeftBorder={true}
                              noBottomBorder={true}
                              padding="4px 0px 0 8px"
                            >
                              <Stack>
                                <Typography variant="subtitle2">
                                  Available
                                </Typography>
                                <Typography variant="body2">0</Typography>
                              </Stack>
                            </AppPaper>
                          </Grid>
                          <Grid item md={6} xs={12} sm={12}>
                            <AppPaper
                              noLeftBorder={true}
                              noRightBorder={true}
                              noBottomBorder={true}
                              padding="4px 0px 0 8px"
                            >
                              <Stack>
                                <Typography variant="subtitle2">
                                  consumed
                                </Typography>
                                <Typography variant="body2">0</Typography>
                              </Stack>
                            </AppPaper>
                          </Grid>
                          <Grid item md={6} xs={12} sm={12}>
                            <AppPaper
                              noLeftBorder={true}
                              noBottomBorder={true}
                              padding="4px 0px 0 8px"
                            >
                              <Stack>
                                <Typography variant="subtitle2">
                                  accured so far
                                </Typography>
                                <Typography variant="body2">0</Typography>
                              </Stack>
                            </AppPaper>
                          </Grid>
                          <Grid item md={6} xs={12} sm={12}>
                            <AppPaper
                              noLeftBorder={true}
                              noRightBorder={true}
                              noBottomBorder={true}
                              padding="4px 0px 0 8px"
                            >
                              <Stack>
                                <Typography variant="subtitle2">
                                  annual quota
                                </Typography>
                                <Typography variant="body2">0</Typography>
                              </Stack>
                            </AppPaper>
                          </Grid>
                        </Grid>
                      </Stack>
                    </AppPaper>
                  </Grid>
                  <Grid item md={12} xs={12}>
                    <AppPaper>
                      <Stack flexDirection="row" gap={1} alignItems={"center"}>
                        <Typography variant="subtitle2">
                          Other Leave Types Available:
                        </Typography>
                        <Typography variant="body2">
                          Beareavement Leave, Paternity Leave
                        </Typography>
                      </Stack>
                    </AppPaper>
                  </Grid>
                </Grid>
              </Stack>
            </Grid>
            <Grid item md={12} xs={12}>
              <Stack gap={0.8}>
                <Typography variant="h6">Leave History</Typography>
                <Grid container>
                  <Grid item md={2} xs={12}>
                    <AppPaper noBottomBorder={true}>
                      <FormControl fullWidth>
                        <InputLabel id="demo-multiple-checkbox-label">
                          Leave Type
                        </InputLabel>
                        <Select
                          labelId="demo-multiple-checkbox-label"
                          id="demo-multiple-checkbox"
                          multiple
                          value={personName}
                          onChange={handleChange2}
                          input={<OutlinedInput label="Leave Type" />}
                          renderValue={(selected) => selected.join(", ")}
                          MenuProps={MenuProps}
                        >
                          {names.map((name) => (
                            <MenuItem key={name} value={name}>
                              <Checkbox
                                checked={personName.indexOf(name) > -1}
                              />
                              <ListItemText primary={name} />
                            </MenuItem>
                          ))}
                        </Select>
                      </FormControl>
                    </AppPaper>
                  </Grid>
                  <Grid item md={2} xs={12}>
                    <AppPaper noBottomBorder={true}>
                      <FormControl fullWidth>
                        <InputLabel id="demo-multiple-checkbox-label">
                          Status
                        </InputLabel>
                        <Select
                          labelId="demo-multiple-checkbox-label"
                          id="demo-multiple-checkbox"
                          multiple
                          value={personName}
                          onChange={handleChange2}
                          input={<OutlinedInput label="Status" />}
                          renderValue={(selected) => selected.join(", ")}
                          MenuProps={MenuProps}
                        >
                          {names.map((name) => (
                            <MenuItem key={name} value={name}>
                              <Checkbox
                                checked={personName.indexOf(name) > -1}
                              />
                              <ListItemText primary={name} />
                            </MenuItem>
                          ))}
                        </Select>
                      </FormControl>
                    </AppPaper>
                  </Grid>
                  <Grid item md={8} xs={12}>
                    <AppPaper noBottomBorder={true}>
                      <Stack sx={{ height: "100%" }} justifyContent="center">
                        <Search>
                          <SearchIconWrapper>
                            <SearchIcon />
                          </SearchIconWrapper>
                          <StyledInputBase
                            placeholder="Search…"
                            inputProps={{ "aria-label": "search" }}
                          />
                        </Search>
                      </Stack>
                    </AppPaper>
                  </Grid>
                  <Grid item md={12} xs={12}>
                    <AppPaper>
                      <Stack alignItems="flex-end">Showing 1 of 100</Stack>
                    </AppPaper>
                  </Grid>
                </Grid>
              </Stack>
            </Grid>
          </Grid>
        </AppTabPanel>
      </Grid>
    </Grid>
  );
};

export default LeaveSummary;
