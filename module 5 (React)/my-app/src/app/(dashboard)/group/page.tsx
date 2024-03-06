"use client";
import React, { useState } from "react";
import GroupsUI from "./components/GroupsUI";

type Props = {};

const Groups = (props: Props) => {
  const [hideModal, setHideModal] = useState({
    edit: true,
    create: true,
    delete: true,
  });

  const groups = [
    { name: "trainees" },
    { name: ".Net Developers" },
    { name: "Java Developers" },
  ];

  function onModalClose() {
    setHideModal({
      edit: true,
      create: true,
      delete: true,
    });
  }

  return (
    <GroupsUI
      groups={groups}
      hideModal={hideModal}
      onShowCreateModal={() =>
        setHideModal({
          edit: true,
          create: false,
          delete: true,
        })
      }
      onShowEditModal={() =>
        setHideModal({
          edit: false,
          create: true,
          delete: true,
        })
      }
      onShowDeleteModal={() =>
        setHideModal({
          edit: true,
          create: true,
          delete: false,
        })
      }
      onModalClose={onModalClose}
    />
  );
};

export default Groups;
