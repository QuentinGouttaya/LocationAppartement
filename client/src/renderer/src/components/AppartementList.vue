<template>
  <div>
    <h1>Appartement</h1>
    <select v-model="selectedAppartement">
      <option v-for="appartement in appartements" :key="appartement.id" :value="appartement">
        {{ appartement.adresse }} , {{ appartement.ville }}
        <!-- replace 'name' with the actual property that contains the appartment's name -->
      </option>
    </select>
    <Appartement v-if="selectedAppartement" :appartement="selectedAppartement" />
  </div>
</template>

<script>
import axios from 'axios'
import Appartement from './Appartement.vue'

export default {
  name: 'AppartementList',
  components: {
    Appartement

  },
  data() {
    return {
      appartements: [],
      selectedAppartement: null
    }
  },
  mounted() {
    axios
      .get('http://localhost:5209/appartement')
      .then(response => (this.appartements = response.data))
  },
  methods: {
    selectAppartement(appartement) {
      this.selectedAppartement = appartement
    }
  }
}
</script>
