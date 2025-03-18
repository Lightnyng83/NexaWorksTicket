# NexaWorksTicket - Modèle Entité-Association
## Introduction
NexaWorksTicket est un système de gestion des tickets permettant de suivre les problèmes signalés par les utilisateurs en lien avec différents produits et systèmes d'exploitation.
Ce document décrit le modèle Entité-Association utilisé pour concevoir la base de données.

## Modèle Entité-Association
Le modèle de la base de données repose sur cinq entités principales : Os, Products, ProductsVersion, ProductVersionOs et Ticket. Ces entités sont interconnectées pour assurer une gestion efficace des tickets et leur traçabilité.

### 1. Os (Systèmes d'exploitation)
Représente les différents systèmes d'exploitation sous lesquels les produits peuvent être utilisés.
**Attributs :**
- `OsId` (clé primaire) : Identifiant unique du système d'exploitation
- `OsName` : Nom du système d'exploitation

### 2. Products (Produits)
Représente les différents logiciels ou produits disponibles dans le système.
**Attributs :**
- `ProductId` (clé primaire) : Identifiant unique du produit
- `ProductName` : Nom du produit

**Relations :**
- Un produit peut avoir plusieurs versions compatibles avec différents systèmes d'exploitation via l'entité intermédiaire ProductVersionOs

### 3. ProductsVersion (Versions de produits)
Représente les différentes versions disponibles pour les produits.
**Attributs :**
- `VersionId` (clé primaire) : Identifiant unique de la version
- `Version` : Numéro de version du produit

### 4. ProductVersionOs (Relation entre produits, versions et OS)
Table de jonction qui établit les relations entre produits, versions et systèmes d'exploitation.
**Attributs :**
- `IdProductVersionOs` (clé primaire) : Identifiant unique de la relation
- `IdProduct` (clé étrangère) : Référence vers le produit
- `IdVersion` (clé étrangère) : Référence vers la version
- `IdOs` (clé étrangère) : Référence vers le système d'exploitation

**Relations :**
- Établit une relation many-to-many entre Products, ProductsVersion et Os

### 5. Ticket (Tickets de support)
Représente les incidents signalés par les utilisateurs.
**Attributs :**
- `TicketId` (clé primaire) : Identifiant unique du ticket
- `ProductVersionOsId` (clé étrangère) : Référence vers la combinaison produit-version-OS concernée
- `CreationDate` : Date de création du ticket
- `FixingDate` : Date de résolution prévue
- `FixingStatus` : Statut de résolution du ticket
- `Problem` : Description du problème rencontré par l'utilisateur
- `ResolutionReport` : Méthodologie de résolution du problème utilisateur

**Relations :**
- Un ticket est lié à une combinaison produit-version-OS via `ProductVersionOsId`

## Schéma des Relations
```
+----------------+         +----------------------+         +-------------------+
|       Os       |         | ProductVersionOs    |         | ProductsVersion  |
+----------------+         +----------------------+         +-------------------+
| OsId (PK)      |<---+----| IdProductVersionOs  |----+--->| VersionId (PK)   |
| OsName         |    |    | IdProduct           |     |   | Version          |
+----------------+    |    | IdVersion           |     |   +-------------------+
                      |    | IdOs                |     |
                      |    +----------------------+    |
                      |              |                 |
                      |              |                 |
                      |              v                 |
                      |    +-------------------+       |
                      |    |      Ticket      |        |
                      |    +-------------------+       |
                      |    | TicketId (PK)    |        |
                      |    | ProductVersionOsId|       |
                      |    | CreationDate     |        |
                      |    | FixingDate       |        |
                      |    | FixingStatus     |        |
                      |    | Problem          |        |
                      |    | ResolutionReport |        |
                      |    +-------------------+       |
                      |                                |
                      |    +-------------------+       |
                      +--->|     Products     |<------+
                           +-------------------+
                           | ProductId (PK)   |
                           | ProductName      |
                           +-------------------+
```

## Remplissage de la Base de Données
Afin de tester le fonctionnement de la base de données, un jeu de 25 tickets d'exemple sera inséré via un SeedData. Ces tickets couvrent plusieurs produits, versions et systèmes d'exploitation, en incluant des problèmes résolus et non résolus.
