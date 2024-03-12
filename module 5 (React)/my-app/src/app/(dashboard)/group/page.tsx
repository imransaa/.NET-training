"use client";
import React, { useState } from "react";
import GroupsContainer from "./components/GroupsContainer";
import { getGroups } from "@/api/groupApis";
import { useRouter } from "next/navigation";
import StoreProvider from "@/app/StoreProvider";

type Props = {};

const Page = async () => {
  const router = useRouter();
  const groups = await getGroups().catch((err) => router.back());

  return (
    <StoreProvider>
      <GroupsContainer groups={groups} />
    </StoreProvider>
  );
};

export default Page;
