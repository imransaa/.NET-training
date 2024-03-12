import {
  documentModalInputChange,
  selectDocumentModalInput,
  selectDocumentModalState,
} from "@/lib/feature/documents/documents.slice";
import { useAppDispatch, useAppSelector } from "@/lib/hooks";
import React, { ChangeEvent } from "react";

type Props = {
  docTypes: any[];
};

const DocumentTypeSelector = (props: Props) => {
  const dispatch = useAppDispatch();
  const hideModal = useAppSelector(selectDocumentModalState);
  const document = useAppSelector(selectDocumentModalInput);

  return (
    <div>
      <p>Document Type</p>
      <select
        className="w-full border border-black focus:border-black focus:ring-0 rounded-lg p-2 shadow-sm "
        name="type"
        id="docType"
        value={document.type}
        onChange={(e: ChangeEvent<HTMLSelectElement>) =>
          dispatch(
            documentModalInputChange({
              key: e.target.name,
              value: e.target.value,
            })
          )
        }
        disabled={!hideModal.delete}
      >
        <option value=""></option>;
        {props.docTypes.map((docType) => (
          <option value={docType.type}>{docType.type}</option>
        ))}
      </select>
    </div>
  );
};

export default DocumentTypeSelector;
