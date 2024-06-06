<script setup lang="ts">
const ipcHandle = () => window.electron.ipcRenderer.send('ping')
</script>

<template>
  <div>
    <nav class="nav">
      <router-link to="/">Home</router-link>
      <router-link to="/about">About</router-link>
      <router-link to="/appartements">Liste Appartements</router-link>
      <router-link to="/clients">Liste Clients</router-link>
      <router-link to="/proprietaires">Liste Proprietaires</router-link>
      <router-link to="/appartement/add">Ajout Appartement</router-link>
      <router-link to="/client/add">Ajout Client</router-link>
      <router-link to="/proprietaire/add">Ajout Proprietaire</router-link>
    </nav>
    <router-view />
  </div>
</template>
