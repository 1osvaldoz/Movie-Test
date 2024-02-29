/* eslint-disable no-param-reassign */
import axios from "axios";

const request = async (params) => {
  const { url, method = "get", data = {}, headers = {}, token = "" } = params;
  try {
    const fullUrl = `${import.meta.env.VITE_API_BASE}${url}`;
    if (token) headers.Authorization = `Bearer ${token}`;
    const response = await axios({
      method,
      headers,
      url: fullUrl,
      data,
    });

    return { error: "", data: response.data, status: "" };
  } catch (err) {
    if (err.message == "Network Error") alert("Error connection");
    return { error: err, data: "", status: err.response?.status };
  }
};

export default request;
