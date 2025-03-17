<template>
  <div class="register-form">
    <div class="form-container">
      <h2 class="text-center mb-4">Kayıt Ol</h2>
      <form @submit.prevent="registerUser">
        <div class="row">
          <!-- Sol Kolon -->
          <div class="col-md-6">
            <div class="form-group">
              <label for="name">Ad:</label>
              <input type="text" v-model="user.name" id="name" class="form-control shadow-sm" placeholder="Adınızı girin" required />
              <p v-if="errorMessage.name" class="error-message">{{ errorMessage.name }}</p>
            </div>
            <div class="form-group">
              <label for="surname">Soyadı:</label>
              <input type="text" v-model="user.surname" id="surname" class="form-control shadow-sm" placeholder="Soyadınızı girin" required />
              <p v-if="errorMessage.surname" class="error-message">{{ errorMessage.surname }}</p>
            </div>
            <div class="form-group">
              <label for="username">Kullanıcı Adı:</label>
              <input type="text" v-model="user.username" id="username" class="form-control shadow-sm" placeholder="Kullanıcı adınızı girin" required />
              <p v-if="errorMessage.username" class="error-message">{{ errorMessage.username }}</p>
            </div>
            <div class="form-group">
              <label for="birthdate">Doğum Tarihi:</label>
              <Datepicker 
                v-model="user.birthdate" 
                format="yyyy-MM-dd"
                :clearable="true" 
                placeholder="Doğum tarihinizi seçin"
                class="form-control shadow-sm"
              />
              <p v-if="errorMessage.birthdate" class="error-message">{{ errorMessage.birthdate }}</p>
            </div>
          </div>
          <!-- Sağ Kolon -->
          <div class="col-md-6">
            <div class="form-group">
              <label for="email">E-posta:</label>
              <input type="email" v-model="user.email" id="email" class="form-control shadow-sm" placeholder="E-postanızı girin" required />
              <p v-if="errorMessage.email" class="error-message">{{ errorMessage.email }}</p>
            </div>
            <div class="form-group">
              <label for="password">Şifre:</label>
              <input type="password" v-model="user.password" id="password" class="form-control shadow-sm" placeholder="Şifrenizi oluşturun" required />
              <p v-if="errorMessage.password" class="error-message">{{ errorMessage.password }}</p>
            </div>
            <div class="form-group">
              <label for="confirmPassword">Şifreyi Onayla:</label>
              <input type="password" v-model="user.confirmPassword" id="confirmPassword" class="form-control shadow-sm" placeholder="Şifrenizi tekrar girin" required />
              <p v-if="errorMessage.confirmPassword" class="error-message">{{ errorMessage.confirmPassword }}</p>
            </div>
            <div class="form-group">
              <label for="phonenumber">Telefon Numarası:</label>
              <input 
                type="text" 
                v-model="user.phonenumber" 
                id="phonenumber" 
                class="form-control shadow-sm" 
                placeholder="Telefon numaranızı girin" 
                required 
                @input="formatPhoneNumber" 
                maxlength="13"
              />
              <p v-if="errorMessage.phonenumber" class="error-message">{{ errorMessage.phonenumber }}</p>
            </div>
            <div class="form-group">
              <label for="address">Adres:</label>
              <input type="text" v-model="user.address" id="address" class="form-control shadow-sm" placeholder="Adresinizi girin" required />
              <p v-if="errorMessage.address" class="error-message">{{ errorMessage.address }}</p>
            </div>
          </div>
        </div>
        <button type="submit" class="btn btn-primary btn-block shadow-lg">Kayıt Ol</button>
      </form>
      <p v-if="errorMessage.general" class="error-message">{{ errorMessage.general }}</p>
    </div>
    <!-- Success Alert -->
    <div v-if="showSuccessPopup" class="success-alert">
      <p>Kayıt başarılı! Şimdi giriş yapabilirsiniz.</p>
      <button @click="redirectToLogin">Giriş Yap</button>
    </div>
  </div>
</template>

<script setup>
import { ref } from "vue";
import AuthService from "@/services/AuthService";
import { useRouter } from "vue-router";
import Datepicker from 'vue3-datepicker'; // Takvim kütüphanesini import et

