import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import BeitragView from '../views/BeitragView.vue'
import LoginView from '../views/LoginView.vue'
import SuchView from '../views/SuchView.vue'
import RegisterView from '../views/RegisterView.vue'
import ProfileView from '../views/ProfileView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView,
      meta: { requiresAuth: true }
    },
    {
      path: '/create-post',
      name: 'Beitrag erstellen',
      component: BeitragView,
      meta: { requiresAuth: true }
    },
    {
      path: '/register',
      name: 'register',
      component: RegisterView,
    },
    {
      path: '/search',
      name: 'Suchen',
      component: SuchView,
      meta: { requiresAuth: true }
    },
    {
      path: '/login',
      name: 'login',
      component: LoginView,
    },
    {
      path: '/profile',
      name: 'profile',
      component: ProfileView,
      meta: { requiresAuth: true }
    }
  ]
})

router.beforeEach((to, from, next) => {
  const requiresAuth = to.matched.some(record => record.meta.requiresAuth);
  const hasGuid = sessionStorage.getItem('userGuid');

  if (requiresAuth && !hasGuid) {
    next('/login'); // Leite den Benutzer zur Login-Seite weiter, wenn Authentifizierung erforderlich ist, aber keine GUID vorhanden ist
  } else {
    next(); // Fortsetzen zur gewünschten Seite
  }
});

export default router
