<template>
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
}
</style>