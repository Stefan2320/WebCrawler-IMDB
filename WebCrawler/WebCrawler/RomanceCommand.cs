﻿/**************************************************************************
 *                                                                        *
 *  File:        RomanceCommand.cs                                        *
 *  Copyright:   (c) 2022, Barbuta Delia Elena                            *
 *  E-mail:      delia-elena.barbuta@student.tuiasi.ro                    *
 *  Description: Class for retrieving information about romance movies.   *
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
using RenderMovieList;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace WebCrawler
{
    /// <summary>
    /// Clasa ce implementeaza interfata Command si care este folosita pentru incarcarea filmelor de drama
    /// </summary>
    public class RomanceCommand : Command
    {
        private MovieList _receiver;
        private string _xpath;
        private string _link;

        /// <summary>
        /// Constructor ce seteaza campurile clasei
        /// Variabilele xpath si link sunt necesare pentru a se putea prelua informatiile de pe site-ul web
        /// Variabila _receiver va fi locul unde se vor stoca filmele si careia i se va delega afisarea in interfata
        /// </summary>
        /// <param name="xpath"></param>
        /// <param name="link"></param>
        public RomanceCommand(string xpath, string link)
        {
            _receiver = MovieList.GetInstance();
            _xpath = xpath;
            _link = link;
        }

        // metoda execute preia de pe website numele, anul, scorul si descrierea celor 50 de filme romantice
        public void Execute()
        {
            //xpath = /html/body/div[3]/div/div[2]/div[3]/div[1]/div/div[3]/div/div[position()>0]
            //xpath nume = /html/body/div[3]/div/div[2]/div[3]/div[1]/div/div[3]/div/div[1]/div[3]/h3/a
            //xpath an = /html/body/div[3]/div/div[2]/div[3]/div[1]/div/div[3]/div/div[1]/div[3]/h3/span[2]
            //xpath rating = /html/body/div[3]/div/div[2]/div[3]/div[1]/div/div[3]/div/div[1]/div[3]/div/div[1]/strong
            //xpath descriere = /html/body/div[3]/div/div[2]/div[3]/div[1]/div/div[3]/div/div[1]/div[3]/p[2]
            var web = new HtmlWeb();
            var document = web.Load(_link);
            var nodes = document.DocumentNode.SelectNodes(_xpath);
            var movieList = new List<Movie> { };


            foreach (var node in nodes)
            {
                try
                {
                    string name = node.SelectSingleNode("div[3]/h3/a").InnerText;
                    string yearUnstripped = node.SelectSingleNode("div[3]/h3/span[2]").InnerText;
                    string yearStripped = yearUnstripped.Replace("(", "").Replace(")", "");
                    yearStripped = Regex.Match(yearStripped, @"\d+").Value;
                    yearStripped = yearStripped.Replace(" ", "").Replace("  ", "");
                    int year = int.Parse(yearStripped);
                    string description = node.SelectSingleNode("div[3]/p[2]").InnerText;
                    description = description.Replace("See full summary&nbsp;&raquo;", "");
                    if (description.Contains("Add a Plot"))
                        description = "No description available!";
                    double rating = double.Parse(node.SelectSingleNode("div[3]/div/div[1]/strong").InnerText);
                    Movie movie = new Movie(name, year, description, rating);
                    movieList.Add(movie);

                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);
                }

            }

            _receiver.SetMovies(movieList);
            _receiver.RenderMovies();
        }
    }
}
