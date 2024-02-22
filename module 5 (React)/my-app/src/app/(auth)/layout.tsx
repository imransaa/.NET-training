import React from "react";
import Layout from "../layout";

type Props = {
    children: React.ReactNode;
};

const layout = (props: Props) => {
  return (
    <Layout>
      <div className="flex flex-col justify-center items-center w-full h-full bg-slate-50">
        <div className="border px-28 py-20 rounded-3xl shadow-xl bg-white w-[32rem]">
          {props.children}
        </div>
      </div>
    </Layout>
  );
};

export default layout;
