export default class LoginModel {
    constructor(username = '', password = '') {
      this.username = username;
      this.password = password;
    }
  
    validate() {
      // Basit bir doğrulama
      if (!this.username || !this.password) {
        throw new Error('Kullanıcı adı ve şifre boş olamaz!');
      }
    }
  }