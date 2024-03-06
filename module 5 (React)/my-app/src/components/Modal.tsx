"use client";
import React from "react";
import { IoClose } from "react-icons/io5";

type Props = {
  hide: boolean;
  onClose: any;
  children: React.ReactNode;
};

const Modal = (props: Props) => {
  return (
    <div
      className={`${props.hide && "hidden"} absolute inset-2/4 z-50 border bg-white w-96 h-96 -translate-x-1/2 -translate-y-1/2 rounded-xl shadow-md p-4 pt-2`}
    >
      <div className="relative h-[1em]">
        <IoClose
          className="absolute right-0 h-[1em] cursor-pointer"
          onClick={props.onClose}
        />
      </div>
      {props.children}
    </div>
  );
};

export default Modal;
