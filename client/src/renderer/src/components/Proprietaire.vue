<template>
  <div>
    <p v-if="proprietaireData" v-for="data in proprietaireData">{{ data }}</p>
  </div>
</template>

<script>
import axios from 'axios'

export default {
  name: 'Proprietaire',
  props: {
    proprietaire: {
      type: Object,
      required: true
    }
  },
  data() {
    return {
      proprietaireData: null
    }
  },
  watch: {
    proprietaire: {
      immediate: true,
      handler(newProprietaire) {
        axios
          .get(`http://localhost:5209/Proprietaire/${newProprietaire.proprietaireId}`)
          .then(response => (this.proprietaireData = response.data))
      }
    }
  }

}
</script>
