<template>
  <div>
    <Navbar />
    <section class="hero">
      <div class="hero-content">
        <h1>Hoş Geldiniz</h1>
        <p>Hayatınızı değiştirecek çözümler burada başlıyor.</p>
        <a href="/about" class="btn-main">Daha Fazla</a>
      </div>
    </section>
    <Footer />
  </div>
</template>

<script>
import Navbar from "@/components/Navbar.vue";
import Footer from "@/components/Footer.vue";

export default {
  components: {
    Navbar,
    Footer,
  },
};
</script>

<style scoped>
@import "@/assets/styles/home.css";
</style>
