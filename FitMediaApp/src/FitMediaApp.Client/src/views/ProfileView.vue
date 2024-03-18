<template>
    <div class="profile">
      <div class="profile-info">
        <div class="profile-picture">
            <img :src="pic" alt="Profilbild">
        </div>
        <div class="profile-details">
          <h1>{{ username }}</h1>
          <p>{{ bio }}</p>
          <button @click="logout" class="logout-btn">Abmelden</button>
        </div>
      </div>
    </div>
    <div class="posts">
      <div class="post-card" v-for="(post, index) in dummyPosts" :key="index">
        <div class="post">
          <div class="post-options">
            <button @click="toggleOptions(index)" class="options-btn">...</button>
            <div v-if="showOptions[index]" class="options-menu">
              <button @click="deletePost(index)" class="delete-btn">Löschen</button>
            </div>
          </div>
          <img :src="post.image" alt="Post Image" class="post-image"> <!-- Größe des Bildes angepasst -->
          <p>{{ post.description }}</p>
        </div>
      </div>
    </div>
  </template>
  
  <script setup>
  import { ref, onMounted } from 'vue';
  import axios from 'axios';
  
  const username = ref('');
  const bio = ref('');
  const pic = ref("src/assets/Test-Bild.png");
  const dummyPosts = ref([
    { id: 1, image: 'https://via.placeholder.com/400x400', description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.' },
    { id: 2, image: 'https://via.placeholder.com/400x400', description: 'Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.' },
    { id: 3, image: 'https://via.placeholder.com/400x400', description: 'Ut enim ad minim veniam, quis nostrud exercitation ullamco labo' },
    { id: 4, image: 'https://via.placeholder.com/400x400', description: 'Ut enim ad minim veniam, quis nostrud exercitation ullamco labo' },
    { id: 5, image: 'https://via.placeholder.com/400x400', description: 'Ut enim ad minim veniam, quis nostrud exercitation ullamco labo' },
    { id: 6, image: 'https://via.placeholder.com/400x400', description: 'Ut enim ad minim veniam, quis nostrud exercitation ullamco labo' }
  ]);
  
  const showOptions = ref(Array(dummyPosts.value.length).fill(false));
  
  function toggleOptions(index) {
    showOptions.value[index] = !showOptions.value[index];
  }
  
  function deletePost(index) {
    dummyPosts.value.splice(index, 1);
    showOptions.value[index] = false;
  }
  
  async function fetchUserData() {
    try {
      const guid = sessionStorage.getItem('userGuid'); // Lade die GUID aus dem Session Storage
      const response = await axios.get(`https://localhost:7001/api/user/${guid}`); // Sende eine Anfrage, um Benutzerdaten abzurufen
      username.value = response.data.username;
      bio.value = response.data.bio;
      pic.value = "https://localhost:7001/" + response.data.profilePicPath;
      console.log(response.data.profilePicPath);
    } catch (error) {
      console.error(error);
      // Hier kannst du eine Fehlerbehandlung hinzufügen, falls der Abruf fehlschlägt
    }
  }

  function logout() {
  sessionStorage.removeItem('userGuid'); // Lösche die GUID aus dem Session Storage
    window.location.href = '/login';
}
  
  onMounted(fetchUserData); // Rufe die Funktion fetchUserData beim Laden der Komponente auf
  </script>
  
  <style scoped>
  /* Stil für die Profilanzeige */
  .profile {
    max-width: 800px;
    margin: 20px auto;
    padding: 20px;
    background-color: #1a1a1a;
    color: #fff;
    border-radius: 8px;
    box-shadow: 0 0 10px rgba(255, 255, 255, 0.1);
  }

  .logout-btn {
  background-color: #ff6347; /* Hintergrundfarbe des Buttons */
  color: #fff; /* Textfarbe */
  border: none; /* Kein Rand */
  border-radius: 4px; /* Abgerundete Ecken */
  padding: 10px 20px; /* Innenabstand */
  font-size: 16px; /* Schriftgröße */
  cursor: pointer; /* Zeiger bei Mouseover */
  transition: background-color 0.3s ease; /* Sanfter Übergang bei Farbänderung */
}

.logout-btn:hover {
  background-color: #d9534f; /* Hintergrundfarbe ändert sich beim Mouseover */
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
  
  .posts {
    display: flex;
    justify-content: center;
    align-items: flex-start; /* Vertikale Ausrichtung anpassen */
    flex-wrap: wrap; /* Postkarten werden in der nächsten Zeile umbrochen */
  }
  
  .post-card {
    position: relative;
    flex: 0 0 calc(33.33% - 20px); /* Jede Karte nimmt 1/3 des verfügbaren Raums ein (mit Abstand) */
    margin: 10px; /* Abstand zwischen den Karten */
  }
  
  .post {
    position: relative;
    background-color: #333;
    padding: 20px;
    border-radius: 8px;
    text-align: center;
  }
  
  .post-options {
    position: absolute;
    top: 10px;
    right: 10px;
  }
  
  .options-btn {
    background: none;
    border: none;
    cursor: pointer;
    font-size: 24px;
  }
  
  .options-menu {
    position: absolute;
    top: 30px;
    right: 0;
    background-color: #fff;
    border: 1px solid #ccc;
    border-radius: 4px;
    padding: 5px;
    box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
    display: none;
  }
  
  .post-card:hover .options-menu {
    display: block;
  }
  
  .delete-btn {
    background: none;
    border: none;
    cursor: pointer;
    padding: 5px 10px;
    color: red;
  }
  
  .post-image {
    width: 50%; /* Bild wird auf 100% der Containerbreite skaliert */
    height: auto; /* Höhe automatisch anpassen */
    border-radius: 8px; /* Abgerundete Ecken für das Bild */
  }
  </style>
  