<template>
  <div>
    <h1>Proprietaire</h1>
    <Proprietaire v-if="selectedProprietaire" :proprietaire="selectedProprietaire" />
    <ul>
      <li class="proprietaireList" v-for="proprietaire in proprietaires" @click="selectProprietaire(proprietaire)">
        <h3>{{ proprietaire.idProprietaire }} {{ proprietaire.nom }} {{ proprietaire.prenom }}</h3>
      </li>
    </ul>
  </div>
</template>

<script>
import axios from 'axios'
import Proprietaire from './Proprietaire.vue'

export default {
  name: 'ProprietaireList',
  components: {
    Proprietaire
  },
  data() {
    return {
      selectedProprietaire: null,
      proprietaires: []
    }
  },
  mounted() {
    axios
      .get('http://localhost:5209/proprietaire')
      .then(response => (this.proprietaires = response.data))
  },
  methods: {
    selectProprietaire(proprietaire) {
      this.selectedProprietaire = proprietaire
    }
  }
}


</script>
