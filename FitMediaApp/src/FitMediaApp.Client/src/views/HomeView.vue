<template>
  <div>
    <div>
      <h1><span style="color: rgb(74, 113, 165);">Fit-</span>Media</h1>
    </div>
    <div>
      <h2 id="short-text">Willkommen zurück <span style="color: rgb(74, 113, 165);">{{ username }}</span>!</h2>
      <h3 id="short-text">Hier sind die <span style="color: rgb(74, 113, 165);">neuesten Beiträge</span>, von denen die dir <span style="color: rgb(74, 113, 165);">wichtig</span> sind.</h3>
    </div>
    <div class="grid-container">
      <div id="border" class="grid-item" v-for="post in Posts" :key="post.guid">
          <h2>{{ post.user.username }}</h2>
          <img :src="post.filePathPic" alt="" width="300" height="300">
          <p id="Beitrag-Text">{{ post.description }}</p>
          <div>
            <input type="text" v-model="post.commentText"> 
            <button id="send" @click="addComment(post)">→</button>
            <button id="like" @click="toggleLike(post)" :style="{ backgroundColor: post.isLiked ? 'red' : 'rgb(74, 113, 165)' }">
              {{ post.isLiked ? '♡' : '♡' }}
            </button>
          </div>
          <div class="comment">
            <p id="single-comment" v-for="comment in post.comments" :key="comment.guid">{{ comment.text }}</p>
          </div>
        </div>
        <div class="item2">
          <div v-for="user in users" :key="user.guid">
            <h3>{{ user.username }}</h3>
            <img :src="`https://localhost:7001/${user.profilePicPath}`" alt="" width="150">
            <button id="folgen" @click="toggleFollowStatus(user)" :style="{ backgroundColor: checkFollowStatus(user.username) ? 'red' : 'rgb(74, 113, 165)' }">
              {{ checkFollowStatus(user.username) ? 'Profil entfolgen' : 'Profil folgen' }}
            </button>
          </div>
        </div>
    </div>
  </div>
</template>

<style scoped>
#single-comment{
  background-color: #0e0f10;
  border-radius: 5px;
  width: 250px;
  padding-left: 5px;
}

#border {
  background-color: #222427;
  border-radius: 5px;
  box-shadow: 0 14px 28px rgba(0, 0, 0, 0.25), 0 10px 10px rgba(0, 0, 0, 0.22);
  width: 300px;
  height: 670px;
  padding: 20px;
  margin-bottom: 40px;
}

.comment {
  height: 200px;
  width: 300px;
  overflow: auto;
}
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
  background-color: #222427;
  border-radius: 5px;
  box-shadow: 0 14px 28px rgba(0, 0, 0, 0.25), 0 10px 10px rgba(0, 0, 0, 0.22);
  height: 670px;
  padding: 10px;
  margin-bottom: 20px;
}

.send{
  margin-top: 6px;
}

#Beitrag-Text{
  overflow: auto;
  width: 295px;
  height: 70px;
  background-color: rgb(26, 27, 28);
  border-radius: 5px;
  padding-left: 5px;
}

h1{
  text-align: center;
}

#short-text{
  text-align: center;
  padding-bottom: 20px;
}

input{
  width: 210px;
  height: 27px;
  border-radius: 5px;
  border: 1px solid;
  margin-bottom: 10px;
}

#send{
  margin-left: 10px;  
  width: 30px;
  height: 30px;
  background-color: rgb(74, 113, 165);
  border-radius: 5px;
  border: 1px solid rgb(74, 113, 165);
  color: white;
}

#like{
  margin-left: 10px;  
  margin-bottom: -10px;
  width: 30px;
  height: 30px;
  background-color: rgb(74, 113, 165);
  border-radius: 5px;
  border: 1px solid rgb(28, 29, 29);
  color: white;
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
  padding-top: 10px;
  margin-top: 10px;
  margin-bottom: 20px;
}

h2{
  margin-top: -10px;
  margin-bottom: -5px;
}
</style>

<script setup>
import { ref, onMounted } from 'vue';
import axios from 'axios';

const username = ref('');
const users = ref([]);
const Posts = ref([]);

function checkFollowStatus(username) {
  const followStatus = localStorage.getItem(`followStatus_${username}`);
  return followStatus === 'true';
}

async function fetchPostUser() {
  try {
    const response = await axios.get(`https://localhost:7001/api/Post?$expand=user,comments`);
    Posts.value = response.data.slice(0, 100);
    console.log(response.data);
  } catch (error) {
    console.error(error);
  }
}

async function addComment(post) {
  console.log(post.guid);
  try {
    const response = await axios.post(`https://localhost:7001/api/Post/comment`, {
      guid: post.guid,
      text: post.commentText,
      date: new Date().toISOString()
    });
    post.comments.push(response.data);
    post.commentText = '';
  } catch (error) {
    console.error(error);
  }
}

async function toggleLike(post) {
  try {
    const response = await axios.post(`https://localhost:7001/api/Post/like/${post.guid}`);
    console.log(`Dir gefällt der Beitrag ${post.guid}. API response:`, response.data);
    post.isLiked = !post.isLiked;
    localStorage.setItem(`likeStatus_${post.guid}`, post.isLiked ? 'liked' : 'unliked');
  } catch (error) {
    console.error(error);
  }
}

async function toggleFollowStatus(user) {
  try {
    const username = user.username;
    const currentStatus = localStorage.getItem(`followStatus_${username}`);
    const newStatus = currentStatus === 'true' ? 'false' : 'true';
    localStorage.setItem(`followStatus_${username}`, newStatus);

    const updatedUsers = users.value.map(u => {
      if (u.username === username) {
        return { ...u, isFollowed: newStatus === 'true' };
      }
      return u;
    });
    users.value = updatedUsers;

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
  fetchPostUser();
  fetchAllUserData();
  fetchUserData();
});

</script>