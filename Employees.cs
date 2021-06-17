using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Test_AvB
{   
    //Vererbung von Eigenschaften der Oberklasse Personen auf Unterklasse Employees
    class Employees : Personen

    {   //zusätzliche Attribute die nur für Mitarbeitende gelten
        private string _Personalnummer;
        private string _Jobbezeichnung;
        private string _Fachbereich;

        //Properties anlegen (für Data Binding im Fenster Ansicht.xaml)
        public string Personalnummer { get { return _Personalnummer; } set { _Personalnummer = value; } }
        public string Jobbezeichnung { get { return _Jobbezeichnung; } set { _Jobbezeichnung = value; } }
        public string Fachbereich { get { return _Fachbereich; } set { _Fachbereich = value; } }

        
        //Konstruktor für neue Mitarbeitenden
        public Employees(DateTime _erstellungsdatum, string _titel, string _pronoun, string _gender, string _firstname, string _lastname,
                        string _streetname, string _housenumber, string _plz, string _city,
                       DateTime _birthday, string _emailadress,
                       string _personalnummer, string _jobbzeichnung, string _fachbereich) : base(_erstellungsdatum, _titel, _pronoun, _gender, _firstname, _lastname, _streetname, _housenumber, _plz, _city, _birthday, _emailadress)
        {
            Personalnummer = _personalnummer;
            Jobbezeichnung = _jobbzeichnung;
            Fachbereich = _fachbereich;
        }

        //Methode der Oberklasse Personen aufrufen und Personalnummer hinzufügen für Anzeige in TextBlock im Ansicht-Fenster
        public override string SteckbriefAnzeigen()
        {
            return base.SteckbriefAnzeigen() + ", Personalnummer: " + Personalnummer;
        }

    }
}
