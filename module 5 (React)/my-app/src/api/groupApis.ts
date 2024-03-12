import { headers } from "next/headers";
import { apiRequest, fetchRequest } from "./apiUtils";

async function getGroups() {
  const token: string = localStorage.getItem("token") || "";
  return await fetchRequest("/api/group", { Authorization: `Bearer ${token}` });
}

async function createGroup(group: any) {
  const token: string = localStorage.getItem("token") || "";
  return await apiRequest("/api/Group", group, "POST", {
    Authorization: `Bearer ${token}`,
  });
}

async function editGroup(groupName: string, group: any) {
  const token: string = localStorage.getItem("token") || "";
  return await apiRequest(`/api/Group/${groupName}`, group, "PUT", {
    Authorization: `Bearer ${token}`,
  });
}

async function deleteGroup(groupName: string) {
  const token: string = localStorage.getItem("token") || "";
  return await apiRequest(`/api/Group/${groupName}`, {}, "DELETE", {
    Authorization: `Bearer ${token}`,
  });
}

export { getGroups, createGroup, editGroup, deleteGroup };
