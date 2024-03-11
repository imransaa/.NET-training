"use client";
import Button from "@/components/Button";
import { IoMdAdd } from "react-icons/io";
import React from "react";
import Modal from "@/components/Modal";
import GroupModal from "./GroupModal";
import Input from "@/components/Input";
import { group } from "console";
import DisplayGroups from "./DisplayGroups";

type Props = {
  groups: any[];
  hideModal: any;
  group: any;
  onModalInputChange: any;
  onShowEditModal: any;
  onShowDeleteModal: any;
  onShowCreateModal: any;
  onModalClose: any;
};

const GroupsUI = (props: Props) => {
  return (
    <div className="w-full h-max-full border rounded-2xl p-5 overflow-auto shadow-md">
      <div className="flex items-center">
        <p className="text-4xl mr-auto">Groups</p>
        <button
          className="text-md text-white border bg-rose-500 rounded-md h-8 p-1 px-3 flex justify-center items-center gap-1 hover:bg-rose-600 active:bg-rose-700"
          onClick={props.onShowCreateModal}
        >
          <IoMdAdd />
          Create
        </button>
      </div>
      <hr className="w-full bg-black/50 my-5" />

      <DisplayGroups
        groups={props.groups}
        onShowEditModal={props.onShowEditModal}
        onShowDeleteModal={props.onShowDeleteModal}
      />

      <GroupModal
        group={props.group}
        hideModal={props.hideModal}
        onModalClose={props.onModalClose}
        onModalInputChange={props.onModalInputChange}
      />
    </div>
  );
};

export default GroupsUI;
