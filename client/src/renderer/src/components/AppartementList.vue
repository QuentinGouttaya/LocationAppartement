<template>
  <div>
    <h1>Appartement</h1>
    <Appartement v-if="selectedAppartement" :appartement="selectedAppartement" />
    <ul>
      <li class="appartementList" v-for="appartement in appartements" @click="selectAppartement(appartement)">
        <h3>{{ appartement.id }}</h3>
      </li>
    </ul>
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
