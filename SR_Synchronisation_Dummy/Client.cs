using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR_Synchronisation_Dummy
{
    public class Client
    {
        Guid testTourGuideId = Guid.NewGuid();
        User testUser;
        TourGuide testGuide;
        List<Tour> testTourList;

        public Client()
        {
            testUser = new User();
            testGuide = new TourGuide();
            testTourList = new List<Tour>();

            /*testUser = new User()
            {
                UserID = testTourGuideId,
                UserName = "test",
                Vorname = "Roman",
                Nachname = "Zachner",
                Addresse = "Kantgasse 25",
                Email = "romanzachner@outlook.com",
                Geburtsdatum = new DateTime(1991, 6, 25),
                Ort = "Gerasdorf",
                Passwort = "test"
            };
            testGuide = new TourGuide()
            {
                TourGuideID = testTourGuideId,
                TourGuideSeitDatum = new DateTime(),
                User = testUser
            };
            testTourList = new List<Tour>() {
                new Tour() {
                    TourID = Guid.NewGuid(),
                    Datum = new DateTime(2017,5,25),
                    Dauer = 200,
                    Bezeichnung = "Paris",
                    Kunden = new List<KundeInTour>() {
                        new KundeInTour() {
                            Teilgenommen = false,
                            Kunde = new Kunde()
                            {
                                KundeID = Guid.NewGuid(),
                                User = new User(){
                                    UserID = Guid.NewGuid(),
                                    Vorname = "Anton",
                                    Nachname = "Mustermann",
                                }
                            }
                        },
                        new KundeInTour() {
                            Teilgenommen = false,
                            Kunde = new Kunde()
                            {
                                KundeID = Guid.NewGuid(),
                                User = new User(){
                                    UserID = Guid.NewGuid(),
                                    Vorname = "Fabian",
                                    Nachname = "Mustermann",
                                }
                            }
                        }
                    },
                    Status = new Status() {
                        Bezeichnung = "offen"
                    },
                    Teilnehmeranzahl = 2,
                    TourGuide = testGuide,
                    TourPositionen = new List<TourPosition>()
                    {
                        new TourPosition()
                        {
                            Bezeichnung = "Eifelturm",
                        }
                    }
                }
            };*/
        }

        public bool Login(string userName, string passwort)
        {
            //if (userName == testGuide.User.UserName && passwort == testGuide.User.Passwort)
            if (userName == "test" && passwort == "test")
                return true;
            return false;
        }

        public TourGuide GetTourGuid(string userName, string passwort)
        {         
            return testGuide;
        }

        public List<Tour> GetTourListByGuideId(Guid id)
        {
            return testTourList;
        }

    }
}
