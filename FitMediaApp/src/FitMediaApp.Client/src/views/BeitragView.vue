<script setup>
</script>

<template>
  <div class="grid-container">
    <div class="border">
      <div class="container">
        <div>
          <h2 class="Bild">Fügen Sie ein Bild hinzu</h2>
        </div>
        <div>
          <label for="file-upload" class="custom-file-upload">
            <input id="file-upload" type="file" @change="handleFileUpload">
            Wählen Sie eine Datei aus
          </label>
          <img v-if="post.file" :src="post.imageUrl" alt="Bildvorschau" id="Upload" width="300" height="300">
          <img v-else src="@/assets/Upload.png" alt="Platzhalterbild" id="Upload" width="300" height="300">
        </div>
        <br>
        <div>
          <h2 class="text-fügen">Fügen Sie einen Text hinzu</h2>
        </div>
        <div>
          <textarea v-model="post.description" cols="35" rows="5"></textarea>
        </div>
        <div>
          <button class="button-1" @click="savePost">Beitrag veröffentlichen</button> 
        </div>
        <br>
        <div v-if="uploadError" class="error">{{ uploadError }}</div>
      </div>
    </div>
    <div>
      <div>
        <h1><span style="color: rgb(74, 113, 165);">Beitrag</span> Erstellen</h1>
        <p>Mit unserer <span style="color: rgb(74, 113, 165);">intuitiven Beitragserstellung</span> kannst du deine <span style="color: rgb(74, 113, 165);">Gedanken</span>, <span style="color: rgb(74, 113, 165);">Erlebnisse</span> und <span style="color: rgb(74, 113, 165);">Ideen</span> in kürzester Zeit mit der <span style="color: rgb(74, 113, 165);">Welt</span> teilen. Wir glauben daran, dass jeder <span style="color: rgb(74, 113, 165);">Beitrag</span> einzigartig ist und eine eigene <span style="color: rgb(74, 113, 165);">Geschichte</span> erzählt</p>
      </div>
      <br>
      <div>
        <h3><span style="color: rgb(74, 113, 165);">Bilder</span> Hinzufügen: Bringe deine <span style="color: rgb(74, 113, 165);">Posts</span> zum <span style="color: rgb(74, 113, 165);">Leben</span>!</h3>
        <p>Möchtest du deinen <span style="color: rgb(74, 113, 165);">Beiträgen</span> das gewisse Etwas verleihen? 
           Auf <span style="color: rgb(74, 113, 165);">Fit-Media</span> kannst du mit unserer <span style="color: rgb(74, 113, 165);">innovativen Funktion</span> jetzt problemlos <span style="color: rgb(74, 113, 165);">Bilder</span> zu deinen <span style="color: rgb(74, 113, 165);">Posts</span> hinzufügen und deine Erlebnisse visuell teilen. 
           Egal, ob es um inspirierende <span style="color: rgb(74, 113, 165);">Momente</span>, aufregende <span style="color: rgb(74, 113, 165);">Ereignisse</span> oder einfach um das tägliche Leben geht 
           – mit unserer <span style="color: rgb(74, 113, 165);">Webapplikation</span> kannst du deine <span style="color: rgb(74, 113, 165);">Geschichten</span> durch <span style="color: rgb(74, 113, 165);">beeindruckende Bilder</span> noch aussagekräftiger gestalten.
        </p>
      </div>
      <br>
      <div>
        <h3><span style="color: rgb(74, 113, 165);">Text</span> hinzufügen: Deine <span style="color: rgb(74, 113, 165);">Worte</span> im Fokus</h3>
        <p>Möchtest du deine <span style="color: rgb(74, 113, 165);">Gedanken</span>, <span style="color: rgb(74, 113, 165);">Ideen</span> und <span style="color: rgb(74, 113, 165);">Geschichten</span> in voller Tiefe teilen? Mit unserer <span style="color: rgb(74, 113, 165);">benutzerfreundlichen</span> Funktion zum Hinzufügen von <span style="color: rgb(74, 113, 165);">Text</span> kannst du <span style="color: rgb(74, 113, 165);">spielend leicht</span> fesselnde Beiträge verfassen. Mit <span style="color: rgb(74, 113, 165);">Fit-Media</span> wird das <span style="color: rgb(74, 113, 165);">Teilen</span> deiner <span style="color: rgb(74, 113, 165);">Gedanken</span> so <span style="color: rgb(74, 113, 165);">unkompliziert</span> wie nie zuvor. Lass deiner <span style="color: rgb(74, 113, 165);">Kreativität</span> freien Lauf und teile deine <span style="color: rgb(74, 113, 165);">einzigartige Stimme</span> mit der <span style="color: rgb(74, 113, 165);">Welt</span>!</p>
      </div>
    </div>
  </div>
