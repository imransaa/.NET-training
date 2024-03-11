const baseUrl = "https://localhost:7205";

const onPostRequest = async (url: string, data: any, headers: any = {}) => {
  return await fetch(baseUrl + url, {
    method: "POST",
    headers: {
      Accept: "application/json",
      "Content-Type": "application/json",
      ...headers,
    },
    body: JSON.stringify(data),
  }).then((res) => res.json());
};

const onGetRequest = async (url: string, headers: any = {}) => {
  return await fetch(baseUrl + url, {
    method: "GET",
    headers: {
      Accept: "application/json",
      "Content-Type": "application/json",
      ...headers,
    },
  }).then((res) => res.json());
};

export { baseUrl, onPostRequest, onGetRequest };
