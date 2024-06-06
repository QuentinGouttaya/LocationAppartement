<template>
  <div class="appartement">
    <p>Adresse : {{ appartement.adresse }}</p>
    <p>Code postal : {{ appartement.codePostal }}, Ville : {{ appartement.ville }}</p>
    <p>Prix : {{ appartement.prixLoc }} €</p>
    <p v-if="proprietaire"> Proprietaire : {{ proprietaire.nom }} {{ proprietaire.prenom }}</p>
    <button v-if="proprietaire" @click="supprimerAppartement(appartement)">Supprimer l'appartement</button>
    <button v-if="proprietaire" @click="input = !input">Modifier l'appartement</button>


  </div>
</template>

<script>
import axios from 'axios'

export default {
  name: 'Appartement',
  props: {
    appartement: {
      type: Object,
      required: true
    }
  },
  data() {
    return {
      proprietaire: null,
      input: false
    }
  },
  watch: {
    appartement: {
      immediate: true,
      handler(newAppartement) {
        axios
          .get(`http://localhost:5209/proprietaire/${newAppartement.proprietaireId}`)
          .then(response => (this.proprietaire = response.data))
      }
    }
  },
  methods: {
    supprimerAppartement(appartement) {
      axios
        .delete(`http://localhost:5209/appartement/${appartement.id}`)
        .then(response => console.log(response.data))
        .catch(error => console.log(error))
        .finally(() => this.$router.push('/'))

    },
  }
}
</script>
