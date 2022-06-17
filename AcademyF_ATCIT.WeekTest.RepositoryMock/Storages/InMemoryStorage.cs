using AcademyF_ATCIT.WeekTest.Core.Entities;
using System;
using System.Collections.Generic;
using AcademyF_ATCIT.WeekTest.RepositoryMock.Storages.Extensions;

namespace AcademyF_ATCIT.WeekTest.RepositoryMock.Storages
{
    public class InMemoryStorage
    {
        #region Private static initialization
        /// <summary>
        /// Lazy loader for singleton storage instance
        /// </summary>
        private static Lazy<InMemoryStorage> _Default = new Lazy<InMemoryStorage>(Initialize);

        /// <summary>
        /// Initialize storage with scenario data
        /// </summary>
        /// <returns>Returns singleton instance</returns>
        private static InMemoryStorage Initialize()
        {
            //Creo una nuova istanza "singleton" della classe
            var instance = new InMemoryStorage
            {
                //Inizializzo la lista di tutte le entità
                GiftCards = new List<GiftCard>(),
                
            };

            #region Dipendenti
            //Inserisco i dati "finti" degli "Utenti"
           /* instance.GenerateIdentityAndPush(i => i.Users, new User
            {
                FirstName = "Mario",
                LastName = "Rossi",
                Email = "mario.rossi@icubed.it",
                IsEnabled = true,
                UserName = "mario.rossi",
                Password = "123456",
                IsAdministrator = true
            });
            instance.GenerateIdentityAndPush(i => i.Users, new User
            {
                FirstName = "Giuseppe",
                LastName = "Verdi",
                Email = "giuseppe.verdi@icubed.it",
                IsEnabled = true,
                UserName = "giuseppe.verdi",
                Password = "123456",
                IsAdministrator = false
            });*/
            #endregion

            #region GiftCard
            //Inserisco i dati "finti" degli "Dipendenti"
            instance.GenerateIdentityAndPush(i => i.GiftCards, new GiftCard
            {
                Mittente = "Mario",
                Destinatario = "Rossi",
                Messaggio = "mario.rossi@icubed.it",
                Importo = 10,
                DataDiScadenza = new DateTime(1999, 1, 1)
                
            });
            instance.GenerateIdentityAndPush(i => i.GiftCards, new GiftCard
            {
                Mittente = "Luigi",
                Destinatario = "Verde",
                Messaggio = "luigi.verde@icubed.it",
                Importo = 10,
                DataDiScadenza = new DateTime(1999, 1, 1)
            });
            instance.GenerateIdentityAndPush(i => i.GiftCards, new GiftCard
            {
                Mittente = "Rossi",
                Destinatario = "Mario",
                Messaggio = "rossi.mario@icubed.it",
                Importo = 10,
                DataDiScadenza = new DateTime(1999, 1, 1)
            });
            #endregion

            //Ritorno l'istanza
            return instance;
        }
        #endregion

        #region Public static methods
        /// <summary>
        /// Singleton instance of storage
        /// </summary>
        public static InMemoryStorage Default { get => _Default.Value; }

        /// <summary>
        /// Destroy singleton instance of storage
        /// </summary>
        public static void Destroy()
        {
            //Ricreando il "lazy" di fatto elimino l'istanza in memoria del database
            //che sarà poi re-inizializzato alla prima chiamata
            _Default = new Lazy<InMemoryStorage>(Initialize);
        }
        #endregion

        /// <summary>
        /// Dipendenti
        /// </summary>
        public List<GiftCard> GiftCards { get; private set; }

        /*/// <summary>
        /// Mansioni
        /// </summary>
        public IList<Mansione> Mansioni { get; set; }

        /// <summary>
        /// Users
        /// </summary>
        public IList<User> Users { get; set; }*/
    }
}
