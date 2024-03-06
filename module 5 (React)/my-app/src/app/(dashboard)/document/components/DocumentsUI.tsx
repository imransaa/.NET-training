import Button from "@/components/Button";
import React from "react";
import { IoMdAdd } from "react-icons/io";

type Props = {
  documents: any[];
};

const DocumentsUI = (props: Props) => {
  return (
    <div className="w-full h-max-full border rounded-2xl p-5 overflow-auto shadow-md">
      <div className="flex items-center">
        <p className="text-4xl mr-auto">Documents</p>
        <button className="text-md text-white border bg-rose-500 rounded-md h-8 p-1 px-3 flex justify-center items-center gap-1 hover:bg-rose-600 active:bg-rose-700">
          <IoMdAdd />
          Create
        </button>
      </div>
      <hr className="w-full bg-black/50 my-5" />
      <div className="w-full">
        <div className="divide-y divide-solid">
          {props.documents.map((document: any, index: number) => {
            return (
              <div key={index} className="py-4 flex gap-2">
                <p className="text-lg mr-auto">{document.name}</p>
                <Button label="Edit" />
                <Button label="Delete" />
              </div>
            );
          })}
        </div>
      </div>
    </div>
  );
};

export default DocumentsUI;
