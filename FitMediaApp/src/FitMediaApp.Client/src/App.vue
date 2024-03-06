<script setup>
import { RouterLink, RouterView } from "vue-router";
import HelloWorld from "./components/HelloWorld.vue";
</script>

<template>
  <header>
    <img alt="FitMedia logo" class="logo" src="@/assets/Fit-Media_logo.png" width="300" height="100" />

    <div class="wrapper">
      <!-- <HelloWorld msg="You dont have an account yet!" /> -->
      <nav>
        <RouterLink to="/">Home</RouterLink>
        <RouterLink to="/login">Login</RouterLink>
      </nav>


  <div>
    <input type="file" @change="handleFileUpload">
    <button @click="saveImageLocally">Bild lokal speichern</button>
  </div>
    </div>
  </header>

  <RouterView />
</template>
<style scoped>
</style>

<script>
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
          this.saveToFileSystem(imageDataUrl);
        };
        reader.readAsDataURL(this.imageFile);
      } else {
        console.error('Es wurde kein Bild ausgewählt');
      }
    },
    saveToFileSystem(dataUrl) {
      const link = document.createElement('a');
      link.href = dataUrl;
      link.download = 'meinBild.jpg';
      link.style.display = 'none';
      document.body.appendChild(link);
      link.click();
      document.body.removeChild(link);
    }
  }
};
</script>