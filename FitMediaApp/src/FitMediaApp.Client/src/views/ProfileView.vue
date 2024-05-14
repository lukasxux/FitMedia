<template>
  <div class="profile">
    <!-- Profilinformationen -->
    <div class="profile-info">
      <div class="profile-picture">
        <img :src="pic" alt="Profilbild">
      </div>
      <div class="profile-details">
        <h1>{{ username }}</h1>
        <!-- Profilstatistiken -->
        <div class="profile-stats">
          <p>{{ followers.length }} Follower</p>
          <p class="following">{{ following.length }} Following</p>
          <p class="following">{{ posts.length }} Posts</p>
        </div>
        <!-- Bio mit HTML-Formatierung -->
        <div v-html="formattedBio" class="formattedBio"></div>
        <!-- Aktionsbuttons -->
        <button @click="logout" class="logout-btn">Abmelden</button>
        <button @click="deleteAccount" class="delete-account-btn">Account löschen</button>
        <button @click="openEditModal" class="update-profile-btn">Profil bearbeiten</button>
      </div>
    </div>

    <!-- Post-Anzeige -->
    <div class="posts" v-if="posts.length > 0">
      <div class="post-card" v-for="(post, index) in posts" :key="index" @click="displayPostGuid(post.guid)">
        <div class="post">
          <!-- Optionen für jeden Post -->
          <div class="post-options">
            <button @click="toggleOptions(index)" class="options-btn">...</button>
            <div v-if="showOptions[index]" class="options-menu">
              <button @click="deletePost(index)" class="delete-btn">Löschen</button>
            </div>
          </div>
          <!-- Bild und Beschreibung des Posts -->
          <img :src="getPostImagePath(post.filePathPic)" alt="Post Image" class="post-image">
          <p>{{ post.description }}</p>
          <!-- Kommentare -->
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
    <!-- Nachricht bei fehlenden Posts -->
    <div v-else class="no-posts">
      <p>Keine Posts vorhanden.</p>
    </div>

    <!-- Modal für Profilbearbeitung -->
    <div class="modal" v-if="isEditModalOpen">
      <div class="modal-content">
        <h2>Profil bearbeiten</h2>
        <label>Username</label>
        <input type="text" style=""  v-model="editedUsername">
        <label>Steckbrief</label>
        <textarea v-model="editedBio" rows="5"></textarea>
        <label>Email</label>
        <input type="text" v-model="editedEmail">
        <button @click="saveProfileChanges">Speichern</button>
        <button @click="closeEditModal">Abbrechen</button>
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref, onMounted, computed } from 'vue';
import axios from 'axios';

// Daten
const username = ref('');
const mail = ref('');
const bio = ref('');
const pic = ref("src/assets/Test-Bild.png");
const posts = ref([]);
const followers = ref([]);
const following = ref([]);
const showOptions = ref([]);
const isEditModalOpen = ref(false);
const editedUsername = ref('');
const editedBio = ref('');
const editedEmail = ref('');

// Methoden
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

async function fetchUserData() {
  try {
    const guid = sessionStorage.getItem('userGuid');
    const response = await axios.get(`https://localhost:7001/api/user/${guid}`);
    username.value = response.data.username;
    mail.value = response.data.mail;
    bio.value = response.data.bio;
    pic.value = "https://localhost:7001/" + response.data.profilePicPath;
    posts.value = response.data.posts;
    followers.value = response.data.followerRecipient;
    following.value = response.data.followerSender;
    showOptions.value = Array(response.data.posts.length).fill(false);
  } catch (error) {
    console.error("Fehler beim Laden der Benutzerdaten:", error);
  }
}

function logout() {
  sessionStorage.removeItem('userGuid');
  window.location.href = '/login';
}

function getPostImagePath(filePath) {
  return filePath === "Path/To/Your/Picture"
    ? 'https://localhost:7001/uploads/57e80e77c688490895cf3d7a4fd8f44c.png'
    : `https://localhost:7001/${filePath}`;
}

function openEditModal() {
  editedUsername.value = username.value;
  editedBio.value = bio.value;
  editedEmail.value = mail.value;
  isEditModalOpen.value = true;
}

function saveProfileChanges() {
  const response =  axios.put('https://localhost:7001/api/User/update', {
          username: editedUsername.value,
          bio: editedBio.value,
          email: editedEmail.value
        });
  username.value = editedUsername.value;
  bio.value = editedBio.value;
  mail.value = editedEmail.value;
  closeEditModal();
}

function closeEditModal() {
  isEditModalOpen.value = false;
}
  
// Berechnete Eigenschaft für die formatierte Bio
const formattedBio = computed(() => {
  return bio.value.split('\n').map(line => `<p>${line}</p>`).join('');
});

// Methode zum Anzeigen der GUID des Posts
function displayPostGuid(postGuid) {
  console.log("GUID des Posts:", postGuid);
}

// Daten beim Laden der Komponente abrufen
onMounted(fetchUserData);
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

.modal {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(0, 0, 0, 0.5); /* Dunkler Hintergrund mit Transparenz */
  display: flex;
  justify-content: center;
  align-items: center;
}

.modal-content {
  background-color: #333; /* Dunklere Hintergrundfarbe für das Modal */
  padding: 20px;
  border-radius: 8px;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.2); /* Leichte Schatten für das Modal */
  color: #fff; /* Textfarbe im Modal */
}

input,
textarea {
  width: calc(100% - 40px);
  padding: 10px;
  margin-bottom: 10px;
  border: 1px solid #ccc;
  border-radius: 4px;
  color: #333; /* Textfarbe für Eingabefelder */
  background-color: #fff; /* Hintergrundfarbe für Eingabefelder */
}

/* Stil für die Buttons im Modal */
.modal-content button {
  background-color: #ff6347;
  color: #fff;
  border: none;
  border-radius: 4px;
  padding: 10px 20px;
  font-size: 16px;
  cursor: pointer;
  transition: background-color 0.3s ease;
  margin-right: 10px;
}

.modal-content button:hover {
  background-color: #d9534f; /* Farbänderung bei Mouseover */
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

.update-profile-btn {
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