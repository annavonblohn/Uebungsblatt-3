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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace WPF_Test_AvB
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {   
        //Liste erstellen für Anzeige in Listbox
        List<Personen> Personenliste = new List<Personen>();

        public MainWindow(DateTime Erstellungsdatum, string Titel, string Pronomen, string Gender, string Vorname, string Nachname, 
            string Straße, string Hausnummer, string Plz, string Ort, string Email, DateTime Birthday, string ID, 
            string Bezeichnung, string FachbereichSemester)
        {
            InitializeComponent();
            //Verbindung von Personenliste zu Listbox
            ListBx_Datasets.ItemsSource(Personenliste);
            

        }

        
        //Konstruktor für Hinzufügen neues Datensatzes

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            //von zu öffnendem Fenster wird neue Instanz erzeugt
            Window1 newWindow = new Window1();

            
            //Fenster wird mit Hilfe von .ShowDialog() geöffnet 
            newWindow.ShowDialog();
           

            //Nach Eingabe in Eingabemaske
            if (newWindow.DialogResult.HasValue && newWindow.DialogResult.Value)
            {
                //Anzeige in ListBox
               //ListBx_Datasets.Items.Add(newDatasetString); alter Weg
            }


            //Default-Einträge zum Überorüfen
            DateTime ichGeburtstag = new DateTime(1995, 12, 25);
            Employees ich = new Employees((new DateTime(2021,06,10)), "Dr.", "sie", "cis weiblich", "Anna", "von Blohn", "Katzbachstr", "3", "10965", "berlin", ichGeburtstag, "anna.vb.1995@gmail.com", "12345", "SHK", "FB2");
            Students du = new Students((new DateTime(2021, 05, 05)), "", "er", "cis männlich", "schmidt", "Karl", "Hohlstr", "25", "66909", "Herschweiler-Pettersheim", ichGeburtstag, "karl.knapp....@de", "441766", "informatik", "5");
            

            //Hinzufügen zu Liste
            Personenliste.Add(ich);
            Personenliste.Add(du);

            //Filter nach "nur Studis" oder "nur Mitarbeitende" -> in ListBox werden nur Datensätze für Mitarbeitende zugefügt
            if (ChckBx_Studis_only.IsChecked == true)
            {
                Personenliste.Add(newDatasetEmployee);
            }

            //Filter nach "nur Mitarbeitende" oder "nur Studis"  -> in ListBox werden nur Datensätze für Studis zugefügt
            else if (ChckBx_Studis_only.IsChecked == true)
            {
                Personenliste.Add(newDatasetStudi);

            }

            else
            {
                Personenliste.Add(newDatasetStudi);
                Personenliste.Add(newDatasetEmployee);
            }


            //ListBox darüber in Kenntnis setzen wenn was hinzugefügt wird und aktualisieren
            ListBx_Datasets.Items.Refresh();


        }

        //bei Tooltip wird folgendes ausgef+hrt
        private void ListBx_Datasets_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {   
            //ausgewähltes Element (Element über dem der Mauszeiger ist) aus Listbox in Klasse Personen "casten" (konvertieren)
            Personen angecklicktesDataset = (Personen)ListBx_Datasets.SelectedItem;
            //für ausgewähltes Dataset die Methode SteckbriefAnzeigen aufrufen um Infos in Textblock anzuzeigen
            TxtBlck_Steckbrief.Text = angecklicktesDataset.SteckbriefAnzeigen();

        }

        //Sortierung nach Erstellungsdatum
        private void Btn_zuletzt_Click(object sender, RoutedEventArgs e)
        {
            
            Personenliste.Sort();
            
        }

        //Sortierung nach alphabetischer Reihenfolge der Nachnamen
        private void Btn_alphabetisch_Click(object sender, RoutedEventArgs e)
        {
            Personenliste.Sort();
        }



        //Datensätze exportieren (ausgewählte Informationen) an Ordner auf meinem Desktop
        private void Btn_Export_Click(object sender, RoutedEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("C:\\Users\\annav\\OneDrive\\Desktop\\Repository_Programmierung 2\\Übungsblatt 3_Anna vB\\Datasets.csv"))
            {   
                foreach(Personen einePerson in Personenliste)
                {   
                    sw.WriteLine("Vorname: " + einePerson.FirstName + ",");
                    sw.WriteLine("Nachname: " + einePerson.LastName +",");
                    sw.WriteLine("Geburtstag: " + einePerson.Birthday);
                    
                }
                sw.WriteLine("");
            }
        }

        //Es wird ein Datensatz ausgewählt der gelöscht oder editiert werden soll 
        private void ListBx_Datasets_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {   
            //Übergabe an Konstruktor fürs Hinzufügen
            Button_Click(sender, e);
            
            //Listbox refreshen um nun korrigierte Azeige zu sehen
            ListBx_Datasets.Items.Refresh();
        }

        //private void DeleteEntry()
        //{
        //    myList.Remove(myListBox.SelectetItem);
        //    myListBox.SelectedItem.Clear();
        //}
    }
}
