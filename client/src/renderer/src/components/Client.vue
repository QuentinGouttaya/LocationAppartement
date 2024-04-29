<template>
  <div>
    <p v-if="clientData">
      {{ clientData.adresse }} {{ clientData.codePostal }} {{
        clientData.ville }}</p>
  </div>
</template>

<script>
import axios from 'axios'

export default {
  name: 'Client',
  props: {
    client: {
      type: Object,
      required: true
    }
  },
  data() {
    return {
      clientData: null
    }
  },
  watch: {
    client: {
      immediate: true,
      handler(newClient) {
        axios
          .get(`http://localhost:5209/Client/${newClient.clientId}`)
          .then(response => (this.clientData = response.data))
      }
    }
  }
}
</script>
