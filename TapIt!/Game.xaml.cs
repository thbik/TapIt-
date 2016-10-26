using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Threading.Tasks;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace TapIt_
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Game : Page
    {
        public Game()
        {
            this.InitializeComponent();
        }
        Random rnd = new Random();
        int liv = 3;
        int scr = 0;
        String str_scr;
        String str_liv;
        int pr_scr = 0;

        int tile_playing;
        int counter = 0;
        Boolean pressed = false, start = false, replay = false;
        Boolean loose = false;


        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {


            do
            {
                await Task.Delay(100);
            } while (start == false);



            do
            {
               
                PlayAgain.Visibility = Visibility.Collapsed;
                Home.Visibility = Visibility.Collapsed;
                replay = false;
                do//Game is on
                {

                    pr_scr = scr;
                    pressed = false;
                    tile_playing = rnd.Next(9);
                    if (liv != 0)
                    {
                        switch (tile_playing)
                        {
                            case 0:
                                if (nw != null) nw.Background = new SolidColorBrush(Windows.UI.Colors.OrangeRed);
                                break;
                            case 1:
                                if (n != null) n.Background = new SolidColorBrush(Windows.UI.Colors.OrangeRed);
                                break;
                            case 2:
                                if (ne != null) ne.Background = new SolidColorBrush(Windows.UI.Colors.OrangeRed);
                                break;
                            case 3:
                                if (wc != null) wc.Background = new SolidColorBrush(Windows.UI.Colors.OrangeRed);
                                break;
                            case 4:
                                if (c != null) c.Background = new SolidColorBrush(Windows.UI.Colors.OrangeRed);
                                break;
                            case 5:
                                if (ec != null) ec.Background = new SolidColorBrush(Windows.UI.Colors.OrangeRed);
                                break;
                            case 6:
                                if (sw != null) sw.Background = new SolidColorBrush(Windows.UI.Colors.OrangeRed);
                                break;
                            case 7:
                                if (s != null) s.Background = new SolidColorBrush(Windows.UI.Colors.OrangeRed);
                                break;
                            case 8:
                                if (se != null) se.Background = new SolidColorBrush(Windows.UI.Colors.OrangeRed);
                                break;
                            default:
                                if (nw != null) nw.Background = new SolidColorBrush(Windows.UI.Colors.OrangeRed);
                                break;
                        }
                        n.IsEnabled = true;
                        nw.IsEnabled = true;
                        ne.IsEnabled = true;
                        c.IsEnabled = true;
                        wc.IsEnabled = true;
                        ec.IsEnabled = true;
                        s.IsEnabled = true;
                        sw.IsEnabled = true;
                        se.IsEnabled = true;
                        if (scr <= 10)
                        {
                            await Task.Delay(1000);
                        }
                        else if (scr <= 20)
                        {
                            await Task.Delay(800);
                        }
                        else if (scr <= 30)
                        {
                            await Task.Delay(600);
                        }
                        else if (scr <= 50)
                        {
                            await Task.Delay(500);
                        }
                        else
                        {
                            await Task.Delay(400);
                        }
                    }

                    nw.Background = new SolidColorBrush(Windows.UI.Colors.Gray);
                    n.Background = new SolidColorBrush(Windows.UI.Colors.Gray);
                    ne.Background = new SolidColorBrush(Windows.UI.Colors.Gray);
                    wc.Background = new SolidColorBrush(Windows.UI.Colors.Gray);
                    c.Background = new SolidColorBrush(Windows.UI.Colors.Gray);
                    ec.Background = new SolidColorBrush(Windows.UI.Colors.Gray);
                    sw.Background = new SolidColorBrush(Windows.UI.Colors.Gray);
                    s.Background = new SolidColorBrush(Windows.UI.Colors.Gray);
                    se.Background = new SolidColorBrush(Windows.UI.Colors.Gray);

                    if (scr == pr_scr)
                    {
                        counter = counter + 1;
                        if (counter==5)
                        {
                            counter = 0;
                            liv = liv - 1;
                            str_liv = liv.ToString();
                            lives.Text = "Lives=" + str_liv;
                        }

                    }
                    else
                    {
                        counter = 0;
                    }
                    //next round

                } while (liv > 0);
                loose = true;
                lives.Text = "Lives=0"; //Game is over
                gameover.Visibility = Visibility.Visible;
                PlayAgain.Visibility = Visibility.Visible;
                Home.Visibility = Visibility.Visible;
                do
                {
                    await Task.Delay(100);
                } while (replay == false);
            } while (replay == true);
            /* nw.Background = new SolidColorBrush(Windows.UI.Colors.Red);
                 n.Background = new SolidColorBrush(Windows.UI.Colors.Red);
                 ne.Background = new SolidColorBrush(Windows.UI.Colors.Red);
                 wc.Background = new SolidColorBrush(Windows.UI.Colors.Red);
                 c.Background = new SolidColorBrush(Windows.UI.Colors.Red);
                 ec.Background = new SolidColorBrush(Windows.UI.Colors.Red);
                 sw.Background = new SolidColorBrush(Windows.UI.Colors.Red);
                 s.Background = new SolidColorBrush(Windows.UI.Colors.Red);
                 se.Background = new SolidColorBrush(Windows.UI.Colors.Red);*/

        }



        /* pr_scr = scr;
                 scr = scr + 1;
                 str_scr = scr.ToString(); ;
                 score.Text = str_scr;

             }
             else
             {

                 liv = liv-1;
                 str_liv = liv.ToString();
                 lives.Text = "Lives=" + str_liv;*/

        private void nw_Click(object sender, RoutedEventArgs e)
        {
            //nw.IsEnabled = false;
            if (start == true && loose == false)
            {
                if (tile_playing == 0)
                {
                    pr_scr = scr;
                    scr = scr + 1;
                    str_scr = scr.ToString(); ;
                    score.Text = str_scr;
                    pressed = true;
                }
                else
                {

                    if (liv > 0)
                    {
                        liv = liv - 1;
                        str_liv = liv.ToString();
                        lives.Text = "Lives=" + str_liv;
                        pressed = true;
                    }
                    else {
                        lives.Text = "Lives=0";
                        gameover.Visibility = Visibility.Visible;
                        loose = true;
                    }
                }



            }
        }

        private void n_Click(object sender, RoutedEventArgs e)
        {
            // n.IsEnabled = false;
            if (start == true && loose == false)
            {
                if (tile_playing == 1)
                {
                    pr_scr = scr;
                    scr = scr + 1;
                    str_scr = scr.ToString(); ;
                    score.Text = str_scr;
                    pressed = true;
                }
                else
                {

                    if (liv > 0)
                    {
                        liv = liv - 1;
                        str_liv = liv.ToString();
                        lives.Text = "Lives=" + str_liv;
                    }
                    else {
                        lives.Text = "Lives=0";
                        gameover.Visibility = Visibility.Visible;
                        loose = true;
                    }
                }




            }
        }

        private void ne_Click(object sender, RoutedEventArgs e)
        {
            //ne.IsEnabled = false;
            if (start == true)
            {
                if (tile_playing == 2 && loose == false)
                {
                    pr_scr = scr;
                    scr = scr + 1;
                    str_scr = scr.ToString(); ;
                    score.Text = str_scr;
                    pressed = true;

                }
                else
                {

                    if (liv > 0)
                    {
                        liv = liv - 1;
                        str_liv = liv.ToString();
                        lives.Text = "Lives=" + str_liv;
                    }
                    else {
                        lives.Text = "Lives=0";
                        gameover.Visibility = Visibility.Visible;
                        loose = true;
                    }
                }





            }
        }

        private void wc_Click(object sender, RoutedEventArgs e)
        {
            //wc.IsEnabled = false;
            if (start == true)
            {
                if (tile_playing == 3 && loose == false)
                {
                    pr_scr = scr;
                    scr = scr + 1;
                    str_scr = scr.ToString(); ;
                    score.Text = str_scr;
                    pressed = true;
                }
                else
                {

                    if (liv > 0)
                    {
                        liv = liv - 1;
                        str_liv = liv.ToString();
                        lives.Text = "Lives=" + str_liv;
                    }
                    else {
                        lives.Text = "Lives=0";
                        gameover.Visibility = Visibility.Visible;
                        loose = true;
                    }
                }





            }
        }


        private void c_Click(object sender, RoutedEventArgs e)
        {
            // c.IsEnabled = false;
            if (start == true)
            {
                if (tile_playing == 4 && loose == false)
                {
                    pr_scr = scr;
                    scr = scr + 1;
                    str_scr = scr.ToString(); ;
                    score.Text = str_scr;
                    pressed = true;
                }
                else
                {

                    if (liv > 0)
                    {
                        liv = liv - 1;
                        str_liv = liv.ToString();
                        lives.Text = "Lives=" + str_liv;
                    }
                    else {
                        lives.Text = "Lives=0";
                        gameover.Visibility = Visibility.Visible;
                        loose = true;
                    }
                }




            }
        }

        private void ec_Click(object sender, RoutedEventArgs e)
        {
            //ec.IsEnabled = false;
            if (start == true)
            {
                if (tile_playing == 5 && loose == false)
                {
                    pr_scr = scr;
                    scr = scr + 1;
                    str_scr = scr.ToString(); ;
                    score.Text = str_scr;
                    pressed = true;
                }
                else
                {

                    if (liv > 0)
                    {
                        liv = liv - 1;
                        str_liv = liv.ToString();
                        lives.Text = "Lives=" + str_liv;
                    }
                    else {
                        lives.Text = "Lives=0";
                        gameover.Visibility = Visibility.Visible;
                        loose = true;
                    }
                }






            }
        }

        private void sw_Click(object sender, RoutedEventArgs e)
        {
            //sw.IsEnabled = false
            if (start == true)
            {

                if (tile_playing == 6 && loose == false)
                {
                    pr_scr = scr;
                    scr = scr + 1;
                    str_scr = scr.ToString(); ;
                    score.Text = str_scr;
                    pressed = true;
                }
                else
                {

                    if (liv > 0)
                    {
                        liv = liv - 1;
                        str_liv = liv.ToString();
                        lives.Text = "Lives=" + str_liv;
                    }
                    else {
                        lives.Text = "Lives=0";
                        gameover.Visibility = Visibility.Visible;
                        loose = true;
                    }
                }



            }
        }

        private void s_Click(object sender, RoutedEventArgs e)
        {
            // s.IsEnabled = false;
            if (start == true)
            {
                if (tile_playing == 7 && loose == false)
                {
                    pr_scr = scr;
                    scr = scr + 1;
                    str_scr = scr.ToString(); ;
                    score.Text = str_scr;
                    pressed = true;
                }
                else
                {

                    if (liv > 0)
                    {
                        liv = liv - 1;
                        str_liv = liv.ToString();
                        lives.Text = "Lives=" + str_liv;
                    }
                    else {
                        lives.Text = "Lives=0";
                        gameover.Visibility = Visibility.Visible;
                        loose = true;
                    }
                }
                if (liv < 0) gameover.Visibility = Visibility.Visible;



            }
        }

        private void se_Click(object sender, RoutedEventArgs e)
        {
            //se.IsEnabled = false;
            if (start == true)
            {
                if (tile_playing == 8 && loose == false)
                {
                    pr_scr = scr;
                    scr = scr + 1;
                    str_scr = scr.ToString(); ;
                    score.Text = str_scr;
                    pressed = true;
                }
                else
                {
                    if (liv > 0)
                    {
                        liv = liv - 1;
                        str_liv = liv.ToString();
                        lives.Text = "Lives=" + str_liv;
                    }
                    else {
                        lives.Text = "Lives=0";
                        gameover.Visibility = Visibility.Visible;
                        loose = true;
                    }
                }




            }
        }

        private void PlayAgain_Click(object sender, RoutedEventArgs e)
        {
            replay = true;
            liv = 3;
            str_liv = liv.ToString();
            lives.Text = "Lives=" + str_liv;
            scr = 0;
            pr_scr = 0;
            str_scr = scr.ToString(); ;
            score.Text = str_scr;
            gameover.Visibility = Visibility.Collapsed;
            loose = false;

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            start = true;
            Start.Visibility = Visibility.Collapsed;
            Back.Visibility = Visibility.Collapsed;
        }

    }
}
