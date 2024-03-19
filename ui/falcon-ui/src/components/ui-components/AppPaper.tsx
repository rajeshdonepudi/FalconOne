import { Paper } from "@mui/material";

const AppPaper = (props: any) => {
  const paperPadding =
    props?.noPadding === true
      ? "0px"
      : props?.padding
      ? props?.padding
      : "1rem";
  const paperRightBorder =
    props?.noRightBorder === true ? "0px" : "1px solid rgba(0, 0, 0, 0.12)";
  const paperLeftBorder =
    props?.noLeftBorder === true ? "0px" : "1px solid rgba(0, 0, 0, 0.12)";
  const paperBottomBorder =
    props?.noBottomBorder === true ? "0px" : "1px solid rgba(0, 0, 0, 0.12)";
  const paperTopBorder =
    props?.noTopBorder === true ? "0px" : "1px solid rgba(0, 0, 0, 0.12)";

  return (
    <Paper
      sx={{
        margin: "0px",
        height: "100%",
        width: "auto",
        padding: paperPadding,
        borderRight: paperRightBorder,
        borderLeft: paperLeftBorder,
        borderTop: paperTopBorder,
        borderBottom: paperBottomBorder,
      }}
      variant="outlined"
      square
    >
      {props.children}
    </Paper>
  );
};

export default AppPaper;
