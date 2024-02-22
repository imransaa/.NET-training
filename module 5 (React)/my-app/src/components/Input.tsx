"use client";
export type InputProps = {
  label: string;
  type: string;
  name: string;
  placeholder?: string;
  value?: string;
  onChange?: any;
  error?: string;
  Icon?: any;
  onIconClick?: any;
}

export default ({
  label,
  type,
  name,
  placeholder,
  value,
  onChange,
  error = "",
  Icon,
  onIconClick,
}: InputProps) => {
  return (
    <div>
      <p className={"" + (error !== "" && "border-rose-800 text-rose-800")}>
        {label}
      </p>
      <div className="relative">
        <input
          className={
            `w-full border focus:border-black focus:ring-0 rounded-lg p-2 shadow-sm ` +
            (error === "" ? "border-black" : "border-rose-800 text-rose-800")
          }
          type={type}
          placeholder={placeholder}
          name={name}
          value={value}
          onChange={onChange}
        />
        {Icon && (
          <div className="absolute right-0 inset-y-0 h-full w-8 flex justify-center items-center rounded-r-lg">
            <Icon className="text-xl" onClick={onIconClick} />
          </div>
        )}
      </div>
      {error !== "" && (
        <p className="text-xs text-wrap text-rose-800 text-bold">{error}</p>
      )}
    </div>
  );
};
