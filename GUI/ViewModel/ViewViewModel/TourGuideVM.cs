using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.ViewModel.EntityViewModel
{
    public class TourGuideVM : ViewModelBase
    {
        public TourGuideVM(int iD, string username)
        {
            ID = iD;
            Username = username;
        }

        public int ID { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
    }
}
