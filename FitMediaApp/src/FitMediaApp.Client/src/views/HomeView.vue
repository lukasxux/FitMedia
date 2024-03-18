<script setup>
</script>

<template>
  <div>
    <div>
      <h1><span style="color: rgb(74, 113, 165);">Fit-</span>Media</h1>
    </div>
    <div>
      <h2 id="short-text">Willkommen zurück <Span style="color: rgb(74, 113, 165);">Username</Span>!</h2>
      <h3 id="short-text">Hier sind die <Span style="color: rgb(74, 113, 165);">neuesten Beiträge</Span>, von denen die dir <Span style="color: rgb(74, 113, 165);">wichtig</Span> sind.</h3>
    </div>
    <div class="grid-container">
        <div class="grid-item">
          <H2>Username</H2>
          <img src="@/assets/Test-Bild.png" alt="" width="300">
          <p id="Beitrag-Text">Neue Bestzeit beim Laufen erreicht! 🏃‍♂️💪 Motivation tanken und Ziele übertreffen. #FitnessLife #LäuferHoch #GrenzenVerschieben</p>
          <div>
            <input type="text"> 
            <button><i class="bi bi-send-fill"></i></button>
          </div>
        </div>
        <div class="grid-item">
          <div class="grid-item">
            <H2>Username</H2>
            <img src="@/assets/Test-Bild.png" alt="" width="300">
            <p id="Beitrag-Text">Neue Bestzeit beim Laufen erreicht! 🏃‍♂️💪 Motivation tanken und Ziele übertreffen. #FitnessLife #LäuferHoch #GrenzenVerschieben</p>
            <div>
              <input type="text"> 
              <button><i class="bi bi-send-fill"></i></button>
            </div>
          </div>
        </div>
        <div class="item2">
          <div>
            <h3>Username</h3>
            <img src="@/assets/profile-picture.png" alt="" width="150">
            <button id="folgen">Profil Folgen</button>
          </div>
          <div>
            <h3>Username</h3>
            <img src="@/assets/profile-picture.png" alt="" width="150">
            <button id="folgen">Profil Folgen</button>
          </div>
          <div>
            <h3>Username</h3>
            <img src="@/assets/profile-picture.png" alt="" width="150">
            <button id="folgen">Profil Folgen</button>
          </div>
          <div>
            <h3>Username</h3>
            <img src="@/assets/profile-picture.png" alt="" width="150">
            <button id="folgen">Profil Folgen</button>
          </div>
          <div>
            <h3>Username</h3>
            <img src="@/assets/profile-picture.png" alt="" width="150">
            <button id="folgen">Profil Folgen</button>
          </div>
          <div>
            <h3>Username</h3>
            <img src="@/assets/profile-picture.png" alt="" width="150">
            <button id="folgen">Profil Folgen</button>
          </div>
          <div>
            <h3>Username</h3>
            <img src="@/assets/profile-picture.png" alt="" width="150">
            <button id="folgen">Profil Folgen</button>
          </div>
          <div>
            <h3>Username</h3>
            <img src="@/assets/profile-picture.png" alt="" width="150">
            <button id="folgen">Profil Folgen</button>
          </div>
        </div>
        <div class="grid-item">
          <div class="grid-item">
            <H2>Username</H2>
            <img src="@/assets/Test-Bild.png" alt="" width="300">
            <p id="Beitrag-Text">Neue Bestzeit beim Laufen erreicht! 🏃‍♂️💪 Motivation tanken und Ziele übertreffen. #FitnessLife #LäuferHoch #GrenzenVerschieben</p>
            <div>
              <input type="text"> 
              <button><i class="bi bi-send-fill"></i></button>
            </div>
          </div>
        </div>  
        <div class="grid-item">
          <div class="grid-item">
            <H2>Username</H2>
            <img src="@/assets/Test-Bild.png" alt="" width="300">
            <p id="Beitrag-Text">Neue Bestzeit beim Laufen erreicht! 🏃‍♂️💪 Motivation tanken und Ziele übertreffen. #FitnessLife #LäuferHoch #GrenzenVerschieben</p>
            <div>
               <input type="text"> 
              <button><i class="bi bi-send-fill"></i></button>
            </div>
          </div>
        </div>
    </div>
  </div>
</template>

<style scoped>
.grid-container {
  display: grid;
  gap: 10px;
  margin-left: 10%;
  padding-bottom: 20px;
}

.item2 {
  grid-column: 3;
  grid-row: 1 / span 2;
  text-align: center;
  margin-right: 50%;
  overflow: auto;
  height: 700px;
  width: 200px;
  margin-top: 45px;
}

#Beitrag-Text{
  overflow: auto;
  height: 100px;
  width: 300px;
}

h1{
  text-align: center;
}

#short-text{
  width: 400px;
  text-align: center;
  margin-left: 37%;
  padding-bottom: 20px;
}

input{
  width: 237.5px;
  height: 27px;
  border-radius: 5px;
  border: 1px solid;
}

button{
  padding-top: 10px;
  margin-left: 10px;  
  width: 30px;
  height: 30px;
  background-color: rgb(74, 113, 165);
  border-radius: 5px;
  border: 1px solid rgb(74, 113, 165);
  transition: transform 80ms ease-in;
}

#folgen{
  background-color: rgb(74, 113, 165);
  border-radius: 5px;
  border: 1px solid rgb(74, 113, 165);
  width: 120px;
  height: 20px;
  color: rgb(255, 255, 255);
  font-size: 12px;
  font-weight: bold;
  transition: transform 80ms ease-in;
  padding-bottom: 25px;
  margin-top: 10px;
  margin-right: 12px;
}
</style>
