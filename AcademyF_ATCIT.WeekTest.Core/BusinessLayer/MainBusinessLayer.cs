using AcademyF_ATCIT.WeekTest.Core.DependencyContainers;
using AcademyF_ATCIT.WeekTest.Core.Entities;
using AcademyF_ATCIT.WeekTest.Core.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using AcademyF_ATCIT.WeekTest.Core.Repositories;
using AcademyF_ATCIT.WeekTest.Core.Core.Entities;

namespace AcademyF_ATCIT.WeekTest.Core.BusinessLayer
{
    public class MainBusinessLayer : BusinessLayerBase
    {
        #region Public properties
        public IProductRepository DipendenteRepository { get; set; }
        public IGiftCardRepository GiftCardRepository { get; set; }
        #endregion

        public MainBusinessLayer()
        {
            DipendenteRepository = DependencyContainer.Resolve<IProductRepository>();
            GiftCardRepository = DependencyContainer.Resolve<IGiftCardRepository>();
        }

        #region GiftCard
        /// <summary>
        /// Get single giftcard by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public GiftCard GiftCardById(int id)
        {
            //TODO non va bene, ma per fare in fretta ci può stare!
            return FetchAllEntities(GiftCardRepository)
                .SingleOrDefault(e => e.Id == id);
        }

        /// <summary>
        /// Lista di tutti i dipendenti nello storage
        /// </summary>
        /// <returns>Ritorna la lista</returns>
        public IList<GiftCard> FetchAllGiftCard()
        {
            //Utilizzo il repository
            return GiftCardRepository.FetchAll();
        }

        /// <summary>
        /// Crea un oggetto "Dipendente" sul database e ritorna le validazioni
        /// </summary>
        /// <param name="entity">Entità</param>
        /// <returns>Ritorna le validazioni fallite (lista vuota => tutto ok!)</returns>
        public IList<ValidationResult> CreateGiftCard(GiftCard entity)
        {
            //Validazione argomenti
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            //Validazione dell'oggetto
            var validations = ValidationUtils.Validate(entity);

            //Se ho validazioni fallite, non vado avanti
            if (validations.Count > 0)
                return validations;

            //Chiedo al repository di creare
            GiftCardRepository.Create(entity);

            //Ritorno le validazioni (che sono vuote) per segnalare
            //che tutto è andato a buon fine
            return validations;
        }

        /// <summary>
        /// Aggiorna un oggetto "GiftCard" sul database e ritorna le validazioni
        /// </summary>
        /// <param name="entity">Entità</param>
        /// <returns>Ritorna le validazioni fallite (lista vuota => tutto ok!)</returns>
        public IList<ValidationResult> UpdateDipendente(GiftCard entity)
        {
            //Validazione argomenti
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            //Validazione dell'oggetto
            var validations = ValidationUtils.Validate(entity);

            //Se ho validazioni fallite, non vado avanti
            if (validations.Count > 0)
                return validations;

            //Chiedo al repository di creare
            GiftCardRepository.Update(entity);

            //Ritorno le validazioni (che sono vuote) per segnalare
            //che tutto è andato a buon fine
            return validations;
        }



        /// <summary>
        /// Elimina un oggetto "Dipendente" sul database e ritorna le validazioni
        /// </summary>
        /// <param name="entity">Entità</param>
        /// <returns>Ritorna le validazioni fallite (lista vuota => tutto ok!)</returns>
        public IList<ValidationResult> DeleteGiftCard(GiftCard entity)
        {
            //Validazione argomenti
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            //Validazione dell'oggetto
            var validations = ValidationUtils.Validate(entity);

            //Se ho validazioni fallite, non vado avanti
            if (validations.Count > 0)
                return validations;

            //Chiedo al repository di creare
            GiftCardRepository.Delete(entity);

            //Ritorno le validazioni (che sono vuote) per segnalare
            //che tutto è andato a buon fine
            return validations;
        }

        #endregion

    }
}
