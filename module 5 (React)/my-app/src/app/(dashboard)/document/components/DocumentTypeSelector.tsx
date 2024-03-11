import React from "react";

type Props = {
  document: any;
  docTypes: any[];
  onOptionChange: any;
  disabled: boolean;
};

const DocumentTypeSelector = (props: Props) => {
  return (
    <div>
      <p>Document Type</p>
      <select
        className="w-full border border-black focus:border-black focus:ring-0 rounded-lg p-2 shadow-sm "
        name="type"
        id="docType"
        value={props.document.type}
        onChange={props.onOptionChange}
        disabled={props.disabled}
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
