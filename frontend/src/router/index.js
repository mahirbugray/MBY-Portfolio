import { createRouter, createWebHistory } from "vue-router";
import Home from "../views/Home.vue";  // Ana sayfa bileşeni
import Login from "../views/Login.vue"; // Login bileşeni
import Register from "../views/Register.vue"; // Register bileşeni
import Profile from "../views/Profile.vue"; // Profil bileşeni

const routes = [
  { path: "/home", component: Home }, // Ana sayfa rotası
  { path: "/login", component: Login, meta: { requiresAuth: false } },  // Giriş sayfası
  { path: "/register", name: "register", component: Register, meta: { requiresAuth: false } }, // Kayıt sayfası, name ekledik
  { path: "/profile", component: Profile, meta: { requiresAuth: true } }, // Profil sayfası, giriş yapılması gerekli
  { path: "/:pathMatch(.*)*", redirect: "/" }, // Geçersiz URL'leri ana sayfaya yönlendir
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

// Kullanıcı girişi kontrolü
router.beforeEach((to, from, next) => {
  const isAuthenticated = !!localStorage.getItem("auth_token"); // Token kontrolü
  if (to.meta.requiresAuth && !isAuthenticated) {
    next("/login"); // Giriş sayfasına yönlendir
  } else {
    next(); // Diğer sayfalara geçişi sağla
  }
});

export default router;
