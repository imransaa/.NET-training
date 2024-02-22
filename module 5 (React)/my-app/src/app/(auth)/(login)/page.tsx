"use client"
import LoginContainer from "./components/LoginContainer";
import LoginUI from "./components/LoginUI";

export default function Login() {
  return (
    <LoginContainer Render={LoginUI} />
  );
}
