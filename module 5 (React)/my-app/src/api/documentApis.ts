import { fetchRequest } from "./apiUtils";

async function getDocTypes(token: string) {
  return await fetchRequest("/api/DocumentType", {
    Authorization: `Bearer ${token}`,
  });
}

async function getDocs(token: string) {
  return await fetchRequest("/api/Document", {
    Authorization: `Bearer ${token}`,
  });
}

export { getDocTypes, getDocs };
