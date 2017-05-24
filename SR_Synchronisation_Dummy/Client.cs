using Shared.DummyEntities;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR_Synchronisation_Dummy
{
    public class Client
    {
        Guid testTourGuideId = Guid.NewGuid();
        DummyTourGuide testGuide;
        List<DummyTour> testTourList;
        List<DummyTourGuide> testTourGuideList;



        public bool Login(string userName, string passwort)
        {
            if (userName == testGuide.User.UserName && passwort == testGuide.User.Password)
                return true;
            return false;
        }

        public DummyTourGuide GetTourGuide(string userName, string passwort)
        {         
            return testGuide;
        }

        public List<DummyTourGuide> GetTourGuideList()
        {
            return testTourGuideList;
        }

        public List<DummyTour> GetTourListByGuideId(Guid id)
        {
            return testTourList;
        }

        public void SetTourList(List<DummyTour> tourList)
        {
            this.testTourList = tourList;
        }

        public Client()
        {
            DummyUser user1 = new DummyUser() {
                UserID = testTourGuideId,
                SureName = "Mustermann",
                PreName = "Max",
                Birthdate = new DateTime(1991,6,25),
                Email = "email1@gmx.at",
                Address = "Kantgasse 25",
                Area = "Gerasdorf",
                Password = "test",
                UserName = "test",
            };
            DummyUser user2 = new DummyUser()
            {
                UserID = Guid.NewGuid(),
                SureName = "MusterFrau",
                PreName = "Sissi",
                Birthdate = new DateTime(1988, 5, 12),
                Email = "email2@gmx.at",
                Address = "Scheunenstraße 12",
                Area = "Föhrnhain",
                Password = "test2",
                UserName = "test2",
            };
            DummyUser user3 = new DummyUser()
            {
                UserID = Guid.NewGuid(),
                SureName = "VanIrgendwo",
                PreName = "Anrea",
                Birthdate = new DateTime(1977, 8, 13),
                Email = "email3@gmx.at",
                Address = "Mittelgasse 1",
                Area = "Leopoldau",
                Password = "test3",
                UserName = "test3",
            };
            DummyUser user4 = new DummyUser()
            {
                UserID = Guid.NewGuid(),
                SureName = "Müller",
                PreName = "Michi",
                Birthdate = new DateTime(1993, 7, 14),
                Email = "email4@gmx.at",
                Address = "Müllweg 33",
                Area = "Seyring",
                Password = "test4",
                UserName = "test4",
            };
            DummyPosition position1 = new DummyPosition()
            {
                PositionID = Guid.NewGuid(),
                Title = "Stephansdome",
                Description = "Der Stephansdom (eigentlich Domkirche St. Stephan zu Wien) am Wiener Stephansplatz (Bezirk Innere Stadt) ist seit 1365 Domkirche (Sitz eines Domkapitels), seit 1469/1479 Kathedrale (Bischofssitz) und seit 1723 Metropolitankirche des Erzbischofs von Wien.",
                FromDateTime = new DateTime(2017, 05, 29, 12, 0, 0),
                ToDateTime = new DateTime(2017, 05, 29, 13, 30, 0),
                GPSPosition = new GeoCoordinate(48.257518, 13.033902)
            };
            DummyPosition position2 = new DummyPosition()
            {
                PositionID = Guid.NewGuid(),
                Title = "Schloss Schönbrunn",
                Description = "Das Schloss Schönbrunn liegt im 13. Wiener Gemeindebezirk Hietzing. Sein Name geht auf einen Kaiser Matthias zugeschriebenen Ausspruch zurück, der hier im Jahr 1619 auf der Jagd einen artesischen Brunnen entdeckt und ausgerufen haben soll: Welch schöner Brunn.",
                FromDateTime = new DateTime(2017, 05, 29, 13, 30, 0),
                ToDateTime = new DateTime(2017, 05, 29, 18, 0, 0),
                GPSPosition = new GeoCoordinate(48.184865, 16.312240)
            };
            DummyPosition position3 = new DummyPosition()
            {
                PositionID = Guid.NewGuid(),
                Title = "Eiffelturm",
                Description = "Der Eiffelturm  ist ein 324 Meter hoher Eisenfachwerkturm in Paris. Er steht im 7. Arrondissement am nordwestlichen Ende des Champ de Mars (Marsfeld), nahe dem Ufer der Seine. Das von 1887 bis 1889 errichtete Bauwerk wurde als monumentales Eingangsportal und Aussichtsturm für die Weltausstellung zur Erinnerung an den 100. Jahrestag der Französischen Revolution errichtet.",
                FromDateTime = new DateTime(2017, 05, 20, 14, 0, 0),
                ToDateTime = new DateTime(2017, 05, 20, 15, 30, 0),
                GPSPosition = new GeoCoordinate(48.85837, 2.294481)
            };
            DummyPosition position4 = new DummyPosition()
            {
                PositionID = Guid.NewGuid(),
                Title = "Louvre",
                Description = "Der Louvre ist ein Kunstmuseum in Paris. Er befindet sich in der ehemaligen Residenz der französischen Könige, dem Palais du Louvre. Das Museum ist mit etwa zehn Millionen Besuchern im Jahr 2012 das meistbesuchte und, gemessen an der Ausstellungsfläche, das drittgrößte Museum der Welt.",
                FromDateTime = new DateTime(2017, 05, 20, 15, 30, 0),
                ToDateTime = new DateTime(2017, 05, 20, 17, 30, 0),
                GPSPosition = new GeoCoordinate(48.860611, 2.337644)
            };
            testGuide = new DummyTourGuide()
            {
                TourGuideID = testTourGuideId,
                User = user1
            };
            DummyTourGuide testGuide1 = new DummyTourGuide()
            {
                TourGuideID = Guid.NewGuid(),
                User = user3
            };
            DummyMember member1 = new DummyMember()
            {
                MemberID = Guid.NewGuid(),
                AttendTour = false,
                User = user2
            };
            DummyMember member2 = new DummyMember()
            {
                MemberID = Guid.NewGuid(),
                AttendTour = false,
                User = user3
            };
            DummyMember member3 = new DummyMember()
            {
                MemberID = Guid.NewGuid(),
                AttendTour = false,
                User = user2
            };
            DummyMember member4 = new DummyMember()
            {
                MemberID = Guid.NewGuid(),
                AttendTour = false,
                User = user4
            };
            DummyTour tour1 = new DummyTour()
            {
                TourID = Guid.NewGuid(),
                Title = "Wien Tour",
                Date = new DateTime(2017, 05, 29, 12, 0, 0),
                State = "offen",
                Positions = new List<DummyPosition>()
                {
                    position1,
                    position2
                },
                Members = new List<DummyMember>()
                {
                    member1,
                    member2
                },
                TourGuide = testGuide
            };
            DummyTour tour2 = new DummyTour()
            {
                TourID = Guid.NewGuid(),
                Title = "Paris Tour",
                Date = new DateTime(2017, 05, 20, 14, 0, 0),
                State = "offen",
                Positions = new List<DummyPosition>()
                {
                    position3,
                    position4
                },
                Members = new List<DummyMember>()
                {
                    member3,
                    member4
                },
                TourGuide = testGuide
            };
            testTourList = new List<DummyTour>() {
                tour1,
                tour2
            };
            testTourGuideList = new List<DummyTourGuide>() {
                testGuide,
                testGuide1
            };
        }
    }
}
