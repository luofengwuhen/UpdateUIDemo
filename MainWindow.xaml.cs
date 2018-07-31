using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading.Tasks;
using System.Threading;

namespace UpdateUIDemo
{ 
    //Dispatcher方法
    public partial class MainWindow : Window
    {


        readonly static object locked = new object();
        int j=1;

        public MainWindow()
        {
            InitializeComponent();
      
             
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //全局报错实例
            //string s = null;
            //s.Trim();
            //return;


            pb.Minimum = 0;
            pb.Maximum = 5;
            Console.WriteLine("第{0}次点击!",j++); 

          Task.Factory.StartNew(Work); //task任务池
             
            //Task.Run(() => new Action(Work));
        }


        private void Work()
        {
            Task task4 = Task.Run(() =>
            {
                lock(locked)
                { 
                    for (int i = 0; i <=5; i++)
                    {
                        Thread.Sleep(1000);
                        pb.Dispatcher.Invoke(() => pb.Value = i);
                    }
                }

            });

            //Task task = new Task((tb) => Begin(this.first), this.first);
            Task task = Task.Run(new Action(delegate
            {
                Thread.Sleep(2000); //延迟2秒
                Begin(this.first);
            }));
            //task.Start(); 
            task.Wait(1000);       // Wait for 1 second.

            Console.WriteLine("Task 1-1 completed: {0}, Status: {1}",
                 task.IsCompleted, task.Status);

            task.GetAwaiter().OnCompleted(() => {
                Console.WriteLine("Task 1-2 completed: {0}, Status: {1}",
                         task.IsCompleted, task.Status);
            });

            //Task task2 = new Task((tb) => Begin(this.second), this.second);

            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken ct = cts.Token;
            Task task2 = new Task(() => Begin3(this.second), ct);
            task2.Start();
            //task2.Wait(); //相当于同步,但不会阻塞主线程
            cts.Cancel();

            Console.WriteLine("Task 2-1 completed: {0}, Status: {1}",
                       task2.IsCompleted, task2.Status);

            //Task task3 = new Task((tb) => Begin(this.Three), this.Three);
            //Task task3 = new Task(() => Begin(this.Three));
            Task task3 = new Task(()=>Begin(this.Three));
              
           
            task3.Start();
            task3.Wait(); 
             
            Begin2(this.Fouth);//异步调用,不用task async/await
        }
        

        private void UpdateTb(TextBlock tb, string text)
        {
            tb.Text = text;
        }


        private async void Begin2(TextBlock tb)
        {
            string Num = "";
            await Task.Run(new Action(() => {

                Num = update(tb);
                tb.Dispatcher.BeginInvoke((Action)delegate ()
                {
                    tb.Text = Num;
                });
            }
            ));

        }

        private string  update(TextBlock tb)
        {
            Thread.Sleep(2000); //延迟2秒

            int i = 100000000;
            while (i > 0)
            {
                i--;
            }
            Random random = new Random();
            String Num = random.Next(0, 100).ToString();
            return Num;    
        }

        private void Begin3(TextBlock tb)
        {
            Thread.Sleep(2000); //延迟2秒 

            Random random = new Random();
            String Num = random.Next(0, 100).ToString();
            
            tb.Dispatcher.BeginInvoke((Action)delegate ()
            {
                tb.Text = Num;
            });
             
        }

        private void Begin(TextBlock tb)
        {
            int i = 100000000;
            while (i > 0)
            {
                i--;
            }
            Random random = new Random();
            String Num = random.Next(0, 100).ToString();
            //1.
            //tb.Text = Num;
            //2.
            //Action<TextBlock, String> updateAction = new Action<TextBlock, string>(UpdateTb);
            //tb.Dispatcher.BeginInvoke(updateAction, tb, Num);
            //3.
            // tb.Dispatcher.Invoke(new Action(delegate
            //{
            //    //tb.Text = Num;
            //    UpdateTb(tb, Num);
            //}));
            //4.
            //tb.Dispatcher.Invoke(() =>
            //{
            //    tb.Text = Num;
            //});
            //5.
            tb.Dispatcher.BeginInvoke((Action)delegate()
            {
                tb.Text = Num;
            });


        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
 
        }

        private void Button_GotFocus(object sender, RoutedEventArgs e)
        {

        }
    }

    /*任务调度器方法*/
    /*public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }
        private readonly TaskScheduler _syncContextTaskScheduler = TaskScheduler.FromCurrentSynchronizationContext();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Task.Factory.StartNew(SchedulerWork);
        }
        private void SchedulerWork()
        {
            Task.Factory.StartNew(Begin, this.first).Wait();
            Task.Factory.StartNew(Begin, this.second).Wait();
            Task.Factory.StartNew(Begin, this.Three).Wait();
        }

        private void Begin(object obj)
        {
            TextBlock tb = obj as TextBlock;
            int i = 100000000;
            while (i > 0)
            {
                i--;
            }
            Random random = new Random();
            String Num = random.Next(0, 100).ToString();
            Task.Factory.StartNew(() => UpdateTb(tb, Num),
                    new CancellationTokenSource().Token, TaskCreationOptions.None, _syncContextTaskScheduler).Wait();
        }
        private void UpdateTb(TextBlock tb, string text)
        {
            tb.Text = text;
        }
    }*/
}
