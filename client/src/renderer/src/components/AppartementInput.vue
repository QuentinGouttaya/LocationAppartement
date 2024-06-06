<template>
  <form @submit.prevent="saveAppartement">
    <div>
      <label for="typeAppart">Type d'appartement:</label>
      <input type="text" id="typeAppart" v-model="appartement.typeAppart" required>
    </div>
    <div>
      <label for="nbrChambre">Nombre de chambres:</label>
      <input type="number" id="nbrChambre" v-model="appartement.nbrChambre" required>
    </div>
    <div>
      <label for="prixLoc">Prix de location:</label>
      <input type="number" id="prixLoc" v-model="appartement.prixLoc" required>
    </div>
    <div>
      <label for="prixCharge">Prix des charges:</label>
      <input type="number" id="prixCharge" v-model="appartement.prixCharge" required>
    </div>
    <div>
      <label for="adresse">Adresse:</label>
      <input type="text" id="adresse" v-model="appartement.adresse" required>
    </div>
    <div>
      <label for="ville">Ville:</label>
      <input type="text" id="ville" v-model="appartement.ville" required>
    </div>
    <div>
      <label for="codePostal">Code postal:</label>
      <input type="text" id="codePostal" v-model="appartement.codePostal" required>
    </div>
    <div>
      <label for="etage">Étage:</label>
      <input type="text" id="etage" v-model="appartement.etage" required>
    </div>
    <div>
      <label for="avecAscenseur">Avec ascenseur:</label>
      <input type="checkbox" id="avecAscenseur" v-model="appartement.avecAscenseur">
    </div>
    <div>
      <label for="avecPreavis">Avec préavis:</label>
      <input type="checkbox" id="avecPreavis" v-model="appartement.avecPreavis">
    </div>
    <div>
      <label for="dateLibre">Date libre:</label>
      <input type="date" id="dateLibre" v-model="appartement.dateLibre" required>
    </div>
    <div>
      <label for="proprietaireId">Propriétaire:</label>
      <select id="proprietaireId" v-model="appartement.proprietaireId" required>
        <option v-for="proprietaire in proprietaires" :key="proprietaire.id" :value="proprietaire.proprietaireId">
          {{ proprietaire.nom }} {{ proprietaire.prenom }}
        </option>
      </select>
    </div>
    <div>
      <label for="arrondissementId">ID de l'arrondissement:</label>
      <input type="number" id="arrondissementId" v-model="appartement.arrondissementId" required>
    </div>
    <button type="submit">{{ appartement.id ? 'Enregistrer' : 'Ajouter' }}</button>
  </form>
</template>

<script>
import axios from 'axios';

export default {
  name: 'AppartementForm',
  props: {
    appartement: {
      type: Object,
      default: () => ({
        typeAppart: '',
        nbrChambre: 0,
        prixLoc: 0,
        prixCharge: 0,
        adresse: '',
        ville: '',
        codePostal: '',
        etage: '',
        avecAscenseur: false,
        avecPreavis: false,
        dateLibre: '',
        proprietaireId: '',
        arrondissementId: 0,
      }),
    },
  },
  data() {
    return {
      proprietaires: [],
    };
  },
  methods: {
    saveAppartement() {
      if (this.appartement.id) {
        axios.put(`http://localhost:5209/appartement/${this.appartement.id}/update`, this.appartement)
          .then(response => {
            console.log(response.data);
          })
          .catch(error => {
            console.error(error);
          });
      } else {
        axios.post('http://localhost:5209/appartement/add', this.appartement)
          .then(response => {
            console.log(response.data);
          })
          .catch(error => {
            console.error(error);
          });
      }
    },
  },
  mounted() {
    axios
      .get('http://localhost:5209/proprietaire')
      .then(response => (this.proprietaires = response.data));
  },
};
</script>

