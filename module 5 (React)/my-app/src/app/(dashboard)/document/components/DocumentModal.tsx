import Input from "@/components/Input";
import Modal from "@/components/Modal";
import React, { ChangeEvent } from "react";
import DocumentTypeSelector from "./DocumentTypeSelector";
import { useAppDispatch, useAppSelector } from "@/lib/hooks";
import {
  closeDocumentModal,
  documentModalInputChange,
  selectDocumentModalInput,
  selectDocumentModalState,
} from "@/lib/feature/documents/documents.slice";

type Props = {
  docTypes: any[];
};

const DocumentModal = (props: Props) => {
  const dispatch = useAppDispatch();
  const hideModal = useAppSelector(selectDocumentModalState);
  const document = useAppSelector(selectDocumentModalInput);

  return (
    <Modal
      hide={hideModal.edit && hideModal.delete && hideModal.create}
      onClose={() => dispatch(closeDocumentModal())}
    >
      <div className="flex flex-col h-full w-full gap-4">
        <Input
          label="Document Name"
          type="text"
          name="name"
          value={document.name}
          onChange={
            !hideModal.delete
              ? () => {}
              : (e: ChangeEvent<HTMLInputElement>) =>
                  dispatch(
                    documentModalInputChange({
                      key: e.target.name,
                      value: e.target.value,
                    })
                  )
          }
        />

        <DocumentTypeSelector docTypes={props.docTypes} />

        <button className="text-md text-white border bg-rose-500 rounded-md w-full h-12 p-1 px-3 flex justify-center items-center gap-1 hover:bg-rose-600 active:bg-rose-700">
          {!hideModal.edit && <p>Edit</p>}
          {!hideModal.delete && <p>Delete</p>}
          {!hideModal.create && <p>Create</p>}
        </button>
      </div>
    </Modal>
  );
};

export default DocumentModal;
