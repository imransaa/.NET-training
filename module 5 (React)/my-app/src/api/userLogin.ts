import baseUrl from "./config";

async function userLogin(data: any) {
  return await fetch(baseUrl + "/api/user/signin", {
    method: "POST",
    headers: {
      Accept: "application/json",
      "Content-Type": "application/json",
    },
    body: JSON.stringify(data),
  }).then((res) => res.json());
}
export default userLogin;
