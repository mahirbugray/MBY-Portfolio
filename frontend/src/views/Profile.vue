<template>
  <div>
    <h2>Profil Sayfası</h2>
    <div v-if="authStore.user">
      <p>Merhaba, {{ authStore.user.email }}</p>
      <input v-model="email" placeholder="Yeni Email" />
      <button @click="updateProfile">Profil Güncelle</button>
    </div>
    <button @click="logout">Çıkış Yap</button>
  </div>
</template>

<script>
import { ref } from "vue";
import { useAuthStore } from "@/store/auth"; // authStore'u import et

export default {
  setup() {
    const authStore = useAuthStore();
    const email = ref(authStore.user?.email || "");

    const updateProfile = () => {
      // Profil güncellemeyi burada backend ile yapabilirsin
      alert("Profil güncelleniyor...");
      // API'ye istek göndermek için bir metot yazmalısınız
    };

    const logout = () => {
      authStore.logoutAndRedirect(); // Çıkış yapma fonksiyonu
    };

    return { authStore, email, updateProfile, logout };
  },
};
</script>
