import axios from 'axios';

const apiUrl = 'http://localhost:5000/api/user';

export default class UserService {
  static async getProfile() {
    try {
      const response = await axios.get(`${apiUrl}/profile`, {
        headers: { Authorization: `Bearer ${localStorage.getItem('auth_token')}` },
      });
      return response.data;
    } catch (error) {
      throw new Error('Profil verisi alınırken hata oluştu.');
    }
  }
}