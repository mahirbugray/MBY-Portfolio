import axios from 'axios';

// API URL'niz
const apiUrl = 'https://localhost:7163/api';

// Axios default headers
axios.defaults.baseURL = apiUrl;

// Auth token varsa, onu her isteğe ekle
axios.interceptors.request.use(
  config => {
    const token = localStorage.getItem('auth_token');
    if (token) {
      config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
  },
  error => {
    return Promise.reject(error);
  }
);

export default axios;
