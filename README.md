# Overview

Ecriture d'un frontend utilisant Blazor, CleanArchitecture (onion style) et Fluent UI

# Logique d'ajout d'une DTO
1) Création du DTO                 -> Application/DTOs
2) Creation Interface              -> Application/Interfaces/Services
3) Implementation Interface        -> Application/Services
4) Ajouter à ApplicationServices   -> Application/

# Logique Ajout Client API Global
1) Creation Interface API Client   -> Application/Interfaces/HttpClients
2) Implementation API Client       -> Infrastructure/HttpClient
3) Ajout à InfrastructureService   -> Infrastructure/

## Utilisation de l'IA
L'IA a été utilisée pour transferer le Template CSS vers une version Blazor Fonctionnant avec FluentUI
