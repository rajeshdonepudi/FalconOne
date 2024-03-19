import { Grid, Stack, Typography } from "@mui/material";
import AppPaper from "@ui-components/AppPaper";
import OutlinedInput from "@mui/material/OutlinedInput";
import InputLabel from "@mui/material/InputLabel";
import MenuItem from "@mui/material/MenuItem";
import FormControl from "@mui/material/FormControl";
import ListItemText from "@mui/material/ListItemText";
import Select, { SelectChangeEvent } from "@mui/material/Select";
import Checkbox from "@mui/material/Checkbox";
import { useState } from "react";
import SearchIcon from "@mui/icons-material/Search";
import { styled, alpha } from "@mui/material/styles";
import InputBase from "@mui/material/InputBase";
import AppCard from "../../ui-components/AppCard";
import Avatar from "@mui/material/Avatar";

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
const EmployeeDirectory = () => {
  const [personName, setPersonName] = useState<string[]>([]);

  const handleChange = (event: SelectChangeEvent<typeof personName>) => {
    const {
      target: { value },
    } = event;
    setPersonName(
      // On autofill we get a stringified value.
      typeof value === "string" ? value.split(",") : value
    );
  };

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
  return (
    <Grid container spacing={0.8}>
      <Grid item md={12} xs={12}>
        <Typography variant="h6">Employee Directory</Typography>
      </Grid>
      <Grid item xs={12} md={12}>
        <Grid container>
          <Grid item md={2} xs={12}>
            <AppPaper>
              <FormControl fullWidth>
                <InputLabel id="demo-multiple-checkbox-label">
                  Department
                </InputLabel>
                <Select
                  labelId="demo-multiple-checkbox-label"
                  id="demo-multiple-checkbox"
                  multiple
                  value={personName}
                  onChange={handleChange}
                  input={<OutlinedInput label="Department" />}
                  renderValue={(selected) => selected.join(", ")}
                  MenuProps={MenuProps}
                >
                  {names.map((name) => (
                    <MenuItem key={name} value={name}>
                      <Checkbox checked={personName.indexOf(name) > -1} />
                      <ListItemText primary={name} />
                    </MenuItem>
                  ))}
                </Select>
              </FormControl>
            </AppPaper>
          </Grid>
          <Grid item md={2} xs={12}>
            <AppPaper>
              <FormControl fullWidth>
                <InputLabel id="demo-multiple-checkbox-label">
                  Location
                </InputLabel>
                <Select
                  labelId="demo-multiple-checkbox-label"
                  id="demo-multiple-checkbox"
                  multiple
                  value={personName}
                  onChange={handleChange}
                  input={<OutlinedInput label="Location" />}
                  renderValue={(selected) => selected.join(", ")}
                  MenuProps={MenuProps}
                >
                  {names.map((name) => (
                    <MenuItem key={name} value={name}>
                      <Checkbox checked={personName.indexOf(name) > -1} />
                      <ListItemText primary={name} />
                    </MenuItem>
                  ))}
                </Select>
              </FormControl>
            </AppPaper>
          </Grid>
          <Grid item md={8} xs={12}>
            <AppPaper>
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
      </Grid>
      <Grid item md={12} xs={12}>
        <Grid container spacing={0.8}>
          {[...Array(70).keys()].map((i, index) => (
            <Grid item md={3} xs={12}>
              <AppCard>
                <Stack
                  spacing={{ xs: 1, sm: 2, md: 3 }}
                  direction={{ xs: "column", md: "row" }}
                  alignItems="center"
                  // justifyContent="center"
                >
                  <Avatar
                    alt="Remy Sharp"
                    src={`https://xsgames.co/randomusers/assets/avatars/male/${
                      index + 1
                    }.jpg`}
                    sx={{ width: 80, height: 80 }}
                  />
                  <Stack>
                    <Stack sx={{ marginBottom: "1rem" }}>
                      <Typography variant="h6">Rajesh Donepudi</Typography>
                      <Typography variant="caption">
                        Software Engineer - G2
                      </Typography>
                    </Stack>
                    <Stack flexDirection="row" gap={0.8}>
                      <Typography variant="subtitle2">Department:</Typography>
                      <Typography variant="body2">.NET</Typography>
                    </Stack>
                    <Stack flexDirection="row" gap={0.8}>
                      <Typography variant="subtitle2">Location:</Typography>
                      <Typography variant="body2">R-Heights</Typography>
                    </Stack>
                    <Stack flexDirection="row" gap={0.8}>
                      <Typography variant="subtitle2">Email:</Typography>
                      <Typography variant="body2">r@r.com</Typography>
                    </Stack>
                    <Stack flexDirection="row" gap={0.8}>
                      <Typography variant="subtitle2">Mobile:</Typography>
                      <Typography variant="body2">8886014996</Typography>
                    </Stack>
                  </Stack>
                </Stack>
              </AppCard>
            </Grid>
          ))}
        </Grid>
      </Grid>
    </Grid>
  );
};

export default EmployeeDirectory;
