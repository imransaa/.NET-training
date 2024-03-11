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
      className={`w-screen h-screen ${props.hide && "hidden"} absolute top-0 left-0 z-40 bg-black/25 flex justify-center items-center`}
      onClick={() => props.onClose()}
    >
      <div
        className={`border bg-white rounded-xl shadow-md p-4 pt-2 z-50`}
        style={{ width: "clamp(200px, 40%, 450px)", height: "auto" }}
        onClick={(e) => e.stopPropagation()}
      >
        <div className="relative h-[1em]">
          <IoClose
            className="absolute right-0 h-[1em] cursor-pointer"
            onClick={props.onClose}
          />
        </div>
        {props.children}
      </div>
    </div>
  );
};

export default Modal;
