<template>
  <div class="main-content">
    <Navbar />

    <!-- Hero Slider -->
    <section class="hero">
      <div class="slider-container">
        <div class="slider" :style="{ transform: 'translateX(' + (-heroIndex * 100) + '%)' }">
          <div v-for="(image, index) in heroImages" :key="index" class="slider-item">
            <img :src="image" alt="Hero Image" class="hero-image" />
          </div>
        </div>

        <!-- Hero Slider Butonları -->
        <div class="slider-navigation">
          <button @click="prevHeroSlide" class="prev-btn">❮</button>
          <button @click="nextHeroSlide" class="next-btn">❯</button>
        </div>
      </div>

      <div class="hero-content">
        <h1>MBY Blog'a Hoş Geldiniz</h1>
        <p>Kendi yolculuğunuzu başlatın, keşfedin ve öğrenin.</p>
        <a href="/about" class="btn-main">Daha Fazla</a>
      </div>
    </section>

    <!-- Beceriler (Hizmetler) Slider -->
    <section class="services">
      <h2 class="skills-title">BECERİLERİM</h2>
      <div class="service-slider">
        <div class="slider-container">
          <div class="slider" :style="{ transform: 'translateX(' + (-serviceIndex * 100) + '%)' }">
            <div class="slider-group" v-for="(group, index) in serviceGroups" :key="index">
              <div class="service-card" v-for="service in group" :key="service.title">
                
                <!-- Font Awesome İkonlar -->
                <font-awesome-icon :icon="service.icon" class="service-icon" />

                <h3>{{ service.title }}</h3>
                <p>{{ service.description }}</p>

                <!-- Skill Bar -->
                <div class="skill-bar">
                  <div class="skill-progress" :style="{ width: service.percentage + '%' }"></div>
                </div>
                <span class="skill-text">{{ service.percentage }}%</span>
              </div>
            </div>
          </div>
        </div>

        <!-- Slider Navigasyon -->
        <div class="slider-navigation">
          <button @click="prevServiceSlide" class="prev-btn">❮</button>
          <button @click="nextServiceSlide" class="next-btn">❯</button>
        </div>
      </div>
    </section>

    <Footer />
  </div>
</template>

<script>
import "@/assets/styles/home.css";

import Navbar from "@/components/Navbar.vue";
import Footer from "@/components/Footer.vue";
import { library } from "@fortawesome/fontawesome-svg-core";
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";
import { faCode, faDatabase, faLaptopCode, faServer, faChartLine, faMobileAlt } from "@fortawesome/free-solid-svg-icons";

// Font Awesome İkonları Tanımla
library.add(faCode, faDatabase, faLaptopCode, faServer, faChartLine, faMobileAlt);

export default {
  components: {
    Navbar,
    Footer,
    FontAwesomeIcon
  },
  data() {
    return {
      heroIndex: 0, // Hero slider index
      serviceIndex: 0, // Service slider index
      heroImages: [
        require('@/assets/images/images1.jpeg'),
        require('@/assets/images/images2.jpg'),
        require('@/assets/images/images3.jpeg'),
        require('@/assets/images/images4.jpg'),
        require('@/assets/images/images5.jpg'),
        require('@/assets/images/images6.jpg')
      ],
      services: [
        { title: "Web Geliştirme", icon: ["fas", "laptop-code"], description: "Hızlı ve modern web siteleri geliştiriyorum.", percentage: 90 },
        { title: "Back-End Geliştirme", icon: ["fas", "server"], description: "Güçlü ve güvenli API'ler oluşturuyorum.", percentage: 85 },
        { title: "Front-End Geliştirme", icon: ["fas", "code"], description: "Şık ve kullanıcı dostu arayüzler tasarlıyorum.", percentage: 80 },
        { title: "Veritabanı Yönetimi", icon: ["fas", "database"], description: "Optimizasyon ve güvenlik odaklı veritabanı yönetimi yapıyorum.", percentage: 75 },
        { title: "SEO ve Performans", icon: ["fas", "chart-line"], description: "SEO uyumlu ve hızlı web projeleri geliştiriyorum.", percentage: 78 },
        { title: "Mobil Uygulama Geliştirme", icon: ["fas", "mobile-alt"], description: "Mobil dostu ve duyarlı uygulamalar tasarlıyorum.", percentage: 82 },
      ],
    };
  },
  computed: {
    serviceGroups() {
      return this.chunkArray(this.services, 3);
    }
  },
  methods: {
    nextHeroSlide() {
      this.heroIndex = (this.heroIndex + 1) % this.heroImages.length;
    },
    prevHeroSlide() {
      this.heroIndex = (this.heroIndex - 1 + this.heroImages.length) % this.heroImages.length;
    },
    nextServiceSlide() {
      this.serviceIndex = (this.serviceIndex + 1) % this.serviceGroups.length;
    },
    prevServiceSlide() {
      this.serviceIndex = (this.serviceIndex - 1 + this.serviceGroups.length) % this.serviceGroups.length;
    },
    autoHeroSlide() {
      setInterval(this.nextHeroSlide, 4000); // Hero slider için otomatik geçiş
    },
    autoServiceSlide() {
      setInterval(this.nextServiceSlide, 4000); // Service slider için otomatik geçiş
    },
    chunkArray(arr, size) {
      return Array.from({ length: Math.ceil(arr.length / size) }, (_, index) =>
        arr.slice(index * size, index * size + size)
      );
    }
  },
  mounted() {
    this.autoHeroSlide(); // Hero slider otomatik geçişi başlat
    this.autoServiceSlide(); // Service slider otomatik geçişi başlat
  }
};
</script>
