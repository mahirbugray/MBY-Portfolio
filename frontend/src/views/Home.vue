<template>
  <div>
    <!-- Navbar -->
    <nav class="navbar">
      <div class="navbar-container">
        <!-- Logo -->
        <a href="/" class="logo">MBY Blog</a>
        
        <!-- Navbar Links -->
        <ul class="navbar-links">
          <li><a href="/">Ana Sayfa</a></li>
          <li><a href="/about">Hakkında</a></li>
          <li><a href="/services">Hizmetler</a></li>
          <li><a href="/contact">İletişim</a></li>
        </ul>

        <!-- Navbar Actions -->
        <div class="navbar-actions">
          <a href="/login" class="btn-nav">Giriş Yap</a>
        </div>
      </div>
    </nav>

    <!-- Main Content -->
    <section class="hero">
      <div class="hero-content">
        <h1>Hoş Geldiniz</h1>
        <p>Hayatınızı değiştirecek çözümler burada başlıyor.</p>
        <a href="/about" class="btn-main">Daha Fazla</a>
      </div>
    </section>

    <!-- Footer -->
    <footer class="footer">
      <div class="footer-content">
        <div class="footer-logo">
          <a href="/" class="logo">WebSite</a>
        </div>
        <ul class="footer-links">
          <li><a href="/privacy">Gizlilik Politikası</a></li>
          <li><a href="/terms">Kullanım Şartları</a></li>
          <li><a href="/contact">İletişim</a></li>
        </ul>
        <div class="social-icons">
          <a href="#" class="social-icon"><i class="fab fa-facebook-f"></i></a>
          <a href="#" class="social-icon"><i class="fab fa-twitter"></i></a>
          <a href="#" class="social-icon"><i class="fab fa-instagram"></i></a>
          <a href="#" class="social-icon"><i class="fab fa-linkedin-in"></i></a>
        </div>
      </div>
    </footer>
  </div>
</template>

<script>
export default {
  name: "Home",
};
</script>

<style scoped>
/* Global Styles */
* {
  margin: 0;
  padding: 0;
  box-sizing: border-box;
}

body {
  font-family: 'Poppins', sans-serif;
  background-color: #f1f1f1;
  color: #333;
}

/* Navbar Styles */
.navbar {
  background: linear-gradient(135deg, #6a11cb, #2575fc); /* Soft gradient with blue tones */
  color: white;
  padding: 20px 40px;
  position: fixed;
  width: 100%;
  top: 0;
  z-index: 1000;
  box-shadow: 0 4px 10px rgba(0, 0, 0, 0.15);
}

.navbar-container {
  display: flex;
  justify-content: space-between;
  align-items: center;
  max-width: 1200px;
  margin: 0 auto;
  width: 100%;
  padding: 0 20px;
}

.navbar .logo {
  font-size: 1.9em;
  font-weight: 700;
  color: white;
  text-decoration: none;
  transition: color 0.3s ease;
}

.navbar .logo:hover {
  color: #ff6347;
}

.navbar-links {
  list-style: none;
  display: flex;
  gap: 30px;
}

.navbar-links li {
  font-size: 1.1em;
  position: relative;
}

.navbar-links a {
  color: white;
  text-decoration: none;
  padding: 10px 15px;
  border-radius: 25px;
  transition: background-color 0.3s ease, color 0.3s ease;
}

.navbar-links a:hover {
  background-color: #ff6347;
  color: white;
  transform: translateY(-3px);
}

/* Navbar Actions */
.navbar-actions {
  display: flex;
  justify-content: flex-end;
}

.navbar-actions .btn-nav {
  background: #ff6347;
  color: white;
  padding: 12px 20px;
  font-size: 1.1em;
  border-radius: 50px;
  text-decoration: none;
  transition: background 0.3s ease, transform 0.3s ease;
}

.navbar-actions .btn-nav:hover {
  background: #ff4500;
  transform: scale(1.05);
}

/* Hero Section Styles */
.hero {
  background: #ffffff; /* White background to separate from navbar */
  color: #333;
  height: 90vh;
  display: flex;
  justify-content: center;
  align-items: center;
  text-align: center;
  padding: 0 20px;
  margin-top: 80px;
  box-shadow: 0px 4px 10px rgba(0, 0, 0, 0.1); /* Subtle shadow to separate from navbar */
}

.hero h1 {
  font-size: 3.5em;
  margin-bottom: 20px;
}

.hero p {
  font-size: 1.4em;
  margin-bottom: 30px;
}

.btn-main {
  background-color: #ff6347;
  color: white;
  padding: 15px 30px;
  border-radius: 50px;
  font-size: 1.2em;
  text-decoration: none;
  transition: background-color 0.3s ease, transform 0.3s ease;
}

.btn-main:hover {
  background-color: #ff4500;
  transform: scale(1.05);
}

/* Footer Styles */
.footer {
  background: #333; /* Dark gray background to separate footer */
  color: white;
  padding: 60px 40px;
  text-align: center;
  position: relative;
  bottom: 0;
  width: 100%;
}

.footer-content {
  display: flex;
  justify-content: space-between;
  align-items: center;
  flex-wrap: wrap;
  gap: 30px;
  max-width: 1200px;
  margin: 0 auto;
}

.footer-logo {
  font-size: 2em;
  font-weight: 700;
}

.footer-logo .logo {
  color: white;
  text-decoration: none;
  transition: color 0.3s ease;
}

.footer-logo .logo:hover {
  color: #ff6347;
}

.footer-links {
  list-style: none;
  display: flex;
  gap: 30px;
}

.footer-links li {
  font-size: 1.1em;
}

.footer-links a {
  color: white;
  text-decoration: none;
  transition: color 0.3s ease;
}

.footer-links a:hover {
  color: #ff6347;
}

.social-icons {
  display: flex;
  gap: 20px;
}

.social-icon {
  font-size: 1.5em;
  color: white;
  transition: color 0.3s ease;
}

.social-icon:hover {
  color: #ff6347;
}

/* Responsive Design */
@media (max-width: 768px) {
  .navbar-container {
    flex-direction: column;
    align-items: center;
  }
  .navbar-links {
    flex-direction: column;
    gap: 15px;
  }
  .hero h1 {
    font-size: 2.5em;
  }
  .hero p {
    font-size: 1.2em;
  }
  .footer-content {
    flex-direction: column;
    text-align: center;
  }
  .social-icons {
    justify-content: center;
  }
}
</style>
