<script setup>
import axios from 'axios';
import { RouterLink, RouterView } from 'vue-router'
</script>

<template>
    <div class="wrapper">
        <nav class="navbar navbar-expand-lg bg-dark text-uppercase fixed-top">
        <a class="navbar-brand text-light h1" id="logo" href="/">
          <img src="@/assets/Fit-Media_logo.png" id="home" width="180" height="60">
        </a>
        <div id="navbarCollapse">
          <button class="navbar-toggler"  type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
          <span class="navbar-toggler-icon" id="navbarIcon"></span>
          </button>
        </div>
        <div class="collapse navbar-collapse" id="navbarNav">
          <ul class="navbar-nav ml-auto">
              <li  class="nav-item mx-0 mx-lg-1" id="padding-left">
                <router-link class="nav-link py-3 px-0 px-lg-3 rounded text-light"  to="/create-post">
                    <h5>Beitrag erstellen</h5>
                </router-link>
              </li>
              <li  class="nav-item mx-0 mx-lg-1" id="padding-left">
                <router-link class="nav-link py-3 px-0 px-lg-3 rounded text-light"  to="/search">
                    <h5>Suchen</h5>
                </router-link>
              </li>
              <li  class="nav-item mx-0 mx-lg-1" id="padding-left">
                <router-link class="nav-link py-3 px-0 px-lg-3 rounded text-light" to="/profile">
                    <h5>Profil</h5>
                </router-link>
              </li>
          </ul>
        </div>
      </nav>
    </div>

  <RouterView />
</template>

<style scoped>
</style>