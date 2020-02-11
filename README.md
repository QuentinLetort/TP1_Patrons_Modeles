# TP1 Patrons et Modèles

Clément Labbé Sou\
Camille Lemauff\
Quentin Letort

## Instanciation de l'API

Pour pouvoir utiliser l'API, l'utilisateur passe par l'ApiBuilder qui permet de définir les différentes options choisies pour la communication, il peut ainsi définir le nombre de threads alloués au job system, le protocole de communication mais également les opérations appliquées sur le flux (compression, encryption).

```cs
ApiBuilder builder = new ApiBuilder();
builder.SetConsoleProtocol();
builder.SetCompression();
builder.SetNbThread(10);

Api api = builder.GetResult();
```

# Utilisation de l'API

On peut ensuite envoyer de la donnée avec une interface simple
```cs
api.Send("data");
```


