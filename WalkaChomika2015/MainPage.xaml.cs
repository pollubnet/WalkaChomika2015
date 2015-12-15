﻿#region License

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

#endregion License

using Ktos.Common;
using System;
using WalkaChomika.Models;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

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
            zwierze1 = new ArmiaChomików(100);
            zwierze2 = new Jednorożec("Rafał", 5);
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
            if (gracz1)
            {
                Atak(zwierze1, zwierze2);
            }
            else
            {
                Atak(zwierze2, zwierze1);
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
        /// Funkcja realizująca atak jednego gracza na drugiego
        /// </summary>
        /// <param name="atakujący">Obiekt który jest atakujący</param>
        /// <param name="cel">Obiekt który jest atakowany</param>
        private void Atak(Zwierzę atakujący, Zwierzę cel)
        {
            Random r = new Random();
            var d = r.NextDouble();

            // mówi czy atak nastąpił, czy mamy testować dalej
            bool czyAtakował = false;

            // dla Zwierzęcia Magicznego 20% szans ataku magicznego
            if ((atakujący is ZwierzęMagiczne) && (d > 0.8))
            {
                (atakujący as ZwierzęMagiczne).AtakujMagicznie(cel);
                Debug.WriteLine(atakujący.Imię + " zaatakował magią!");
                czyAtakował = true;
            }

            // jeżeli nie udało się, a atakujący lata, to może zużyć swój ruch
            // na start do lotu z 40% szans na powodzenie - start też jest uznawany
            // za atak, mimo, że nie zadaje obrażeń
            if (!czyAtakował && (atakujący is ILatający) && (d > 0.6))
            {
                if (!(atakujący as ILatający).CzyLata)
                {
                    (atakujący as ILatający).Lataj();
                    Debug.WriteLine(atakujący.Imię + " odleciał!");
                    czyAtakował = true;
                }
            }

            // jeśli nie zaatakował w żaden specjalny sposób, gryzie
            if (!czyAtakował)
                atakujący.Gryź(cel);
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

        private void btnAutoFight_Click(object sender, RoutedEventArgs e)
        {
            while (btnNextTurn.IsEnabled)
                Tura();
        }
    }
}