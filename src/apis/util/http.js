import axios from "axios";

const instance = axios.create({
  baseURL: "http://localhost:3000",
  timeout: 10000,
});

export const request = async ({ url, method, data }) => {
  try {
    const response = await instance({
      url,
      method,
      data,
    });
    return response;
  } catch (error) {
    console.error("API request error:", error);
    throw error;
  }
};