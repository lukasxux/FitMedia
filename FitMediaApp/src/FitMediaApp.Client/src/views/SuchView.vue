<template>
  <div>
    <div>
      <h1><span style="color: rgb(74, 113, 165);">Neues</span> Entdecken</h1>
    </div>
    <div>
      <p id="short-text">Suche mithilfe der <span style="color: rgb(74, 113, 165);">innovativen Suchfunktion</span> von <span style="color: rgb(74, 113, 165);">Fit-Media</span> nach neuen interessanten <span style="color: rgb(74, 113, 165);">Personen</span>, die dir bei deinen <span style="color: rgb(74, 113, 165);">Fitnesszielen</span> helfen können. Außerdem kannst du neue <span style="color: rgb(74, 113, 165);">Freunde</span> kennenlernen. Gib einfach unten einen <span style="color: rgb(74, 113, 165);">Namen</span> ein und <span style="color: rgb(74, 113, 165);">wähle</span> eines Von den <span style="color: rgb(74, 113, 165);">vorgeschlagenen Profilen</span>.</p>
    </div>
    <div class="search-container">
      <img
        src="@/assets/Fit-Media_logo.png"
        alt="Fit-Media logo"
        class="logo"
        width="75"
        height="25"
      />
      <form @submit.prevent="searchUsers">
        <input type="text" v-model="searchQuery" placeholder="Search..." />
        <button type="submit"><i class="fas fa-search"></i></button>
      </form>
    </div>
    <div class="grid-container">
      
    </div>
  </div>
</template>

<style scoped>
 .search-container {
  margin-top: 30px;
  margin-bottom: 10px;
  background-color: rgb(74, 113, 165);
  display: flex;
  align-items: center;
  padding: 10px;
  border-radius: 5px;
  width: 1000px;
  margin-left: 15%;
}

button[type="submit"] {
  border: none;
  background-color: transparent;
  cursor: pointer;
  margin-right: 10px;
}

input[type="text"] {
  border: none;
  outline: none;
  padding: 10px;
  flex: 1;
}

form {
  display: flex;
  align-items: center;
  border-radius: 10px;
  flex: 1;
  background-color: white;
  padding: 5px;
}

.logo {
  margin-right: 10px;
}

input[type="text"] {
  border: none;
  outline: none;
  padding: 10px;
  flex: 1;
  color: #222;
}

h1{
  text-align: center;
}

#short-text{
  width: 500px;
  text-align: center;
  margin-left: 33.5%;
}

.grid-container {
  display: grid;
  grid-template-columns: auto auto auto auto;
  margin-top: 2.5%;
  margin-left: 4%;
}

.grid-item{
  padding-bottom: 50px;
}

#Beitrag-Text{
  overflow: auto;
  height: 100px;
  width: 300px;
}

input{
  width: 237.5px;
  height: 10px;
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
</style>