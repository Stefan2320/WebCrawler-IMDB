/**************************************************************************
 *                                                                        *
 *  File:        Movie.cs                                                 *
 *  Copyright:   (c) 2022, Scinteie Gabriel Alexandru                     *
 *  E-mail:      scinteie-gabriel.alexandru@student.tuiasi.ro             *
 *  Description: Class used to store information about a movie            *
 *                                                                        *
 *                                                                        *
 *  This code and information is provided "as is" without warranty of     *
 *  any kind, either expressed or implied, including but not limited      *
 *  to the implied warranties of merchantability or fitness for a         *
 *  particular purpose. You are free to use this source code in your      *
 *  applications as long as the original copyright notice is included.    *
 *                                                                        *
 **************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenderMovieList
{
    /// <summary>
    /// Clasa ce stocheaza informatiile despre un anume film: titlue, anul aparitiei, rating si descrierea
    /// </summary>
    public class Movie
    {
        private string _title;
        private int _year;
        private string _description;
        private double _rating;

        /// <summary>
        /// Constructor ce seteaza membrii clasei
        /// </summary>
        /// <param name="title"></param>
        /// <param name="year"></param>
        /// <param name="description"></param>
        /// <param name="rating"></param>
        public Movie(string title, int year, string description, double rating)
        {
            _title = title;
            _year = year;
            _description = description;
            _rating = rating;
        }

        public string Title { get => _title; set => _title = value; }
        public int Year { get => _year; set => _year = value; }
        public string Description { get => _description; set => _description = value; }
        public double Rating { get => _rating; set => _rating = value; }
    }
}
