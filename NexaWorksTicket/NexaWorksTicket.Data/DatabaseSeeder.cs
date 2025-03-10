using Microsoft.Extensions.DependencyInjection;
using NexaWorksTicket.Models.Bdd;

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
                dbContext.ProductsVersions.Add(new ProductsVersion { Version = "1.0"});
                dbContext.ProductsVersions.Add(new ProductsVersion { Version = "1.1" }); 
                dbContext.ProductsVersions.Add(new ProductsVersion { Version = "1.2"});
                dbContext.ProductsVersions.Add(new ProductsVersion { Version = "1.3"});
                dbContext.ProductsVersions.Add(new ProductsVersion { Version = "2.0"});
                dbContext.ProductsVersions.Add(new ProductsVersion { Version = "2.1"});

                dbContext.SaveChanges();
            }


            #endregion ----- ProductsVersions -----

            #region ----- Products -----

            var products = dbContext.Products.ToList();
            if (products.Count == 0)
            {
                dbContext.Products.Add(new Product { ProductName = "Trader en Herbe"});
                dbContext.Products.Add(new Product { ProductName = "Maitre des Investissements"});
                dbContext.Products.Add(new Product { ProductName = "Planificateur d'Entrainement"}); // Version 1.0 - Supporté sur: Linux, MacOS
                dbContext.Products.Add(new Product { ProductName = "Planificateur d'Anxiété Sociale"}); // Version 1.0 - Supporté sur: MacOS, Windows, Android, iOS

                dbContext.SaveChanges();
            }

            #endregion ----- Products -----

            #region ----- ProductVersionOs -----

            var productVersionOsList = dbContext.ProductVersionOs.ToList();
            if (productVersionOsList.Count == 0)
            {
                // Récupération des OS
                var osLinux = dbContext.Os.First(o => o.OsName == "Linux");
                var osMacOS = dbContext.Os.First(o => o.OsName == "MacOS");
                var osWindows = dbContext.Os.First(o => o.OsName == "Windows");
                var osAndroid = dbContext.Os.First(o => o.OsName == "Android");
                var osiOS = dbContext.Os.First(o => o.OsName == "iOS");
                var osWinMobile = dbContext.Os.First(o => o.OsName == "Windows Mobile");

                // Récupération des Produits
                var productTrader = dbContext.Products.First(p => p.ProductName == "Trader en Herbe");
                var productMaitre = dbContext.Products.First(p => p.ProductName == "Maitre des Investissements");
                var productEntrainement = dbContext.Products.First(p => p.ProductName == "Planificateur d'Entrainement");
                var productAnxiete = dbContext.Products.First(p => p.ProductName == "Planificateur d'Anxiété Sociale");

                // Récupération des Versions
                // Pour Trader en Herbe : versions 1.0, 1.1, 1.2, 1.3
                var version1_0 = dbContext.ProductsVersions.First(v => v.Version == "1.0");
                var version1_1 = dbContext.ProductsVersions.First(v => v.Version == "1.1");
                var version1_2 = dbContext.ProductsVersions.First(v => v.Version == "1.2");
                var version1_3 = dbContext.ProductsVersions.First(v => v.Version == "1.3");
                // Pour Maitre des Investissements : versions 1.0, 2.0, 2.1
                var version2_0 = dbContext.ProductsVersions.First(v => v.Version == "2.0");
                var version2_1 = dbContext.ProductsVersions.First(v => v.Version == "2.1");

                // ----- Trader en Herbe -----
                // Version 1.0 : Linux, MacOS
                dbContext.ProductVersionOs.Add(new ProductVersionOs
                {
                    IdProduct = productTrader.ProductId,
                    IdVersion = version1_0.VersionId,
                    IdOs = osLinux.OsId
                });
                dbContext.ProductVersionOs.Add(new ProductVersionOs
                {
                    IdProduct = productTrader.ProductId,
                    IdVersion = version1_0.VersionId,
                    IdOs = osMacOS.OsId
                });

                // Version 1.1 : Linux, MacOS, Windows
                dbContext.ProductVersionOs.Add(new ProductVersionOs
                {
                    IdProduct = productTrader.ProductId,
                    IdVersion = version1_1.VersionId,
                    IdOs = osLinux.OsId
                });
                dbContext.ProductVersionOs.Add(new ProductVersionOs
                {
                    IdProduct = productTrader.ProductId,
                    IdVersion = version1_1.VersionId,
                    IdOs = osMacOS.OsId
                });
                dbContext.ProductVersionOs.Add(new ProductVersionOs
                {
                    IdProduct = productTrader.ProductId,
                    IdVersion = version1_1.VersionId,
                    IdOs = osWindows.OsId
                });

                // Version 1.2 : Linux, MacOS, Windows, Android, iOS, Windows Mobile
                dbContext.ProductVersionOs.Add(new ProductVersionOs { IdProduct = productTrader.ProductId, IdVersion = version1_2.VersionId, IdOs = osLinux.OsId });
                dbContext.ProductVersionOs.Add(new ProductVersionOs { IdProduct = productTrader.ProductId, IdVersion = version1_2.VersionId, IdOs = osMacOS.OsId });
                dbContext.ProductVersionOs.Add(new ProductVersionOs { IdProduct = productTrader.ProductId, IdVersion = version1_2.VersionId, IdOs = osWindows.OsId });
                dbContext.ProductVersionOs.Add(new ProductVersionOs { IdProduct = productTrader.ProductId, IdVersion = version1_2.VersionId, IdOs = osAndroid.OsId });
                dbContext.ProductVersionOs.Add(new ProductVersionOs { IdProduct = productTrader.ProductId, IdVersion = version1_2.VersionId, IdOs = osiOS.OsId });
                dbContext.ProductVersionOs.Add(new ProductVersionOs { IdProduct = productTrader.ProductId, IdVersion = version1_2.VersionId, IdOs = osWinMobile.OsId });

                // Version 1.3 : Linux, MacOS, Windows, Android
                dbContext.ProductVersionOs.Add(new ProductVersionOs { IdProduct = productTrader.ProductId, IdVersion = version1_3.VersionId, IdOs = osLinux.OsId });
                dbContext.ProductVersionOs.Add(new ProductVersionOs { IdProduct = productTrader.ProductId, IdVersion = version1_3.VersionId, IdOs = osMacOS.OsId });
                dbContext.ProductVersionOs.Add(new ProductVersionOs { IdProduct = productTrader.ProductId, IdVersion = version1_3.VersionId, IdOs = osWindows.OsId });
                dbContext.ProductVersionOs.Add(new ProductVersionOs { IdProduct = productTrader.ProductId, IdVersion = version1_3.VersionId, IdOs = osAndroid.OsId });

                // ----- Maitre des Investissements -----
                // Version 1.0 : Linux, MacOS
                dbContext.ProductVersionOs.Add(new ProductVersionOs { IdProduct = productMaitre.ProductId, IdVersion = version1_0.VersionId, IdOs = osLinux.OsId });
                dbContext.ProductVersionOs.Add(new ProductVersionOs { IdProduct = productMaitre.ProductId, IdVersion = version1_0.VersionId, IdOs = osMacOS.OsId });
                // Version 2.0 : Linux, MacOS, Windows
                dbContext.ProductVersionOs.Add(new ProductVersionOs { IdProduct = productMaitre.ProductId, IdVersion = version2_0.VersionId, IdOs = osLinux.OsId });
                dbContext.ProductVersionOs.Add(new ProductVersionOs { IdProduct = productMaitre.ProductId, IdVersion = version2_0.VersionId, IdOs = osMacOS.OsId });
                dbContext.ProductVersionOs.Add(new ProductVersionOs { IdProduct = productMaitre.ProductId, IdVersion = version2_0.VersionId, IdOs = osWindows.OsId });
                // Version 2.1 : Linux, MacOS, Windows, Android
                dbContext.ProductVersionOs.Add(new ProductVersionOs { IdProduct = productMaitre.ProductId, IdVersion = version2_1.VersionId, IdOs = osLinux.OsId });
                dbContext.ProductVersionOs.Add(new ProductVersionOs { IdProduct = productMaitre.ProductId, IdVersion = version2_1.VersionId, IdOs = osMacOS.OsId });
                dbContext.ProductVersionOs.Add(new ProductVersionOs { IdProduct = productMaitre.ProductId, IdVersion = version2_1.VersionId, IdOs = osWindows.OsId });
                dbContext.ProductVersionOs.Add(new ProductVersionOs { IdProduct = productMaitre.ProductId, IdVersion = version2_1.VersionId, IdOs = osAndroid.OsId });

                // ----- Planificateur d'Entrainement -----
                // Version 1.0 : Linux, MacOS
                dbContext.ProductVersionOs.Add(new ProductVersionOs { IdProduct = productEntrainement.ProductId, IdVersion = version1_0.VersionId, IdOs = osLinux.OsId });
                dbContext.ProductVersionOs.Add(new ProductVersionOs { IdProduct = productEntrainement.ProductId, IdVersion = version1_0.VersionId, IdOs = osMacOS.OsId });
                // Version 1.1 : Linux, MacOS, Windows, Android, iOS, Windows Mobile
                dbContext.ProductVersionOs.Add(new ProductVersionOs { IdProduct = productEntrainement.ProductId, IdVersion = version1_1.VersionId, IdOs = osLinux.OsId });
                dbContext.ProductVersionOs.Add(new ProductVersionOs { IdProduct = productEntrainement.ProductId, IdVersion = version1_1.VersionId, IdOs = osMacOS.OsId });
                dbContext.ProductVersionOs.Add(new ProductVersionOs { IdProduct = productEntrainement.ProductId, IdVersion = version1_1.VersionId, IdOs = osWindows.OsId });
                dbContext.ProductVersionOs.Add(new ProductVersionOs { IdProduct = productEntrainement.ProductId, IdVersion = version1_1.VersionId, IdOs = osAndroid.OsId });
                dbContext.ProductVersionOs.Add(new ProductVersionOs { IdProduct = productEntrainement.ProductId, IdVersion = version1_1.VersionId, IdOs = osiOS.OsId });
                dbContext.ProductVersionOs.Add(new ProductVersionOs { IdProduct = productEntrainement.ProductId, IdVersion = version1_1.VersionId, IdOs = osWinMobile.OsId });
                // Version 2.0 : Linux, MacOS, Windows, Android
                dbContext.ProductVersionOs.Add(new ProductVersionOs { IdProduct = productEntrainement.ProductId, IdVersion = version2_0.VersionId, IdOs = osLinux.OsId });
                dbContext.ProductVersionOs.Add(new ProductVersionOs { IdProduct = productEntrainement.ProductId, IdVersion = version2_0.VersionId, IdOs = osMacOS.OsId });
                dbContext.ProductVersionOs.Add(new ProductVersionOs { IdProduct = productEntrainement.ProductId, IdVersion = version2_0.VersionId, IdOs = osWindows.OsId });
                dbContext.ProductVersionOs.Add(new ProductVersionOs { IdProduct = productEntrainement.ProductId, IdVersion = version2_0.VersionId, IdOs = osAndroid.OsId });

                // ----- Planificateur d'Anxiété Sociale -----
                // Version 1.0 : Linux, MacOS, Windows, Android
                dbContext.ProductVersionOs.Add(new ProductVersionOs { IdProduct = productAnxiete.ProductId, IdVersion = version1_0.VersionId, IdOs = osLinux.OsId });
                dbContext.ProductVersionOs.Add(new ProductVersionOs { IdProduct = productAnxiete.ProductId, IdVersion = version1_0.VersionId, IdOs = osMacOS.OsId });
                dbContext.ProductVersionOs.Add(new ProductVersionOs { IdProduct = productAnxiete.ProductId, IdVersion = version1_0.VersionId, IdOs = osWindows.OsId });
                dbContext.ProductVersionOs.Add(new ProductVersionOs { IdProduct = productAnxiete.ProductId, IdVersion = version1_0.VersionId, IdOs = osAndroid.OsId });
                // Version 1.1 : Linux, MacOS, Windows, Android
                dbContext.ProductVersionOs.Add(new ProductVersionOs { IdProduct = productAnxiete.ProductId, IdVersion = version1_1.VersionId, IdOs = osLinux.OsId });
                dbContext.ProductVersionOs.Add(new ProductVersionOs { IdProduct = productAnxiete.ProductId, IdVersion = version1_1.VersionId, IdOs = osMacOS.OsId });
                dbContext.ProductVersionOs.Add(new ProductVersionOs { IdProduct = productAnxiete.ProductId, IdVersion = version1_1.VersionId, IdOs = osWindows.OsId });
                dbContext.ProductVersionOs.Add(new ProductVersionOs { IdProduct = productAnxiete.ProductId, IdVersion = version1_1.VersionId, IdOs = osAndroid.OsId });

                dbContext.SaveChanges();
            }

            #endregion ----- ProductVersionOs -----


            #region ----- Tickets -----

            var tickets = dbContext.Tickets.ToList();
            if (tickets.Count() == 0)
            {
                dbContext.Tickets.Add(new Ticket { ProductVersionOsId = 1, CreationDate = DateOnly.FromDateTime(DateTime.Now), FixingStatus = FixingStatus.Fixed, FixingDate = DateOnly.FromDateTime(DateTime.Now).AddDays(1), Problem = "L'utilisateur ne parvient pas à exécuter le programme sur sa machine.", ResolutionReport = "Le client utilise un MacBook, cette version du logiciel n'est pas supportée par sa machine." });
                dbContext.Tickets.Add(new Ticket { ProductVersionOsId = 12, CreationDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-3)), FixingStatus = FixingStatus.Fixed, FixingDate = DateOnly.FromDateTime(DateTime.Now).AddDays(-1), Problem = "L'application plante après l'ouverture.", ResolutionReport = "Le bug était causé par un fichier de configuration corrompu. Correction appliquée." });
                dbContext.Tickets.Add(new Ticket { ProductVersionOsId = 23, CreationDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-5)), FixingStatus = FixingStatus.Open, Problem = "Impossible d'enregistrer les préférences de l'utilisateur." });
                dbContext.Tickets.Add(new Ticket { ProductVersionOsId = 34, CreationDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-7)), FixingStatus = FixingStatus.Fixed, FixingDate = DateOnly.FromDateTime(DateTime.Now).AddDays(-2), Problem = "L'affichage est déformé en mode sombre.", ResolutionReport = "Correction appliquée." });
                dbContext.Tickets.Add(new Ticket { ProductVersionOsId = 44, CreationDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-1)), FixingStatus = FixingStatus.Open, Problem = "L'application consomme trop de batterie sur Android." });

                dbContext.Tickets.Add(new Ticket { ProductVersionOsId = 2, CreationDate = DateOnly.FromDateTime(DateTime.Now), FixingStatus = FixingStatus.Fixed, FixingDate = DateOnly.FromDateTime(DateTime.Now).AddDays(2), Problem = "Les achats intégrés échouent sur iOS.", ResolutionReport = "Problème de validation de paiement avec Apple. Correction appliquée." });
                dbContext.Tickets.Add(new Ticket { ProductVersionOsId = 13, CreationDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-2)), FixingStatus = FixingStatus.Fixed, FixingDate = DateOnly.FromDateTime(DateTime.Now).AddDays(-1), Problem = "Impossible de synchroniser avec le serveur.", ResolutionReport = "Correction appliquée." });
                dbContext.Tickets.Add(new Ticket { ProductVersionOsId = 28, CreationDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-10)), FixingStatus = FixingStatus.Open, Problem = "L'exportation des données ne fonctionne pas sur MacOS." });
                dbContext.Tickets.Add(new Ticket { ProductVersionOsId = 39, CreationDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-6)), FixingStatus = FixingStatus.Fixed, FixingDate = DateOnly.FromDateTime(DateTime.Now).AddDays(-4), Problem = "L'application ne répond plus après une heure d'utilisation.", ResolutionReport = "Optimisation mémoire appliquée." });
                dbContext.Tickets.Add(new Ticket { ProductVersionOsId = 40, CreationDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-8)), FixingStatus = FixingStatus.Open, Problem = "Les notifications push ne fonctionnent pas." });
                dbContext.Tickets.Add(new Ticket { ProductVersionOsId = 21, CreationDate = DateOnly.FromDateTime(DateTime.Now), FixingStatus = FixingStatus.Fixed, FixingDate = DateOnly.FromDateTime(DateTime.Now).AddDays(3), Problem = "Le mode hors ligne ne fonctionne pas.", ResolutionReport = "Ajout d'un cache local." });
                dbContext.Tickets.Add(new Ticket { ProductVersionOsId = 14, CreationDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-5)), FixingStatus = FixingStatus.Fixed, FixingDate = DateOnly.FromDateTime(DateTime.Now).AddDays(-2), Problem = "Crash lors de l'ajout de nouveaux utilisateurs.", ResolutionReport = "Correction du bug lié à la base de données." });
                dbContext.Tickets.Add(new Ticket { ProductVersionOsId = 19, CreationDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-3)), FixingStatus = FixingStatus.Open, Problem = "Les graphiques ne s'affichent pas sur iOS." });
                dbContext.Tickets.Add(new Ticket { ProductVersionOsId = 25, CreationDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-4)), FixingStatus = FixingStatus.Open, Problem = "Le texte est trop petit sur les écrans haute résolution." });
                dbContext.Tickets.Add(new Ticket { ProductVersionOsId = 31, CreationDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-7)), FixingStatus = FixingStatus.Fixed, FixingDate = DateOnly.FromDateTime(DateTime.Now).AddDays(-3), Problem = "Impossible de supprimer un compte utilisateur.", ResolutionReport = "Ajout du bouton de suppression." });
                dbContext.Tickets.Add(new Ticket { ProductVersionOsId = 42, CreationDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-9)), FixingStatus = FixingStatus.Fixed, FixingDate = DateOnly.FromDateTime(DateTime.Now).AddDays(-6), Problem = "Problème d'affichage sur tablettes.", ResolutionReport = "Correction CSS appliquée." });
                dbContext.Tickets.Add(new Ticket { ProductVersionOsId = 35, CreationDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-2)), FixingStatus = FixingStatus.Open, Problem = "Les données ne se chargent pas au démarrage." });
                dbContext.Tickets.Add(new Ticket { ProductVersionOsId = 16, CreationDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-5)), FixingStatus = FixingStatus.Fixed, FixingDate = DateOnly.FromDateTime(DateTime.Now).AddDays(-1), Problem = "Erreur 500 lors de la connexion.", ResolutionReport = "Correction côté API." });
                dbContext.Tickets.Add(new Ticket { ProductVersionOsId = 27, CreationDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-6)), FixingStatus = FixingStatus.Open, Problem = "La mise à jour automatique ne fonctionne pas." });
                dbContext.Tickets.Add(new Ticket { ProductVersionOsId = 18, CreationDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-10)), FixingStatus = FixingStatus.Fixed, FixingDate = DateOnly.FromDateTime(DateTime.Now).AddDays(-7), Problem = "L'application consomme trop de mémoire.", ResolutionReport = "Optimisation appliquée." });
                dbContext.Tickets.Add(new Ticket { ProductVersionOsId = 9, CreationDate = DateOnly.FromDateTime(DateTime.Now), FixingStatus = FixingStatus.Open, Problem = "Le dark mode ne s'active pas automatiquement." });
                dbContext.Tickets.Add(new Ticket { ProductVersionOsId = 7, CreationDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-5)), FixingStatus = FixingStatus.Fixed, FixingDate = DateOnly.FromDateTime(DateTime.Now).AddDays(-2), Problem = "L'authentification échoue avec Google.", ResolutionReport = "Mise à jour du SDK OAuth." });
                dbContext.Tickets.Add(new Ticket { ProductVersionOsId = 11, CreationDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-8)), FixingStatus = FixingStatus.Open, Problem = "Impossible d'ajouter une carte bancaire." });
                dbContext.Tickets.Add(new Ticket { ProductVersionOsId = 4, CreationDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-3)), FixingStatus = FixingStatus.Fixed, FixingDate = DateOnly.FromDateTime(DateTime.Now).AddDays(-1), Problem = "Les filtres de recherche ne fonctionnent pas.", ResolutionReport = "Correction du bug." });
                dbContext.Tickets.Add(new Ticket { ProductVersionOsId = 1, CreationDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-4)), FixingStatus = FixingStatus.Open, Problem = "Les notifications ne s'affichent pas sur Android." });

                dbContext.SaveChanges();

            }

            #endregion ----- Tickets -----

        }
    }
}
