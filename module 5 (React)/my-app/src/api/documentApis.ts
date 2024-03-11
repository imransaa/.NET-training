import { onGetRequest } from "./apiUtils";

async function getDocTypes(token: string) {
  return await onGetRequest("/api/DocumentType", {
    Authorization: `Bearer ${token}`,
  });
}

async function getDocs(token: string) {
  return await onGetRequest("/api/Document", {
    Authorization: `Bearer ${token}`,
  });
}

export { getDocTypes, getDocs };
