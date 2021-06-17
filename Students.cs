using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Test_AvB
{
    class Students : Personen
    {
        private string _Matrikelnummer;
        private string _Studiengang;
        private string _Fachsemester;

        //Properties anlegen (für Data Binding im Fenster Ansicht.xaml)
        public string Matrikelnummer { get { return _Matrikelnummer; } set { _Matrikelnummer = value; } }
        public string Studiengang { get { return _Studiengang; } set { _Studiengang = value; } }
        public string Fachsemester { get { return _Fachsemester; } set { _Fachsemester = value; } }

        //Konstruktor für neue Studis
        public Students(DateTime _erstellungsdatum, string _titel, string _pronoun, string _gender, string _firstname, string _lastname,
                        string _streetname, string _housenumber, string _plz, string _city,
                       DateTime _birthday, string _emailadress,
                       string _matrikelnummer, string _studiengang, string _fachsemester) : base(_erstellungsdatum, _titel, _pronoun, _gender, _firstname, _lastname, _streetname, _housenumber, _plz, _city, _birthday, _emailadress)
        {
            Matrikelnummer = _matrikelnummer;
            Studiengang = _studiengang;
            Fachsemester = _fachsemester;
        }

        //Methode der Oberklasse Personen aufrufen und Matrikelnummer hinzufügen für Anzeige in TextBlock im Ansicht-Fenster
        public override string SteckbriefAnzeigen()
        {
            return base.SteckbriefAnzeigen() + ", Matrikelnummer: " + Matrikelnummer;
        }


    }
}
