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
    </nav>
    <router-view />
  </div>
</template>
