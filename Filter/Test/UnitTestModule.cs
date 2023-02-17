using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Filter;
using RenderMovieList;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Test
{
    [TestClass]
    public class UnitTestModule
    {
        private ExtendedTextBox _searchBox = new ExtendedTextBox();
        private Filter.Filter _filter = new Filter.Filter();

        private Movie _testMovie1 = new Movie("The Theory of Everything", 2014, "Description1", 7.7);
        private Movie _testMovie2 = new Movie("The Imitation Game", 2014, "Description2", 8.0);
        private Movie _testMovie3 = new Movie("Imitation", 2001, "Description3", 7.6);
        List<Movie> _listOfMovies;
        private DataGridView _dataGrid = new DataGridView();

        private void InitializeData()
        {
            _searchBox.AddSubscriber(_filter);

            _listOfMovies = new List<Movie> { _testMovie1, _testMovie2, _testMovie3 };
            Render.SetDataGrid(_dataGrid);

            MovieList.GetInstance().SetMovies(_listOfMovies);
            MovieList.GetInstance().RenderMovies();
        }

        [TestMethod]
        public void TestAddSubscriber()
        {
            _searchBox.AddSubscriber(_filter);

            bool pass = true;

            if (_searchBox.GetSubscribers().Count != 1)
                pass = false;
            else
                if(_searchBox.GetSubscribers()[0] != _filter)
                    pass = false;

            Assert.AreEqual(true, pass);
        }

        [TestMethod]
        public void TestDeleteSubscriber()
        {
            _searchBox.AddSubscriber(_filter);
            _searchBox.DeleteSubscriber(_filter);

            Assert.AreEqual(0, _searchBox.GetSubscribers().Count);
        }

        [TestMethod]
        public void TestFilterNull()
        {
            InitializeData();

            _searchBox.Text = "";
            _searchBox.Notify();
            List<Movie> filteredListOfMovies = Render.GetMovieList();

            bool corresponding = true;

            if (filteredListOfMovies.Count != _listOfMovies.Count)
            {
                corresponding = false;
            }

            else
                for(int i = 0; i < filteredListOfMovies.Count; i++)
                {
                    if (filteredListOfMovies[i].Equals(_listOfMovies[i]) == false)
                        corresponding = false;
                }

            Assert.AreEqual(true, corresponding);
        }

        [TestMethod]
        public void TestFilterSameBeginningMovies()
        {
            InitializeData();

            _searchBox.Text = "The";
            _searchBox.Notify();
            List<Movie> filteredListOfMovies = Render.GetMovieList();

            bool corresponding = true;

            if (filteredListOfMovies.Count != 2)
            {
                corresponding = false;
            }
            else
            {
                if (filteredListOfMovies[0].Equals(_testMovie1) == false || filteredListOfMovies[1].Equals(_testMovie2) == false)
                    corresponding = false;
            }

            Assert.AreEqual(true, corresponding);
        }

        [TestMethod]
        public void TestFilterNoMovieFound()
        {
            InitializeData();

            _searchBox.Text = "Z";
            _searchBox.Notify();
            List<Movie> filteredListOfMovies = Render.GetMovieList();

            bool corresponding = true;

            if (filteredListOfMovies.Count != 0)
            {
                corresponding = false;
            }

            Assert.AreEqual(true, corresponding);
        }

        [TestMethod]
        public void TestFilterCaseSensitiveCheck()
        {
            InitializeData();

            _searchBox.Text = "t";
            _searchBox.Notify();
            List<Movie> filteredListOfMovies = Render.GetMovieList();

            bool corresponding = true;

            if (filteredListOfMovies.Count != 0)
            {
                corresponding = false;
            }

            Assert.AreEqual(true, corresponding);
        }

        [TestMethod]
        public void TestFilterNoMovieFound2()
        {
            InitializeData();

            _searchBox.Text = "Thee";
            _searchBox.Notify();
            List<Movie> filteredListOfMovies = Render.GetMovieList();

            bool corresponding = true;

            if (filteredListOfMovies.Count != 0)
            {
                corresponding = false;
            }

            Assert.AreEqual(true, corresponding);
        }

        [TestMethod]
        public void TestFilterSearchedStringAtEnd()
        {
            InitializeData();

            _searchBox.Text = "Game";
            _searchBox.Notify();
            List<Movie> filteredListOfMovies = Render.GetMovieList();

            bool corresponding = true;

            if (filteredListOfMovies.Count != 0)
            {
                corresponding = false;
            }

            Assert.AreEqual(true, corresponding);
        }

        [TestMethod]
        public void TestFilterSearchedStringInMiddle()
        {
            InitializeData();

            _searchBox.Text = "Theory";
            _searchBox.Notify();
            List<Movie> filteredListOfMovies = Render.GetMovieList();

            bool corresponding = true;

            if (filteredListOfMovies.Count != 0)
            {
                corresponding = false;
            }

            Assert.AreEqual(true, corresponding);
        }

        [TestMethod]
        public void TestFilterSearchThenDelete()
        {
            InitializeData();

            _searchBox.Text = "The";
            _searchBox.Notify();

            _searchBox.Text = "";
            _searchBox.Notify();

            List<Movie> filteredListOfMovies = Render.GetMovieList();

            bool corresponding = true;

            if (filteredListOfMovies.Count != _listOfMovies.Count)
            {
                corresponding = false;
            }

            else
                for (int i = 0; i < filteredListOfMovies.Count; i++)
                {
                    if (filteredListOfMovies[i].Equals(_listOfMovies[i]) == false)
                        corresponding = false;
                }

            Assert.AreEqual(true, corresponding);
        }

        [TestMethod]
        public void TestFilterConsecutiveSearches()
        {
            InitializeData();

            _searchBox.Text = "The ";
            _searchBox.Notify();

            _searchBox.Text += "I";
            _searchBox.Notify();

            List<Movie> filteredListOfMovies = Render.GetMovieList();

            Assert.AreEqual(true, filteredListOfMovies[0].Equals(_listOfMovies[1]));
        }
    }
}

