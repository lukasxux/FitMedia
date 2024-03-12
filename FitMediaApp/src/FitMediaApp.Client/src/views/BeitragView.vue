<script setup>
</script>

<template>
  <div class="grid-container">
    <div class="border" id="border">
      <div class="container" id="container">
        <div>
          <h2 class="Bild">Fügen Sie ein Bild hinzu</h2>
        </div>
        <div>
          <img src="@/assets/Upload.png" alt="" width="300" length="300">
        </div>
        <br>
        <div>
          <h2 class="text-fügen">Fügen Sie einen Text hinzu</h2>
        </div>
        <div>
          <textarea id="text" name="text" cols="35" rows="5"></textarea>
        </div>
        <div>
          <button class="button-1">Beitrag veröffentlichen</button> 
          <button class="button-2">Beitrag verwerfen</button>
        </div>
        <br>
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

button{
  margin-left: 7%;
  width: 110px;
  height: 50px;
  margin-top: 25px;
  background-color: rgb(74, 113, 165);
  color: rgb(255, 255, 255);
  border-radius: 20px;
  border: 1px solid rgb(74, 113, 165);
  font-size: 12px;
  font-weight: bold;
  transition: transform 80ms ease-in;
}

.Bild{
  margin-left: 5%;
}

.text-fügen{
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
</style>