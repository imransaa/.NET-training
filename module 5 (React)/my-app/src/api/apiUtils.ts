const baseUrl = "https://localhost:7205";

const apiRequest = async (
  url: string,
  data: any = {},
  method: string = "POST",
  headers: any = {}
) => {
  return await fetch(baseUrl + url, {
    method: method,
    headers: {
      Accept: "application/json",
      "Content-Type": "application/json",
      ...headers,
    },
    body: JSON.stringify(data),
  }).then((res) => res.json());
};

const fetchRequest = async (url: string, headers: any = {}) => {
  return await fetch(baseUrl + url, {
    method: "GET",
    headers: {
      Accept: "application/json",
      "Content-Type": "application/json",
      ...headers,
    },
  }).then((res) => res.json());
};

export { baseUrl, apiRequest, fetchRequest };
