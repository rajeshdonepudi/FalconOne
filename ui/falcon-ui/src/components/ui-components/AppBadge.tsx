import { Chip, alpha } from "@mui/material";

const AppBadge = (props: {
  label: string;
  size?: "small" | "medium";
  color?:
    | "primary"
    | "warning"
    | "info"
    | "error"
    | "success"
    | "secondary"
    | "default";
}) => {
  var s = (theme: any) =>
    alpha(theme.palette.primary.main, theme.palette.action.activatedOpacity);
  return (
    <Chip
      sx={{
        borderRadius: "5px",
      }}
      label={props.label}
      size={props?.size ?? "small"}
      color={props?.color ?? "default"}
    />
  );
};

export default AppBadge;
