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
using DStructures.LinkedList;
using DStructures.LinkedList.Interfaces;

namespace DStructuresUI
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LinkedList LList = new LinkedList();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            int val = Convert.ToInt32(tbAddValue.Text);
            LinkedListItem i = new LinkedListItem(val);
            LList.Add(i);

            LbItemCount.Content = LList.Count;

            drawStructure(LList, CContent);
        }

        private void drawStructure(LinkedList l, Canvas c)
        {
            c.Children.Clear();
            double width = c.Width;
            int count = LList.Count;
            ILinkedListItem item = LList.First;

            //von hier den letzten Pfeil verbinden
            double prevHookX = 0;
            double prevHookY = 0;

            double x = 0, y = 0;
            bool breakline = false;

            for (int i = 0; i < count; i++)
            {
                if(i > 0 && i % 5 == 0)
                {
                    //breakLine
                    y += 100;
                    breakline = true;
                }

                c.Height = y + 300;

                x = (i % 5) * 100 + 25;

                drawRectItemTo(x, y, item.Data, 80, 60, c);

                double endX = x;
                double endY = y;

                if(breakline)
                {
                    breakline = false;

                    //Strich nach rechts
                    double x1end = prevHookX + 20 + 80;
                    double y1end = prevHookY + 30;
                    drawLine(prevHookX + 80, prevHookY + 30, x1end, y1end, c);

                    //Strich nach unten
                    double x2end = x1end;
                    double y2end = y1end + 50;
                    drawLine(x1end, y1end, x2end, y2end, c);

                    //Strich nach links
                    double x3end = 10;
                    double y3end = y2end;
                    drawLine(x2end, y2end, x3end, y3end, c);

                    //Strich nach unten
                    double x4end = x3end;
                    double y4end = y3end +50;
                    drawLine(x3end, y3end, x4end, y4end, c);

                    //Strich nach rechts
                    double x5end = x4end + 15;
                    double y5end = y4end;
                    drawLine(x4end, y4end, x5end, y5end, c);
                    drawTipAt(x5end, y5end, c);

                }
                else if (!breakline && prevHookX != 0)
                {
                    drawLine(prevHookX + 80, prevHookY + 30, endX, endY + 30, c);
                    drawTipAt(endX, endY + 30, c);
                }

                prevHookX = endX;
                prevHookY = endY;
                item = item.Next;
            }
        }

        private void drawRectItemTo(double x, double y, int caption, double width, double height, Canvas c)
        {
            Rectangle r = new Rectangle();
            r.Stroke = Brushes.Black;
            
            r.Width = width;
            r.Height = height;

            c.Children.Add(r);
            Canvas.SetTop(r, y);
            Canvas.SetLeft(r, x);

            Label l = new Label();
            l.Content = caption;
            c.Children.Add(l);
            Canvas.SetTop(l, y + 15);
            Canvas.SetLeft(l, x + 20);
        }

        private void drawLine(double startX, double startY, double endX, double endY, Canvas c)
        {

            Line l = new Line();
            l.Stroke = Brushes.Black;

            l.X1 = startX;
            l.Y1 = startY;
            l.X2 = endX;
            l.Y2 = endY;
            l.StrokeThickness = 2;

            c.Children.Add(l);
        }

        private void drawTipAt(double x, double y, Canvas c)
        {
            Line l = new Line();
            l.Stroke = Brushes.Black;

            l.X1 = x;
            l.Y1 = y;
            l.X2 = x-5;
            l.Y2 = y-5;
            l.StrokeThickness = 2;
        
            c.Children.Add(l);
            l = new Line();
            l.Stroke = Brushes.Black;

            l.X1 = x;
            l.Y1 = y;
            l.X2 = x - 5;
            l.Y2 = y + 5;
            l.StrokeThickness = 2;

            c.Children.Add(l);
        }

        private void btnAddRandomItems_Click(object sender, RoutedEventArgs e)
        {
            int count = Convert.ToInt32(tbAddRand.Text);
            Random r = new Random();

            for (int i = 0; i < count; i++)
            {
                int val = r.Next(0, 100);
                LinkedListItem item = new LinkedListItem(val);
                LList.Add(item);

                LbItemCount.Content = LList.Count;
            }
            drawStructure(LList, CContent);
        }

        private void btnDeleteLast_Click(object sender, RoutedEventArgs e)
        {
            LList.RemoveLast();
            drawStructure(LList, CContent);
        }
    }
}
