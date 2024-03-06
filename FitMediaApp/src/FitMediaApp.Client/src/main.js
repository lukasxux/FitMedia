import { createApp } from 'vue'
import App from './App.vue'
import router from './router'

import './assets/main.css'


export default {
    data() {
      return {
        imageFile: null
      };
    },
    methods: {
      handleFileUpload(event) {
        this.imageFile = event.target.files[0];
      },
      saveImageLocally() {
        if (this.imageFile) {
          const reader = new FileReader();
          reader.onload = () => {
            const imageDataUrl = reader.result;
            localStorage.setItem('uploadedImage', imageDataUrl);
            console.log('Bild erfolgreich lokal gespeichert');
            alert("Bild wurde erfolgreich gespeichert")
          };
          reader.readAsDataURL(this.imageFile);
        } else {
          console.error('Es wurde kein Bild ausgewählt');
          alert("Es wurde kein Bild gefunden")
        }
      }
    }
  };


const app = createApp(App)

app.use(router)

app.mount('#app')
