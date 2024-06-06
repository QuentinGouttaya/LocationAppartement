<template>
  <div>
    <p v-if="clientData">Nom : {{ clientData.nom }} <br>
      Prénom : {{ clientData.prenom }} <br>
      Adresse : {{ clientData.adresse }} <br>
      Code postal : {{ clientData.codePostal }} <br>
      Ville : {{ clientData.ville }} <br>
      Téléphone : {{ clientData.tel }} <br>
    </p> <br>
    <button v-if="clientData" @click="consulterDemandes(clientData.demandes)">Consulter les demandes</button>
    <ul v-if="selectedDemandes">
      <li v-for="demande in selectedDemandes" :key="demande.id">
        <Demande :demande="demande" />
      </li>
    </ul>
  </div>
</template>

<script>
import axios from 'axios'
import Demande from './Demande.vue'


export default {
  components: {
    Demande
  },
  props: {
    client: {
      type: Object,
      required: true
    }
  },
  data() {
    return {
      clientData: null,
      selectedDemandes: []
    }
  },
  watch: {
    client: {
      immediate: true,
      handler(newClient) {
        axios
          .get(`http://localhost:5209/Client/${newClient.clientId}`)
          .then(response => (this.clientData = response.data)
          )
          .catch(error => console.log(error))
          .finally(() => this.selectedDemandes = [])


      }
    }
  },
  methods: {
    consulterDemandes() {
      if (this.clientData && this.clientData.demandes && this.selectedDemandes.length === 0) {
        this.selectedDemandes = this.clientData.demandes
      } else {
        this.selectedDemandes = []
      }
    }
  }
}
</script>

