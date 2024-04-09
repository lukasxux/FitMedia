<script setup>
</script>

<template>
  <div>
    <div>
      <h1><span style="color: rgb(74, 113, 165);">Fit-</span>Media</h1>
    </div>
    <div>
      <h2 id="short-text">Willkommen zurück <Span style="color: rgb(74, 113, 165);">{{ username }}</Span>!</h2>
      <h3 id="short-text">Hier sind die <Span style="color: rgb(74, 113, 165);">neuesten Beiträge</Span>, von denen die dir <Span style="color: rgb(74, 113, 165);">wichtig</Span> sind.</h3>
    </div>
    <div class="grid-container">
        <div class="grid-item">
          <H2>Luca</H2>
          <img src="@/assets/Test-Bild.png" alt="" width="300">
          <p id="Beitrag-Text">Neue Bestzeit beim Laufen erreicht! 🏃‍♂️💪 Motivation tanken und Ziele übertreffen. #FitnessLife #LäuferHoch #GrenzenVerschieben</p>
          <div>
            <input type="text" v-model="commentText"> 
            <button @click="addComment"><i class="bi bi-send-fill"></i></button>
          </div>
          <p id="kommentar">{{ newComment }}</p>
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
          <div v-for="user in users" :key="user.guid">
            <h3>{{ user.username }}</h3>
            <img :src="`https://localhost:7001/${user.profilePicPath}`" alt="" width="150">
            <button id="folgen" @click="toggleFollowStatus(user)" :style="{ backgroundColor: checkFollowStatus(user.username) ? 'red' : 'rgb(74, 113, 165)' }">
              {{ checkFollowStatus(user.username) ? 'Profil entfernen' : 'Profil folgen' }}
            </button>
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
  text-align: center;
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
  border: 1px solid rgb(28, 29, 29);
  width: 120px;
  height: 20px;
  color: rgb(255, 255, 255);
  font-size: 12px;
  font-weight: bold;
  transition: transform 80ms ease-in;
  padding-bottom: 25px;
  margin-top: 10px;
  margin-right: 12px;
  margin-bottom: 20px;
}
</style>

<script setup>
import { ref, onMounted } from 'vue';
import axios from 'axios';

const username = ref('');
const commentText = ref('');
const newComment = ref('');
const users = ref([]);

// Funktion zur Prüfung und Wiederherstellung des Follow-Status aus dem localStorage
function checkFollowStatus(username) {
  const followStatus = localStorage.getItem(`followStatus_${username}`);
  return followStatus === 'true'; // Gibt true zurück, wenn Benutzer gefolgt ist, sonst false
}

// Funktion zum Ändern des Follow-Status im localStorage und lokalen Zustand
async function toggleFollowStatus(user) {
  try {
    const username = user.username;
    const currentStatus = localStorage.getItem(`followStatus_${username}`);
    const newStatus = currentStatus === 'true' ? 'false' : 'true';
    localStorage.setItem(`followStatus_${username}`, newStatus);

    // Lokalen Zustand aktualisieren
    const updatedUsers = users.value.map(u => {
      if (u.username === username) {
        return { ...u, isFollowed: newStatus === 'true' };
      }
      return u;
    });
    users.value = updatedUsers;

    // API-Aufruf zum Folgen/Entfolgen des Benutzers
    const response = await axios.post(`https://localhost:7001/api/User/follow/${username}`);
    console.log(`Du folgst jetzt ${username}. API response:`, response.data);
  } catch (error) {
    console.error(error);
  }
}

async function fetchUserData() {
  try {
    const guid = sessionStorage.getItem('userGuid');
    const response = await axios.get(`https://localhost:7001/api/user/${guid}`);
    username.value = response.data.username;
  } catch (error) {
    console.error(error);
  }
}

async function fetchAllUserData() {
  try {
    const response = await axios.get('https://localhost:7001/api/User');
    const userDataWithFollowStatus = response.data.map(user => ({
      ...user,
      isFollowed: checkFollowStatus(user.username)
    }));
    users.value = userDataWithFollowStatus;
  } catch (error) {
    console.error(error);
  }
}

onMounted(() => {
  fetchAllUserData();
  fetchUserData();
});

</script>