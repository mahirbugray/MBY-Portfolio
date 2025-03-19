<template>
  <div>
    <Navbar />
    <div class="login-form">
      <div class="form-container">
        <h2 class="text-center mb-4">Giriş Yap</h2>
        <form @submit.prevent="loginUser">
          <div class="row">
            <div class="col-md-12">
              <div class="form-group">
                <label for="email">E-posta:</label>
                <input type="email" v-model="user.email" id="email" class="form-control shadow-sm" placeholder="E-postanızı girin" required />
                <p v-if="errorMessage.email" class="error-message">{{ errorMessage.email }}</p>
              </div>
              <div class="form-group">
                <label for="password">Şifre:</label>
                <input type="password" v-model="user.password" id="password" class="form-control shadow-sm" placeholder="Şifrenizi girin" required />
                <p v-if="errorMessage.password" class="error-message">{{ errorMessage.password }}</p>
              </div>
            </div>
          </div>
          <div class="form-group text-center">
            <button type="submit" class="btn btn-primary btn-block shadow-lg">Giriş Yap</button>
          </div>
        </form>
        <p v-if="errorMessage.general" class="error-message">{{ errorMessage.general }}</p>
        <div class="register-link">
          <p>Hesabınız yok mu? <span @click="redirectToRegister" class="link-text">Kayıt Ol</span></p>
        </div>
      </div>
    </div>
    <Footer />
  </div>
</template>

<script setup>
import { ref } from "vue";
import AuthService from "@/services/AuthService";
import { useRouter } from "vue-router";
import Navbar from "@/components/Navbar.vue";
import Footer from "@/components/Footer.vue";
import "@/assets/styles/login.css";

const router = useRouter();
const user = ref({
  email: "",
  password: ""
});

const errorMessage = ref({
  general: "",
  email: "",
  password: ""
});

const loginUser = async () => {
  errorMessage.value.general = "";
  try {
    await AuthService.login(user.value);
    router.push({ name: "home" });
  } catch (error) {
    if (error.response && error.response.data) {
      const errors = error.response.data.errors;
      for (const key in errors) {
        if (errorMessage.value[key] !== undefined) {
          errorMessage.value[key] = errors[key].join(", ");
        }
      }
    } else {
      errorMessage.value.general = "Giriş sırasında bir hata oluştu!";
    }
  }
};

const redirectToRegister = () => {
  router.push({ name: "register" });
};
</script>
