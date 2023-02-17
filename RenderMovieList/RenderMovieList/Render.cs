/**************************************************************************
 *                                                                        *
 *  File:        Render.cs                                                *
 *  Copyright:   (c) 2022, Scinteie Gabriel Alexandru                     *
 *  E-mail:      scinteie-gabriel.alexandru@student.tuiasi.ro             *
 *  Description: Class used to render informations about the list         *
 *               of movies                                                *
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
using System.Windows.Forms;
using System.Windows.Controls;

namespace RenderMovieList
{
    /// <summary>
    /// Clasa ce se ocupa de afisarea informatiilor specifice fiecarui film dintr-o lista
    /// </summary>
    public class Render
    {
        private static DataGridView _dataGrid;
        private static TextBox _descriptionBox;
        private static List<Movie> _movieList = null;

        /// <summary>
        /// Returneaza ultima lista de filme afisata in interfata
        /// </summary>
        /// <returns></returns>
        public static List<Movie> GetMovieList()
        {
            return _movieList;
        }

        /// <summary>
        /// Clasa folosita pentru a putea stoca intr-un tip de date separat Titlul, Anul si Ratingul unui film de catre Descrierea lui
        /// </summary>
        public class MovieWithoutDescription
        {
            private string _title;
            private int _year;
            private double _rating;

            /// <summary>
            /// Constructorul cu parametrii specifici
            /// </summary>
            /// <param name="title"></param>
            /// <param name="year"></param>
            /// <param name="rating"></param>
            public MovieWithoutDescription(string title, int year, double rating)
            {
                _title = title;
                _year = year;
                _rating = rating;
            }

            public string Title { get => _title; set => _title = value; }
            public int Year { get => _year; set => _year = value; }
            public double Rating { get => _rating; set => _rating = value; }
        }

        /// <summary>
        /// Setter al membrului dataGrid unde se vor afisa Titlurile, Anii si Rating-urile
        /// </summary>
        /// <param name="dataGrid"></param>
        public static void SetDataGrid(DataGridView dataGrid)
        {
            _dataGrid = dataGrid;
        }

        /// <summary>
        /// Setter al TextBox-ului unde se va afisa Descrierea
        /// </summary>
        /// <param name="textBox"></param>
        public static void SetDescriptionBox(TextBox textBox)
        {
            _descriptionBox = textBox;
        }

        /// <summary>
        /// Metoda ce afiseaza in dataGrid Titlurile, Anii si Rating-urile
        /// Este nevoie de o lista de tipul MovieWithoutDescription pentru a putea stoca intr-o structura de date doar Titlul, Anul si Rating-ul unui film pentru a putea seta parametrul dataSource al dataGridului
        /// </summary>
        /// <param name="movies"></param>
        public static void RenderMovies(List<Movie> movies)
        {
            
            List<MovieWithoutDescription> moviesWithoutImage = new List<MovieWithoutDescription>();

            for(int i = 0; i < movies.Count; i++)
            {   
                moviesWithoutImage.Add(new MovieWithoutDescription(movies[i].Title, movies[i].Year, movies[i].Rating));
            }

            _movieList =  movies;

            try
            {
                _dataGrid.DataSource = moviesWithoutImage;
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

        }

        /// <summary>
        /// Metoda ce primeste ca parametru al catelea film din lista de filme a fost selectat si afiseaza in TextBox-ul de pe interfata descrierea acestui film
        /// </summary>
        /// <param name="index"></param>
        public static void RenderDescription(int index)
        {
            try
            {
                _descriptionBox.Text = _movieList[index].Description;
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
        }
    }
}
