using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml;
using InsTsinghuaPlus.View;
using InsTsinghuaPlus.View.NewsPage;
using InsTsinghuaPlus.View.CoursePage;
using InsTsinghuaPlus.View.Mails;
using InsTsinghuaPlus.View.SecurityLevel;
using Windows.UI.Xaml.Controls;
using System.Collections.ObjectModel;

namespace InsTsinghuaPlus.ViewModel.MainPageViewModel
{
    public class MainPageViewModel:BaseViewModel
    {
        private List<NavMenuItem> _navMenuPrimaryItem = new List<NavMenuItem>(
            new[]
            {
                new NavMenuItem()
                {
                    FontFamily = new FontFamily("Segoe MDL2 Assets"),
                    Icon = "\xE80F",
                    Label = "新闻",
                    Selected = Visibility.Visible,
                    DestPage = "InsTsinghuaPlus.View.NewsPage.News"
                },
                 new NavMenuItem()
                {
                    FontFamily = new FontFamily("Segoe MDL2 Assets"),
                    Icon = "\xE7BE",
                    Label = "学堂",
                    Selected = Visibility.Collapsed,
                    DestPage = "InsTsinghuaPlus.View.CoursePage.WebLearn"
                },
                new NavMenuItem()
                {
                    FontFamily = new FontFamily("Segoe MDL2 Assets"),
                    Icon = "\xE119",
                    Label = "邮箱",
                    Selected = Visibility.Collapsed,
                    DestPage = "InsTsinghuaPlus.View.Mails.Email"
                },

            });

        private List<NavMenuItem> _navMenuSecondaryItem = new List<NavMenuItem>(
            new[]
            {
                new NavMenuItem()
                {
                    FontFamily = new FontFamily("Segoe MDL2 Assets"),
                    Icon = "\xE13D",
                    Label = "登录",
                    Selected = Visibility.Collapsed,
                    DestPage = "InsTsinghuaPlus.View.SecurityLevel.LoginPage"
                }
            });

        private bool _open;

        public List<NavMenuItem> NavMenuPrimaryItem
        {
            get
            {
                return _navMenuPrimaryItem;
            }
            set
            {
                _navMenuPrimaryItem = value;
                //foreach(NavMenuItem np in _navMenuPrimaryItem)
                //{
                //    OnPropertyChanged("np");
                //}
                //OnPropertyChanged("navMenuPrimaryItem");
            }
        }

        public List<NavMenuItem> NavMenuSecondaryItem
        {
            get
            {
                return _navMenuSecondaryItem;
            }
            set
            {
                _navMenuSecondaryItem = value;
                //OnPropertyChanged("navMenuPrimaryItem");
            }
        }

        public bool Open
        {
            get
            {
                return _open;
            }
            set
            {
                _open = value;
                OnPropertyChanged("Open");
            }
        }

        public void MenuCommand(object sender, RoutedEventArgs e)
        {
            Open = true;
        }
        public String _titleText;
        public String TitleText
        {
            get
            {
                return _titleText;
            }
            set
            {
                _titleText = value;
                OnPropertyChanged("TitleText");
            }
        }
        public Page _framePage;
        public Page FramePage
        {
            get
            {
                return _framePage;
            }
            set
            {
                _framePage = value;
                OnPropertyChanged("FramePage");
            }
        }
        private NavMenuItem _selectedData;

        public void NavMenuListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            // 遍历，将选中Rectangle隐藏
            foreach (var np in _navMenuPrimaryItem)
            {
                np.Selected = Visibility.Collapsed;
            }
            foreach (var ns in _navMenuSecondaryItem)
            {
                ns.Selected = Visibility.Collapsed;
            }
            _selectedData = e.ClickedItem as NavMenuItem;
            // Rectangle显示并导航
            _selectedData.Selected = Visibility.Visible;
            TitleText = _selectedData.Label;
            if (_selectedData.DestPage != null)
            {
                FramePage = Activator.CreateInstance(Type.GetType(_selectedData.DestPage)) as Page;
            }

            //RootSplitView.IsPaneOpen = false;
            OnPropertyChanged("SelectedData");

        }

        public MainPageViewModel()
        {
            FramePage = Activator.CreateInstance(Type.GetType("InsTsinghuaPlus.View.NewsPage.News")) as Page;
            TitleText = "InsTsinghua";
            _selectedData = NavMenuPrimaryItem[0];
            Open = false;
        }
    }
}
