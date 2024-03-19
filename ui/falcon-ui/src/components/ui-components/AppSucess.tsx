import { Box, Stack, Typography } from "@mui/material";
import React from "react";

const AppSucess = (props: any) => {
  return (
    <Stack direction="column" justifyContent="center" alignItems="center">
      <Typography sx={{ fontWeight: "bold", fontSize: "2.5rem" }}>
        {props.message}
      </Typography>
      <Box sx={{ maxWidth: "400px", maxHeight: "400px" }}>
        <lottie-player
          src="https://assets1.lottiefiles.com/packages/lf20_jbrw3hcz.json"
          background="transparent"
          speed="1"
          loop
          autoplay
        ></lottie-player>
      </Box>
    </Stack>
  );
};

export default AppSucess;
