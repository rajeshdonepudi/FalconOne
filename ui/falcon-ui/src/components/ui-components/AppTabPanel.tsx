import { Box, Typography } from "@mui/material";

interface TabPanelProps {
  children?: React.ReactNode;
  index: number;
  value: number;
}

const AppTabPanel = (props: TabPanelProps) => {
  const { children, value, index, ...other } = props;

  return (
    <div
      role="tabpanel"
      hidden={value !== index}
      id={`simple-tabpanel-${index}`}
      aria-labelledby={`simple-tab-${index}`}
      {...other}
    >
      {value === index && children}
    </div>
  );
};

export default AppTabPanel;