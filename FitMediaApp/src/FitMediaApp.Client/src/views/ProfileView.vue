<template>
  <div class="profile">
    <div class="profile-info">
      <div class="profile-picture">
        <img :src="pic" alt="Profilbild">
      </div>
      <div class="profile-details">
        <h1>{{ username }}</h1>
        <div class="profile-stats">
          <p>{{ followers.length }} Follower </p>
          <p class="following">{{ following.length }} Following</p>
          <p class="following">{{ posts.length }} Posts</p>
        </div>
        <div v-html="formattedBio" class="formattedBio"></div>
        <button @click="logout" class="logout-btn">Abmelden</button>
        <button @click="deleteAccount" class="delete-account-btn">Account löschen</button>
      </div>
    </div>
  </div>
  <div class="posts" v-if="posts.length > 0">
    <div class="post-card" v-for="(post, index) in posts" :key="index" @click="displayPostGuid(post.guid)">
      <div class="post">
        <div class="post-options">
          <button @click="toggleOptions(index)" class="options-btn">...</button>
          <div v-if="showOptions[index]" class="options-menu">
            <button @click="deletePost(index)" class="delete-btn">Löschen</button>
          </div>
        </div>
        <img :src="getPostImagePath(post.filePathPic)" alt="Post Image" class="post-image">
        <p>{{ post.description }}</p>
        <div class="comment">
          <div v-if="post.comments.length === 0" class="no-comments">
  <p>Noch keine Kommentare</p>
</div>
<div v-else>
  <div v-for="(comment, cIndex) in post.comments" :key="cIndex" class="comment">
    <p>{{ comment.text }}</p>
  </div>
</div>

        </div>
      </div>
    </div>
  </div>
  <div v-else class="no-posts">
    <p>Keine Posts vorhanden.</p>
  </div>
</template>

<script setup>
import { ref, onMounted, computed } from 'vue';
import axios from 'axios';

const username = ref('');
const bio = ref('');
const pic = ref("src/assets/Test-Bild.png");
const posts = ref([]);
const followers = ref([]);
const following = ref([]);
const showOptions = ref([]);

async function toggleOptions(index) {
  showOptions.value[index] = !showOptions.value[index];
}

async function deletePost(index) {
  try {
    const postGuid = posts.value[index].guid;
    await axios.delete(`https://localhost:7001/api/Post/${postGuid}`);
    posts.value.splice(index, 1);
    showOptions.value[index] = false;
  } catch (error) {
    console.error("Fehler beim Löschen des Beitrags:", error);
  }
}

async function deleteAccount() {
  try {
    await axios.delete(`https://localhost:7001/api/User`);
    sessionStorage.removeItem('userGuid');
    window.location.href = '/register';
  } catch (error) {
    console.error("Fehler beim Löschen des Accounts:", error);
  }
}

async function fetchUserData() {
  try {
    const guid = sessionStorage.getItem('userGuid');
    const response = await axios.get(`https://localhost:7001/api/user/${guid}`);
    username.value = response.data.username;
    bio.value = response.data.bio;
    pic.value = "https://localhost:7001/" + response.data.profilePicPath;
    
    if (response.data.posts.length > 0) {
      for (const post of response.data.posts) {
        const postResponse = await axios.get(`https://localhost:7001/api/Post/${post.guid}?$expand=comments`);
        post.comments = postResponse.data.comments;
      }
      posts.value = response.data.posts;
      showOptions.value = Array(response.data.posts.length).fill(false);
    }
    
    followers.value = response.data.followerRecipient;
    following.value = response.data.followerSender;
  } catch (error) {
    console.error(error);
  }
}

function logout() {
  sessionStorage.removeItem('userGuid');
  window.location.href = '/login';
}

function getPostImagePath(filePath) {
  if (filePath === "Path/To/Your/Picture") {
    return 'https://localhost:7001/uploads/57e80e77c688490895cf3d7a4fd8f44c.png';
  } else {
    return `https://localhost:7001/${filePath}`;
  }
}

onMounted(fetchUserData);

const formattedBio = computed(() => {
  return bio.value.split('\n').map(line => `<p>${line}</p>`).join('');
});

// Methode zum Anzeigen der GUID des Posts
function displayPostGuid(postGuid) {
  console.log("GUID des Posts:", postGuid);
}
</script>

<style scoped>
/* Stil für die Profilanzeige */
.comment {
  padding: 5px; /* Reduziere den Innenabstand */
  border-radius: 5px;
  margin-bottom: 5px; /* Kleinerer Abstand zwischen den Kommentaren */
  color: orange;
  max-height: 100px; /* Begrenze die maximale Höhe des Kommentarbereichs */
  overflow: hidden; /* Verhindere, dass der Kommentarbereich über die maximale Höhe hinausragt */
}

.delete-account-btn {
  background-color: #ff6347;
  color: #fff;
  border: none;
  border-radius: 4px;
  padding: 10px 20px;
  font-size: 16px;
  cursor: pointer;
  transition: background-color 0.3s ease;
  margin-right: 10px;
  margin-left: 10px;
}

.delete-account-btn:hover {
  background-color: #d9534f;
}

.no-posts {
  display: flex;
  justify-content: center;
  align-items: center;
  height: 200px; /* Du kannst die Höhe anpassen, um die Position der Nachricht zu ändern */
  font-size: 24px; /* Größe der Nachricht anpassen */
}

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


.comment {
  padding: 5px; /* Reduziere den Innenabstand */
  border-radius: 5px;
  margin-bottom: 5px; /* Kleinerer Abstand zwischen den Kommentaren */
  color: orange;
  max-height: 100px; /* Begrenze die maximale Höhe des Kommentarbereichs */
  overflow: hidden; /* Verhindere, dass der Kommentarbereich über die maximale Höhe hinausragt */
}

.comment p {
  margin: 0; /* Entferne den Standardabstand für <p>-Tags */
}

.no-comments {
  text-align: center;
  color: #999;
}
.profile-stats {
  display: flex;
}

.profile-stats .stat {
  margin-right: 20px; /* Abstand zwischen den Statistiken */
}
.profile-stats .following {
  margin-left: 10px; /* Abstand vor dem Following-Text */
}
</style>