import { Box, Button, Grid, Stack, Typography } from "@mui/material";
import AppCard from "@ui-components/AppCard";
import Avatar from "@mui/material/Avatar";
import ThumbUpOffAltOutlinedIcon from "@mui/icons-material/ThumbUpOffAltOutlined";
import ChatOutlinedIcon from "@mui/icons-material/ChatOutlined";
import SimpleImageSlider from "react-simple-image-slider";
import AddReactionOutlinedIcon from "@mui/icons-material/AddReactionOutlined";
const Test = () => {
  return (
    <Box>
      <AppCard>
        <Grid container spacing={0.8}>
          <Grid item md={12} xs={12}>
            <Stack gap={1} flexDirection="row" alignItems="center">
              <Avatar
                alt="Remy Sharp"
                src="https://xsgames.co/randomusers/assets/avatars/male/1.jpg"
              />
              <Stack>
                <Stack gap={1} flexDirection="row" alignItems="center">
                  <Typography variant="body2">Rajesh Donepudi</Typography>
                  <Typography variant="caption">created a post</Typography>
                </Stack>
                <Typography variant="caption">a month ago</Typography>
              </Stack>
            </Stack>
          </Grid>
          <Grid item md={12} xs={12}>
            <Typography variant="body2">
              Lorem ipsum dolor sit amet consectetur adipisicing elit. Ipsum hic
              eligendi quo. Magnam odit quam iure, amet laborum magni doloribus.
            </Typography>
          </Grid>
          <Grid
            item
            md={12}
            sm={12}
            xs={12}
            style={{ position: "relative", height: "400px" }}
          >
            <SimpleImageSlider
              style={{ display: "flex" }}
              width={"100%"}
              height={"100%"}
              useGPURender={true}
              images={[
                {
                  url: "https://images5.alphacoders.com/568/568499.jpg",
                },
                {
                  url: "https://c4.wallpaperflare.com/wallpaper/764/505/66/baby-groot-4k-hd-superheroes-wallpaper-preview.jpg",
                },
                {
                  url: "https://a-static.besthdwallpaper.com/colorful-beach-view-wallpaper-2048x1152-10917_49.jpg",
                },
              ]}
              showBullets={false}
              showNavs={true}
            />
          </Grid>
          <Grid item md={12} xs={12}>
            <Grid container spacing={0.8}>
              <Grid item md={3} xs={6}>
                <Button startIcon={<ThumbUpOffAltOutlinedIcon />}></Button>
              </Grid>
              <Grid item md={3} xs={6}>
                <Button startIcon={<ChatOutlinedIcon />}></Button>
              </Grid>
              <Grid item md={3} xs={6} justifyContent="center">
                <Button startIcon={<AddReactionOutlinedIcon />}></Button>
              </Grid>
              <Grid item md={3} xs={6}>
                <Stack height="100%" justifyContent="center">
                  <Typography variant="body2">0 Comments </Typography>
                </Stack>
              </Grid>
            </Grid>
          </Grid>
        </Grid>
      </AppCard>
    </Box>
  );
};

export default Test;
