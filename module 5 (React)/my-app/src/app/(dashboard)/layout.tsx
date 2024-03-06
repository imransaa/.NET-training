import React from "react";
import Layout from "../layout";
import Sidebar from "./components/Sidebar";

type Props = {
  children: React.ReactNode;
};

const layout = (props: Props) => {
  return (
    <Layout>
      <div className="flex flex-row w-full h-full">
        <div
          className="flex h-full"
          style={{ width: "clamp(250px, 35%, 400px)" }}
        >
          <Sidebar />
        </div>
        <div className="h-full w-full overflow-auto p-4">{props.children}</div>
      </div>
    </Layout>
  );
};

export default layout;
