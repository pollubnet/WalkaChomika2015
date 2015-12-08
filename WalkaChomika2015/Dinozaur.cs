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
    /// Dinozaur, klasa dziedzicząca po Zwierzę
    /// </summary>
    class Dinozaur : Zwierzę
    {
        /// <summary>
        /// Konstruktor, nadaje bazowe, bardzo duże,
        /// wartości HP i obrazeń
        /// </summary>
        /// <param name="imię">Imię stworzenia</param>
        public Dinozaur(string imię)
        {
            this.HP = 100000;
            this.Damage = 150;
            this.Imię = imię;
        }
    }
}
