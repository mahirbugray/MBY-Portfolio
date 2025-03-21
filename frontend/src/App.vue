<template>
  <div id="app">
    <router-view></router-view> <!-- Sayfa geçişi için -->
  </div>
</template>

<script>
import { onMounted } from "vue";
import { useAuthStore } from "@/store/auth";

export default {
  setup() {
    const authStore = useAuthStore();

    // Kullanıcı giriş yapmışsa bilgilerini al
    onMounted(() => {
      if (authStore.isLoggedIn) {
        authStore.fetchUser();
      }
    });

    return {};
  },
};
</script>