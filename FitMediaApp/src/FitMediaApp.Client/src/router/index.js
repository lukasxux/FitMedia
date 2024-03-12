import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import BeitragView from '../views/BeitragView.vue'
import LoginView from '../views/LoginView.vue'
import SuchView from '../views/SuchView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView,
    },
    {
      path: '/create-post',
      name: 'Beitrag erstellen',
      component: BeitragView,
    },
    {
      path: '/login',
      name: 'Login',
      component: LoginView,
    },
    {
      path: '/search',
      name: 'Suchen',
      component: SuchView,
    }
  ]
})

export default router
