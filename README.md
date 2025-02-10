# NexaWorksTicket - Modèle Entité-Association

## Introduction

NexaWorksTicket est un système de gestion des tickets permettant de suivre les problèmes signalés par les utilisateurs en lien avec différents produits et systèmes d'exploitation.

Ce document décrit le modèle Entité-Association utilisé pour concevoir la base de données.

## Modèle Entité-Association

Le modèle de la base de données repose sur quatre entités principales : Os, Products, ProductsVersion et Ticket. Ces entités sont interconnectées pour assurer une gestion efficace des tickets et leur traçabilité.

### 1. Os (Systèmes d'exploitation)

Représente les différents systèmes d'exploitation sous lesquels les produits peuvent être utilisés.

**Attributs :**
- `OsId` (int, clé primaire) : Identifiant unique du système d'exploitation
- `OsName` (nvarchar(100)) : Nom du système d'exploitation

### 2. Products (Produits)

Représente les différents logiciels ou produits disponibles dans le système.

**Attributs :**
- `ProductId` (int, clé primaire) : Identifiant unique du produit
- `ProductName` (nvarchar(50)) : Nom du produit
- `VersionId` (int, clé étrangère) : Référence vers la version du produit

**Relations :**
- Un produit est associé à une version de produit via `VersionId`

### 3. ProductsVersion (Versions de produits)

Représente les différentes versions des produits, associées aux systèmes d'exploitation pris en charge.

**Attributs :**
- `VersionId` (int, clé primaire) : Identifiant unique de la version
- `Version` (nvarchar(10)) : Numéro de version du produit
- `OsId` (int, clé étrangère) : Référence vers le système d'exploitation

**Relations :**
- Une version est liée à un système d'exploitation via `OsId`
- Une version peut être utilisée par plusieurs produits

### 4. Ticket (Tickets de support)

Représente les incidents signalés par les utilisateurs.

**Attributs :**
- `TicketId` (int, clé primaire) : Identifiant unique du ticket
- `Description` (text) : Description du problème rencontré
- `FixingDate` (datetime, valeur par défaut : GETDATE()) : Date de résolution prévue
- `FixingStatus` (enum, valeur par défaut : Open) : Statut de résolution du ticket
- `ProductId` (int, clé étrangère) : Référence vers le produit concerné
- `Problem` (string) : Contient la description du problème rencontré par l'utilisateur
- `ResolutionReport` (string, can be null) : Contient la méthodologie de résolution du problème utilisateur

**Relations :**
- Un ticket est lié à un produit via `ProductId`

## Schéma des Relations

```
+--------------------+
|        Os         |
+--------------------+
| OsId (PK)         |
| OsName            |
+--------------------+
         |
         | (1,N)
         v
+------------------------+
|    ProductsVersion    |
+------------------------+
| VersionId (PK)        |
| Version               |
| OsId (FK)            |
+------------------------+
         |
         | (1,N)
         v
+--------------------+
|     Products      |
+--------------------+
| ProductId (PK)    |
| ProductName       |
| VersionId (FK)    |
+--------------------+
         |
         | (1,N)
         v
+--------------------+
|      Ticket       |
+--------------------+
| TicketId (PK)     |
| Description       |
| FixingDate        |
| FixingStatus      |
| ProductId (FK)    |
| Problem           |
| ResolutionReport  |
+--------------------+
```

## Remplissage de la Base de Données

Afin de tester le fonctionnement de la base de données, un jeu de 25 tickets d'exemple sera inséré via un SeedData. Ces tickets couvrent plusieurs produits, versions et systèmes d'exploitation, en incluant des problèmes résolus et non résolus.