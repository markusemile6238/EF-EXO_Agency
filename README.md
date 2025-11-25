# EF-EXO_Agency

Exercice melant création de la base de donnée en EF avec les constraints.
Ce qui devait a mon avis être un exo simple c'est compliqué de mon plein gré.
Avec d'autre cours entre le debut de l'exo et le jour de la remise, on a vue les design pattern
et on nous a poussé au challenge d'implementer le tout à cet EXO... du coup plus de boulot

Au final la console permet 
*   d'ajouter une destination (Pays-ville,etc...) - Clef unique sur country/city
*   d'ajouter une activité relier à une destination avec une FK sur destinationID
*   de lister les destination
*   et de créer une réservation avec 
    *   nom du client
    *   la destination choisis
    *   la date de départ
    *   les activitées possibles selon la destination (avec info et prix)
    *   pour finir par afficher le resumer et le cout des activitées

**Ce que j'ai implémenter personnellement c'est...**
> * Builder Fluent pour les Activity et le Booking<br>
> * Une factory pour le DbContext puisque la structure est divisé
> * Un helper pour me facilité les interaction avec le clavier, pour les reponse basic o/n
> * Instauration des IRepository - Repository - Service et DTO
> * Ajout de methode EF propre a leur model
> * Sauvegarde dans la base de donnée (en cours pour la reservation...)  
