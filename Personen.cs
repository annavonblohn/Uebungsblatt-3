using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Test_AvB
{
    abstract class Personen : IComparable
    {
        private DateTime _Erstellungsdatum;

        private string _Titel;
        private string _Pronoun;
        private string _Gender;
        private string _FirstName;
        private string _LastName;

        private string _StreetName;
        private string _HouseNumber;
        private string _Plz;
        private string _City;

        private DateTime _Birthday;
        private string _EmailAdress;
       
        //private DateTime Erstellungsdatum;


        //Konstruktor für Klasse Person
        public Personen(DateTime _erstellungsdatum, string _titel, string _pronoun, string _gender, string _firstname, string _lastname,
                        string _streetname, string _housenumber, string _plz, string _city,
                        DateTime _birthday, string _emailadress)

        {
            Erstellungsdatum = _erstellungsdatum;
            Titel = _titel;
            Pronoun = _pronoun;
            Gender = _gender;
            FirstName = _firstname;
            LastName = _lastname;

            StreetName = _streetname;
            HouseNumber = _housenumber;
            Plz = _plz;
            City = _city;

            Birthday = _birthday;
            EmailAdress = _emailadress;

        }

        //Properties anlegen(für Data Binding im Fenster Ansicht.xaml)
        public DateTime Erstellungsdatum { get { return _Erstellungsdatum; } set { _Erstellungsdatum = value; } }
        public string Titel { get { return _Titel; } set { _Titel = value; } }
        public string Pronoun { get { return _Pronoun; } set { _Pronoun = value; } }

        public string Gender { get { return _Gender; } set { _Gender = value; } }

        public string FirstName { get { return _FirstName; } set { _FirstName = value; } }

        public string LastName { get { return _LastName; } set { _LastName = value; } }

        public string StreetName { get { return _StreetName; } set { _StreetName = value; } }

        public string HouseNumber { get { return _HouseNumber; } set { _HouseNumber = value; } }

        public string Plz { get { return _Plz; } set { _Plz = value; } }

        public string City { get { return _City; } set { _City = value; } }

        public DateTime Birthday {  get { return _Birthday; } set { _Birthday = value; } }

        public string EmailAdress { get { return _EmailAdress; } set { _EmailAdress = value; } }






        //Sortierung nach Erstellungsdatum(Konto mit frühestem Erstellungsdatum wird nach oben geschoben)
        public int CompareTo(object obj)
        {
            Personen vergleichsPerson = (Personen)obj;
            if (DateTime.Compare(this.Erstellungsdatum, vergleichsPerson.Erstellungsdatum) < 0)
            {
                //Erstes Datum ist früher als das zweite -> Index muss -1 sein um betrachtetes Object eins nach oben zu schieben
                return -1;
            }

            else if (DateTime.Compare(this.Erstellungsdatum, vergleichsPerson.Erstellungsdatum) > 0)
            {
                //Erstes Datum ist später als das zweite -> Index muss +1 sein um betrachtetes Object eins nach unten zu schieben
                return 1;

            }

            //Wenn Reihenfolge beibehalten werden soll
            return 0;
        }

        //Sortieren nach alphabet
        public int CompareToAlphabet(object obj)
        {
            Personen vergleichsPerson = (Personen)obj;
            if (this.LastName[0] < vergleichsPerson.LastName[0])
            {
                //Erster char von String Array VergleichsPerson ist alphabetisch nach this.LastName
                return -1;
            }

            else if (this.LastName[0] > vergleichsPerson.LastName[0])
            {
                ////Erster char von String Array VergleichsPerson ist alphabetisch nach this.LastName
                return 1;
            }

            //Wenn Reihenfolge beibehalten werden soll
            return 0;
        }




    //Funktion für Steckbrief bei MouseOver
    public virtual string SteckbriefAnzeigen()
        {
            return "Name: " + LastName + ", Vorname: " + FirstName + ", Pronomen: " + Pronoun + ", Gender:" + Gender + ", Erstellungsdatum: " + Erstellungsdatum + ", Email-Adresse: " + EmailAdress + ", Ort: " + City;
        }

    }

     
}
