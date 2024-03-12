"use client";
import React, { useState } from "react";
import DocumentsUI from "./DocumentsUI";

type Props = {
  docTypes: any[];
};

const DocumentsContainer = (props: Props) => {
  const docs = [
    { name: "Developer Trainees", type: "spreadsheet" },
    { name: ".Net Roadmap", type: "doc" },
    { name: "Java Roadmap", type: "doc" },
  ];

  return <DocumentsUI documents={docs} docTypes={props.docTypes} />;
};

export default DocumentsContainer;
