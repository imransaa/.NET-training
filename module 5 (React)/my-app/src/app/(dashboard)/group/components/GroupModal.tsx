import Input from "@/components/Input";
import Modal from "@/components/Modal";
import {
  closeGroupModal,
  groupModalInput,
  selectGroupModalInput,
  selectGroupModalState,
} from "@/lib/feature/groups/groups.slice";
import { useAppDispatch, useAppSelector } from "@/lib/hooks";
import React, { ChangeEvent, ChangeEventHandler } from "react";

type Props = {
  onModalSubmit: any;
};

const GroupModal = (props: Props) => {
  const dispatch = useAppDispatch();
  const group = useAppSelector(selectGroupModalInput);
  const hideModal = useAppSelector(selectGroupModalState);

  return (
    <Modal
      hide={hideModal.edit && hideModal.delete && hideModal.create}
      onClose={() => dispatch(closeGroupModal())}
    >
      <div className="flex flex-col h-full w-full gap-4">
        <Input
          label="Group Name"
          type="text"
          name="name"
          value={group.name}
          onChange={
            !hideModal.delete
              ? () => {}
              : (e: ChangeEvent<HTMLInputElement>) =>
                  dispatch(groupModalInput(e.target.value))
          }
        />

        <button
          className="text-md text-white border bg-rose-500 rounded-md w-full h-12 p-1 px-3 flex justify-center items-center gap-1 hover:bg-rose-600 active:bg-rose-700"
          onClick={props.onModalSubmit}
        >
          {!hideModal.edit && <p>Edit</p>}
          {!hideModal.delete && <p>Delete</p>}
          {!hideModal.create && <p>Create</p>}
        </button>
      </div>
    </Modal>
  );
};

export default GroupModal;
