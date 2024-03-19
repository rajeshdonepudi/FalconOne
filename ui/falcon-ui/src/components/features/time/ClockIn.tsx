import Button from "@mui/material/Button";
import Stack from "@mui/material/Stack";
import ClockInImage from "../../../assets/Features/ClockIn/clockinbg1.jpg";
import ScheduleOutlinedIcon from "@mui/icons-material/ScheduleOutlined";
import AccessTimeOutlinedIcon from "@mui/icons-material/AccessTimeOutlined";
const ClockIn = () => {
  const divStyle = {
    background: `url(${ClockInImage})`,
    backgroundRepeat: "no-repeat",
    height: "120px",
    opacity: "0.9",
    backgroundPosition: "center",
    padding: "0.5rem",
    backgroundSize: "cover",
  };

  return (
    <Stack style={divStyle} gap="0.4rem" direction="row" alignItems="flex-end">
      <Button
        size="small"
        variant="contained"
        endIcon={<ScheduleOutlinedIcon />}
      >
        Clock IN
      </Button>
      <Button
        size="small"
        variant="contained"
        endIcon={<AccessTimeOutlinedIcon />}
      >
        Clock out
      </Button>
    </Stack>
  );
};

export default ClockIn;
