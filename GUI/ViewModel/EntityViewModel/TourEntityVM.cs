using GalaSoft.MvvmLight;
using Shared.DummyEntities;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.ViewModel.EntityViewModel
    {
        public class TourEntityVM : ViewModelBase
        {
            private DummyTour tour;
            private ObservableCollection<PositionEntityVM> positions;
            private ObservableCollection<MemberEntityVM> members;

            public TourEntityVM(DummyTour tour)
            {
                this.tour = tour;
                if (tour.Positions != null)
                {
                    positions = new ObservableCollection<PositionEntityVM>();
                    foreach (DummyPosition position in tour.Positions)
                    {
                        positions.Add(new PositionEntityVM(position));
                    }
                }
                if (tour.Members != null)
                {
                    members = new ObservableCollection<MemberEntityVM>();
                    foreach (DummyMember member in tour.Members)
                    {
                        members.Add(new MemberEntityVM(member));
                    }
                }
            }

            public string Title
            {
                get
                {
                    return tour.Name;
                }

                set
                {
                    tour.Name = value;
                }
            }

        public DateTime Startdate
        {
            get
            {
                return tour.StartDate;
            }

            set
            {
                tour.StartDate = value;
            }
        }
        public DateTime Enddate
        {
            get
            {
                return tour.EndDate;
            }

            set
            {
                tour.EndDate = value;
            }
        }


        public string Duration
            {
                get
                {
                /**DateTime dt = new DateTime(0);
                if (tour.Positions == null || tour.Positions.Count == 0)
                    return dt + new TimeSpan(0);
                if (tour.Positions.Count == 1)
                    return dt + (tour.Positions[0].ToDateTime - tour.Positions[0].FromDateTime);
                return dt + (tour.Positions[tour.Positions.Count - 1].ToDateTime - tour.Positions[0].FromDateTime);**/
                return (Enddate - Startdate).ToString();
                }
            }

            public string State
            {
                get
                {
                    return tour.State;
                }

                set
                {
                    tour.State = value;
                }
            }

            public ObservableCollection<PositionEntityVM> Positions
            {
                get
                {
                    return positions;
                }

                set
                {
                    positions = value;
                    tour.Positions.Clear();
                    foreach (PositionEntityVM position in positions)
                    {
                        tour.Positions.Add(position.TourPosition);
                    }
                    RaisePropertyChanged();
                }
            }

            public ObservableCollection<MemberEntityVM> Members
            {
                get
                {
                    return members;
                }

                set
                {
                    members = value;
                    tour.Members.Clear();
                    foreach (MemberEntityVM member in members)
                    {
                        tour.Members.Add(member.Member);
                    }
                    RaisePropertyChanged();
                }
            }

            public DummyTour Tour
            {
                get
                {
                    return tour;
                }

                set
                {
                    tour = value;
                }
            }
        }
}
