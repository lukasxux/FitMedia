<template>
  <div class="grid-container">
    <div class="border form-container sign-up-container" id="border">
      <div class="container" id="container">
        <h1 id="create-account">Account erstellen</h1>
        <div class="input-container">
          <input type="text" placeholder="Benutzername" v-model="username" />
        </div>
        <div class="input-container">
          <input type="email" placeholder="E-Mail" v-model="email" />
        </div>
        <div class="input-container">
          <input type="password" placeholder="Passwort" v-model="password" />
        </div>
        <div class="input-container">
          <input type="file" id="profile-image" name="profile-image" accept="image/png, image/jpeg" @change="previewImage($event)">
        </div>
        <div class="input-container">
          <input type="text" placeholder="Steckbrief" style="height: 50px;" v-model="bio" />
        </div>
        <button @click="registerUser">Registrieren</button>
        <h3>Du hast <span class="highlight">bereits</span> einen Account?</h3>
        <button id="signUp" @click="redirectToLogin">Einloggen</button>
      </div>
    </div>
    <div>
      <h1>Hallo, Sportsfreund!</h1>
      <p>
        Herzlich Willkommen auf unserer Social Fitness Plattform
      </p>
      <p>
        Entdecke eine blühende Fitness-Community! Schließe dich uns an,
        um dich zu <span class="highlight">vernetzen</span>, zu
        <span class="highlight">teilen</span>, und um Ziele zu
        <span class="highlight">erreichen!</span>
      </p>
      <p>
        <span class="highlight">Vernetze dich</span>: Finde Fitnessfreunde.
        Erhalte Unterstützung, Motivation und Ratschläge von Menschen, die
        deinen Weg verstehen.
      </p>
      <p>
        <span class="highlight">Teile</span>: Inspiriere mit Fortschritten,
        Workouts und Tipps. Lerne von anderen und trage zu unserer
        unterstützenden Community bei.
      </p>
      <p>
        <span class="highlight">Erreiche</span>: Erreiche deine Fitnessziele
        mit unserer unterstützenden Community. Ob Gewichtsverlust,
        Muskelaufbau oder einfach nur eine bessere Gesundheit, wir helfen
        dir zum Erfolg.
      </p>
      <p>
        Warte nicht länger! <span class="highlight">Melde dich jetzt an</span>
        und lass uns gemeinsam die Reise zu einer besseren Gesundheit
        antreten! 
      </p>
    </div>
  </div>

  <div id="image-preview-container">
    <h1 v-if="showPreviewText">Ausgewähltes Bild</h1>
    <div class="image-preview" id="image-preview"></div>
  </div>
</template>

<script setup>
import { ref } from 'vue';
import axios from 'axios';

const showPreviewText = ref(false);
const username = ref('');
const email = ref('');
const password = ref('');
const bio = ref('');

function previewImage(event) {
  console.log("Bild ausgewählt");
  const file = event.target.files[0];
  const url = URL.createObjectURL(file);
  const img = document.createElement('img');
  img.src = url;
  img.style.width = '200px'; // Vorschau-Größe anpassen

  // Vorheriges Bildvorschau-Element leeren
  const imagePreview = document.getElementById('image-preview');
  while (imagePreview.firstChild) {
    imagePreview.removeChild(imagePreview.lastChild);
  }

  // Neues Bildvorschau-Element hinzufügen
  imagePreview.appendChild(img);
  showPreviewText.value = true; // Setze die Variable, um den Text anzuzeigen
}

function redirectToLogin() {
  // Weiterleitung zur Registrierungsseite
  window.location.href = "/login";
}
</script>

<script>
import axios from 'axios';

export default {
  data() {
    return {
      model: {
        email: "",
        password: "",
        username: "",
        bio: "",
      }
    };
  },
  methods: {
    async registerUser() {
      try {
        const response = await axios.post("https://localhost:7001/api/User/register", {
          username: this.username,
          mail: this.email,
          profilePicPath: "path/to/image",
          initialPasswords: this.password,
          bio: this.bio
        });
        alert("Registration successful!");
      } catch (error) {
        console.error(error);
        alert("Registration failed.");
      }
    },
  }
}
</script>

<style scoped>
/* CSS-Stile hier einfügen */
.highlight {
  color: rgb(74, 113, 165);
  font-size: 18px;
  font-weight: bold;
}

.container {
  margin-left: auto;
  margin-right: auto;
  display: flex;
  flex-direction: column;
  align-items: center;
}

.input-container {
  width: 80%;
}

form {
  background-color: #222;
  display: flex;
  align-items: center;
  justify-content: center;
  flex-direction: column;
  padding: 0 50px;
  height: 100%;
  text-align: center;
}

input {
  background-color: #eee;
  border: none;
  padding: 12px;
  margin: 8px 0;
  width: 100%; /* Adjust width as needed */
}

#image-preview-container {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  margin-top: 20px;
}

.image-preview {
  width: 200px;
  height: 200px;
  overflow: hidden;
  margin-bottom: 10px;
}

#image-preview img {
  width: 100%;
  height: 100%;
  object-fit: cover;
}

.border {
  background-color: #151618;
  border-radius: 10px;
  border-left: 200px;
  box-shadow: 0 14px 28px rgba(0, 0, 0, 0.25), 0 10px 10px rgba(0, 0, 0, 0.22);
  width: 500px;
  min-height: 450px;
  margin-left: auto;
  margin-right: auto;
}

button:hover {
  cursor: pointer; /* Ändere den Mauszeiger auf Zeiger, wenn über dem Button */
}

button {
  width: 110px;
  height: 50px;
  margin-top: 5px;
  margin-bottom: 10px;
  background-color: rgb(74, 113, 165);
  color: rgb(255, 255, 255);
  border-radius: 20px;
  border: 1px solid rgb(74, 113, 165);
  font-size: 12px;
  font-weight: bold;
  transition: transform 80ms ease-in;
}

p {
  font-size: 18px;
  font-weight: 100;
  line-height: 20px;
  letter-spacing: 0.5px;
  margin: 20px 0 30px;
  margin-bottom: 0px;
  color: #ffffff;
}

.Bild {
  margin-left: 5%;
}

.grid-container {
  display: grid;
  grid-template-columns: auto auto;
  margin-left: 5%;
  padding-bottom: 5%;
}

p {
  width: 500px;
}
</style>
