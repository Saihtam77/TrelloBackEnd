
INSERT INTO User (nom) VALUES ('User 1');
INSERT INTO User (nom) VALUES ('User 2');
INSERT INTO User (nom) VALUES ('User 3');

INSERT INTO Projet (nom) VALUES ('Projet 1');
INSERT INTO Projet (nom) VALUES ('Projet 2');
INSERT INTO Projet (nom) VALUES ('Projet 3');

INSERT INTO Liste (nom, projet_id) VALUES ('Liste 1', 1);
INSERT INTO Liste (nom, projet_id) VALUES ('Liste 2', 1);
INSERT INTO Liste (nom, projet_id) VALUES ('Liste 3', 2);
INSERT INTO Liste (nom, projet_id) VALUES ('Liste 4', 2);
INSERT INTO Liste (nom, projet_id) VALUES ('Liste 5', 3);
INSERT INTO Liste (nom, projet_id) VALUES ('Liste 6', 3);

-- insert 3 tache pour chaque liste
INSERT INTO Tache (nom, description, liste_id,endDate) VALUES ('Tache 1', 'Description 1', 1, '2020-12-01');
INSERT INTO Tache (nom, description, liste_id, endDate) VALUES ('Tache 2', 'Description 2', 1, '2020-12-02');
INSERT INTO Tache (nom, description, liste_id, endDate) VALUES ('Tache 3', 'Description 3', 1, '2020-12-03');

INSERT INTO Tache (nom, description, liste_id, endDate) VALUES ('Tache 4', 'Description 4', 2, '2020-12-04');
INSERT INTO Tache (nom, description, liste_id, endDate) VALUES ('Tache 5', 'Description 5', 2, '2020-12-05');
INSERT INTO Tache (nom, description, liste_id, endDate) VALUES ('Tache 6', 'Description 6', 2, '2020-12-06');

INSERT INTO Tache (nom, description, liste_id, endDate) VALUES ('Tache 7', 'Description 6', 3, '2020-12-06');
INSERT INTO Tache (nom, description, liste_id, endDate) VALUES ('Tache 8', 'Description 7', 3, '2020-12-07');
INSERT INTO Tache (nom, description, liste_id, endDate) VALUES ('Tache 9', 'Description 8', 3, '2020-12-08');

--  Commentaire (contenu, tache_id)

INSERT INTO Commentaire (contenu, tache_id) VALUES ('Commentaire 1', 1);
INSERT INTO Commentaire (contenu, tache_id) VALUES ('Commentaire 2', 1);
INSERT INTO Commentaire (contenu, tache_id) VALUES ('Commentaire 3', 2);
INSERT INTO Commentaire (contenu, tache_id) VALUES ('Commentaire 4', 2);
INSERT INTO Commentaire (contenu, tache_id) VALUES ('Commentaire 5', 3);
INSERT INTO Commentaire (contenu, tache_id) VALUES ('Commentaire 6', 3);
INSERT INTO Commentaire (contenu, tache_id) VALUES ('Commentaire 7', 4);
INSERT INTO Commentaire (contenu, tache_id) VALUES ('Commentaire 8', 4);
INSERT INTO Commentaire (contenu, tache_id) VALUES ('Commentaire 9', 5);
INSERT INTO Commentaire (contenu, tache_id) VALUES ('Commentaire 10', 5);
INSERT INTO Commentaire (contenu, tache_id) VALUES ('Commentaire 11', 6);
INSERT INTO Commentaire (contenu, tache_id) VALUES ('Commentaire 12', 6);
INSERT INTO Commentaire (contenu, tache_id) VALUES ('Commentaire 13', 7);
INSERT INTO Commentaire (contenu, tache_id) VALUES ('Commentaire 14', 7);
INSERT INTO Commentaire (contenu, tache_id) VALUES ('Commentaire 15', 8);
INSERT INTO Commentaire (contenu, tache_id) VALUES ('Commentaire 16', 8);
INSERT INTO Commentaire (contenu, tache_id) VALUES ('Commentaire 17', 9);
INSERT INTO Commentaire (contenu, tache_id) VALUES ('Commentaire 18', 9);