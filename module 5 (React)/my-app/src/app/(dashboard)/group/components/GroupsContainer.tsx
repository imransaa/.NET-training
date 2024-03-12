"use client";
import React, { useState } from "react";
import GroupsUI from "./GroupsUI";
import { createGroup, deleteGroup, editGroup } from "@/api/groupApis";
import { useRouter } from "next/navigation";
import { useAppDispatch, useAppSelector } from "@/lib/hooks";
import {
  closeGroupModal,
  selectGroupModalInput,
  selectGroupModalState,
  selectedGroup,
} from "@/lib/feature/groups/groups.slice";

type Props = {
  groups: any[];
};

const GroupsContainer = (props: Props) => {
  const dispatch = useAppDispatch();
  const hideModal = useAppSelector(selectGroupModalState);
  const group = useAppSelector(selectGroupModalInput);
  const selectGroup = useAppSelector(selectedGroup);

  const router = useRouter();

  async function onModalSubmit() {
    if (!hideModal.create) {
      await createGroup({ name: group.name })
        .then(() => dispatch(closeGroupModal()))
        .catch((err) => router.back());
    } else if (!hideModal.edit) {
      await editGroup(selectGroup.name, { name: group.name })
        .then(() => dispatch(closeGroupModal()))
        .catch((err) => router.back());
    } else {
      await deleteGroup(selectGroup.name)
        .then(() => dispatch(closeGroupModal()))
        .catch((err) => router.back());
    }

    router.refresh();
  }

  return <GroupsUI groups={props.groups} onModalSubmit={onModalSubmit} />;
};

export default GroupsContainer;
