<template>
  <div class="appartement">
    <h3>{{ appartement.id }}</h3>
    <p>{{ appartement.adresse }}</p>
    <p>{{ appartement.codePostal }} {{ appartement.ville }}</p>
    <p>{{ appartement.prixLoc }} €</p>
    <p v-if="proprietaire">{{ proprietaire.nom }} {{ proprietaire.prenom }}</p>
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
      proprietaire: null
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
  }
}
</script>

