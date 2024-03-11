"use client";
import React, { useState } from "react";
import DocumentsUI from "./DocumentsUI";

type Props = {
  docTypes: any[];
};

const DocumentsContainer = (props: Props) => {
  const [hideModal, setHideModal] = useState({
    edit: true,
    create: true,
    delete: true,
  });

  const [document, setDocument] = useState({ id: 0, name: "", type: "" });

  const docs = [
    { id: 0, name: "Developer Trainees", type: "spreadsheet" },
    { id: 1, name: ".Net Roadmap", type: "doc" },
    { id: 2, name: "Java Roadmap", type: "doc" },
  ];

  function onModalClose() {
    setHideModal({
      edit: true,
      create: true,
      delete: true,
    });
  }

  function onShowCreateModal() {
    setDocument({ id: 0, name: "", type: "" });
    setHideModal({
      edit: true,
      create: false,
      delete: true,
    });
  }

  function onShowEditModal(index: number) {
    setDocument(docs[index]);
    setHideModal({
      edit: false,
      create: true,
      delete: true,
    });
  }

  function onShowDeleteModal(index: number) {
    setDocument(docs[index]);
    setHideModal({
      edit: true,
      create: true,
      delete: false,
    });
  }

  function onModalInputChange(e: any) {
    setDocument((prevGroup) => ({
      ...prevGroup,
      [e.target.name]: e.target.value,
    }));
  }

  return (
    <DocumentsUI
      documents={docs}
      docTypes={props.docTypes}
      hideModal={hideModal}
      document={document}
      onModalInputChange={onModalInputChange}
      onShowCreateModal={onShowCreateModal}
      onShowEditModal={onShowEditModal}
      onShowDeleteModal={onShowDeleteModal}
      onModalClose={onModalClose}
    />
  );
};

export default DocumentsContainer;
