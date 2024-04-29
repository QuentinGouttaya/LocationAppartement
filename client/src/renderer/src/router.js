import { createRouter, createWebHashHistory } from 'vue-router'
import AppartementList from './components/AppartementList.vue'
import Appartement from './components/Appartement.vue'
import About from './components/About.vue'
import Home from './components/Home.vue'
import ClientList from './components/ClientList.vue'
import Proprietaire from './components/Proprietaire.vue'
import ProprietaireList from './components/ProprietaireList.vue'


const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/appartements',
    name: 'AppartementList',
    component: AppartementList
  },
  {
    path: '/appartement/:id',
    name: 'Appartement',
    component: Appartement
  },
  {
    path: '/proprietaires/',
    name: 'ProprietaireList',
    component: ProprietaireList
  },
  {
    path: '/proprietaire/:id',
    name: 'Proprietaire',
    component: Proprietaire
  },
  {
    path: '/clients',
    name: 'Clients',
    component: ClientList
  },
  {
    path: '/about',
    name: 'About',
    component: About
  }
]

const router = createRouter({
  history: createWebHashHistory(),
  routes
})

export default router
