import React from "react";

type Props = {
  user: string;
  options: any;
  selected: number;
};

const SidebarUI = (props: Props) => {
  return (
    <div className="p-5 w-full bg-neutral-800 text-white rounded-2xl m-4">
      <div className="text-md h-16 flex justify-center items-center">
        Hi, {props.user}
      </div>
      <hr className="w-full mt-2 mb-4 border border-white/50" />
      <div className="flex flex-col gap-2">
        {props.options.map((option: any, index: number) => {
          return (
            <div
              key={index}
              className={`w-full h-14 rounded-md flex justify-center items-center cursor-pointer ${
                index === props.selected
                  ? "bg-rose-500 hover:bg-rose-500"
                  : "hover:bg-white/30"
              }`}
              onClick={option.onOptionClick}
            >
              {option.name}
            </div>
          );
        })}
      </div>
    </div>
  );
};

export default SidebarUI;
