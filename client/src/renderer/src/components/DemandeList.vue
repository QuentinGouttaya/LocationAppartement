<template>
  <div>
    <h2>Demandes pour {{ client.nom }} {{ client.prenom }}</h2>
    <ul>
      <li v-for="demande in demandes" :key="demande.id">
        {{ demande.appartementId }}
      </li>
    </ul>
  </div>
</template>

<script>
import axios from 'axios'

export default {
  props: {
    client: {
      type: Object,
      required: true
    }
  },
  data() {
    return {
      demandes: []
    }
  },
  mounted() {
    axios
      .get(`http://localhost:5209/${this.client.id}/demandes`)
      .then(response => (this.demandes = response.data))
  }
}
</script>
