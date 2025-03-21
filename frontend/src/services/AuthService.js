import axios from "axios";

// API URL'si
const API_URL = "https://localhost:7163/api/Account";

const AuthService = {
  // Kullanıcı giriş işlemi
  async login(credentials) {
    try {
      const response = await axios.post(`${API_URL}/Login`, credentials);
      return response.data;
    } catch (error) {
      throw error.response ? error.response.data : error.message;
    }
  },

  // Kullanıcı kayıt işlemi
  async register(userData) {
    try {
      const response = await axios.post(`${API_URL}/Register`, userData);
      return response.data;
    } catch (error) {
      throw error.response ? error.response.data : error.message;
    }
  },

  // Giriş yapan kullanıcıyı al
  async getUser() {
    const token = localStorage.getItem("auth_token");

    if (!token) throw new Error("Token bulunamadı");

    try {
      const response = await axios.get(`${API_URL}/GetUser`, {
        headers: { Authorization: `Bearer ${token}` },
      });
      return response.data;
    } catch (error) {
      throw error.response ? error.response.data : error.message;
    }
  },

  // JWT Token'ını kaydet
  saveToken(token) {
    localStorage.setItem("auth_token", token);
  },

  // JWT Token'ını sil
  removeToken() {
    localStorage.removeItem("auth_token");
  },
};

export default AuthService;
