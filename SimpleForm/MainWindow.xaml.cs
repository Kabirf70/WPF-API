using Newtonsoft.Json.Linq;
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
using System.Collections.ObjectModel;

namespace SimpleForm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Post> posts;

        public MainWindow()
        {
            posts = new ObservableCollection<Post>();
            InitializeComponent();
        }

        private void ClickUrl_Click(object sender, RoutedEventArgs e)
        {
            ClientSite clientSite = new ClientSite();
            clientSite.Url = UrlText.Text;
            string strResponse = string.Empty;
            strResponse = clientSite.makeRequest();
            JArray response = JArray.Parse(strResponse);
            List<Post> postList = Post.FromJsonArray(response);
            foreach(Post p in postList)
            {
                posts.Add(p);
            }

            listview2.ItemsSource = posts;
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string Title = InTitle.Text;
            string Body = InBody.Text;

            //InTitle.Text = Title;
            //InBody.Text = Body;

            Post newPost = new Post(Title, Body);
            posts.Add(newPost);
            

        }
    }
}
