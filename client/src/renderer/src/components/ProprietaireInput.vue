<template>
  <form @submit.prevent="addProprietaire">
    <div>
      <label for="prenom">Prénom:</label>
      <input type="text" id="prenom" v-model="proprietaire.prenom" required>
    </div>
    <div>
      <label for="nom">Nom:</label>
      <input type="text" id="nom" v-model="proprietaire.nom" required>
    </div>
    <div>
      <label for="adresse">Adresse:</label>
      <input type="text" id="adresse" v-model="proprietaire.adresse" required>
    </div>
    <div>
      <label for="ville">Ville:</label>
      <input type="text" id="ville" v-model="proprietaire.ville" required>
    </div>
    <div>
      <label for="codePostal">Code postal:</label>
      <input type="text" id="codePostal" v-model="proprietaire.codePostal" required>
    </div>
    <div>
      <label for="tel">Téléphone:</label>
      <input type="text" id="tel" v-model="proprietaire.tel" required>
    </div>
    <button type="submit">Ajouter</button>
  </form>
</template>

<script>
import axios from 'axios';

export default {
  name: 'ProprietaireForm',
  data() {
    return {
      proprietaire: {
        prenom: '',
        nom: '',
        adresse: '',
        ville: '',
        codePostal: '',
        tel: '',
        appartements: [],
      },
    };
  },
  methods: {
    addProprietaire() {
      axios.post('http://localhost:5209/proprietaire/add', this.proprietaire)
        .then(response => {
          console.log(response.data);
        })
        .catch(error => {
          console.error(error);
        });
    },
  },
};
</script>
