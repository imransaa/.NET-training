"use client";
import { userLogin } from "@/api/userApis";
import InputUtils from "@/utils/inputUtils";
import { useRouter } from "next/navigation";
import React, { useEffect, useState } from "react";

type Props = {
  Render: any;
};

const LoginContainer = (props: Props) => {
  const [input, setInput] = useState({
    email: "",
    password: "",
  });
  const [inputError, setInputError] = useState({
    email: "",
    password: "",
  });
  const [hidePassword, setHidePassword] = useState(true);
  const [loading, setLoading] = useState(false);
  const router = useRouter();

  const isError = hasInputError(input, inputError);

  useEffect(() => {
    checkErrors();
  }, [input]);

  function onInputChange(e: any) {
    setInput((prevInput) => ({
      ...prevInput,
      [e.target.name]: e.target.value,
    }));
  }

  function checkErrors() {
    let emailErrors = InputUtils.checkEmailError(input.email);
    let passwordErrors = InputUtils.checkPasswordError(input.password);

    setInputError((prevErrors) => ({
      ...prevErrors,
      email: emailErrors,
      password: passwordErrors,
    }));
  }

  function onSubmit() {
    if (!isError) {
      setLoading(true);
      userLogin(input)
        .then((res) => {
          if (res?.token) {
            alert("Succesfully logged in");
            console.log(res.token);
          } else {
            alert("Invalid Credentials");
          }
        })
        .catch((err) => alert("Invalid Credentials."))
        .finally(() => setLoading(false));
    }
  }

  return (
    <div>
      {
        <props.Render
          input={input}
          inputError={inputError}
          onInputChange={onInputChange}
          hidePassword={hidePassword}
          onHidePasswordClick={() => setHidePassword((prevState) => !prevState)}
          isError={isError}
          onSubmit={onSubmit}
          onRegister={() => router.push("/register")}
          loading={loading}
        />
      }
    </div>
  );
};

function hasInputError(input: any, inputError: any) {
  return inputError.email !== "" ||
    inputError.password !== "" ||
    input.email === "" ||
    input.password === ""
    ? true
    : false;
}

export default LoginContainer;
