import AddPhotoAlternateOutlinedIcon from "@mui/icons-material/AddPhotoAlternateOutlined";
import Tooltip from "@mui/material/Tooltip";
import { useRef } from "react";
const AppImageUploader = (props: any) => {
  const imagePickerRef = useRef<HTMLInputElement>(null);
  return (
    <form>
      <Tooltip sx={{ cursor: "pointer" }} title="Add images">
        <AddPhotoAlternateOutlinedIcon
          color="action"
          onClick={() =>
            imagePickerRef.current && imagePickerRef.current.click()
          }
        />
      </Tooltip>
      <input
        ref={imagePickerRef}
        style={{ display: "none" }}
        type="file"
        alt=""
        multiple
        accept="image/*"
        onChange={(e) => {
          props?.imagePickerState(e?.target?.files);
        }}
      />
    </form>
  );
};

export default AppImageUploader;
