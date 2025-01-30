using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace NexaWorksTicket.Data
{
    public static class DatabaseSeeder
    {
        public static void SeedDatabase(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope(); //en cas d'erreur, mettre le reste du code de cette page entre {}
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            dbContext.Database.EnsureCreated();

            #region ----- OS -----

            var os = dbContext.Os.ToList();
            if (os.Count == 0)
            {
                dbContext.Os.Add(new Os { OsName = "Windows" });
                dbContext.Os.Add(new Os { OsName = "Linux" });
                dbContext.Os.Add(new Os { OsName = "MacOS" });
                dbContext.Os.Add(new Os { OsName = "Android" });
                dbContext.Os.Add(new Os { OsName = "iOS" });
                dbContext.Os.Add(new Os { OsName = "Windows Mobile" });
                dbContext.SaveChanges();
            }

            #endregion ----- OS -----

            #region ----- ProductsVersions -----

            var productsVersions = dbContext.ProductsVersions.ToList();
            if (productsVersions.Count == 0)
            {
                // Trader en Herbe 1.0
                dbContext.ProductsVersions.Add(new ProductsVersion { Version = "1.0", OsId = 1 }); // Windows
                dbContext.ProductsVersions.Add(new ProductsVersion { Version = "1.0", OsId = 2 }); // Linux

                // Trader en Herbe 1.1
                dbContext.ProductsVersions.Add(new ProductsVersion { Version = "1.1", OsId = 1 }); // Windows
                dbContext.ProductsVersions.Add(new ProductsVersion { Version = "1.1", OsId = 2 }); // Linux
                dbContext.ProductsVersions.Add(new ProductsVersion { Version = "1.1", OsId = 3 }); // MacOS

                // Trader en Herbe 1.2
                dbContext.ProductsVersions.Add(new ProductsVersion { Version = "1.2", OsId = 1 }); // Windows
                dbContext.ProductsVersions.Add(new ProductsVersion { Version = "1.2", OsId = 2 }); // Linux
                dbContext.ProductsVersions.Add(new ProductsVersion { Version = "1.2", OsId = 3 }); // MacOS
                dbContext.ProductsVersions.Add(new ProductsVersion { Version = "1.2", OsId = 4 }); // Android
                dbContext.ProductsVersions.Add(new ProductsVersion { Version = "1.2", OsId = 5 }); // iOS
                dbContext.ProductsVersions.Add(new ProductsVersion { Version = "1.2", OsId = 6 }); // Windows Mobile

                // Trader en Herbe 1.3
                dbContext.ProductsVersions.Add(new ProductsVersion { Version = "1.3", OsId = 1 }); // Windows
                dbContext.ProductsVersions.Add(new ProductsVersion { Version = "1.3", OsId = 3 }); // MacOS
                dbContext.ProductsVersions.Add(new ProductsVersion { Version = "1.3", OsId = 4 }); // Android
                dbContext.ProductsVersions.Add(new ProductsVersion { Version = "1.3", OsId = 5 }); // iOS

                // Maitre des Investissements 1.0
                dbContext.ProductsVersions.Add(new ProductsVersion { Version = "1.0", OsId = 3 }); // MacOS
                dbContext.ProductsVersions.Add(new ProductsVersion { Version = "1.0", OsId = 5 }); // iOS

                // Maitre des Investissements 2.0
                dbContext.ProductsVersions.Add(new ProductsVersion { Version = "2.0", OsId = 3 }); // MacOS
                dbContext.ProductsVersions.Add(new ProductsVersion { Version = "2.0", OsId = 4 }); // Android
                dbContext.ProductsVersions.Add(new ProductsVersion { Version = "2.0", OsId = 5 }); // iOS

                // Maitre des Investissements 2.1
                dbContext.ProductsVersions.Add(new ProductsVersion { Version = "2.1", OsId = 3 }); // MacOS
                dbContext.ProductsVersions.Add(new ProductsVersion { Version = "2.1", OsId = 1 }); // Windows
                dbContext.ProductsVersions.Add(new ProductsVersion { Version = "2.1", OsId = 4 }); // Android
                dbContext.ProductsVersions.Add(new ProductsVersion { Version = "2.1", OsId = 5 }); // iOS

                // Planificateur d'Entrainement 1.0
                dbContext.ProductsVersions.Add(new ProductsVersion { Version = "1.0", OsId = 2 }); // Linux
                dbContext.ProductsVersions.Add(new ProductsVersion { Version = "1.0", OsId = 3 }); // MacOS

                // Planificateur d'Entrainement 1.1
                dbContext.ProductsVersions.Add(new ProductsVersion { Version = "1.1", OsId = 2 }); // Linux
                dbContext.ProductsVersions.Add(new ProductsVersion { Version = "1.1", OsId = 3 }); // MacOS
                dbContext.ProductsVersions.Add(new ProductsVersion { Version = "1.1", OsId = 1 }); // Windows
                dbContext.ProductsVersions.Add(new ProductsVersion { Version = "1.1", OsId = 4 }); // Android
                dbContext.ProductsVersions.Add(new ProductsVersion { Version = "1.1", OsId = 5 }); // iOS
                dbContext.ProductsVersions.Add(new ProductsVersion { Version = "1.1", OsId = 6 }); // Windows Mobile

                // Planificateur d'Entrainement 2.0
                dbContext.ProductsVersions.Add(new ProductsVersion { Version = "2.0", OsId = 3 }); // MacOS
                dbContext.ProductsVersions.Add(new ProductsVersion { Version = "2.0", OsId = 1 }); // Windows
                dbContext.ProductsVersions.Add(new ProductsVersion { Version = "2.0", OsId = 4 }); // Android
                dbContext.ProductsVersions.Add(new ProductsVersion { Version = "2.0", OsId = 5 }); // iOS

                // Planificateur d'Anxiété Sociale 1.0
                dbContext.ProductsVersions.Add(new ProductsVersion { Version = "1.0", OsId = 3 }); // MacOS
                dbContext.ProductsVersions.Add(new ProductsVersion { Version = "1.0", OsId = 1 }); // Windows
                dbContext.ProductsVersions.Add(new ProductsVersion { Version = "1.0", OsId = 4 }); // Android
                dbContext.ProductsVersions.Add(new ProductsVersion { Version = "1.0", OsId = 5 }); // iOS

                // Planificateur d'Anxiété Sociale 1.1
                dbContext.ProductsVersions.Add(new ProductsVersion { Version = "1.1", OsId = 3 }); // MacOS
                dbContext.ProductsVersions.Add(new ProductsVersion { Version = "1.1", OsId = 1 }); // Windows
                dbContext.ProductsVersions.Add(new ProductsVersion { Version = "1.1", OsId = 4 }); // Android
                dbContext.ProductsVersions.Add(new ProductsVersion { Version = "1.1", OsId = 5 }); // iOS

                dbContext.SaveChanges();
            }


            #endregion ----- ProductsVersions -----

            #region ----- Products -----

            var products = dbContext.Products.ToList();
            if (products.Count == 0)
            {
                // Trader en Herbe - toutes les versions
                dbContext.Products.Add(new Product { ProductName = "Trader en Herbe", VersionId = 1 }); // Version 1.0 - Supporté sur: Linux, Windows
                dbContext.Products.Add(new Product { ProductName = "Trader en Herbe", VersionId = 2 }); // Version 1.1 - Supporté sur: Linux, MacOS, Windows
                dbContext.Products.Add(new Product { ProductName = "Trader en Herbe", VersionId = 3 }); // Version 1.2 - Supporté sur: Linux, MacOS, Windows, Android, iOS, Windows Mobile
                dbContext.Products.Add(new Product { ProductName = "Trader en Herbe", VersionId = 4 }); // Version 1.3 - Supporté sur: MacOS, Windows, Android, iOS

                // Maitre des Investissements - toutes les versions
                dbContext.Products.Add(new Product { ProductName = "Maitre des Investissements", VersionId = 1 }); // Version 1.0 - Supporté sur: MacOS, iOS
                dbContext.Products.Add(new Product { ProductName = "Maitre des Investissements", VersionId = 5 }); // Version 2.0 - Supporté sur: MacOS, Android, iOS
                dbContext.Products.Add(new Product { ProductName = "Maitre des Investissements", VersionId = 6 }); // Version 2.1 - Supporté sur: MacOS, Windows, Android, iOS

                // Planificateur d'Entrainement - toutes les versions
                dbContext.Products.Add(new Product { ProductName = "Planificateur d'Entrainement", VersionId = 1 }); // Version 1.0 - Supporté sur: Linux, MacOS
                dbContext.Products.Add(new Product { ProductName = "Planificateur d'Entrainement", VersionId = 2 }); // Version 1.1 - Supporté sur: Linux, MacOS, Windows, Android, iOS, Windows Mobile
                dbContext.Products.Add(new Product { ProductName = "Planificateur d'Entrainement", VersionId = 5 }); // Version 2.0 - Supporté sur: MacOS, Windows, Android, iOS

                // Planificateur d'Anxiété Sociale - toutes les versions
                dbContext.Products.Add(new Product { ProductName = "Planificateur d'Anxiété Sociale", VersionId = 1 }); // Version 1.0 - Supporté sur: MacOS, Windows, Android, iOS
                dbContext.Products.Add(new Product { ProductName = "Planificateur d'Anxiété Sociale", VersionId = 2 }); // Version 1.1 - Supporté sur: MacOS, Windows, Android, iOS

                dbContext.SaveChanges();
            }

            #endregion ----- Products -----

            #region ----- Tickets -----

            var tickets = dbContext.Tickets.ToList();
            if (tickets.Count() == 0)
            {
                dbContext.Tickets.Add(new Ticket { ProductId = 1, CreationDate = DateOnly.FromDateTime(DateTime.Now), FixingStatus = FixingStatus.Fixed, FixingDate = DateOnly.FromDateTime(DateTime.Now).AddDays(1), Problem = "L'utilisateur ne parvient pas à exécuter le programme sur sa machine.", ResolutionReport = "Le client utilise un MacBook, cette version du logiciel n'est pas supportée par sa machine." });
                dbContext.Tickets.Add(new Ticket { ProductId = 2, CreationDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-3)), FixingStatus = FixingStatus.Fixed, FixingDate = DateOnly.FromDateTime(DateTime.Now).AddDays(-1), Problem = "L'application plante après l'ouverture.", ResolutionReport = "Le bug était causé par un fichier de configuration corrompu. Correction appliquée." });
                dbContext.Tickets.Add(new Ticket { ProductId = 3, CreationDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-5)), FixingStatus = FixingStatus.Open, Problem = "Impossible d'enregistrer les préférences de l'utilisateur." });
                dbContext.Tickets.Add(new Ticket { ProductId = 4, CreationDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-7)), FixingStatus = FixingStatus.Fixed, FixingDate = DateOnly.FromDateTime(DateTime.Now).AddDays(-2), Problem = "L'affichage est déformé en mode sombre.", ResolutionReport = "Correction appliquée." });
                dbContext.Tickets.Add(new Ticket { ProductId = 5, CreationDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-1)), FixingStatus = FixingStatus.Open, Problem = "L'application consomme trop de batterie sur Android." });

                dbContext.Tickets.Add(new Ticket { ProductId = 6, CreationDate = DateOnly.FromDateTime(DateTime.Now), FixingStatus = FixingStatus.Fixed, FixingDate = DateOnly.FromDateTime(DateTime.Now).AddDays(2), Problem = "Les achats intégrés échouent sur iOS.", ResolutionReport = "Problème de validation de paiement avec Apple. Correction appliquée." });
                dbContext.Tickets.Add(new Ticket { ProductId = 7, CreationDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-2)), FixingStatus = FixingStatus.Fixed, FixingDate = DateOnly.FromDateTime(DateTime.Now).AddDays(-1), Problem = "Impossible de synchroniser avec le serveur.", ResolutionReport = "Correction appliquée." });
                dbContext.Tickets.Add(new Ticket { ProductId = 8, CreationDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-10)), FixingStatus = FixingStatus.Open, Problem = "L'exportation des données ne fonctionne pas sur MacOS." });
                dbContext.Tickets.Add(new Ticket { ProductId = 9, CreationDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-6)), FixingStatus = FixingStatus.Fixed, FixingDate = DateOnly.FromDateTime(DateTime.Now).AddDays(-4), Problem = "L'application ne répond plus après une heure d'utilisation.", ResolutionReport = "Optimisation mémoire appliquée." });
                dbContext.Tickets.Add(new Ticket { ProductId = 10, CreationDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-8)), FixingStatus = FixingStatus.Open, Problem = "Les notifications push ne fonctionnent pas." });

                dbContext.Tickets.Add(new Ticket { ProductId = 11, CreationDate = DateOnly.FromDateTime(DateTime.Now), FixingStatus = FixingStatus.Fixed, FixingDate = DateOnly.FromDateTime(DateTime.Now).AddDays(3), Problem = "Le mode hors ligne ne fonctionne pas.", ResolutionReport = "Ajout d'un cache local." });
                dbContext.Tickets.Add(new Ticket { ProductId = 12, CreationDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-5)), FixingStatus = FixingStatus.Fixed, FixingDate = DateOnly.FromDateTime(DateTime.Now).AddDays(-2), Problem = "Crash lors de l'ajout de nouveaux utilisateurs.", ResolutionReport = "Correction du bug lié à la base de données." });
                dbContext.Tickets.Add(new Ticket { ProductId = 1, CreationDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-3)), FixingStatus = FixingStatus.Open, Problem = "Les graphiques ne s'affichent pas sur iOS." });
                dbContext.Tickets.Add(new Ticket { ProductId = 2, CreationDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-4)), FixingStatus = FixingStatus.Open, Problem = "Le texte est trop petit sur les écrans haute résolution." });
                dbContext.Tickets.Add(new Ticket { ProductId = 3, CreationDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-7)), FixingStatus = FixingStatus.Fixed, FixingDate = DateOnly.FromDateTime(DateTime.Now).AddDays(-3), Problem = "Impossible de supprimer un compte utilisateur.", ResolutionReport = "Ajout du bouton de suppression." });

                dbContext.Tickets.Add(new Ticket { ProductId = 4, CreationDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-9)), FixingStatus = FixingStatus.Fixed, FixingDate = DateOnly.FromDateTime(DateTime.Now).AddDays(-6), Problem = "Problème d'affichage sur tablettes.", ResolutionReport = "Correction CSS appliquée." });
                dbContext.Tickets.Add(new Ticket { ProductId = 5, CreationDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-2)), FixingStatus = FixingStatus.Open, Problem = "Les données ne se chargent pas au démarrage." });
                dbContext.Tickets.Add(new Ticket { ProductId = 6, CreationDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-5)), FixingStatus = FixingStatus.Fixed, FixingDate = DateOnly.FromDateTime(DateTime.Now).AddDays(-1), Problem = "Erreur 500 lors de la connexion.", ResolutionReport = "Correction côté API." });
                dbContext.Tickets.Add(new Ticket { ProductId = 7, CreationDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-6)), FixingStatus = FixingStatus.Open, Problem = "La mise à jour automatique ne fonctionne pas." });
                dbContext.Tickets.Add(new Ticket { ProductId = 8, CreationDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-10)), FixingStatus = FixingStatus.Fixed, FixingDate = DateOnly.FromDateTime(DateTime.Now).AddDays(-7), Problem = "L'application consomme trop de mémoire.", ResolutionReport = "Optimisation appliquée." });

                dbContext.Tickets.Add(new Ticket { ProductId = 9, CreationDate = DateOnly.FromDateTime(DateTime.Now), FixingStatus = FixingStatus.Open, Problem = "Le dark mode ne s'active pas automatiquement." });
                dbContext.Tickets.Add(new Ticket { ProductId = 10, CreationDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-5)), FixingStatus = FixingStatus.Fixed, FixingDate = DateOnly.FromDateTime(DateTime.Now).AddDays(-2), Problem = "L'authentification échoue avec Google.", ResolutionReport = "Mise à jour du SDK OAuth." });
                dbContext.Tickets.Add(new Ticket { ProductId = 11, CreationDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-8)), FixingStatus = FixingStatus.Open, Problem = "Impossible d'ajouter une carte bancaire." });
                dbContext.Tickets.Add(new Ticket { ProductId = 12, CreationDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-3)), FixingStatus = FixingStatus.Fixed, FixingDate = DateOnly.FromDateTime(DateTime.Now).AddDays(-1), Problem = "Les filtres de recherche ne fonctionnent pas.", ResolutionReport = "Correction du bug." });
                dbContext.Tickets.Add(new Ticket { ProductId = 1, CreationDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-4)), FixingStatus = FixingStatus.Open, Problem = "Les notifications ne s'affichent pas sur Android." });

                dbContext.SaveChanges();

            }

            #endregion ----- Tickets -----

        }
    }
}
