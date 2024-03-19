import { Box, Stack } from "@mui/material";

const NotFound = (props: any) => {
  return (
    <Stack
      sx={{
        maxWidth: "400px",
        maxHeight: "400px",
      }}
      direction="row"
      justifyContent="center"
    >
      <Box>
        <lottie-player
          src={props.url}
          background="transparent"
          speed="1"
          loop
          autoplay
        ></lottie-player>
      </Box>
    </Stack>
  );
};

export default NotFound;
