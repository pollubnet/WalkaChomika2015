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
        /// <summary>
        /// Prywatne pola, które będą wspólne dla wszystkich funkcji (metod)
        /// w klasie odpowiedzialnej za wyświetlanie tego okna
        /// </summary>
        private Zwierzę chomik;
        private Zwierzę pies;

        /// <summary>
        /// Konstruktor, uruchamia się przy tworzeniu okna
        /// </summary>
        public MainPage()
        {
            this.InitializeComponent();

            // tworzenie nowego obiektu i nadawanie jego cech
            chomik = new Zwierzę();
            chomik.HP = 5;
            chomik.Imię = "Pucuś";
            chomik.Mana = 0;
            chomik.Damage = 2;

            // można też utworzyć obiekt i nadawać mu cechy od razu
            pies = new Zwierzę()
            {
                Imię = "Dino",
                Damage = 5,
                Mana = 0,
                HP = 20
            };

        }

        /// <summary>
        /// Funkcja realizująca walkę pomiędzy zmiennymi przekazywanymi w parametrach
        /// czyli Zwierzęciem 1 i Zwierzęciem 2. Zwierzę 1 atakuje 2.
        /// </summary>
        /// <param name="zwierze1"></param>
        /// <param name="zwierze2"></param>
        private void Walka(Zwierzę zwierze1, Zwierzę zwierze2)
        {
            int z = 0;


            while (zwierze2.CzyŻyje())
            {
                zwierze1.Gryź(zwierze2);
                z++;
            }

            // ustawiamy tekst w polu tekstowym
            liczbaUgryzien.Text = z.ToString();
        }

        /// <summary>
        /// Obsługa kliknięcia przycisku
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender, RoutedEventArgs e)
        {
            // uruchomienie walki pomiędzy zwierzątkami utworzonymi w konstruktorze
            Walka(chomik, pies);
        }
    }
}
