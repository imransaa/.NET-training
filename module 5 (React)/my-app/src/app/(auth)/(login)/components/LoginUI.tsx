"use client";
import Input, { InputProps } from "@/components/Input";
import React from "react";
import { IoIosEye, IoIosEyeOff } from "react-icons/io";
import Loading from "../../loading";
import Button, { ButtonProps } from "@/components/Button";

type Props = {
  input: any;
  inputError: any;
  onInputChange: any;
  Icon: any;
  hidePassword: boolean;
  onHidePasswordClick: any;
  isError: boolean;
  onSubmit: any;
  onRegister: any;
  loading: boolean;
};

const LoginUI = (props: Props) => {
  const inputs: InputProps[] = [
    {
      label: "Email",
      type: "email",
      name: "email",
      value: props.input.email,
      onChange: props.onInputChange,
      error: props.inputError.email,
      placeholder: "example@email.com",
    },
    {
      label: "Password",
      type: props.hidePassword ? "password" : "text",
      name: "password",
      value: props.input.password,
      onChange: props.onInputChange,
      error: props.inputError.password,
      Icon: props.hidePassword ? IoIosEye : IoIosEyeOff,
      onIconClick: props.onHidePasswordClick,
    },
  ];

  const buttons: ButtonProps[] = [
    {
      label: "Submit",
      type: "submit",
      onClick: props.onSubmit,
      disabled: props.isError,
    },
    {
      label: "Register",
      onClick: props.onRegister,
    },
  ];

  return (
    <div className="flex flex-col gap-5">
      {props.loading && <Loading />}

      <p className="text-3xl text-center">Login</p>

      {inputs.map((inputProps, index) => (
        <Input key={index} {...inputProps} />
      ))}

      <div className="grid grid-flow-col justify-stretch gap-2 grid-cols-2 mt-2">
        {buttons.map((buttonProps, index) => {
          return <Button key={index} {...buttonProps} />;
        })}
      </div>
    </div>
  );
};

export default LoginUI;
