<script setup>
import { RouterLink, RouterView } from 'vue-router'
</script>

<template>
    <div class="wrapper">
        <nav class="navbar navbar-expand-lg bg-dark text-uppercase fixed-top">
        <div class="collapse navbar-collapse" id="navbarNav">
          <ul class="navbar-nav ml-auto">
              <li  class="nav-item mx-0 mx-lg-1" id="logo">
                <routerLink to="/">
                  <img src="@/assets/Fit-Media_logo.png" class="home" width="180" height="60">
                </routerLink>
              </li>
              <li  class="margin-left" id="padding-left">
                <router-link class="nav-link py-3 px-0 px-lg-3 rounded text-light"  to="/create-post">
                    <span style="color: rgb(74, 113, 165);">Beitrag</span> Erstellen
                </router-link>
              </li>
              <li  class="nav-item mx-0 mx-lg-1" id="padding-left">
                <router-link class="nav-link py-3 px-0 px-lg-3 rounded text-light"  to="/search">
                    <span style="color: rgb(74, 113, 165);">Neues</span> Entdecken
                </router-link>
              </li>
              <li  class="nav-item mx-0 mx-lg-1" id="padding-left">
                <router-link class="nav-link py-3 px-0 px-lg-3 rounded text-light" to="/profile">
                    <span style="color: rgb(74, 113, 165);">Profil</span> Übersicht
                </router-link>
              </li>
          </ul>
        </div>
      </nav>
    </div>

  <RouterView />
</template>

<style scoped>
li {
  display: inline;
  float: left;
}
ul {
  margin-bottom: 40px;
  overflow: hidden;
}

li a {
  display: block;
  color: white;
  text-align: center;
  padding: 14px 16px;
  text-decoration: none;
  text-transform: uppercase;
  font-size: 20px;
}

li a:hover {
  background-color: #111;
}

#padding-left{
  padding-left: 20px;
}

.margin-left{
  margin-left: 40%;
}

#logo{
  margin-left: -40px;
  margin-top: -10px;
}
</style>