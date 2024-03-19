import Typography from "@mui/material/Typography";
import moment from "moment";
import { useEffect, useState } from "react";

const AppLiveClock = () => {
  const [state, setState] = useState<string>();
  useEffect(() => {
    const intervalID = setInterval(() => {
      setState(() => moment().format("LTS"));
    }, 1000);

    return () => clearInterval(intervalID);
  }, []);
  return <Typography variant="body2">{state}</Typography>;
};

export default AppLiveClock;
