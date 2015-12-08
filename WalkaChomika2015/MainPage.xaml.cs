#region License
/*
 * Written in 2014 by Marcin Badurowicz <m dot badurowicz at pollub dot pl>
 *
 * To the extent possible under law, the author(s) have dedicated
 * all copyright and related and neighboring rights to this 
 * software to the public domain worldwide. This software is 
 * distributed without any warranty. 
 *
 * You should have received a copy of the CC0 Public Domain 
 * Dedication along with this software. If not, see 
 * <http://creativecommons.org/publicdomain/zero/1.0/>. 
 */
#endregion

using Ktos.Common;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WalkaChomika
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private TextBoxTraceListener Debug;

        /// <summary>
        /// Prywatne pola, które będą wspólne dla wszystkich funkcji (metod)
        /// w klasie odpowiedzialnej za wyświetlanie tego okna
        /// </summary>
        private Zwierzę zwierze1;
        private Zwierzę zwierze2;

        /// <summary>
        /// Konstruktor, uruchamia się przy tworzeniu okna
        /// </summary>
        public MainPage()
        {
            this.InitializeComponent();
            Debug = new TextBoxTraceListener(debug);

            // tworzenie nowego obiektu i nadawanie jego cech poprzez konstruktor
            // domyślny lub z parametrami
            zwierze1 = new ChomikSzaman("Pucuś", 10);            
            zwierze2 = new Chomik("Lucjan");

        }

        /// <summary>
        /// Pole które określa czy jest tura gracza1 czy też nie
        /// </summary>
        private bool gracz1 = true;

        /// <summary>
        /// Funkcja realizująca walkę pomiędzy zmiennymi przekazywanymi w parametrach
        /// czyli Zwierzęciem 1 i Zwierzęciem 2. Zwierzę 1 atakuje 2.
        /// </summary>        
        private void Tura()
        {
            Random r = new Random();
            var d = r.NextDouble();


            if (gracz1)
            {
                // 20% szans na atak magiczny
                if (d > 0.8)
                {
                    if (zwierze1 is ZwierzęMagiczne)
                    {
                        (zwierze1 as ZwierzęMagiczne).AtakujMagicznie(zwierze2);
                        Debug.WriteLine(zwierze1.Imię + " zaatakował magią!");
                    }
                }
                zwierze1.Gryź(zwierze2);
            }
            else
            {
                if (d > 0.8)
                {
                    if (zwierze2 is ZwierzęMagiczne)
                    {
                        ((ZwierzęMagiczne)zwierze2).AtakujMagicznie(zwierze1);
                        Debug.WriteLine(zwierze2.Imię + " zaatakował magią!");
                    }
                }
                zwierze2.Gryź(zwierze1);
            }

            if (!zwierze1.CzyŻyje())
            {
                Debug.WriteLine(zwierze1.Imię + " nie żyje :(");
                btnNextTurn.IsEnabled = false;
            }

            if (!zwierze2.CzyŻyje())
            {
                Debug.WriteLine(zwierze2.Imię + " nie żyje :(");
                btnNextTurn.IsEnabled = false;
            }

            Debug.WriteLine(zwierze1.Stan());
            Debug.WriteLine(zwierze2.Stan());

            gracz1 = !gracz1;
        }

        /// <summary>
        /// Obsługa kliknięcia przycisku
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender, RoutedEventArgs e)
        {
            // uruchomienie walki pomiędzy zwierzątkami utworzonymi w konstruktorze
            Tura();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // wszystko można zrzutować na System.Object, jeżeli ktoś potrzebuje
            (zwierze1 as object).ToString();
        }
    }
}
