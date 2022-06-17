using AcademyF_ATCIT.WeekTest.Core.Entities;
using AcademyF_ATCIT.WeekTest.Core.Repositories;
using AcademyF_ATCIT.WeekTest.WPF.Messages;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AcademyF_ATCIT.WeekTest.WPF.ViewModels.Summary
{
    public class SummaryViewModel : ViewModelBase
    {
        private List<string> _giftcards;
        private string _selectedItem;
        private string _itemDetails;
        private bool _selected;
        private string _textCards;

        private IGiftCardRepository _giftCardRepository;

        public bool ViewCards
        {
            get { return _selected; }
            set { _selected = value; RaisePropertyChanged(); }
        }

        public List<string> GiftCards
        {
            get => _giftcards;
            set
            {
                _giftcards = value;
                RaisePropertyChanged();
            }
        }
        public string SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                RaisePropertyChanged();
            }
        }

        public string ItemDetails
        {
            get => _itemDetails;
            set
            {
                _itemDetails = value;
                RaisePropertyChanged();
            }
        }
        public string TextCards
        {
            get { return _textCards; }
            set
            {
                _textCards = value;
                RaisePropertyChanged();
            }
        }
        public ICommand ViewCardCommand { get; set; }
        public ICommand UpdateCardCommand { get; set; }
        public ICommand DeleteCardCommand { get; set; }
        public ICommand SetCardCommand { get; set; }


        public SummaryViewModel ()
        {
            ViewCardCommand = new RelayCommand(ViewCard);
            //UpdateCardCommand = new RelayCommand(UpdateCard);
        }

       /* private void UpdateCard()
        {

            if (SelectedItem != null)
            {
                GiftCard giftcard = _giftCardRepository.FetchAll()
                    .FirstOrDefault(p => p.Mittente.Equals(SelectedItem, StringComparison.InvariantCultureIgnoreCase));
                if (giftcard != null)
                {
                    _totalCart += product.Price;
                    //Mostrare a video
                    TextCart = $"Hai speso {_totalCart} euro";
                }
            }

        }*/

        private void ViewCard()
        {
            if (SelectedItem != null)

            {
                GiftCard giftcard = _giftCardRepository.FetchAll()
                    .FirstOrDefault(g => g.Mittente.Equals(SelectedItem, StringComparison.InvariantCultureIgnoreCase));
                ItemDetails = giftcard is null ? "Gift Card non trovata" : giftcard.ToString();
            }
            DialogMessage dialog = new DialogMessage { Content = ItemDetails };
            Messenger.Default.Send(dialog);
        }
    }
}
