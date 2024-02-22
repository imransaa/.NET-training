"use client";
export type ButtonProps = {
  label: string;
  type?: any;
  onClick?: any;
  disabled?: boolean;
}

export default ({ label, type, onClick, disabled }: ButtonProps) => {
  return (
    <button
      className={"border border-black rounded-md p-1 px-3" + (disabled ? "" : "transition ease-in-out hover:bg-black hover:text-white")}
      type={type}
      onClick={onClick}
      disabled={disabled}
    >
      {label}
    </button>
  );
};
