<template>
  <div>
    <Navbar />

    <!-- Hero Slider -->
    <section class="hero">
      <div class="slider-container">
        <div class="slider" :style="{ transform: 'translateX(' + (-currentIndex * 100) + '%)' }">
          <div 
            v-for="(image, index) in heroImages" 
            :key="index" 
            class="slider-item"
          >
            <img :src="image" alt="Hero Image" class="hero-image" />
          </div>
        </div>

        <div class="slider-navigation">
          <button @click="prevSlide" class="prev-btn">❮</button>
          <button @click="nextSlide" class="next-btn">❯</button>
        </div>
      </div>

      <div class="hero-content">
        <h1>MBY Blog'a Hoş Geldiniz</h1>
        <p>Kendi yolculuğunuzu başlatın, keşfedin ve öğrenin.</p>
        <a href="/about" class="btn-main">Daha Fazla</a>
      </div>
    </section>

    <Footer />
  </div>
</template>
<script>
import Navbar from "@/components/Navbar.vue";
import Footer from "@/components/Footer.vue";
import "@/assets/styles/home.css";

export default {
  components: {
    Navbar,
    Footer
  },
  data() {
    return {
      currentIndex: 0,  // Slider'ın şu anki index'i
      heroImages: [
        require('@/assets/images/images1.jpeg'),
        require('@/assets/images/images2.jpg'),
        require('@/assets/images/images3.jpeg'),
        require('@/assets/images/images4.jpg'),
        require('@/assets/images/images5.jpg'),
        require('@/assets/images/images6.jpg')
      ],
    };
  },
  methods: {
    nextSlide() {
      this.currentIndex = (this.currentIndex + 1) % this.heroImages.length;
    },
    prevSlide() {
      this.currentIndex = (this.currentIndex - 1 + this.heroImages.length) % this.heroImages.length;
    },
    autoSlide() {
      setInterval(this.nextSlide, 3000);  // Her 3 saniyede bir sonraki slide'a geç
    }
  },
  mounted() {
    this.autoSlide();  // Sayfa yüklendiğinde otomatik kaydırmayı başlat
  }
};
</script>





