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
using TextClassification.Controller;
using TextClassification.Domain;

namespace TextClassificationWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartLearning_Click(object sender, RoutedEventArgs e)
        {
            //start time
            DateTimeOffset now = DateTimeOffset.UtcNow; 

            KnowledgeBuilder nb = new KnowledgeBuilder();

            // initiate the learning process
            nb.Train();

            // getting the (whole) knowledge found in ClassA and in ClassB
            Knowledge k = nb.GetKnowledge();


            // get a part of the knowledge - here just for debugging
            BagOfWords bof = k.GetBagOfWords();

            //end time
            DateTimeOffset end = DateTimeOffset.UtcNow;

            long unixTimeMilliseconds = end.ToUnixTimeMilliseconds()-now.ToUnixTimeMilliseconds(); 
           
            TrainingTime.Text = unixTimeMilliseconds + " ms"; 



            List<string> entries = bof.GetEntriesInDictionary();

            //List object
            List<ListItems> items = new List<ListItems>();
            
            //looping through all entries and adding them to the list obj
            for (int i = 0; i < entries.Count; i++) 
            {
                items.Add(new ListItems() { Title = entries[i] });
            }

            //Adding the list to the xaml
            ListOfItems.ItemsSource = items;
            
            

        }
        public class ListItems
        {
            public string Title { get; set; }
            
        }
    }
}
