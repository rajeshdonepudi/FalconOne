import {
  Box,
  Button,
  Divider,
  Grid,
  Paper,
  Stack,
  Tab,
  Tabs,
  Typography,
} from "@mui/material";
import AppTabPanel from "@ui-components/AppTabPanel";
import { useState } from "react";
import BadgeOutlinedIcon from "@mui/icons-material/BadgeOutlined";
import WorkOutlineOutlinedIcon from "@mui/icons-material/WorkOutlineOutlined";
import FolderOutlinedIcon from "@mui/icons-material/FolderOutlined";
import SchoolOutlinedIcon from "@mui/icons-material/SchoolOutlined";
import DesignServicesOutlinedIcon from "@mui/icons-material/DesignServicesOutlined";
import LockIcon from "@mui/icons-material/Lock";
import IconStyles from "../../../styles/IconStyles";
import AddOutlinedIcon from "@mui/icons-material/AddOutlined";
const ViewDocuments = () => {
  const iconStyles = IconStyles();
  const [value, setValue] = useState(0);

  const handleChange = (event: React.SyntheticEvent, newValue: number) => {
    setValue(newValue);
  };

  return (
    <Grid container spacing={0.8}>
      <Grid item md={12} xs={12} sx={{ margin: "1rem" }}>
        <Typography variant="h6">Employee Documents</Typography>
      </Grid>
      <Grid item md={12} xs={12}>
        <Grid container spacing={0.8}>
          <Grid item md={2} xs={12}>
            <Paper variant="outlined" square>
              <Stack>
                <Stack sx={{ padding: "0.6rem" }} alignItems="center">
                  <Typography justifySelf="center" variant="subtitle2">
                    EMPLOYEE DOCUMENT FOLDERS
                  </Typography>
                </Stack>
                <Stack>
                  <Divider />
                </Stack>
                <Stack sx={{ height: 300, alignItems: "center" }}>
                  <Tabs
                    orientation="vertical"
                    variant="scrollable"
                    value={value}
                    onChange={handleChange}
                    aria-label="Vertical tabs example"
                    sx={{
                      borderColor: "divider",
                    }}
                  >
                    <Tab
                      icon={<BadgeOutlinedIcon />}
                      iconPosition="start"
                      label="Identity Docs"
                    />
                    <Tab
                      icon={<WorkOutlineOutlinedIcon />}
                      iconPosition="start"
                      label="Previous Experience"
                    />
                    <Tab
                      icon={<FolderOutlinedIcon />}
                      iconPosition="start"
                      label="Employee Letters"
                    />
                    <Tab
                      icon={<SchoolOutlinedIcon />}
                      iconPosition="start"
                      label="Degrees & Certification"
                    />
                    <Tab
                      icon={<FolderOutlinedIcon />}
                      iconPosition="start"
                      label="Offer Letters"
                    />
                    <Tab
                      icon={<DesignServicesOutlinedIcon />}
                      iconPosition="start"
                      label="Signatures"
                    />
                  </Tabs>
                </Stack>
              </Stack>
            </Paper>
          </Grid>
          <Grid item md={7} xs={12}>
            <AppTabPanel value={value} index={0}>
              <Grid container spacing={0.8}>
                <Grid item md={12} xs={12}>
                  <Paper variant="outlined" square>
                    <Stack>
                      <Stack
                        sx={{ margin: 1 }}
                        gap={0.8}
                        flexDirection="row"
                        alignItems="center"
                      >
                        <BadgeOutlinedIcon className={iconStyles.icon} />
                        <Stack>
                          <Typography variant="subtitle2">
                            Identity Docs
                          </Typography>
                          <Typography variant="caption">
                            An identity document is any document which may be
                            used to verifiy aspects of a personal identity
                          </Typography>
                        </Stack>
                      </Stack>
                      <Divider />
                      <Box>
                        <Stack
                          gap={0.8}
                          flexDirection="row"
                          alignItems="center"
                          justifyContent="center"
                          margin={2}
                        >
                          <LockIcon />
                          <Stack>
                            <Typography variant="subtitle2">SECURE</Typography>
                            <Typography
                              sx={{ color: "primary.main" }}
                              variant="caption"
                            >
                              Only selected people can view this information
                            </Typography>
                          </Stack>
                        </Stack>
                      </Box>
                    </Stack>
                  </Paper>
                </Grid>
                <Grid item md={12} xs={12}>
                  <Paper variant="outlined" square>
                    <Grid container>
                      <Grid item md={12} xs={12} sx={{ padding: "1rem" }}>
                        <Typography variant="subtitle2">
                          Driving License
                        </Typography>
                      </Grid>
                      <Grid item md={12} xs={12}>
                        <Divider />
                      </Grid>
                      <Grid item md={12} xs={12}>
                        <Box>
                          <Stack
                            gap={0.8}
                            flexDirection="row"
                            alignItems="center"
                            justifyContent="center"
                            margin={2}
                          >
                            <Button
                              variant="outlined"
                              startIcon={<AddOutlinedIcon />}
                            >
                              Add details
                            </Button>
                          </Stack>
                        </Box>
                      </Grid>
                    </Grid>
                  </Paper>
                </Grid>
                <Grid item md={12} xs={12}>
                  <Paper variant="outlined" square>
                    <Grid container>
                      <Grid item md={12} xs={12} sx={{ padding: "1rem" }}>
                        <Typography variant="subtitle2">PAN Card</Typography>
                      </Grid>
                      <Grid item md={12} xs={12}>
                        <Divider />
                      </Grid>
                      <Grid item md={12} xs={12}>
                        <Box>
                          <Stack
                            gap={0.8}
                            flexDirection="row"
                            alignItems="center"
                            justifyContent="center"
                            margin={2}
                          >
                            <Button
                              variant="outlined"
                              startIcon={<AddOutlinedIcon />}
                            >
                              Add details
                            </Button>
                          </Stack>
                        </Box>
                      </Grid>
                    </Grid>
                  </Paper>
                </Grid>
                <Grid item md={12} xs={12}>
                  <Paper variant="outlined" square>
                    <Grid container>
                      <Grid item md={12} xs={12} sx={{ padding: "1rem" }}>
                        <Typography variant="subtitle2">Passport</Typography>
                      </Grid>
                      <Grid item md={12} xs={12}>
                        <Divider />
                      </Grid>
                      <Grid item md={12} xs={12}>
                        <Box>
                          <Stack
                            gap={0.8}
                            flexDirection="row"
                            alignItems="center"
                            justifyContent="center"
                            margin={2}
                          >
                            <Button
                              variant="outlined"
                              startIcon={<AddOutlinedIcon />}
                            >
                              Add details
                            </Button>
                          </Stack>
                        </Box>
                      </Grid>
                    </Grid>
                  </Paper>
                </Grid>
                <Grid item md={12} xs={12}>
                  <Paper variant="outlined" square>
                    <Grid container>
                      <Grid item md={12} xs={12} sx={{ padding: "1rem" }}>
                        <Typography variant="subtitle2">Aadhaar</Typography>
                      </Grid>
                      <Grid item md={12} xs={12}>
                        <Divider />
                      </Grid>
                      <Grid item md={12} xs={12}>
                        <Box>
                          <Stack
                            gap={0.8}
                            flexDirection="row"
                            alignItems="center"
                            justifyContent="center"
                            margin={2}
                          >
                            <Button
                              variant="outlined"
                              startIcon={<AddOutlinedIcon />}
                            >
                              Add details
                            </Button>
                          </Stack>
                        </Box>
                      </Grid>
                    </Grid>
                  </Paper>
                </Grid>
                <Grid item md={12} xs={12}>
                  <Paper variant="outlined" square>
                    <Grid container>
                      <Grid item md={12} xs={12} sx={{ padding: "1rem" }}>
                        <Typography variant="subtitle2">Voter Id</Typography>
                      </Grid>
                      <Grid item md={12} xs={12}>
                        <Divider />
                      </Grid>
                      <Grid item md={12} xs={12}>
                        <Box>
                          <Stack
                            gap={0.8}
                            flexDirection="row"
                            alignItems="center"
                            justifyContent="center"
                            margin={2}
                          >
                            <Button
                              variant="outlined"
                              startIcon={<AddOutlinedIcon />}
                            >
                              Add details
                            </Button>
                          </Stack>
                        </Box>
                      </Grid>
                    </Grid>
                  </Paper>
                </Grid>
              </Grid>
            </AppTabPanel>
            <AppTabPanel value={value} index={1}>
              <Grid container spacing={0.8}>
                <Grid item md={12} xs={12}>
                  <Paper variant="outlined" square>
                    <Stack>
                      <Stack
                        sx={{ margin: 1 }}
                        gap={0.8}
                        flexDirection="row"
                        alignItems="center"
                      >
                        <WorkOutlineOutlinedIcon className={iconStyles.icon} />
                        <Stack>
                          <Typography variant="subtitle2">
                            Previous Experience
                          </Typography>
                          <Typography variant="caption">
                            Previous experience documents are required to know
                            necessary details about an employee's previous work
                            experience.
                          </Typography>
                        </Stack>
                      </Stack>
                      <Divider />
                      <Box>
                        <Stack
                          gap={0.8}
                          flexDirection="row"
                          alignItems="center"
                          justifyContent="center"
                          margin={2}
                        >
                          <LockIcon />
                          <Stack>
                            <Typography variant="subtitle2">SECURE</Typography>
                            <Typography
                              sx={{ color: "primary.main" }}
                              variant="caption"
                            >
                              Only selected people can view this information
                            </Typography>
                          </Stack>
                        </Stack>
                      </Box>
                    </Stack>
                  </Paper>
                </Grid>
                <Grid item md={12} xs={12}>
                  <Paper variant="outlined" square>
                    <Grid container>
                      <Grid item md={12} xs={12} sx={{ padding: "1rem" }}>
                        <Typography variant="subtitle2">
                          Previous Experience
                        </Typography>
                      </Grid>
                      <Grid item md={12} xs={12}>
                        <Divider />
                      </Grid>
                      <Grid item md={12} xs={12}>
                        <Box>
                          <Stack
                            gap={0.8}
                            flexDirection="row"
                            alignItems="center"
                            justifyContent="center"
                            margin={2}
                          >
                            <Button
                              variant="outlined"
                              startIcon={<AddOutlinedIcon />}
                            >
                              Add details
                            </Button>
                          </Stack>
                        </Box>
                      </Grid>
                    </Grid>
                  </Paper>
                </Grid>
                <Grid item md={12} xs={12}>
                  <Paper variant="outlined" square>
                    <Grid container>
                      <Grid item md={12} xs={12} sx={{ padding: "1rem" }}>
                        <Typography variant="subtitle2">Resume</Typography>
                      </Grid>
                      <Grid item md={12} xs={12}>
                        <Divider />
                      </Grid>
                      <Grid item md={12} xs={12}>
                        <Box>
                          <Stack
                            gap={0.8}
                            flexDirection="row"
                            alignItems="center"
                            justifyContent="center"
                            margin={2}
                          >
                            <Button
                              variant="outlined"
                              startIcon={<AddOutlinedIcon />}
                            >
                              Add details
                            </Button>
                          </Stack>
                        </Box>
                      </Grid>
                    </Grid>
                  </Paper>
                </Grid>
              </Grid>
            </AppTabPanel>
            <AppTabPanel value={value} index={2}>
              <Grid container spacing={0.8}>
                <Grid item md={12} xs={12}>
                  <Paper variant="outlined" square>
                    <Stack>
                      <Stack
                        sx={{ margin: 1 }}
                        gap={0.8}
                        flexDirection="row"
                        alignItems="center"
                      >
                        <FolderOutlinedIcon className={iconStyles.icon} />
                        <Stack>
                          <Typography variant="subtitle2">
                            Employee Letters
                          </Typography>
                          <Typography variant="caption">
                            The folder contains all generated employee letters.
                          </Typography>
                        </Stack>
                      </Stack>
                      <Divider />
                      <Box>
                        <Stack
                          gap={0.8}
                          flexDirection="row"
                          alignItems="center"
                          justifyContent="center"
                          margin={2}
                        >
                          <LockIcon />
                          <Stack>
                            <Typography variant="subtitle2">SECURE</Typography>
                            <Typography
                              sx={{ color: "primary.main" }}
                              variant="caption"
                            >
                              Only selected people can view this information
                            </Typography>
                          </Stack>
                        </Stack>
                      </Box>
                    </Stack>
                  </Paper>
                </Grid>
              </Grid>
            </AppTabPanel>
            <AppTabPanel value={value} index={3}>
              <Grid container spacing={0.8}>
                <Grid item md={12} xs={12}>
                  <Paper variant="outlined" square>
                    <Stack>
                      <Stack
                        sx={{ margin: 1 }}
                        gap={0.8}
                        flexDirection="row"
                        alignItems="center"
                      >
                        <SchoolOutlinedIcon className={iconStyles.icon} />
                        <Stack>
                          <Typography variant="subtitle2">
                            Degrees & Certificates
                          </Typography>
                          <Typography variant="caption">
                            This section contain details about all the Degrees &
                            Certificate of an employee.
                          </Typography>
                        </Stack>
                      </Stack>
                      <Divider />
                      <Box>
                        <Stack
                          gap={0.8}
                          flexDirection="row"
                          alignItems="center"
                          justifyContent="center"
                          margin={2}
                        >
                          <LockIcon />
                          <Stack>
                            <Typography variant="subtitle2">SECURE</Typography>
                            <Typography
                              sx={{ color: "primary.main" }}
                              variant="caption"
                            >
                              Only selected people can view this information
                            </Typography>
                          </Stack>
                        </Stack>
                      </Box>
                    </Stack>
                  </Paper>
                </Grid>
                <Grid item md={12} xs={12}>
                  <Paper variant="outlined" square>
                    <Grid container>
                      <Grid item md={12} xs={12} sx={{ padding: "1rem" }}>
                        <Typography variant="subtitle2">
                          Previous Experience
                        </Typography>
                      </Grid>
                      <Grid item md={12} xs={12}>
                        <Divider />
                      </Grid>
                      <Grid item md={12} xs={12}>
                        <Box>
                          <Stack
                            gap={0.8}
                            flexDirection="row"
                            alignItems="center"
                            justifyContent="center"
                            margin={2}
                          >
                            <Button
                              variant="outlined"
                              startIcon={<AddOutlinedIcon />}
                            >
                              Add details
                            </Button>
                          </Stack>
                        </Box>
                      </Grid>
                    </Grid>
                  </Paper>
                </Grid>
                <Grid item md={12} xs={12}>
                  <Paper variant="outlined" square>
                    <Grid container>
                      <Grid item md={12} xs={12} sx={{ padding: "1rem" }}>
                        <Typography variant="subtitle2">Resume</Typography>
                      </Grid>
                      <Grid item md={12} xs={12}>
                        <Divider />
                      </Grid>
                      <Grid item md={12} xs={12}>
                        <Box>
                          <Stack
                            gap={0.8}
                            flexDirection="row"
                            alignItems="center"
                            justifyContent="center"
                            margin={2}
                          >
                            <Button
                              variant="outlined"
                              startIcon={<AddOutlinedIcon />}
                            >
                              Add details
                            </Button>
                          </Stack>
                        </Box>
                      </Grid>
                    </Grid>
                  </Paper>
                </Grid>
              </Grid>
            </AppTabPanel>
            <AppTabPanel value={value} index={4}>
              <Grid container spacing={0.8}>
                <Grid item md={12} xs={12}>
                  <Paper variant="outlined" square>
                    <Stack>
                      <Stack
                        sx={{ margin: 1 }}
                        gap={0.8}
                        flexDirection="row"
                        alignItems="center"
                      >
                        <FolderOutlinedIcon className={iconStyles.icon} />
                        <Stack>
                          <Typography variant="subtitle2">
                            Offer Letters
                          </Typography>
                          <Typography variant="caption">
                            This section contains employee offer letters.
                          </Typography>
                        </Stack>
                      </Stack>
                      <Divider />
                      <Box>
                        <Stack
                          gap={0.8}
                          flexDirection="row"
                          alignItems="center"
                          justifyContent="center"
                          margin={2}
                        >
                          <LockIcon />
                          <Stack>
                            <Typography variant="subtitle2">SECURE</Typography>
                            <Typography
                              sx={{ color: "primary.main" }}
                              variant="caption"
                            >
                              Only selected people can view this information
                            </Typography>
                          </Stack>
                        </Stack>
                      </Box>
                    </Stack>
                  </Paper>
                </Grid>
              </Grid>
            </AppTabPanel>
            <AppTabPanel value={value} index={5}>
              <Grid container spacing={0.8}>
                <Grid item md={12} xs={12}>
                  <Paper variant="outlined" square>
                    <Stack>
                      <Stack
                        sx={{ margin: 1 }}
                        gap={0.8}
                        flexDirection="row"
                        alignItems="center"
                      >
                        <DesignServicesOutlinedIcon
                          className={iconStyles.icon}
                        />
                        <Stack>
                          <Typography variant="subtitle2">
                            Signatures
                          </Typography>
                          <Typography variant="caption">
                            Signatures can be used to digitally sign documents.
                          </Typography>
                        </Stack>
                      </Stack>
                      <Divider />
                      <Box>
                        <Stack
                          gap={0.8}
                          flexDirection="row"
                          alignItems="center"
                          justifyContent="center"
                          margin={2}
                        >
                          <LockIcon />
                          <Stack>
                            <Typography variant="subtitle2">SECURE</Typography>
                            <Typography
                              sx={{ color: "primary.main" }}
                              variant="caption"
                            >
                              Only selected people can view this information
                            </Typography>
                          </Stack>
                        </Stack>
                      </Box>
                    </Stack>
                  </Paper>
                </Grid>
              </Grid>
            </AppTabPanel>
          </Grid>
        </Grid>
      </Grid>
    </Grid>
  );
};

export default ViewDocuments;
