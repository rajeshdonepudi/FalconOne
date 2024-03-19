import { Box, CircularProgress } from "@mui/material";
import { Suspense } from "react";

const AppLazyLoader = (props: any) => {
  return (
    <Suspense
      fallback={
        <Box
          sx={{
            width: "100%",
            display: "flex",
            justifyContent: "center",
          }}
        >
          <CircularProgress />
        </Box>
      }
    >
      {props.children}
    </Suspense>
  );
};

export default AppLazyLoader;