</template>

<style scoped>
#input{
padding: 67px;
}

.border {
  background-color: #151618;
  border-radius: 10px;
  border-left: 200px;
  box-shadow: 0 14px 28px rgba(0, 0, 0, 0.25), 0 10px 10px rgba(0, 0, 0, 0.22);
  width: 500px;
  min-height: 450px;
  margin-left: 18%;
}

.container{
  margin-left: 19%;
}

button:hover {
  cursor: pointer; /* Ändere den Mauszeiger auf Zeiger, wenn über dem Button */
}

button{
  margin-left: 12%;
  width: 200px;
  height: 30px;
  margin-top: 15px;
  background-color: rgb(74, 113, 165);
  color: rgb(255, 255, 255);
  border-radius: 10px;
  border: 1px solid rgb(74, 113, 165);
  font-size: 12px;
  font-weight: bold;
  transition: transform 80ms ease-in;
}

.Bild{
  margin-left: 5%;
}

.text-fügen{
  margin-top: 5px;
  margin-left: 2.3%;
}

textarea{
  width: 295px;
}

.grid-container {
  display: grid;
  grid-template-columns: auto auto;
  margin-left: 5%;
  padding-bottom: 5%;
}

p{
  width: 500px;
}

.custom-file-upload {
  margin-top: 10px;
  margin-left: 15.5%;
  background-color: rgb(74, 113, 165);
  color: white;
  padding: 6px 12px;
  border-radius: 10px;
  cursor: pointer;
  font-size: 12px;
  font-weight: bold;
}

.custom-file-upload input[type="file"] {
  display: none;
}

#Upload{
  margin-top: 15px; 
}
</style>

<script>
import axios from 'axios';

export default {
  data() {
    return {
      post: {
        description: "",
        file: null,
        imageUrl: ""
      },
      uploadError: null
    };
  },
  methods: {
    handleFileUpload(event) {
      const file = event.target.files[0];
      const url = URL.createObjectURL(file);
      this.post.imageUrl = url;
      this.post.file = file;
    },
    async savePost() {
      try {
        if (!this.post.description || !this.post.file) {
          this.uploadError = "Bitte füllen Sie alle Felder aus.";
          return;
        }

        const formData = new FormData();
        formData.append('Description', this.post.description);
        formData.append('File', this.post.file);
        console.log(this.post.file);

        const uploadPostPath = 'https://localhost:7001/api/Post/uploadPost';

        axios.defaults.withCredentials = true;
        await axios.post(uploadPostPath, formData, {
          headers: {
            'Content-Type': 'multipart/form-data'
          }
        });
        
        console.log('Beitrag erfolgreich erstellt');
        window.location.href = "/profile";
        // Reset der Eingaben nach erfolgreichem Speichern
        this.resetForm();
      } catch (error) {
        console.error('Fehler beim Erstellen des Beitrags:', error);
        this.uploadError = "Fehler beim Hochladen des Beitrags. Bitte überprüfen Sie Ihre Verbindung und versuchen Sie es erneut.";
      }
    },
    resetForm() {
      // Zurücksetzen der Eingabefelder
      this.post.description = "";
      this.post.file = null;
      this.post.imageUrl = "";
    }
  }
}
</script>
