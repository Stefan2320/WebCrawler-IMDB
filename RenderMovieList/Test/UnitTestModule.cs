using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using RenderMovieList;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Test
{
    [TestClass]
    public class UnitTestModule
    {
        private Movie _testMovie = new Movie("The Theory of Everything", 2014, "Description", 7.7);
        private Movie _testMovie2 = new Movie("The Imitation Game", 2014, "Another description", 8.0);

        [TestMethod]
        public void TestMovieTitleSetter()
        {
            Assert.AreEqual("The Theory of Everything", _testMovie.Title);
        }

        [TestMethod]
        public void TestMovieYearSetter()
        {
            Assert.AreEqual(2014, _testMovie.Year);
        }

        [TestMethod]
        public void TestMovieDescriptionSetter()
        {
            Assert.AreEqual("Description", _testMovie.Description);
        }

        [TestMethod]
        public void TestMovieRatingSetter()
        {
            Assert.AreEqual(7.7, _testMovie.Rating);
        }

        [TestMethod]
        public void TestRenderDescription()
        {
            // Testeaza daca descrierea unui film a fost scrisa corect in TextBoxul corespunzator

            List<Movie> listOfMovies = new List<Movie> { _testMovie, _testMovie2 };
            TextBox descriptionBox = new TextBox();
            DataGridView dataGrid = new DataGridView();
            Render.SetDescriptionBox(descriptionBox);
            Render.SetDataGrid(dataGrid);
            Render.RenderMovies(listOfMovies);
            Render.RenderDescription(1);
            Assert.AreEqual("Another description", descriptionBox.Text);
        }
    }
}
