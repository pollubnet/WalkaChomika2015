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

#endregion License

using System;

namespace WalkaChomika.Models
{
    /// <summary>
    /// Klasa wyjątku NoManaException rzucanego, jeżeli próbujemy wykonać akcję,
    /// a nie ma many.
    ///
    /// Wszystkie klasy wyjątków dziedziczą po System.Exception
    /// </summary>
    internal class NoManaException : Exception
    {
        /// <summary>
        /// Konstruktor bazowy
        /// </summary>
        public NoManaException()
        {
        }

        /// <summary>
        /// Konstruktor przyjmujący komunikat, który będziemy mogli przekazać dalej,
        /// na przykład do użytkownika
        /// </summary>
        /// <param name="message">Komunikat błędu</param>
        public NoManaException(string message) : base(message)
        {
        }

        /// <summary>
        /// Konstruktor przyjmujący komunikat oraz wewnętrzny wyjątek.
        ///
        /// Pozwala na opakowanie jednego wyjątku w drugi albo zwrócenie ich łańcucha.
        /// Wszystkie te konstruktory uruchamiają konstruktor bazowy przekazując mu
        /// parametry, ale mogą też mieć własną logikę.
        /// </summary>
        /// <param name="message">Komunikat błędu</param>
        /// <param name="innerException">Wewnętrzny wyjątek</param>
        public NoManaException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}