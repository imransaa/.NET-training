"use client";
import React, { useState } from "react";
import SidebarUI from "./SidebarUI";
import { useRouter } from "next/navigation";

type Props = {};

const Sidebar = (props: Props) => {
  const [selected, setSelected] = useState(0);

  const router = useRouter();

  const user = "Saad Imran";

  const options = [
    {
      name: "Groups",
      onOptionClick: () => {
        setSelected(0);
        router.push("/group");
      },
    },
    {
      name: "Documents",
      onOptionClick: () => {
        setSelected(1);
        router.push("/document");
      },
    },
  ];

  return <SidebarUI user={user} options={options} selected={selected} />;
};

export default Sidebar;
