<template>
  <div>
    <h1>Client</h1>

    <select v-if="clients.length > 0" v-model="selectedClient">
      <option v-for="client in clients" :key="client.id" :value="client">
        {{ client.nom }} {{ client.prenom }}
      </option>
    </select> <br>
    <Client v-if="selectedClient" :client="selectedClient" />
  </div>
</template>

<script>
import axios from 'axios'
import Client from './Client.vue'

export default {
  name: 'ClientList',
  components: {
    Client,
  },
  data() {
    return {
      clients: [],
      selectedClient: null,
      demandes: []
    }
  },
  mounted() {
    axios
      .get('http://localhost:5209/client')
      .then(response => (this.clients = response.data))
  },
}
</script>
