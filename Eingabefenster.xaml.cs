using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF_Test_AvB
{
    /// <summary>
    /// Interaktionslogik für Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        //public void HandingOverData()
        //{
        //    MainWindow newAnzeige = new MainWindow(Titel, TxtBx_Pronoun.Text, TxtBx_Gender.Text
        //        TxtBx_FirstName.Text, TxtBx_LastName.Text, TxtBx_StreetName.Text, )
        //}
        //public bool AddDataset = true;
        public Window1()
        {
            this.InitializeComponent();
          
        }

         public void Btn_Save_Click(object sender, RoutedEventArgs e)
        {

            var Erstellungsdatum = DateTime.Now;

            string Titel = TxtBx_Titel.Text;
            string Pronomen = TxtBx_Pronoun.Text;
            string Gender = TxtBx_Gender.Text;
            string Vorname = TxtBx_FirstName.Text;
            string Nachname = TxtBx_LastName.Text;
            string Straße = TxtBx_StreetName.Text;
            string Hausnummer = TxtBx_HouseNumber.Text;
            string Plz = TxtBx_plz.Text;
            string Ort = TxtBx_city.Text;
            DateTime Geburtstag = DatePicker_Birthday.DisplayDate;
            string Email = TxtBx_emailadress.Text;
            
            //Deklaration newDataset
            Personen newDatasetStudi;
            Personen newDatasetEmployee;

            //Konstruktoren
            //If-Statement für RadioButton Studi oder Employee
            if (RadioBtn_Employee.IsChecked == true)
            {
                //Variablen die nur für Employees sind
                string Personalnummer = TxtBx_Personalnummer.Text;
                string Jobbezeichnung = TxtBx_Jobbezeichnung.Text;
                string Fachbereich = TxtBx_Fachbereich.Text;

                newDatasetEmployee = new Employees(Erstellungsdatum, Titel, Pronomen, Gender, Vorname, Nachname, Straße, Hausnummer, Plz, Ort,
                Geburtstag, Email, Personalnummer, Jobbezeichnung, Fachbereich);
               
                // Optional (deshalb auskommentiert): Dataset zusätzlich als string um im ANsicht-Fenster anzuzeigen
                // string newDatasetString = newDataset.Erstellungsdatum + ", " + newDataset.LastName + ", " + newDataset.FirstName + ", Personalnummer: " + Personalnummer;

            }

            else
            {
                //Variablen die nur für Studis sind
                string Matrikelnummer = TxtBx_Matrikelnummer.Text;
                string Studiengang = TxtBx_Studiengang.Text;
                string Fachsemester = TxtBx_Fachsemester.Text;

                newDatasetStudi = new Students(Erstellungsdatum, Titel, Pronomen, Gender, Vorname, Nachname, Straße, Hausnummer, Plz, Ort,
                    Geburtstag, Email, Matrikelnummer, Studiengang, Fachsemester);

                //Optional (deshalb auskommentiert): Dataset zusätzlich als string um im ANsicht-Fenster anzuzeigen
                // string newDatasetString = newDataset.Erstellungsdatum + ", " + newDataset.LastName + ", " + newDataset.FirstName + ", Matrikelnummer: " + Matrikelnummer;


            }
            


            //DialogResult auf True um im MainWindow die hinzugefügten Daten erhalten zu können
            this.DialogResult = true;
            //Fenster schließen
            this.Close();


            //TextBoxen wieder "leeren"

            TxtBx_Titel.Text = "";
            TxtBx_Pronoun.Text = "";
            TxtBx_Gender.Text = "";
            TxtBx_FirstName.Text="";
            TxtBx_LastName.Text = "";
            TxtBx_StreetName.Text = "";
            TxtBx_HouseNumber.Text = "";
            TxtBx_plz.Text = "";
            TxtBx_city.Text = "";
           ////DatePicker_Birthday.DisplayDate = "";
            TxtBx_emailadress.Text = "";

        }

        //Übergabe der Werte an das Hauptfenster "Ansicht"
        public void HandingOverData()
        {
            MainWindow newDatasetStudi = new MainWindow(DateTime.Now, TxtBx_Titel.Text, TxtBx_Pronoun.Text, TxtBx_Gender.Text, TxtBx_FirstName.Text, TxtBx_LastName.Text, 
                TxtBx_StreetName.Text, TxtBx_HouseNumber.Text, TxtBx_plz.Text, TxtBx_city.Text, TxtBx_emailadress.Text, 
                DatePicker_Birthday.DisplayDate, TxtBx_Matrikelnummer.Text, TxtBx_Studiengang.Text, TxtBx_Fachsemester.Text);

            MainWindow newDatasetEmployee = new MainWindow(DateTime.Now, TxtBx_Titel.Text, TxtBx_Pronoun.Text, TxtBx_Gender.Text, TxtBx_FirstName.Text, TxtBx_LastName.Text,
                TxtBx_StreetName.Text, TxtBx_HouseNumber.Text, TxtBx_plz.Text, TxtBx_city.Text, TxtBx_emailadress.Text,
                DatePicker_Birthday.DisplayDate, TxtBx_Personalnummer.Text, TxtBx_Jobbezeichnung.Text, TxtBx_Fachbereich.Text);


            //newAnzeige.ShowDialog();
        }

        //Wenn Radio-Button von je Studis oder EMployees checked werden die jeweiligen Felder enabled, andernfalls nicht
        public void RadioBtn_Student_Checked(object sender, RoutedEventArgs e)
        {   //für zugehörige Felder (Matrikelnr, STudiengang u Fachsemester) ist Eingabe möglich
            TxtBx_Matrikelnummer.IsEnabled = true;
            TxtBx_Studiengang.IsEnabled = true;
            TxtBx_Fachsemester.IsEnabled = true;
            
            //für nicht zugehörige Felder (Personalnr, Jobbezeichnung, FB) keine Eingabe möglich 
            //-> ausgegraut + eventuelle vorherige EIngabe durch leere Zeichenkette ( "" ) ersetzt
            TxtBx_Personalnummer.IsEnabled = false;
            TxtBx_Personalnummer.Text = "";
            TxtBx_Jobbezeichnung.IsEnabled = false;
            TxtBx_Jobbezeichnung.Text = "";
            TxtBx_Fachbereich.IsEnabled = false;
            TxtBx_Fachbereich.Text = "";
        }

        //das selbe in grün
         public void RadioBtn_Employee_Checked(object sender, RoutedEventArgs e)
        {
            TxtBx_Personalnummer.IsEnabled = true;
            TxtBx_Jobbezeichnung.IsEnabled = true;
            TxtBx_Fachbereich.IsEnabled = true;

            TxtBx_Matrikelnummer.IsEnabled = false;
            TxtBx_Matrikelnummer.Text = "";
            TxtBx_Studiengang.IsEnabled = false;
            TxtBx_Studiengang.Text = "";
            TxtBx_Fachsemester.IsEnabled = false;
            TxtBx_Fachsemester.Text = "";
        }
    }
}
