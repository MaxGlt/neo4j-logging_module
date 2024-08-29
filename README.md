# LoggingModule

## Description

`LoggingModule` est un module de journalisation développé en C# pour les applications utilisant le .NET Framework. Il est conçu pour intercepter et enregistrer les détails des requêtes HTTP en cours de traitement dans une application. Ce module facilite la surveillance et le débogage des opérations HTTP, tout en assurant une gestion efficace des URL et des redirections via des règles de réécriture spécifiques implémentées par un script PowerShell.

## Fonctionnalités

- **Journalisation des requêtes HTTP** : Capture et enregistre les détails des requêtes HTTP, y compris les en-têtes, les corps de requête, les réponses et les statuts.
- **Règles de réécriture des URL** : Implémente des règles de réécriture via un script PowerShell pour gérer les redirections et la modification des URL.
- **Envoi des logs vers une API dédiée** : Utilise un endpoint spécifique pour transmettre les données de journalisation à une API dédiée, permettant une centralisation et une analyse des logs.

## Installation

### Prérequis

- .NET Framework 4.x (ou plus récent)
- Visual Studio 2019 ou plus récent
- PowerShell 5.1 ou plus récent (pour les règles de réécriture)

## Contribution
Les contributions sont les bienvenues ! Si vous avez des suggestions, des améliorations ou des rapports de bogues, n'hésitez pas à ouvrir une issue ou à soumettre une pull request.

## Licence
Ce projet est sous licence MIT. Voir le fichier LICENSE pour plus de détails.