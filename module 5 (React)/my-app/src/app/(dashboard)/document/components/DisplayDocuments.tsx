import Button from "@/components/Button";
import React from "react";

type Props = {
  documents: any[];
  onShowEditModal: any;
  onShowDeleteModal: any;
};

const DisplayDocuments = (props: Props) => {
  return (
    <div className="w-full">
      <div className="divide-y divide-solid">
        {props.documents.map((group: any, index: number) => {
          return (
            <div key={index} className="py-4 flex gap-2">
              <p className="text-lg mr-auto">{group.name}</p>
              <Button
                label="Edit"
                onClick={() => props.onShowEditModal(index)}
              />
              <Button
                label="Delete"
                onClick={() => props.onShowDeleteModal(index)}
              />
            </div>
          );
        })}
      </div>
    </div>
  );
};

export default DisplayDocuments;
