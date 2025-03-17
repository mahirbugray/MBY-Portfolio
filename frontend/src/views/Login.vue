<template>
  <div class="login-form">
    <div class="form-container">
      <h2 class="text-center mb-4">Giriş Yap</h2>
      <form @submit.prevent="loginUser">
        <div class="row">
          <!-- Sol Kolon -->
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
          <button type="submit" @click="redirectToHome" class="btn btn-primary btn-block shadow-lg">Giriş Yap</button>
        </div>
      </form>
      <p v-if="errorMessage.general" class="error-message">{{ errorMessage.general }}</p>
      <div class="register-link">
        <p>Hesabınız yok mu? <span @click="redirectToRegister" class="link-text">Kayıt Ol</span></p>
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref } from "vue";
import AuthService from "@/services/AuthService";
import { useRouter } from "vue-router";

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

const redirectToHome = () => {
  router.push({name: "home"})
}

</script>

<style scoped>
/* Modern Background */
.login-form {
  background: linear-gradient(135deg, #6a11cb, #2575fc);
  padding: 50px 0;
  min-height: 100vh;
  display: flex;
  justify-content: center;
  align-items: center;
}

.form-container {
  background: #fff;
  padding: 30px;
  border-radius: 8px;
  box-shadow: 0 10px 20px rgba(0, 0, 0, 0.1);
  width: 100%;
  max-width: 600px;
  border-top-left-radius: 40px;
  border-bottom-right-radius: 40px;
}

/* Form Elements Styling */
h2 {
  font-family: 'Arial', sans-serif;
  font-weight: 600;
  color: #333;
  text-transform: uppercase;
}

input[type="email"],
input[type="password"] {
  border-radius: 10px;
  padding: 15px;
  margin-bottom: 15px;
  border: 1px solid #ddd;
  transition: all 0.3s ease-in-out;
}

input[type="email"]:focus,
input[type="password"]:focus {
  border-color: #2575fc;
  box-shadow: 0 0 10px rgba(37, 117, 252, 0.4);
}

button[type="submit"] {
  background: #2575fc;
  color: white;
  padding: 15px 30px;
  border-radius: 50px;
  border: none;
  font-size: 16px;
  cursor: pointer;
  transition: background 0.3s;
  width: 100%;
}

button[type="submit"]:hover {
  background: #6a11cb;
}

/* Error message styling */
.error-message {
  color: #e74c3c;
  font-size: 0.875rem;
  margin-top: 5px;
}

/* Register Link */
.register-link {
  margin-top: 1rem;
  text-align: center;
}

.register-link .link-text {
  color: #2575fc;
  cursor: pointer;
  font-weight: bold;
  text-decoration: underline;
}

.register-link .link-text:hover {
  color: #6a11cb;
}
</style>
