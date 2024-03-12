"use client";
import { IoMdAdd } from "react-icons/io";
import React from "react";
import GroupModal from "./GroupModal";
import DisplayGroups from "./DisplayGroups";
import { useAppDispatch } from "@/lib/hooks";
import { openCreateGroupModal } from "@/lib/feature/groups/groups.slice";

type Props = {
  groups: any[];
  onModalSubmit: any;
};

const GroupsUI = (props: Props) => {
  const dispatch = useAppDispatch();

  return (
    <div className="w-full h-max-full border rounded-2xl p-5 overflow-auto shadow-md">
      <div className="flex items-center">
        <p className="text-4xl mr-auto">Groups</p>
        <button
          className="text-md text-white border bg-rose-500 rounded-md h-8 p-1 px-3 flex justify-center items-center gap-1 hover:bg-rose-600 active:bg-rose-700"
          onClick={() => dispatch(openCreateGroupModal())}
        >
          <IoMdAdd />
          Create
        </button>
      </div>
      <hr className="w-full bg-black/50 my-5" />

      <DisplayGroups groups={props.groups} />

      <GroupModal onModalSubmit={props.onModalSubmit} />
    </div>
  );
};

export default GroupsUI;
