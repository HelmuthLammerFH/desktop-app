using GalaSoft.MvvmLight;
using Shared.DummyEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.ViewModel.EntityViewModel
{
    public class MemberEntityVM : ViewModelBase
    {
        private DummyMember member;

        public MemberEntityVM(DummyMember member)
        {
            this.member = member;
        }

        public string Firstname
        {
            get
            {
                return member.User.Firstname;
            }

            set
            {
                member.User.Firstname = value;
            }
        }

        public string Lastname
        {
            get
            {
                return member.User.Lastname;
            }

            set
            {
                member.User.Lastname = value;
            }
        }

        public bool AttendTour
        {
            get
            {
                return member.AttendTour;
            }

            set
            {
                member.AttendTour = value;
            }
        }

        public DummyMember Member
        {
            get
            {
                return member;
            }

            set
            {
                member = value;
            }
        }
    }
}
