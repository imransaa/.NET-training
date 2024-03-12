import Button from "@/components/Button";
import React from "react";
import { IoMdAdd } from "react-icons/io";
import DisplayDocuments from "./DisplayDocuments";
import DocumentModal from "./DocumentModal";
import { useAppDispatch } from "@/lib/hooks";
import { openCreateDocumentModal } from "@/lib/feature/documents/documents.slice";

type Props = {
  documents: any[];
  docTypes: any[];
};

const DocumentsUI = (props: Props) => {
  const dispatch = useAppDispatch();

  return (
    <div className="w-full h-max-full border rounded-2xl p-5 overflow-auto shadow-md">
      <div className="flex items-center">
        <p className="text-4xl mr-auto">Documents</p>
        <button
          className="text-md text-white border bg-rose-500 rounded-md h-8 p-1 px-3 flex justify-center items-center gap-1 hover:bg-rose-600 active:bg-rose-700"
          onClick={() => dispatch(openCreateDocumentModal())}
        >
          <IoMdAdd />
          Create
        </button>
      </div>
      <hr className="w-full bg-black/50 my-5" />

      <DisplayDocuments documents={props.documents} />

      <DocumentModal docTypes={props.docTypes} />
    </div>
  );
};

export default DocumentsUI;
