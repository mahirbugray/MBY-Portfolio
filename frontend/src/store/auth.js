import { defineStore } from "pinia";
import AuthService from "@/services/AuthService";

export const useAuthStore = defineStore("auth", {
  state: () => ({
    user: null,
    confirmationMessage: "",
  }),
  actions: {
    async login(credentials) {
      try {
        const response = await AuthService.login(credentials);
        localStorage.setItem("auth_token", response.accessToken);

        this.user = response;
        this.confirmationMessage = response.isConfirmed ? "" : "Mail adresinizi onaylayın";
      } catch (error) {
        console.error("Giriş başarısız:", error);
        throw error;
      }
    },

    async fetchUser() {
      const token = localStorage.getItem("auth_token");
      if (!token) return;

      try {
        const userData = await AuthService.getUser();
        this.user = userData;
        this.confirmationMessage = userData.isConfirmed ? "" : "Mail adresinizi onaylayın";
      } catch (error) {
        console.error("Kullanıcı bilgisi alınamadı:", error);
        this.logout(); // Kullanıcı bilgisi alınamazsa çıkış yap
      }
    },

    logout() {
      localStorage.removeItem("auth_token");
      this.user = null;
      this.confirmationMessage = "";
    },
  },
});
