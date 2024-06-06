<template>
  <div>
    <h2>Demande #{{ demande.id }}</h2>
    <p>Date limite: {{ demande.dateLimite }}</p>
    <Appartement v-if="appartement" :appartement="appartement" />
    <label v-if='demande' for=rib>RIB</label>
    <input type='text' id='rib' name='rib' v-model='rib'>
    <button v-if='demande' @click='accepterDemande(demande)'>Accepter la
      demande</button>

  </div>
</template>

<script>
import axios from 'axios'
import Appartement from './Appartement.vue'

export default {
  components: {
    Appartement
  },
  props: {
    demande: {
      type: Object,
      required: true
    }
  },
  data() {
    return {
      appartement: null,
      rib: ''
    }
  },
  mounted() {
    axios
      .get(`http://localhost:5209/appartement/${this.demande.appartementId}`)
      .then(response => (this.appartement = response.data))

  },
  methods: {
    accepterDemande() {
      const url = `http://localhost:5209/demande/${this.demande.id}/accept`;
      const demandeId = this.demande.id;
      const clientId = this.demande.clientId;
      const rib = this.rib;

      axios.post(url, { demandeId, clientId, rib })
        .then(response => console.log(response.data))
        .catch(error => console.log(error));

    },
  }
}

</script>
