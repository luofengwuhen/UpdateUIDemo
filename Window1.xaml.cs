using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

namespace UpdateUIDemo
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {


        Person pen = new Person();
        public DataTable dt = null;
        public Window1()
        {
            InitializeComponent();

            //初始化选择城市的下拉列表
            InitCityComboBox();
            IntiData();
            //写法1
            //pen.Age = 20;
            //Binding binding = new Binding();
            //binding.Source = pen;
            //binding.Path = new PropertyPath("Age");
            // BindingOperations.SetBinding(txtName, TextBox.TextProperty, binding);
            //BindingOperations.SetBinding(txbAge, TextBlock.TextProperty, binding);

            //与控件绑定
            //this.txtName.SetBinding(TextBox.TextProperty, new Binding("Value") { ElementName = "slider1" });

            txtAge.Text = "20";//pen.Age.ToString();
            
            //写法2
            this.txtAge.SetBinding(TextBox.TextProperty, new Binding("Age"){Source = pen =new Person() {Age = Convert.ToInt32(txtAge.Text) },Mode =BindingMode.OneWay});



            this.listView1.DataContext = dt;
            this.listView1.SetBinding(ListView.ItemsSourceProperty, new Binding());
        }
        private void btnAge_1_Click(object sender, RoutedEventArgs e)
        {
            pen.Age += 1;
        }


        private  class Person : INotifyPropertyChanged
        {
            //INotifyPropertyChanged向客户端发出某一属性值已更改的通知。
            public event PropertyChangedEventHandler PropertyChanged;
            public string name { get; set; }

            private int age;
            public int Age { get
                {
                    return age;
                }
                set {
                    age = value;
                    if (this.PropertyChanged != null)
                    {
                        this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Age"));
                        // 通知Binding是“Age”这个属性的值改变了
                    }
                }
            } 
        }

        // 准备数据
        private Dictionary<string, string[]> cityAndCommunityDictionary = new Dictionary<string, string[]>()
        {
            { "南宁", new string[] { "南宁A社区", "南宁B社区", } },
            { "柳州", new string[] { "柳州A社区", "柳州B社区", "柳州C社区", "柳州D社区" } },
            { "桂林", new string[] { "桂林A社区", "桂林B社区", "桂林C社区" } },
        };


        /// <summary>
        /// 初始化选择城市的下拉列表
        /// </summary>
        private void InitCityComboBox()
        {
            // 初始化城市列表
            ItemCollection coll = cityComboxBox.Items;
            foreach (KeyValuePair<string, string[]> kvp in cityAndCommunityDictionary)
            {
                ComboBoxItem boxItem = new ComboBoxItem() { Content = kvp.Key };
                coll.Add(boxItem);
            }

            // 给ComboBox注册一个选项改变的事件
            cityComboxBox.SelectionChanged += new SelectionChangedEventHandler(cityComboxBox_SelectionChanged);
        }

        private void cityComboxBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // 当前城市的社区
            ItemCollection coll = communityComboxBox.Items;
            // 先清空
            coll.Clear();
            // 再添加
            foreach (KeyValuePair<string, string[]> kvp in cityAndCommunityDictionary)
            {
                // kvp.Value = { "南宁A社区", "南宁B社区", }
                // 此时的 cityComboxBox.SelectedValue = System.Windows.Controls.ComboBoxItem: 南宁
                // 所以如果用这种方法获取选中的值，还需要切割字符串
                ComboBoxItem selectedCity = cityComboxBox.SelectedItem as ComboBoxItem;
                string cityName = selectedCity.Content.ToString();

                if (cityName.Equals(kvp.Key))
                {
                    foreach (var item in kvp.Value)
                    {
                        // item = "南宁A社区"
                        ComboBoxItem boxItem = new ComboBoxItem() { Content = item };
                        coll.Add(boxItem);
                    }
                }
            } 
        }

        private void IntiData()
        {
            dt = new DataTable("T_User");
            dt.Columns.Add("UserNo", typeof(string));
            dt.Columns.Add("UserName", typeof(string));
            dt.Columns.Add("UserRealName", typeof(string));
            dt.Columns.Add("UserEmail", typeof(string));
            dt.Columns.Add("UserAddress", typeof(string));

            for (int i = 0; i < 10; i++)
            {
                DataRow dr = dt.NewRow();
                dr["UserNo"] = "10000" + i.ToString();
                dr["UserName"] = "haiziguo";
                dr["UserRealName"] = "李占朋";
                dr["UserEmail"] = "lizhpeng@126.com";
                dt.Rows.Add(dr);
            }
        }

    }
}
