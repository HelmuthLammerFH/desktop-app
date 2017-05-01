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

        public string Prename
        {
            get
            {
                return member.User.PreName;
            }

            set
            {
                member.User.PreName = value;
            }
        }

        public string SureName
        {
            get
            {
                return member.User.SureName;
            }

            set
            {
                member.User.SureName = value;
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
