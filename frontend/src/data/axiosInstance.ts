import axios from "axios";

const axiosInstance = axios.create({
  baseURL: "http://localhost:5222/API/v1",
  timeout: 5000, 
  headers: {
    "Content-Type": "application/json",
  },
});

export default axiosInstance;