using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WebCrawler;
using RenderMovieList;
using Filter;
using System.Windows.Forms;

namespace Test
{
    [TestClass]
    public class UnitTestModule
    {
        ExtendedTextBox _searchBox = new ExtendedTextBox();
        DataGridView dataGrid = new DataGridView();
        WebCrawlerInterface _invoker = new WebCrawlerImplementation();

        [TestMethod]
        public void TestCommedyCommand()
        {
            Render.SetDataGrid(dataGrid);

            _invoker.SetCommand(new ComedyCommand("/html/body/div[3]/div/div[2]/div[3]/div[1]/div/div[3]/div/div[position()>0]", "https://www.imdb.com/search/title/?title_type=feature&genres=comedy&sort=user_rating,desc"));
            _invoker.ExecuteCommand();

            Assert.AreEqual(50, Render.GetMovieList().Count);
        }

        [TestMethod]
        public void TestHorrorCommand()
        {
            Render.SetDataGrid(dataGrid);

            _invoker.SetCommand(new HorrorCommand("/html/body/div[3]/div/div[2]/div[3]/div[1]/div/div[3]/div/div[position()>0]", "https://www.imdb.com/search/title/?title_type=feature&genres=horror&sort=user_rating,desc"));
            _invoker.ExecuteCommand();

            Assert.AreEqual(50, Render.GetMovieList().Count);
        }

        [TestMethod]
        public void TestDramaCommand()
        {
            Render.SetDataGrid(dataGrid);

            _invoker.SetCommand(new DramaCommand("/html/body/div[3]/div/div[2]/div[3]/div[1]/div/div[3]/div/div[position()>0]", "https://www.imdb.com/search/title/?title_type=feature&genres=drama&sort=user_rating,desc"));
            _invoker.ExecuteCommand();

            Assert.AreEqual(50, Render.GetMovieList().Count);
        }

        [TestMethod]
        public void TestRomanceCommand()
        {
            Render.SetDataGrid(dataGrid);

            _invoker.SetCommand(new RomanceCommand("/html/body/div[3]/div/div[2]/div[3]/div[1]/div/div[3]/div/div[position()>0]", "https://www.imdb.com/search/title/?title_type=feature&genres=romance&sort=user_rating,desc"));
            _invoker.ExecuteCommand();

            Assert.AreEqual(50, Render.GetMovieList().Count);
        }

        [TestMethod]
        public void TestSciFiCommand()
        {
            Render.SetDataGrid(dataGrid);

            _invoker.SetCommand(new ScifiCommand("/html/body/div[3]/div/div[2]/div[3]/div[1]/div/div[3]/div/div[position()>0]", "https://www.imdb.com/search/title/?title_type=feature&genres=sci-fi&sort=user_rating,desc&explore=genres"));
            _invoker.ExecuteCommand();

            Assert.AreEqual(49, Render.GetMovieList().Count);
        }
    }
}
