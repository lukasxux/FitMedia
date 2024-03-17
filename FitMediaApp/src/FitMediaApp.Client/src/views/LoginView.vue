<template>
    <div class="grid-container">
      <div class="border form-container sign-up-container" id="border">
        <div class="container" id="container">
          <h1 id="create-account">Einloggen</h1>
          <div class="input-container">
            <input type="text" placeholder="Benutzername / E-Mail" />
          </div>
          <div class="input-container">
            <input type="password" placeholder="Passwort" />
          </div>
          <button>Einloggen</button>
          <h3>Du hast <span class="highlight">noch keinen</span>  Account?</h3>
          <button id="signUp" @click="redirectToRegister">Registrieren</button>
        </div>
      </div>
      <div>
        <h1>Willkommen zurück!</h1>
        <p>
            Willkommen zurück!
        </p>
        <p>
            Schön, dass du <span class="highlight">wieder </span>da bist auf unserer Social Fitness Plattform.
        </p>
        <p>
            <span class="highlight">Entdecke</span>, 
            <span class="highlight">vernetze dich</span> und <span class="highlight">erreiche</span> deine Ziele gemeinsam mit unserer 
            Fitness-Community.
        </p>
        <p>
            <span class="highlight">Teile</span> deine Fortschritte, finde Unterstützung 
            und motiviere andere.
        </p>
        <p>
            <h2>Bereit zum Start?</h2>
        </p>
        <p>
            <span class="highlight">Melde dich jetzt an</span> und sei dabei, wenn wir gemeinsam auf dem Weg zu einem gesünderen Leben sind!
        </p>
      </div>
    </div>
  
    <div id="image-preview-container">
      <h1 v-if="showPreviewText" >Ausgewähltes Bild</h1>
      <div class="image-preview" id="image-preview"></div>
    </div>
  </template>
  
  <style scoped>

button:hover {
  cursor: pointer; /* Ändere den Mauszeiger auf Zeiger, wenn über dem Button */
}

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
  
  <script setup>
  import { ref } from 'vue';
    function redirectToRegister() {
    // Weiterleitung zur Registrierungsseite
    window.location.href = "/register";
    }

  </script>
  