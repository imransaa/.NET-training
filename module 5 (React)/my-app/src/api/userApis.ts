import { baseUrl, onPostRequest } from "./apiUtils";

async function userLogin(data: any) {
  return await onPostRequest("/api/user/signin", data);
}

async function userSignup(data: any) {
  return await onPostRequest("/api/user/signup", data);
}

export { userLogin, userSignup };
