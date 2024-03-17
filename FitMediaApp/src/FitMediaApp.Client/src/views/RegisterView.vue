<script setup>
</script>

<template>
  <div class="container">
    <div class="form-container sign-up-container">
      <form @submit.prevent="loginUser">
        <h1 id="sign-account">Anmelden</h1>
        <input type="email" placeholder="E-Mail" v-model="model.email" />
        <input
          type="password"
          placeholder="Passwort"
          v-model="model.password"
        />
        <button type="submit">Anmelden</button>
      </form>
    </div>
    <div class="form-container sign-in-container">
      <form action="#">
        <br>
        <h1 id="create-account">Account erstellen</h1>
        <br>
        <input
          type="text"
          placeholder="Benutzername"
          v-model="regmodel.regUsername"
        />
        <input type="email" placeholder="E-Mail" v-model="regmodel.regEmail" />
        <input
          type="password"
          placeholder="Passwort"
          v-model="regmodel.regPassword"
        />
        <div class="image-container">
          <input type="file" id="profile-image" name="profile-image" accept="image/png, image/jpeg" @change="previewImage">
        </div>

        <br>
        <input
          type="text"
          placeholder="Steckbrief"
          v-model="regmodel.regCharacteristics"
          style="height: 100px;"
        />

        <button>Registrieren</button>
        <br>
        <h3>Du hast <span class="highlight">bereits</span> einen Account?</h3>
        <br>
        <button class="ghost" id="signUp">Einloggen</button>
        <br>
      </form>
    </div>
    <div class="overlay-container">
      <div class="overlay">
        <div class="overlay-panel overlay-right">
          <h1>Hallo!</h1>
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
    </div>
  </div>

  <div id="image-preview-container">
  <h1 v-if="showPreviewText" >Ausgewähltes Bild</h1>
  <div class="image-preview" id="image-preview"></div>
</div>


</template>


<style scoped>

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

.preview-text {
  font-size: 18px;
  font-weight: bold;
  color: #ffffff; /* Farbe entsprechend anpassen */
}

#profile-image {
  width: 400px;
  margin-bottom: -20px;
}

.highlight {
  color: rgb(74, 113, 165);
  font-size: 18px;
  font-weight: bold;
}

#forgot-password {
  color: #ffffff;
}

#create-account,
#sign-account {
  color: #ffffff;
}

@import url("https://fonts.googleapis.com/css?family=Montserrat:400,800");

* {
  box-sizing: border-box;
}

body {
  background: #151618; /* Hintergrundfarbe entsprechend anpassen */
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: column;
  font-family: "Montserrat", sans-serif;
  height: 100vh;
  margin: -20px 0 50px;
}

h1 {
  font-weight: bold;
  margin: 0;
}

h2 {
  text-align: center;
}

p {
  font-size: 18px;
  font-weight: 100;
  line-height: 20px;
  letter-spacing: 0.5px;
  margin: 20px 0 30px;
  margin-bottom: 0px;
  color: #ffffff; /* Farbe entsprechend anpassen */
}

span {
  font-size: 12px;
}

a {
  color: #ffffff; /* Farbe entsprechend anpassen */
  font-size: 14px;
  text-decoration: none;
  margin: 15px 0;
}

button{
  margin-left: 7%;
  width: 150px;
  height: 50px;
  margin-top: 15px;
  background-color: rgb(74, 113, 165);
  color: rgb(255, 255, 255);
  border-radius: 20px;
  border: 1px solid rgb(74, 113, 165);
  font-size: 20px;
  font-weight: bold;
  transition: transform 80ms ease-in;
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
  padding: 12px 15px;
  margin: 8px 0;
  width: 100%;
}

.container {
  background-color: #151618; /* Hintergrundfarbe entsprechend anpassen */
  border-radius: 10px;
  box-shadow: 0 14px 28px rgba(0, 0, 0, 0.25), 0 10px 10px rgba(0, 0, 0, 0.22);
  margin: auto;
  margin-top: 8%;
  max-width: 1000px;
  min-height: 580px;
  text-align: center;
  overflow: hidden;
  overflow-y: hidden;
}

.form-container {
  position: absolute;
  top: 0;
  height: 100%;
  transition: all 0.6s ease-in-out;
}

.sign-in-container {
  left: 0;
  width: 50%;
  z-index: 2;
}

.container.right-panel-active .sign-in-container {
  transform: translateX(100%);
}

.sign-up-container {
  left: 0;
  width: 50%;
  opacity: 0;
  z-index: 1;
}

.container.right-panel-active .sign-up-container {
  transform: translateX(100%);
  opacity: 1;
  z-index: 5;
  animation: show 0.6s;
}

@keyframes show {
  0%,
  49.99% {
    opacity: 0;
    z-index: 1;
  }

  50%,
  100% {
    opacity: 1;
    z-index: 5;
  }
}

.overlay-container {
  position: absolute;
  top: 0;
  left: 50%;
  width: 50%;
  height: 100%;
  overflow: hidden;
  transition: transform 0.6s ease-in-out;
  z-index: 100;
}

.container.right-panel-active .overlay-container {
  transform: translateX(-100%);
}

.overlay {
  background: #222;
  background-repeat: no-repeat;
  background-size: cover;
  background-position: 0 0;
  color: #ffffff;
  position: relative;
  left: -100%;
  height: 100%;
  width: 200%;
  transform: translateX(0);
  transition: transform 0.6s ease-in-out;
}

.container.right-panel-active .overlay {
  transform: translateX(50%);
}

.overlay-panel {
  position: absolute;
  display: flex;
  align-items: center;
  justify-content: center;
  flex-direction: column;
  padding: 0 40px;
  text-align: center;
  top: 0;
  height: 100%;
  width: 50%;
  transform: translateX(0);
  transition: transform 0.6s ease-in-out;
}

.overlay-left {
  transform: translateX(-20%);
}

.container.right-panel-active .overlay-left {
  transform: translateX(0);
}

.overlay-right {
  right: 0;
  transform: translateX(0);
}

.container.right-panel-active .overlay-right {
  transform: translateX(20%);
}

.social-container {
  margin: 20px 0;
}

.social-container a {
  border: 1px solid rgb(74, 113, 165);
  border-radius: 50%;
  display: inline-flex;
  justify-content: center;
  align-items: center;
  margin: 0 5px;
  height: 40px;
  width: 40px;
}
</style>


<script>
export default {
  data() {
    return {
      regmodel: {
        regUsername: "",
        regEmail: "",
        regPassword: "",
        regCharacteristics: ""
      },
      model: {
        email: "",
        password: ""
      },
      showPreviewText: false // Füge die Variable hier hinzu
    };
  },
  methods: {
    async registerUser() {
      // Implementiere deine Logik für die Registrierung hier
    },
    async loginUser() {
      // Implementiere deine Logik für das Einloggen hier
    },
    previewImage() {
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
  this.showPreviewText = true; // Setze die Variable, um den Text anzuzeigen
}

  }
};
</script>