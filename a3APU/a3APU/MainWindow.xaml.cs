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
using Microsoft.Win32;

namespace a3APU
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// This program is written for the course "Advanced .NET" by Per Johansson 8307160450
    /// </summary>
    public partial class MainWindow : Window
    {
        AnimalHandler animalController;

        public MainWindow()
        {
            InitializeComponent();
            Init();
        }

        /// <summary>
        /// Init GUI at start
        /// </summary>
        private void Init()
        {
            animalController = new AnimalHandler();
            lboxCategory.ItemsSource = animalController.getListCategories();
            lboxCategory.SelectedIndex = 0;
            lboxSpecies.ItemsSource = animalController.getListSpecies(lboxCategory.SelectedIndex);
            lboxSpecies.SelectedIndex = 0;
            lboxGender.ItemsSource = animalController.getListGender();
            lboxGender.SelectedIndex = 0;
        }

        /// <summary>
        /// Updates the interface when user interacts with program
        /// </summary>
        private void UpdateGUI()
        {
            listViewAnimals.Items.Clear();
            foreach (var ani in animalController.getAnimalsList())
                listViewAnimals.Items.Add(ani);
        }


        /// <summary>
        /// Fires when user submits information to the specified class and
        /// stores it in a list.
        /// This method also checks for erronous user input.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            {
                try
                {
                    if (int.Parse(tbAge.Text) >= 0)
                    {
                        if (listViewAnimals.SelectedIndex >= 0)
                        {
                            animalController.createAnimalatIndex(listViewAnimals.SelectedIndex, lboxSpecies.SelectedIndex,
                                tbName.Text, int.Parse(tbAge.Text), lboxCategory.SelectedIndex, lboxGender.SelectedIndex);
                            listViewAnimals.UnselectAll();
                            UpdateGUI();
                        }
                        else
                        {
                            animalController.createAnimal(lboxSpecies.SelectedIndex, tbName.Text, int.Parse(tbAge.Text), 
                                lboxCategory.SelectedIndex, lboxGender.SelectedIndex);

                            UpdateGUI();
                            tbAge.Text = "";
                            tbName.Text = "";
                        }
                    }
                    else
                        lblOutputInfo.Content = "Really? Age is less than zero?";
                }
                catch (Exception ex)
                {
                    string message = "Woops something went wrong here!\n";
                    message += ex.Message;
                    MessageBox.Show(message, "Woops, a bump in the road", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }            
        }

        /// <summary>
        /// Fires when the user changes category.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lboxCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lboxSpecies.ItemsSource = animalController.getListSpecies(lboxCategory.SelectedIndex);
            lboxSpecies.SelectedIndex = 0;
            try
            {
                lblOutputInfo.Content = "";
                lbGetDataAnimSpec.Content = "";
                string picString = lboxCategory.SelectedValue.ToString();
                pictureBox.Source = animalController.fetchCatPic(picString);
            }
            catch (PictrureLibrary.CategoryNotFoundExcetion ex)
            {
                pictureBox.Source = null;
                lblOutputInfo.Content = "Pictures error! " + ex.Message;
            }
        }

        /// <summary>
        /// Fetches the specific animals extra information string-
        /// The if clause makes sure this function only is called
        /// when something in the listbox is chosen. It sets
        /// the GUI controls to correspond to the selected 
        /// animal values.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listViewAnimals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listViewAnimals.SelectedIndex >= 0)
            {
                lbGetDataAnimSpec.Content = animalController.getSpecificAnimal(listViewAnimals.SelectedIndex).GetAnimalSpecificData();
                lblOutputInfo.Content = animalController.getSpecificAnimal(listViewAnimals.SelectedIndex).GetAnimalSpecificData();
                tbAge.Text = animalController.getSpecificAnimal(listViewAnimals.SelectedIndex).Age.ToString();
                tbName.Text = animalController.getSpecificAnimal(listViewAnimals.SelectedIndex).name;
                lboxCategory.SelectedIndex = (int)animalController.getSpecificAnimal(listViewAnimals.SelectedIndex).Category;
                lboxGender.SelectedIndex = (int)animalController.getSpecificAnimal(listViewAnimals.SelectedIndex).Gender;
                lboxSpecies.SelectedValue = animalController.getSpecificAnimal(listViewAnimals.SelectedIndex).Species;
            }  
        }


        /// <summary>
        /// Button interaction that deselects chosen value in listview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeselectList_Click(object sender, RoutedEventArgs e)
        {
            listViewAnimals.UnselectAll();
            UpdateGUI();
        }
                

        #region Menu operations


        /// <summary>
        /// NEW
        /// Start a new motel. Asks user if sure and acts on user input.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (animalController.getNumberofAnimals() > 0) 
            {
                MessageBoxResult boxtalk =
                    MessageBox.Show("Starting a new motel will discard current data.\n Do you want to proceed?", "Are you sure?",
                    MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                if (boxtalk.ToString()=="OK")
                {
                    lblOutputInfo.Content = "New motel initialized!";
                    Init();
                    UpdateGUI();
                }
                else
                {
                    lblOutputInfo.Content = "User aborted new motel.";
                }
            }
        }

        /// <summary>
        /// OPEN
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openf = new OpenFileDialog();
                openf.FileName = "Animal_Motel";
                openf.DefaultExt = ".dat";//Default file extension
                openf.Filter = "Binary data (.dat)|*.dat";//Filter by extension.

            openf.ShowDialog();
            string path = openf.FileName;
            if(path != null)
                animalController.OpenData(path);
            UpdateGUI();
        }

        /// <summary>
        /// SAVE
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            if (animalController.SaveData())
                lblOutputInfo.Content = "Data saved.";
            else
                MenuItem_Click_3(null, null);
        }

        /// <summary>
        /// SAVE AS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            if (animalController.getNumberofAnimals() > 0)
            {
                dialog.FileName = "Animal_Motel";//Default filename
                dialog.DefaultExt = ".dat";//Default extension
                dialog.Filter = "Binary data (.dat)|*.dat";//Filter by extension

                dialog.ShowDialog();
                string file = dialog.FileName;
                if (animalController.SaveDataAs(file))
                    lblOutputInfo.Content = "Data saved.";
                else
                    lblOutputInfo.Content = "Data not saved.";
            }
            else
            {
                lblOutputInfo.Content = "You must atleast have one animal in the motel to be able to save!";
            }
        }


        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            if (animalController.getNumberofAnimals() > 0)
            {
                MessageBoxResult rs = MessageBox.Show("Exit?\nAll unsaved data will be lost.", "Exit the application", 
                    MessageBoxButton.OKCancel, MessageBoxImage.Question);

                if (rs.ToString() == "OK")
                    Close();
            }
            else
                Close();
        }
        #endregion

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (animalController.getNumberofAnimals() > 0)
            {
                MessageBoxResult shutdown = MessageBox.Show("Are you sure,\nall unsaved progress will be lost?", "Shutdown?",
                    MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (shutdown.ToString() == "OK")
                    e.Cancel = false;
                else
                    e.Cancel = true;
            }
        }
    }
}
