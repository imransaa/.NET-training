import InputUtils from "@/utils/inputUtils";
import { useRouter } from "next/navigation";
import React, { useEffect, useState } from "react";

type Props = {
  Render: any;
};

const RegisterContainer = (props: Props) => {
  const [input, setInput] = useState({
    name: "",
    email: "",
    password: "",
    reenter_password: "",
  });
  const [inputError, setInputError] = useState({
    email: "",
    password: "",
    reenter_password: "",
  });
  const [hidePassword, setHidePassword] = useState(true);
  const [hideReenterPassword, setHideReenterPassword] = useState(true);
  const [loading, setLoading] = useState(false);

  const router = useRouter();

  const error =
    inputError.email !== "" ||
    inputError.password !== "" ||
    input.email === "" ||
    input.password === "" ||
    input.reenter_password === "" ||
    input.name == ""
      ? true
      : false;

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
    let reenter_passwordErrors = "";

    if (
      input.reenter_password !== "" &&
      input.password !== input.reenter_password
    ) {
      reenter_passwordErrors = "Passwords dont match.";
    }

    setInputError((prevErrors) => ({
      ...prevErrors,
      email: emailErrors,
      password: passwordErrors,
      reenter_password: reenter_passwordErrors,
    }));
  }

  function onHidePasswordClick() {
    setHidePassword((prevState) => !prevState);
  }

  function onHideReenterPasswordClick() {
    setHideReenterPassword((prevState) => !prevState);
  }

  function onSubmit() {
    if (!error) {
      //   setLoading(true);
      //   userLogin(input)
      //     .then((res) => {
      //       if (res?.token) {
      //         alert("Succesfully registered in");
      //         console.log(res.token);
      //       } else {
      //         alert("Invalid Credentials");
      //       }
      //     })
      //     .catch((err) => alert("Invalid Credentials."))
      //     .finally(() => setLoading(false));
      router.push("/");
    }
  }

  function onLogin() {
    router.push("/");
  }

  return (
    <div>
      {
        <props.Render
          input={input}
          inputError={inputError}
          error={error}
          onInputChange={onInputChange}
          hidePassword={hidePassword}
          hideReenterPassword={hideReenterPassword}
          onHidePasswordClick={onHidePasswordClick}
          onHideReenterasswordClick={onHideReenterPasswordClick}
          onSubmit={onSubmit}
          onLogin={onLogin}
          loading={loading}
        />
      }
    </div>
  );
};

export default RegisterContainer;
