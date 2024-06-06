import { createRouter, createWebHashHistory } from 'vue-router'
import AppartementList from './components/AppartementList.vue'
import Appartement from './components/Appartement.vue'
import About from './components/About.vue'
import Home from './components/Home.vue'
import ClientList from './components/ClientList.vue'
import Proprietaire from './components/Proprietaire.vue'
import ProprietaireList from './components/ProprietaireList.vue'
import Demande from './components/Demande.vue'
import DemandeList from './components/DemandeList.vue'
import AjoutClient from './components/AjoutClient.vue'
import AppartementInput from './components/AppartementInput.vue'
import ProprietaireInput from './components/ProprietaireInput.vue'


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
    path: '/appartement/add',
    name: 'Ajouter un appartement',
    component: AppartementInput
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
    path: '/proprietaire/add',
    name: 'Ajouter un proprietaire',
    component: ProprietaireInput
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
    path: '/client/ajouter',
    name: 'Ajouter un client',
    component: AjoutClient
  },
  {
    path: '/demandes',
    name: 'Demandes',
    component: DemandeList
  },
  {
    path: '/demande/:id',
    name: 'Demande',
    component: Demande
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
