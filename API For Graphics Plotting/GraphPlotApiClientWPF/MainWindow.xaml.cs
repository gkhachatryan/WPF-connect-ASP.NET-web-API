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
using System.Windows.Threading;

namespace GraphPlotApiClientWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Polyline polyline;

        public MainWindow()
        {
            polyline = new Polyline { Stroke = Brushes.DarkRed };

            InitializeComponent();
        }

        private Point CorrespondingPoint(Point pt)
        {
            double xmin = 0;
            double xmax = 6.5;
            double ymin = -1.1;
            double ymax = 1.1;

            var result = new Point
            {
                X = (pt.X - xmin) * canvas.Width / (xmax - xmin),
                Y = canvas.Height - (pt.Y - ymin) * canvas.Height / (ymax - ymin)
            };

            return result;
        }

        private void Draw_Graph_Click(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            JavaScriptSerializer jss = new JavaScriptSerializer();
            string url = string.Format("http://localhost:53901/api/plot");
            client.GetAsync(url).ContinueWith(resurse =>
            {
                HttpResponseMessage message = client.GetAsync(url).Result;
                string responseText = message.Content.ReadAsStringAsync().Result;
                List<Point> list = jss.Deserialize<List<Point>>(responseText);

                Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                   (Action)(() =>
                    {
                       foreach (var item in list)
                          {
                            polyline.Points.Add(CorrespondingPoint(new Point(item.X, item.Y)));
                          }
                       canvas.Children.Add(polyline);
                      }));
            });
        }

    }
}