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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkaChomika
{
    /// <summary>
    /// Jednorożec - zwierzę magiczne od razu implementujące interfejs ILatający,
    /// czyli latające
    /// </summary>
    class Jednorożec : ZwierzęMagiczne, ILatający
    {
        /// <summary>
        /// Konstuktor wypełniający domyślnymi wartościami
        /// </summary>
        /// <param name="imię"></param>
        /// <param name="mana"></param>
        public Jednorożec(string imię, int mana)
        {
            this.Imię = imię;
            this.Mana = mana;
            this.HP = 1000;
            this.Agility = 5;
            this.CzyLata = false;
        }

        /// <summary>
        /// Definiuje, czy aktualnie lata, czy nie
        /// </summary>
        public bool CzyLata { get; set; }

        /// <summary>
        /// Poderwanie się do lotu, zwiększa zwinność
        /// </summary>
        public void Lataj()
        {
            if (Mana > 1)
            {
                CzyLata = true;
                this.Agility = 7;
                this.Mana--;
            }
            
        }
    }
}
