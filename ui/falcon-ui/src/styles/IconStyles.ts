import { Theme } from "@mui/material/styles";
import { makeStyles } from "@mui/styles";
import "react-toastify/dist/ReactToastify.css";

const IconStyles = makeStyles((theme: Theme) => ({
  icon: {
    backgroundColor:
      theme.palette.mode === "dark"
        ? theme.palette.grey[700]
        : theme.palette.primary.main,
    zIndex: 1,
    color: "#fff",
    width: 40,
    height: 40,
    padding: 8,
    display: "flex",
    borderRadius: "50%",
    justifyContent: "center",
    alignItems: "center",
  },
}));

export default IconStyles;
