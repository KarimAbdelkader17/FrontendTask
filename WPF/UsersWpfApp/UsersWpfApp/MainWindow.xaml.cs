using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;
using UsersWpfApp.Helpers;
using UsersWpfApp.WPF.ViewModels;

namespace UsersWpfApp
{
    public partial class MainWindow : Window
    {
        private IDisposable _server = null;
        static DispatcherTimer dispatcherTimer = new DispatcherTimer();
        static ObservableCollection<UserInfoViewModel> allUsersInfo = new ObservableCollection<UserInfoViewModel>();
        static int currentPage = 1;
        static int Total_pages = 1;
      
        public MainWindow()
        {
            InitializeComponent();
        }

        private  void startButton_Click(object sender, RoutedEventArgs e)
        {
                string baseAddress = "http://localhost:5000/";
                _server = WebApp.Start<Startup>(url: baseAddress);
                SetTimer();
        }

        private void stopButton_Click(object sender, RoutedEventArgs e)
        {
          if(_server != null)
                _server.Dispose();  
        }


        public List<UserInfoViewModel> GetData()
        {
            return Convert(UsersDataContext.GetInstance().UsersInfo);
        }

        private List<UserInfoViewModel> Convert(List<UserInfo> usersInfo)
        {
            return usersInfo.Select(a => new UserInfoViewModel
            {

                page = a.page,
                per_page = a.per_page,
                total = a.total,
                total_pages = a.total_pages,

                data = a.data.Select(d => new UserViewModel
                {
                    email = d.email,
                    first_name = d.first_name,
                    last_name = d.last_name,
                    avatar = d.avatar

                }).ToList()


            }).ToList();
        }


        protected void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            RebindDataAsync();
        }
        private void SetTimer()
        {
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
            dispatcherTimer.Start();
        }

        private void RebindDataAsync()
        {

            var data = GetData();

            if (data.Count != 0)
            {
                data = data.OrderBy(d => d.page).ToList();
                for (int i = 0; i < data.Count; i++)
                {
                    var userInfo = allUsersInfo.FirstOrDefault(u => u.page == data[i].page);
                    if (userInfo == null)
                        allUsersInfo.Add(data[i]);
                }


                Total_pages = allUsersInfo[currentPage - 1].total_pages;
                numPagesTextBox.Text = Total_pages.ToString();
                usersDataGrid.ItemsSource = allUsersInfo[currentPage - 1].data;
            }

        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentPage < allUsersInfo.Count)
            {
                usersDataGrid.ItemsSource = allUsersInfo[currentPage].data;
                currentPage = currentPage + 1;
            }

        }

        private void previousButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentPage - 1 <= allUsersInfo.Count && currentPage != 1)
            {
                usersDataGrid.ItemsSource = allUsersInfo[currentPage - 2].data;
                currentPage = currentPage - 1;
            }
        }

    }
}
