export default class RegisterModel {
    constructor(name = '', surname='',username = '', email = '', password = '', confirmPassword = '',phonenumber='',birthdate='', address='') {
      this.name = name;
      this.surname=surname;
      this.username = username;
      this.email = email;
      this.password = password;
      this.confirmPassword = confirmPassword;
      this.phonenumber = phonenumber;
      this.birthdate=birthdate;
      this.address = address;
    }
  
    validate() {
      if (!this.name || !this.surname || !this.username || !this.email || !this.password || !this.confirmPassword || !this.phonenumber || !this.birthdate || !this.address) {
        throw new Error('Tüm alanlar zorunludur!');
      }
      if (this.password !== this.confirmPassword) {
        throw new Error('Şifreler eşleşmiyor!');
      }
      const emailPattern = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
      if (!emailPattern.test(this.email)) {
        throw new Error('Geçersiz e-posta adresi!');
      }
    }
  }