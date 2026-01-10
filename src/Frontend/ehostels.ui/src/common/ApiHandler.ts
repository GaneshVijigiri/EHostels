import axios from "axios";
const api = axios.create({
  baseURL: import.meta.env.VITE_API_BASE_URL || "",
});
api.interceptors.request.use(
  (request) => {
    const token = localStorage.getItem("token");
    if (token) {
      request.headers["Authorization"] = `Bearer ${token}`;
    }
    return request;
  },
  (error) => {
    return Promise.reject(error);
  }
);
api.interceptors.response.use(
  (response) => response,
  async (error) => {
    const originalRequest = error.config;
    if (
      error.response &&
      error.response.status === 401 &&
      !originalRequest._retry
    ) {
      originalRequest._retry = true;
      const refreshToken = localStorage.getItem("refreshToken");
      if (refreshToken) {
        try {
          const res = await api.post(
            "/api/ehostels/Identity/refresh-token",
            JSON.stringify(refreshToken),
            {
              headers: {
                "Content-Type": "application/json",
              },
            }
          );
          if (res) {
            localStorage.setItem("token", res.data.data.accessToken);
            originalRequest.headers[
              "Authorization"
            ] = `Bearer ${res.data.data.accessToken}`;
            return api.request(originalRequest);
          }
        } catch (error) {
          localStorage.removeItem("token");
          localStorage.removeItem("refreshToken");
          return Promise.reject(error);
        }
      } else {
      }
    }
  }
);

export const postAsync = async (url: string, data: any) => {
  return api.post(url, data);
};
export const getAsync = async (url: string, params?: any) => {
  return api.get(url, { params });
};
