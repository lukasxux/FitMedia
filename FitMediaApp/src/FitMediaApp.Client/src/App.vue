<script setup>
import { RouterLink, RouterView } from 'vue-router'
import HelloWorld from './components/HelloWorld.vue'
</script>

<template>
  <header>
    <img alt="FitMedia logo" class="logo" src="@/assets/Fit-Media_logo.png" width="300" height="100" />

    <div class="wrapper">
      <HelloWorld msg="You dont have an account yet!" />
      <nav>
        <RouterLink to="/">Home</RouterLink>
        <RouterLink to="/about">About</RouterLink>
      </nav>
    </div>
  </header>

  <RouterView />
</template>
<style scoped>
</style>
