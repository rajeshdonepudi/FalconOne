import {
  Avatar,
  IconButton,
  List,
  ListItem,
  ListItemAvatar,
  ListItemText,
} from "@mui/material";
import FolderIcon from "@mui/icons-material/Folder";
import DeleteIcon from "@mui/icons-material/Delete";
import { useEffect, useState } from "react";
import Lightbox from "yet-another-react-lightbox";
import "yet-another-react-lightbox/styles.css";
import CloseIcon from "@mui/icons-material/Close";
const AppImageList = (props: any) => {
  const [slides, setSlides] = useState([]);
  const [imagePreviewerState, setImagePreviewerState] = useState({
    visible: false,
    images: [],
  });

  const readFileAsBase64 = (file: any) =>
    new Promise((resolve, reject) => {
      const reader = new FileReader();
      reader.readAsDataURL(file);
      reader.onload = () => resolve(reader.result);
      reader.onerror = (error) => reject(error);
    });

  const GetSlides = async (imageFiles: any) => {
    let images = [];
    for (let index = 0; index < imageFiles.length; index++) {
      const imageFile = imageFiles[index];
      var result = await readFileAsBase64(imageFile);
      images.push(result);
    }
    return images.map((i) => ({ src: i }));
  };

  const GetSlides2 = async (imageFiles: any) => {
    let images = [];
    for (let index = 0; index < imageFiles.length; index++) {
      const imageFile = imageFiles[index];
      var result = await readFileAsBase64(imageFile);
      images.push({
        name: imageFile.name,
        image: result,
        index: index,
      });
    }
    return images;
  };

  useEffect(() => {
    GetSlides2(props?.images).then((res: any) => setSlides(res));
  }, [props?.images]);

  const handleImageClick = (imageInfo: any) => {
    setImagePreviewerState((prev: any) => {
      return {
        ...prev,
        visible: true,
        images: [{ src: imageInfo.image }],
      };
    });
  };

  const handlePreviewerClose = () => {
    setImagePreviewerState((prev) => {
      return {
        ...prev,
        visible: false,
        images: [],
      };
    });
  };

  const handlePostImageRemove = (name: any) => {
    const selectedImages = Array.from(props?.images) as File[];
    const postImages = selectedImages.filter((x: File) => x.name !== name);
    props?.managePostImages(postImages);
  };

  return (
    <div>
      <List>
        {slides &&
          slides.map((i: any) => {
            return (
              <ListItem
                style={{
                  cursor: "pointer",
                }}
                secondaryAction={
                  <IconButton
                    onClick={() => handlePostImageRemove(i.name)}
                    edge="end"
                    aria-label="delete"
                  >
                    <CloseIcon />
                  </IconButton>
                }
              >
                <ListItemAvatar>
                  <Avatar variant="square" src={i.image} />
                </ListItemAvatar>
                <ListItemText
                  onClick={() => handleImageClick(i)}
                  secondary={i.name + i.index}
                />
              </ListItem>
            );
          })}
      </List>
      <Lightbox
        close={handlePreviewerClose}
        open={imagePreviewerState.visible}
        slides={imagePreviewerState.images}
      />
    </div>
  );
};

export default AppImageList;
