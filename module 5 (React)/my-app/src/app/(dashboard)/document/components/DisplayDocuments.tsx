import Button from "@/components/Button";
import {
  openDeleteDocumentModal,
  openEditDocumentModal,
} from "@/lib/feature/documents/documents.slice";
import { useAppDispatch } from "@/lib/hooks";
import React from "react";

type Props = {
  documents: any[];
};

const DisplayDocuments = (props: Props) => {
  const dispatch = useAppDispatch();

  return (
    <div className="w-full">
      <div className="divide-y divide-solid">
        {props.documents.map((group: any, index: number) => {
          return (
            <div key={index} className="py-4 flex gap-2">
              <p className="text-lg mr-auto">{group.name}</p>
              <Button
                label="Edit"
                onClick={() => dispatch(openEditDocumentModal(group))}
              />
              <Button
                label="Delete"
                onClick={() => dispatch(openDeleteDocumentModal(group))}
              />
            </div>
          );
        })}
      </div>
    </div>
  );
};

export default DisplayDocuments;
