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
    /// Interfejs opisujący wszystkie cechy i funkcje zwierząt latających
    /// </summary>
    interface ILatający
    {
        /// <summary>
        /// Mówi czy zwierzę aktualnie lata
        /// </summary>
        bool CzyLata { get; set; }

        /// <summary>
        /// Poderwanie się do lotu - co faktycznie będzie to powodować,
        /// zależy od implementacji.
        /// </summary>
        void Lataj();
    }
}
