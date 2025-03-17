import { createApp } from 'vue'
import App from './App.vue'
import { createPinia } from "pinia";
import 'bootstrap/dist/css/bootstrap.min.css';
import router from './router'

const pinia = createPinia();
const app = createApp(App);

app.use(pinia);
app.use(router);
app.mount("#app");