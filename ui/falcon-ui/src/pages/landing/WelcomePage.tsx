import { Stack, Typography } from "@mui/material";
import { Link } from "react-router-dom";

const WelcomePage = () => {
  return (
    <Stack alignItems="center" sx={{ maxWidth: "450px", maxHeight: "450px" }}>
      <Stack
        sx={{ maxHeight: "225px" }}
        alignItems="center"
        flexDirection="row"
      >
        <Link to={"/login"}>
          <Typography variant="h1">Get started</Typography>
        </Link>
        <lottie-player
          src={"https://assets1.lottiefiles.com/packages/lf20_80nu1g6c.json"}
          background="transparent"
          speed="1"
          loop
          autoplay
        ></lottie-player>
      </Stack>
      <lottie-player
        src={
          "https://lottie.host/0dfd3d7e-da1b-494c-bd19-b857cd702336/qYSpvwtc0h.json"
        }
        background="transparent"
        speed="1"
        loop
        autoplay
      ></lottie-player>
    </Stack>
  );
};

export default WelcomePage;
