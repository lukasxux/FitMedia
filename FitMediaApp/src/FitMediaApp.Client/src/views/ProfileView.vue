<template>
    <div class="profile">
      <div class="profile-info">
        <div class="profile-picture">
          <img src="../assets/Test-Bild.png" alt="Profilbild">
        </div>
        <div class="profile-details">
          <h1>{{ profile.name }}</h1>
          <p>{{ profile.bio }}</p>
        </div>
      </div>
    </div>
    <div class="user-images">
      <h2 class="section-title">Meine Beiträge</h2>
      <div class="image-grid">
        <div v-for="(image, index) in images" :key="index" class="image-item">
          <img :src="image.url" alt="Bild">
          <p>{{ image.caption }}</p>
        </div>
      </div>
    </div>
  </template>
  
  <script setup>
  import { ref } from 'vue';
  
  const profile = ref({
    name: 'Max Mustermann',
    bio: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed eget elit aliquam, fringilla libero at, volutpat justo.',
  });
  
  const images = ref([
    { url: "/src/assets/Test-Bild.png", caption: 'Erster Bildtext' },
    { url: "/src/assets/Test-Bild.png", caption: 'Zweiter Bildtext' },
    { url: "/src/assets/Test-Bild.png", caption: 'Dritter Bildtext' }
  ]);
  </script>
  
  <style scoped>
  .profile {
    max-width: 800px;
    margin: 20px auto;
    padding: 20px;
    background-color: #1a1a1a;
    color: #fff;
    border-radius: 8px;
    box-shadow: 0 0 10px rgba(255, 255, 255, 0.1);
  }
  
  .profile-info {
    display: flex;
    align-items: center;
    margin-bottom: 20px;
  }
  
  .profile-picture img {
    width: 150px;
    height: 150px;
    border-radius: 50%;
    overflow: hidden;
  }
  
  .profile-details {
    margin-left: 20px;
  }
  
  .user-images {
    margin-top: 20px;
  }
  
  .user-images h2.section-title {
    text-align: center;
    margin-bottom: 20px;
  }
  
  .image-grid {
    display: flex;
    flex-wrap: wrap;
    justify-content: center;
    gap: 20px;
  }
  
  .image-item {
    text-align: center;
  }
  
  .image-item img {
    width: 250px;
    border-radius: 5px;
  }
  
  .image-item p {
    color: #ccc;
    font-size: 14px;
    margin-top: 10px;
  }
  </style>
  