using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RenderMovieList;

namespace Filter
{
    public class Filter : Subscriber
    {
        public void Update(string cautare)
        {

            List<Movie> optionList = MovieList.GetInstance().GetMovies();
            List<Movie> found = new List<Movie> { };

            if(cautare == "")
            {
                Render.RenderMovies(optionList);
                return;
            }

            for (int i = 0; i < optionList.Count; i++)
            {
                if (optionList[i].Title.StartsWith(cautare))
                {
                    found.Add(optionList[i]);
                }
            }
            Render.RenderMovies(found);
        }
    }
}
