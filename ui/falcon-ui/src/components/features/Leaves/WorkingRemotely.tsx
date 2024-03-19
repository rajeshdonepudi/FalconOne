import { Avatar, Stack, Typography } from "@mui/material";
import AppCard from "@ui-components/AppCard";

const WorkingRemotely = () => {
  return (
    <AppCard>
      <Stack gap={0.8}>
        <Typography variant="subtitle2">ON LEAVE TODAY</Typography>
        <Stack direction="row" spacing={2}>
          <Avatar alt="Remy Sharp" src="/static/images/avatar/1.jpg" />
          <Avatar alt="Travis Howard" src="/static/images/avatar/2.jpg" />
          <Avatar alt="Cindy Baker" src="/static/images/avatar/3.jpg" />
        </Stack>
      </Stack>
    </AppCard>
  );
};

export default WorkingRemotely;
