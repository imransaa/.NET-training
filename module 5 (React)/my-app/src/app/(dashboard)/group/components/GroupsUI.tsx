"use client";
import Button from "@/components/Button";
import { IoMdAdd } from "react-icons/io";
import React from "react";
import Modal from "@/components/Modal";

type Props = {
  groups: any[];
  hideModal: any;
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
      <div className="w-full">
        <div className="divide-y divide-solid">
          {props.groups.map((group: any, index: number) => {
            return (
              <div key={index} className="py-4 flex gap-2">
                <p className="text-lg mr-auto">{group.name}</p>
                <Button label="Edit" onClick={props.onShowEditModal} />
                <Button label="Delete" onClick={props.onShowDeleteModal} />
              </div>
            );
          })}
        </div>
      </div>

      <Modal
        hide={
          props.hideModal.edit &&
          props.hideModal.delete &&
          props.hideModal.create
        }
        onClose={props.onModalClose}
      >
        {!props.hideModal.edit && <p>Edit</p>}
        {!props.hideModal.delete && <p>Delete</p>}
        {!props.hideModal.create && <p>Create</p>}
      </Modal>
    </div>
  );
};

export default GroupsUI;
