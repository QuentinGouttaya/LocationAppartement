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
    id UUID UNIQUE PRIMARY KEY NOT NULL UNIQUE REFERENCES "Personne"(id) ON DELETE CASCADE,
    id_client UUID UNIQUE NOT NULL DEFAULT uuid_generate_v4()
);

CREATE TABLE "Proprietaire" (
    id UUID UNIQUE PRIMARY KEY NOT NULL REFERENCES "Personne"(id) ON DELETE CASCADE,
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
    id UUID UNIQUE PRIMARY KEY NOT NULL UNIQUE REFERENCES "Personne"(id) ON DELETE CASCADE,
    id_locataire UUID NOT NULL DEFAULT uuid_generate_v4(),
    rib VARCHAR(34) NOT NULL UNIQUE,
    id_appartement UUID REFERENCES "Appartement"(id)
);

CREATE TABLE "Demande" (
    id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    id_client UUID NOT NULL REFERENCES "Client"(id_client) ON DELETE CASCADE,
    id_appartement UUID NOT NULL REFERENCES "Appartement"(id) ON DELETE CASCADE,
    date_limite DATE NOT NULL
);



INSERT INTO "Arrondissement" (libelle) VALUES ('Le-Plateau Mont-Royal');
INSERT INTO "Arrondissement" (libelle) VALUES ('Rosemont–La Petite-Patrie');
INSERT INTO "Arrondissement" (libelle) VALUES ('Ville-Marie');
INSERT INTO "Arrondissement" (libelle) VALUES ('Villeray–Saint-Michel');
INSERT INTO "Arrondissement" (libelle) VALUES ('Hochelaga-Maisonneuve');

INSERT INTO "Personne" (prenom, nom, adresse, ville, code_postal, tel) VALUES ('Jean', 'Dupont', '123 rue Saint-Denis', 'Montigny', '78000', '0606060606');
INSERT INTO "Personne" (prenom, nom, adresse, ville, code_postal, tel) VALUES ('Marie', 'Lefebvre', '456 rue Sherbrooke', 'Paris', '75000', '0707070707');
INSERT INTO "Personne" (prenom, nom, adresse, ville, code_postal, tel) VALUES ('Pierre', 'Martin', '789 rue Sherbrooke', 'Paris', '75000', '0808080808');
INSERT INTO "Personne" (prenom, nom, adresse, ville, code_postal, tel) VALUES ('Sophie', 'Bernard', '321 rue Saint-Denis', 'Montigny', '78000', '0909090909');
INSERT INTO "Personne" (prenom, nom, adresse, ville, code_postal, tel) VALUES ('Luc', 'Durand', '654 rue Sherbrooke', 'Paris', '75000', '1010101010');
INSERT INTO "Personne" (prenom, nom, adresse, ville, code_postal, tel) VALUES ('Jeanne', 'Leroy', '987 rue Saint-Denis', 'Montigny', '78000', '1111111111');
INSERT INTO "Personne" (prenom, nom, adresse, ville, code_postal, tel) VALUES ('Marcel', 'Petit', '147 rue Sherbrooke', 'Paris', '75000', '1212121212');
INSERT INTO "Personne" (prenom, nom, adresse, ville, code_postal, tel) VALUES ('Emilie', 'Robert', '258 rue Saint-Denis', 'Montigny', '78000', '1313131313');
INSERT INTO "Personne" (prenom, nom, adresse, ville, code_postal, tel) VALUES ('Antoine', 'Garcia', '369 rue Sherbrooke', 'Paris', '75000', '1414141414');
INSERT INTO "Personne" (prenom, nom, adresse, ville, code_postal, tel) VALUES ('Mathieu', 'Gonzalez', '741 rue Saint-Denis', 'Montigny', '78000', '1515151515');

INSERT INTO "Proprietaire" (id) VALUES ((SELECT id FROM "Personne" WHERE nom = 'Dupont'));
INSERT INTO "Proprietaire" (id) VALUES ((SELECT id FROM "Personne" WHERE nom = 'Martin'));

INSERT INTO "Client" (id) VALUES ((SELECT id FROM "Personne" WHERE nom = 'Gonzalez'));
INSERT INTO "Client" (id) VALUES ((SELECT id FROM "Personne" WHERE nom = 'Garcia'));

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
    'F3',
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
    'T2',
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
    'T3',
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
    'Studio',
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


INSERT INTO "Locataire" (id, rib, id_appartement)
VALUES (
    (SELECT id FROM "Personne" WHERE nom = 'Bernard'),
    '1234567890123456789012345678901234',
    (SELECT id FROM "Appartement" WHERE adresse = '3333 rue Ontario')
);

INSERT INTO "Locataire" (id, rib, id_appartement)
VALUES (
    (SELECT id FROM "Personne" WHERE nom = 'Durand'),
    '8901234567890123456789012455678900',
    (SELECT id FROM "Appartement" WHERE adresse = '9101 avenue du Parc')
);



INSERT INTO "Demande" (id_appartement, id_client, date_limite) VALUES (
    (SELECT id FROM "Appartement" WHERE adresse = '9101 avenue du Parc'),
    (SELECT id_client FROM "Client" WHERE id = (SELECT id FROM "Personne" WHERE nom = 'Gonzalez' AND prenom = 'Mathieu')),
    '2023-05-01'
);

INSERT INTO "Demande" (id_appartement, id_client, date_limite) VALUES (
    (SELECT id FROM "Appartement" WHERE adresse = '3333 rue Ontario'),
    (SELECT id_client FROM "Client" WHERE id = (SELECT id FROM "Personne" WHERE nom = 'Garcia' AND prenom = 'Antoine')),
    '2023-05-01'
);