const router = useRouter();
const user = ref({
  name: "",
  surname: "",
  username: "",
  email: "",
  password: "",
  confirmPassword: "",
  phonenumber: "",
  birthdate: "",
  address: "",
});

const errorMessage = ref({
  general: "",
  name: "",
  surname: "",
  username: "",
  email: "",
  password: "",
  confirmPassword: "",
  phonenumber: "",
  birthdate: "",
  address: "",
});

const showSuccessPopup = ref(false);

const validateEmail = (email) => {
  const regex = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$/;
  return regex.test(email);
};

const validatePhoneNumber = (phone) => {
  const regex = /^\+90\d{10}$/; // Türkiye telefon numarası formatı
  return regex.test(phone);
};

const validatePassword = (password) => {
  const regex = /^(?=.*[a-z])(?=.*[A-Z]).{8,}$/; // En az 8 karakter, büyük ve küçük harf içermeli
  return regex.test(password);
};

const validateBirthdate = (birthdate) => {
  const age = new Date().getFullYear() - new Date(birthdate).getFullYear();
  return age >= 18; // Kullanıcı 18 yaşından büyük olmalı
};

// Telefon numarasını +90 ile başlatma ve sadece rakam girilmesine izin verme
const formatPhoneNumber = () => {
  if (!user.value.phonenumber.startsWith('+90')) {
    user.value.phonenumber = '+90' + user.value.phonenumber.replace(/[^\d]/g, '');
  } else {
    user.value.phonenumber = '+90' + user.value.phonenumber.slice(3).replace(/[^\d]/g, '');
  }
};

const registerUser = async () => {
  // Hata mesajlarını sıfırlama
  for (const key in errorMessage.value) {
    errorMessage.value[key] = "";
  }

  // Şifre ve şifre onayı kontrolü
  if (user.value.password !== user.value.confirmPassword) {
    errorMessage.value.confirmPassword = "Şifreler uyuşmuyor!";
    return;
  }

  // E-posta doğrulama
  if (!validateEmail(user.value.email)) {
    errorMessage.value.email = "Geçerli bir e-posta adresi girin!";
    return;
  }

  // Telefon numarası doğrulama
  if (!validatePhoneNumber(user.value.phonenumber)) {
    errorMessage.value.phonenumber = "Geçerli bir telefon numarası girin (+90XXXXXXXXXX)!";
    return;
  }

  // Şifre doğrulama
  if (!validatePassword(user.value.password)) {
    errorMessage.value.password = "Şifre en az 8 karakter, büyük ve küçük harf içermelidir!";
    return;
  }

  // Doğum tarihi doğrulama (Yaş kontrolü)
  if (!validateBirthdate(user.value.birthdate)) {
    errorMessage.value.birthdate = "18 yaşından büyük olmanız gerekmektedir!";
    return;
  }

  try {
    await AuthService.register(user.value);
    showSuccessPopup.value = true;

    // Hide alert after 3 seconds
    setTimeout(() => {
      showSuccessPopup.value = false;
    }, 3000);
  } catch (error) {
    if (error.response && error.response.data) {
      const errors = error.response.data.errors;
      for (const key in errors) {
        if (errorMessage.value[key] !== undefined) {
          errorMessage.value[key] = errors[key].join(", ");
        }
      }
    } else {
      errorMessage.value.general = "Kayıt sırasında bir hata oluştu!";
    }
  }
};

const redirectToLogin = () => {
  showSuccessPopup.value = false;
  router.push({ name: "login" });
};
</script>

<style scoped>
/* Modern Background */
.register-form {
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

input[type="text"],
input[type="email"],
input[type="password"],
input[type="date"] {
  border-radius: 10px;
  padding: 15px;
  margin-bottom: 15px;
  border: 1px solid #ddd;
  width: 100%;
}

.error-message {
  color: red;
  font-size: 0.9em;
}

.success-alert {
  background-color: #4CAF50;
  color: white;
  padding: 10px;
  border-radius: 5px;
  text-align: center;
}
</style>
