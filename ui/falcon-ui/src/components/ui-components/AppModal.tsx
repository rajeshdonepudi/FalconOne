import CloseIcon from "@mui/icons-material/Close";
import Button from "@mui/material/Button";
import Dialog from "@mui/material/Dialog";
import DialogActions from "@mui/material/DialogActions";
import DialogContent from "@mui/material/DialogContent";
import DialogTitle from "@mui/material/DialogTitle";
import IconButton from "@mui/material/IconButton";
import { styled } from "@mui/material/styles";
import * as React from "react";
import { useTranslation } from "react-i18next";

const BootstrapDialog = styled(Dialog)(({ theme }) => ({
  "& .MuiDialogContent-root": {
    padding: theme.spacing(4),
  },
  "& .MuiDialogActions-root": {
    padding: theme.spacing(3),
  },
}));

export interface DialogTitleProps {
  id: string;
  children?: React.ReactNode;
  onClose: () => void;
}

function BootstrapDialogTitle(props: DialogTitleProps) {
  const { children, onClose, ...other } = props;

  return (
    <DialogTitle sx={{ m: 0, p: 2 }} {...other}>
      {children}
      {onClose ? (
        <IconButton
          aria-label="close"
          onClick={onClose}
          sx={{
            position: "absolute",
            right: 8,
            top: 8,
            color: (theme) => theme.palette.grey[500],
          }}
        >
          <CloseIcon />
        </IconButton>
      ) : null}
    </DialogTitle>
  );
}

export default function AppModal(props: any) {
  const { t: commonLocale } = useTranslation("common");
  return (
    <div>
      <BootstrapDialog
        onClose={props?.handleClose}
        aria-labelledby="customized-dialog-title"
        open={props?.show}
      >
        <BootstrapDialogTitle
          id="customized-dialog-title"
          onClose={props?.handleClose}
        >
          {props.modalTitle}
        </BootstrapDialogTitle>
        <DialogContent dividers>{props?.children}</DialogContent>
        <DialogActions>
          <Button onClick={props?.handleClose} variant="outlined">
            {commonLocale("cancel")}
          </Button>
          <Button variant="contained" autoFocus onClick={props?.handleOk}>
            {props?.okButtonText}
          </Button>
        </DialogActions>
      </BootstrapDialog>
    </div>
  );
}
