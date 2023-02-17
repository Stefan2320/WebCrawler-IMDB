/**************************************************************************
 *                                                                        *
 *  File:        MovieList.cs                                             *
 *  Copyright:   (c) 2022, Scinteie Gabriel Alexandru                     *
 *  E-mail:      scinteie-gabriel.alexandru@student.tuiasi.ro             *
 *  Description: Class used to store information about a list of movies   *
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
    /// Clasa ce stocheaza o lista de filme dintr-o anumita categorie si care poate incepe procesul de afisare in interfata a respectivei liste
    /// Clasa este un Singleton pentru ca la un moment dat de timp exista o singura lista unica de filme ce trebuie stocata si pentru 
    /// a se crea un punct de acces global la lista de filme curent selectata de utilizator
    /// </summary>
    public class MovieList
    {
        private static MovieList _instance = null;
        private List<Movie> _movieList;

        /// <summary>
        /// Getter pentru lista de filme
        /// </summary>
        /// <returns></returns>
        public List<Movie> GetMovies()
        {
            return _movieList;
        }

        /// <summary>
        /// Setter pentru lista de filme
        /// </summary>
        /// <param name="movieList"></param>
        public void SetMovies(List<Movie> movieList)
        {
            _movieList = movieList;
        }

        /// <summary>
        /// Getter pentru instanta specific Singletonului
        /// </summary>
        /// <returns></returns>
        public static MovieList GetInstance()
        {
            if(_instance == null)
                _instance = new MovieList();
            return _instance;
        }

        /// <summary>
        /// Metoda ce deleaga clasei Render afisarea in interfata a listei de filme 
        /// </summary>
        public void RenderMovies()
        {
            Render.RenderMovies(_movieList);
        }

    }
}
