"use client";
import makeStore from "@/lib/store";
import { AppStore } from "@/lib/store";
import React, { useRef } from "react";
import { Provider } from "react-redux";

type Props = {
  children: React.ReactNode;
};

const StoreProvider = (props: Props) => {
  const storeRef = useRef<AppStore | null>(null);

  if (!storeRef.current) {
    storeRef.current = makeStore();
  }

  return <Provider store={storeRef.current}>{props.children}</Provider>;
};

export default StoreProvider;
