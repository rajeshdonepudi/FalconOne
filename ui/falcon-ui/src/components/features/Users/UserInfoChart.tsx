import { Stack } from "@mui/material";
import { useEffect, useState } from "react";
import { Pie, PieChart, ResponsiveContainer, Tooltip } from "recharts";

const UserInfoChart = () => {
  const [h, seth] = useState(0);

  const data01 = [
    { name: "Group A", value: 400 },
    { name: "Group B", value: 300 },
    { name: "Group C", value: 300 },
    { name: "Group D", value: 200 },
    { name: "Group E", value: 278 },
    { name: "Group F", value: 189 },
  ];

  const data02 = [
    { name: "Group A", value: 2400 },
    { name: "Group B", value: 4567 },
    { name: "Group C", value: 1398 },
    { name: "Group D", value: 9800 },
    { name: "Group E", value: 3908 },
    { name: "Group F", value: 4800 },
  ];

  useEffect(() => {
    seth(
      document
        .getElementsByClassName("user-info-parent")[0]
        ?.getBoundingClientRect()?.width
    );
  }, [window.onresize]);
  return (
    <PieChart width={h} height={250}>
      <Pie
        dataKey="value"
        isAnimationActive={true}
        data={data01}
        cx="50%"
        cy="50%"
        outerRadius={80}
        fill="#8884d8"
        label
      />
      <Tooltip />
    </PieChart>
  );
};

export default UserInfoChart;
