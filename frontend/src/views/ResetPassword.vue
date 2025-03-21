<template>
    <div>
      <h2>Şifre Sıfırlama</h2>
      <input v-model="email" placeholder="E-posta adresinizi girin" />
      <button @click="sendResetEmail">E-posta Gönder</button>
    </div>
  </template>
  
  <script>
  import axios from "axios";
  import { ref } from "vue";
  
  export default {
    setup() {
      const email = ref("");
  
      const sendResetEmail = async () => {
        try {
          await axios.post("https://localhost:7163/api/auth/send-email", {
            to: email.value,
            subject: "Şifre Sıfırlama",
            body: "Şifrenizi sıfırlamak için tıklayın...",
          });
          alert("E-posta gönderildi.");
        } catch (error) {
          console.error("E-posta gönderme hatası:", error);
        }
      };
  
      return { email, sendResetEmail };
    },
  };
  </script>
  