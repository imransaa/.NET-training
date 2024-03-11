import Input from "@/components/Input";
import Modal from "@/components/Modal";
import React from "react";

type Props = {
  hideModal: any;
  group: any;
  onModalInputChange: any;
  onModalClose: any;
};

const GroupModal = (props: Props) => {
  return (
    <Modal
      hide={
        props.hideModal.edit && props.hideModal.delete && props.hideModal.create
      }
      onClose={props.onModalClose}
    >
      <div className="flex flex-col h-full w-full gap-4">
        <Input
          label="Group Name"
          type="text"
          name="name"
          value={props.group?.name}
          onChange={
            !props.hideModal.delete ? () => {} : props.onModalInputChange
          }
        />

        <button className="text-md text-white border bg-rose-500 rounded-md w-full h-12 p-1 px-3 flex justify-center items-center gap-1 hover:bg-rose-600 active:bg-rose-700">
          {!props.hideModal.edit && <p>Edit</p>}
          {!props.hideModal.delete && <p>Delete</p>}
          {!props.hideModal.create && <p>Create</p>}
        </button>
      </div>
    </Modal>
  );
};

export default GroupModal;
