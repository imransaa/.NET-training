"use client";
export type ButtonProps = {
  label: string;
  color?: string;
  type?: any;
  onClick?: any;
  disabled?: boolean;
};

export default (props: ButtonProps) => {
  let color = props.color
    ? `hover:bg-${props.color} hover:border`
    : "hover:bg-black";

  return (
    <button
      className={`border border-black rounded-md p-1 px-3 ${
        props.disabled
          ? "cursor-not-allowed"
          : `transition ease-in-out hover:text-white ${color}`
      }`}
      type={props.type}
      onClick={props.onClick}
      disabled={props.disabled}
    >
      {props.label}
    </button>
  );
};
