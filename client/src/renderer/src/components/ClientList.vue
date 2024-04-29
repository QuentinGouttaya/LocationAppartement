<template>
  <div>
    <h1>Client</h1>
    <ul>
      <li class="clientList" v-for="client in clients" @click="selectClient(client)">
        <h3>{{ client.nom }} {{ client.prenom }}</h3>
      </li>
    </ul>
    <Client v-if="selectedClient" :client="selectedClient" />
  </div>
</template>

<script>
import axios from 'axios'
import Client from './Client.vue'

export default {
  name: 'ClientList',
  components: {
    Client
  },
  data() {
    return {
      clients: [],
      selectedClient: null
    }
  },
  mounted() {
    axios
      .get('http://localhost:5209/client')
      .then(response => (this.clients = response.data))
  },
  methods: {
    selectClient(client) {
      this.selectedClient = client
    }
  }
}
</script>
