import Button, { ButtonProps } from "@/components/Button";
import Input, { InputProps } from "@/components/Input";
import React from "react";
import { IoIosEye, IoIosEyeOff } from "react-icons/io";
import Loading from "../../loading";

type Props = {
  input: any;
  inputError: any;
  isError: boolean;
  onInputChange: any;
  hidePassword: any;
  hideReenterPassword: any;
  onHidePasswordClick: any;
  onHideReenterPasswordClick: any;
  onSubmit: any;
  onLogin: any;
  loading: boolean;
};

const RegisterUI = (props: Props) => {
  const inputs: InputProps[] = [
    {
      label: "Name",
      type: "text",
      name: "name",
      value: props.input.name,
      onChange: props.onInputChange,
      placeholder: "John Doe",
    },
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
    {
      label: "Re-enter Password",
      type: props.hideReenterPassword ? "password" : "text",
      name: "reenter_password",
      value: props.input.reenter_password,
      onChange: props.onInputChange,
      error: props.inputError.reenter_password,
      Icon: props.hideReenterPassword ? IoIosEye : IoIosEyeOff,
      onIconClick: props.onHideReenterPasswordClick,
    },
  ];

  const buttons: ButtonProps[] = [
    {
      label: "Submit",
      onClick: props.onSubmit,
      disabled: props.isError,
    },
    {
      label: "Login",
      onClick: props.onLogin,
    },
  ];

  return (
    <div className="flex flex-col gap-5">
      {props.loading && <Loading />}

      <p className="text-3xl text-center">Register</p>

      {inputs.map((inputProps, index) => {
        return <Input key={index} {...inputProps} />;
      })}

      <div className="grid grid-flow-col justify-stretch gap-2 grid-cols-2 mt-2">
        {buttons.map((buttonProps, index) => {
          return <Button key={index} {...buttonProps} />;
        })}
      </div>
    </div>
  );
};

export default RegisterUI;
