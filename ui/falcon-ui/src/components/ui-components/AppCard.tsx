import { Skeleton, SxProps, Theme } from "@mui/material";
import Paper from "@mui/material/Paper";

const AppCard = (props: any) => {
  return (
    <Paper
      elevation={0}
      className="app-card"
      sx={{
        padding: "1rem",
        height: "100%",
        width: "100%",
        // boxShadow: "0 4px 12px rgba(0, 0, 0, 0.05) !important",
      }}
    >
      {props.children}
    </Paper>
  );
};

export default AppCard;
