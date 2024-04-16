CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

CREATE TABLE "Personne" (
    id UUID UNIQUE PRIMARY KEY DEFAULT uuid_generate_v4(),
    prenom VARCHAR(35) NOT NULL,
    nom VARCHAR(35) NOT NULL,
    adresse VARCHAR(75) UNIQUE NOT NULL,
    ville VARCHAR(25),
    code_postal VARCHAR(5),
    tel VARCHAR(11)
);

CREATE TABLE "Client" (
    id UUID UNIQUE PRIMARY KEY NOT NULL UNIQUE REFERENCES "Personne"(id),
    id_client UUID UNIQUE NOT NULL DEFAULT uuid_generate_v4()
);

CREATE TABLE "Proprietaire" (
    id UUID UNIQUE PRIMARY KEY NOT NULL REFERENCES "Personne"(id),
    id_proprietaire UUID UNIQUE NOT NULL DEFAULT uuid_generate_v4()
);

CREATE TABLE "Arrondissement" (
    id SERIAL PRIMARY KEY,
    libelle VARCHAR(25) NOT NULL
);

CREATE TABLE "Appartement" (
    id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    type_appart VARCHAR(50) NOT NULL,
    nbr_chambre INTEGER NOT NULL,
    prix_loc DECIMAL(10,2) NOT NULL,
    prix_charge DECIMAL(10,2) NOT NULL,
    adresse VARCHAR(75) UNIQUE NOT NULL,
    ville VARCHAR(25),
    code_postal VARCHAR(7),
    etage VARCHAR(2),
    avec_ascenseur BOOLEAN NOT NULL,
    avec_preavis BOOLEAN NOT NULL,
    date_libre DATE,
    id_proprietaire UUID NOT NULL REFERENCES "Proprietaire"(id_proprietaire),
    id_arrondissement INTEGER NOT NULL REFERENCES "Arrondissement"(id)
);


CREATE TABLE "Locataire" (
    id UUID UNIQUE PRIMARY KEY NOT NULL UNIQUE REFERENCES "Personne"(id),
    id_locataire UUID NOT NULL DEFAULT uuid_generate_v4(),
    rib VARCHAR(34) NOT NULL UNIQUE,
    id_appartement UUID REFERENCES "Appartement"(id)
);

CREATE TABLE "Demande" (
    id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    id_client UUID UNIQUE NOT NULL REFERENCES "Client"(id_client),
    id_appartement UUID UNIQUE NOT NULL REFERENCES "Appartement"(id)
);


INSERT INTO "Arrondissement" (libelle) VALUES ('Le-Plateau Mont-Royal');
INSERT INTO "Arrondissement" (libelle) VALUES ('Rosemont–La Petite-Patrie');
INSERT INTO "Arrondissement" (libelle) VALUES ('Ville-Marie');
INSERT INTO "Arrondissement" (libelle) VALUES ('Villeray–Saint-Michel');
INSERT INTO "Arrondissement" (libelle) VALUES ('Hochelaga-Maisonneuve');

INSERT INTO "Personne" (prenom, nom, adresse, ville, code_postal, tel) VALUES ('Jean', 'Dupont', '123 rue Saint-Denis', 'Montigny', '78000', '0606060606');
INSERT INTO "Personne" (prenom, nom, adresse, ville, code_postal, tel) VALUES ('Marie', 'Lefebvre', '456 rue Sherbrooke', 'Paris', '75000', '0707070707');
INSERT INTO "Personne" (prenom, nom, adresse, ville, code_postal, tel) VALUES ('Pierre', 'Martin', '789 rue Sherbrooke', 'Paris', '75000', '0808080808');

INSERT INTO "Proprietaire" (id) VALUES ((SELECT id FROM "Personne" WHERE nom = 'Dupont'));
INSERT INTO "Proprietaire" (id) VALUES ((SELECT id FROM "Personne" WHERE nom = 'Martin'));

INSERT INTO "Appartement" (type_appart, nbr_chambre, prix_loc, prix_charge, adresse, ville, code_postal, etage, avec_ascenseur, avec_preavis, date_libre, id_proprietaire, id_arrondissement)
VALUES (
    'Studio',
    1,
    750,
    50,
    '123 rue Saint-Denis',
    'Montréal',
    '78000',
    '2',
    true,
    true,
    '2023-03-01',
    (SELECT id_proprietaire FROM "Proprietaire" WHERE id = (SELECT id FROM "Personne" WHERE nom = 'Dupont')),
    (SELECT id FROM "Arrondissement" WHERE id = '1')
);


INSERT INTO "Appartement" (type_appart, nbr_chambre, prix_loc, prix_charge, adresse, ville, code_postal, etage, avec_ascenseur, avec_preavis, date_libre, id_proprietaire, id_arrondissement)
VALUES (
    '5 1/2',
    3,
    1800,
    100,
    '1234 rue Saint-Laurent',
    'Montréal',
    'H2X 2S5',
    '4',
    true,
    true,
    '2023-05-01',
    (SELECT id_proprietaire FROM "Proprietaire" WHERE id = (SELECT id FROM "Personne" WHERE nom = 'Dupont')),
    (SELECT id FROM "Arrondissement" WHERE id = '2')
);

INSERT INTO "Appartement" (type_appart, nbr_chambre, prix_loc, prix_charge, adresse, ville, code_postal, etage, avec_ascenseur, avec_preavis, date_libre, id_proprietaire, id_arrondissement)
VALUES (
    '4 1/2',
    2,
    1500,
    80,
    '5678 rue Saint-Denis',
    'Montréal',
    'H2S 2R1',
    '2',
    false,
    true,
    '2023-04-15',
    (SELECT id_proprietaire FROM "Proprietaire" WHERE id = (SELECT id FROM "Personne" WHERE nom = 'Martin')),
    (SELECT id FROM "Arrondissement" WHERE id = '2')
);

INSERT INTO "Appartement" (type_appart, nbr_chambre, prix_loc, prix_charge, adresse, ville, code_postal, etage, avec_ascenseur, avec_preavis, date_libre, id_proprietaire, id_arrondissement)
VALUES (
    '3 1/2',
    1,
    1200,
    70,
    '9101 avenue du Parc',
    'Montréal',
    'H2N 1Y5',
    '1',
    false,
    false,
    '2023-03-15',
    (SELECT id_proprietaire FROM "Proprietaire" WHERE id = (SELECT id FROM "Personne" WHERE nom = 'Dupont')),
    (SELECT id FROM "Arrondissement" WHERE id = '3')
);

INSERT INTO "Appartement" (type_appart, nbr_chambre, prix_loc, prix_charge, adresse, ville, code_postal, etage, avec_ascenseur, avec_preavis, date_libre, id_proprietaire, id_arrondissement)
VALUES (
    '2 1/2',
    0,
    800,
    50,
    '3333 rue Ontario',
    'Montréal',
    'H2K 1X1',
    '3',
    true,
    false,
    '2023-02-01',
    (SELECT id_proprietaire FROM "Proprietaire" WHERE id = (SELECT id FROM "Personne" WHERE nom = 'Martin')),
    (SELECT id FROM "Arrondissement" WHERE id = '4')
);
