<template>
  <div>
    <h2>Ajouter un client</h2>
    <form @submit.prevent="ajouterClient">
      <label for="nom">Nom</label>
      <input type="text" id="nom" name="nom" v-model="nom" required>
      <label for="prenom">Prenom</label>
      <input type="text" id="prenom" name="prenom" v-model="prenoms" required>
      <label for="adresse">Adresse</label>
      <input type="text" id="adresse" name="adresse" v-model="adresse" required>
      <label for="codePostal">Code postal</label>
      <input type="text" id="codePostal" name="codePostal" v-model="codePostal" required>
      <label for="ville">Ville</label>
      <input type="text" id="ville" name="ville" v-model="ville" required>
      <label for="tel">Telephone</label>
      <input type="text" id="tel" name="tel" v-model="tel" required>
      <h2>Ajouter une demande</h2>
      <label for="rib">RIB</label>
      <input type="text" id="rib" name="rib" v-model="demand.rib" required>

      <label for="appartementId">Appartement</label>
      <select id="appartementId" name="appartementId" v-model="demand.appartementId" required>
        <option v-for="appartement in appartements" :key="appartement.id" :value="appartement.id">
          {{ appartement.adresse }}, {{ appartement.ville }}, {{ appartement.codePostal }}, {{ appartement.prixLoc }}
        </option>
      </select>

      <label for="dateLimite">Date limite</label>
      <input type="date" id="dateLimite" name="dateLimite" v-model="demand.dateLimite" required>

      <button type="submit">Ajouter</button>
    </form>
  </div>
</template>

<script>
import axios from 'axios';
import Appartement from './Appartement.vue';
export default {
  name: 'AjoutClient',
  components: {
    Appartement
  },
  data() {
    return {
      client: {
        nom: '',
        prenoms: '',
        adresse: '',
        codePostal: '',
        ville: '',
        tel: ''
      }
    };
  },
  methods: {
    ajouterClient() {
      axios
        .post('http://localhost:5209/client/add', {
          nom: this.nom,
          prenom: this.prenoms,
          adresse: this.adresse,
          codePostal: this.codePostal,
          ville: this.ville,
          tel: this.tel,
        })
        .then(() => {
          this.nom = '';
          this.prenoms = '';
          this.adresse = '';
          this.codePostal = '';
          this.ville = '';
          this.tel = '';
        })
        .catch((error) => {
          console.error(error);
        });
    }
</script>
