"use client";
import React, { useState } from "react";
import GroupsUI from "./components/GroupsUI";

type Props = {
  docTypes: any[];
};

const Groups = (props: Props) => {
  const [hideModal, setHideModal] = useState({
    edit: true,
    create: true,
    delete: true,
  });

  const [group, setGroup] = useState({ id: 0, name: "" });

  const groups = [
    { id: 1, name: "trainees" },
    { id: 2, name: ".Net Developers" },
    { id: 3, name: "Java Developers" },
  ];

  function onModalClose() {
    setHideModal({
      edit: true,
      create: true,
      delete: true,
    });
  }

  function onShowCreateModal() {
    setGroup({ id: 0, name: "" });
    setHideModal({
      edit: true,
      create: false,
      delete: true,
    });
  }

  function onShowEditModal(index: number) {
    setGroup(groups[index]);
    setHideModal({
      edit: false,
      create: true,
      delete: true,
    });
  }

  function onShowDeleteModal(index: number) {
    setGroup(groups[index]);
    setHideModal({
      edit: true,
      create: true,
      delete: false,
    });
  }

  function onModalInputChange(e: any) {
    setGroup((prevGroup) => ({
      ...prevGroup,
      [e.target.name]: e.target.value,
    }));
  }

  return (
    <GroupsUI
      groups={groups}
      hideModal={hideModal}
      group={group}
      onModalInputChange={onModalInputChange}
      onShowCreateModal={onShowCreateModal}
      onShowEditModal={onShowEditModal}
      onShowDeleteModal={onShowDeleteModal}
      onModalClose={onModalClose}
    />
  );
};

export default Groups;
