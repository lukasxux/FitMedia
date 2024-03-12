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
      </div>
        <div class="grid-item">
            <div class="grid-item">
        <H2>Username</H2>
        <img src="@/assets/Test-Bild.png" alt="" width="300">
        <p id="Beitrag-Text">Neue Bestzeit beim Laufen erreicht! 🏃‍♂️💪 Motivation tanken und Ziele übertreffen. #FitnessLife #LäuferHoch #GrenzenVerschieben</p>
      </div>
        </div>
        <div class="item2">
            <div>
                <img src="@/assets/profile-picture.png" alt="" width="150">
                <h3>Username</h3>
            </div>
            <div>
                <img src="@/assets/profile-picture.png" alt="" width="150">
                <h3>Username</h3>
            </div>
            <div>
                <img src="@/assets/profile-picture.png" alt="" width="150">
                <h3>Username</h3>
            </div>
            <div>
                <img src="@/assets/profile-picture.png" alt="" width="150">
                <h3>Username</h3>
            </div>
            <div>
                <img src="@/assets/profile-picture.png" alt="" width="150">
                <h3>Username</h3>
            </div>
            <div>
                <img src="@/assets/profile-picture.png" alt="" width="150">
                <h3>Username</h3>
            </div>
            <div>
                <img src="@/assets/profile-picture.png" alt="" width="150">
                <h3>Username</h3>
            </div>
        </div>
        <div class="grid-item">
            <div class="grid-item">
        <H2>Username</H2>
        <img src="@/assets/Test-Bild.png" alt="" width="300">
        <p id="Beitrag-Text">Neue Bestzeit beim Laufen erreicht! 🏃‍♂️💪 Motivation tanken und Ziele übertreffen. #FitnessLife #LäuferHoch #GrenzenVerschieben</p>
      </div>
        </div>  
        <div class="grid-item">
            <div class="grid-item">
        <H2>Username</H2>
        <img src="@/assets/Test-Bild.png" alt="" width="300">
        <p id="Beitrag-Text">Neue Bestzeit beim Laufen erreicht! 🏃‍♂️💪 Motivation tanken und Ziele übertreffen. #FitnessLife #LäuferHoch #GrenzenVerschieben</p>
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

h3{
  padding-bottom: 30px;
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

</style>
