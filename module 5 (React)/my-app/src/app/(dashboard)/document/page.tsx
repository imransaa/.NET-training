"use client";
import React from "react";
import { getDocTypes, getDocs } from "@/api/documentApis";
import { useRouter } from "next/navigation";
import DocumentsContainer from "./components/DocumentsContainer";

const Page = async () => {
  const router = useRouter();
  const token: string = localStorage.getItem("token") || "";
  const docTypes = await getDocTypes(token).catch((err) => {
    console.log(err);
    router.back();
  });
  // const documents = await getDocs(token).catch((err) => {
  //   console.log(err);
  //   router.back();
  // });

  return <DocumentsContainer docTypes={docTypes} />;
};

export default Page;
