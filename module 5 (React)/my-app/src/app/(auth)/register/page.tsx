"use client";
import RegisterContainer from "./components/RegisterContainer";
import RegisterUI from "./components/RegisterUI";

export default () => {
  return <RegisterContainer Render={RegisterUI} />;
};
