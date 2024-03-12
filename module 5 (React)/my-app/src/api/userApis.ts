import { baseUrl, apiRequest } from "./apiUtils";

async function userLogin(data: any) {
  return await apiRequest("/api/user/signin", data);
}

async function userSignup(data: any) {
  return await apiRequest("/api/user/signup", data);
}

export { userLogin, userSignup };
