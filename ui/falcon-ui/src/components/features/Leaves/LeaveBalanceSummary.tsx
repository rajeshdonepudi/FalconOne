import AppCard from "@ui-components/AppCard";
import Typography from "@mui/material/Typography";
import Stack from "@mui/material/Stack";

const LeaveBalanceSummary = () => {
  return (
    <AppCard>
      <Typography variant="subtitle2">LEAVE BALANCES</Typography>
      <Stack pt={2} direction="row" justifyContent="space-around" spacing={2}>
        <Stack direction="column">
          <Typography variant="subtitle2">OPTIONAL</Typography>
          <Typography variant="body2">9</Typography>
        </Stack>
        <Stack direction="column">
          <Typography variant="subtitle2">EARNED</Typography>
          <Typography variant="body2">10</Typography>
        </Stack>
      </Stack>
    </AppCard>
  );
};

export default LeaveBalanceSummary;
