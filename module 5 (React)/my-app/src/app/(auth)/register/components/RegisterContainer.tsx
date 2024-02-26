import { userSignup } from "@/api/userApis";
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

  const isError = hasInputError(input, inputError);

  const router = useRouter();

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
    let reenter_passwordErrors =
      input.reenter_password !== "" && input.password !== input.reenter_password
        ? "Passwords dont match."
        : "";

    setInputError((prevErrors) => ({
      ...prevErrors,
      email: emailErrors,
      password: passwordErrors,
      reenter_password: reenter_passwordErrors,
    }));
  }

  function onSubmit() {
    const signupData = {
      name: input.name,
      email: input.email,
      password: input.password,
    };

    if (!isError) {
      setLoading(true);
      userSignup(signupData)
        .then((res) => {
          if (res?.name && res?.email) {
            alert("Succesfully registered");
            setLoading(false);
            router.push("/");
          } else {
            alert("Error while signing up");
          }
        })
        .catch((err) => alert("Error while signing up"))
        .finally(() => setLoading(false));
    }
  }

  return (
    <div>
      {
        <props.Render
          input={input}
          inputError={inputError}
          isError={isError}
          onInputChange={onInputChange}
          hidePassword={hidePassword}
          hideReenterPassword={hideReenterPassword}
          onHidePasswordClick={() => setHidePassword((prevState) => !prevState)}
          onHideReenterPasswordClick={() =>
            setHideReenterPassword((prevState) => !prevState)
          }
          onSubmit={onSubmit}
          onLogin={() => router.push("/")}
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
    input.password === "" ||
    input.reenter_password === "" ||
    input.name == ""
    ? true
    : false;
}

export default RegisterContainer;
