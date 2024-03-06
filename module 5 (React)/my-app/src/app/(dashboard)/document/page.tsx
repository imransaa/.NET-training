import React from "react";
import DocumentsUI from "./components/DocumentsUI";

type Props = {};

const Documents = (props: Props) => {
  const docs = [
    { name: "Developer Trainees" },
    { name: ".Net Roadmap" },
    { name: "Java Roadmap" },
  ];

  return <DocumentsUI documents={docs} />;
};

export default Documents;
