/**************************************************************************
 *                                                                        *
 *  File:        FormSciFi.cs                                             *
 *  Copyright:   (c) 2022, Prioteasa Ioana Cristina                       *
 *  E-mail:      ioana-cristina.prioteasa@student.tuiasi.ro               *
 *  Description: Class rendering the Sci-Fi Movie child form and the      *
 *  logic behind it.                                                      *
 *                                                                        *
 *                                                                        *
 *  This code and information is provided "as is" without warranty of     *
 *  any kind, either expressed or implied, including but not limited      *
 *  to the implied warranties of merchantability or fitness for a         *
 *  particular purpose. You are free to use this source code in your      *
 *  applications as long as the original copyright notice is included.    *
 *                                                                        *
 **************************************************************************/
using Filter;
using RenderMovieList;
using System.Windows.Forms;
using WebCrawler;

namespace ProiectIp.Forms
{
    /// <summary>
    /// Clasa pentru form-ul copil a filmelor SF
    /// </summary>
    public partial class FormScifi : Form
    {
        /// <summary>
        /// Variabile private
        /// </summary>
        private WebCrawlerInterface _invoker;
        private ExtendedTextBox _searchBox;
        /// <summary>
        /// Constructorul clasei pentru FormScifi
        /// </summary>
        public FormScifi()
        {
            InitializeComponent();

            _searchBox = new ExtendedTextBox();

            _searchBox.Width = 450;
            _searchBox.Height = 16;
            _searchBox.Left = 170;
            _searchBox.Top = 23;
            _searchBox.Text = "";

            _searchBox.KeyDown += new KeyEventHandler(TextBox_KeyDown);
            _searchBox.KeyUp += new KeyEventHandler(TextBox_KeyUp);

            Controls.Add(_searchBox);
            _searchBox.BringToFront();

            Subscriber _subscriber = new Filter.Filter();
            _searchBox.AddSubscriber(_subscriber);

            Render.SetDataGrid(movie_grid);
            Render.SetDescriptionBox(descriptionBox);

            _invoker = new WebCrawlerImplementation();

            _invoker.SetCommand(new ScifiCommand("/html/body/div[3]/div/div[2]/div[3]/div[1]/div/div[3]/div/div[position()>0]", "https://www.imdb.com/search/title/?title_type=feature&genres=sci-fi&sort=user_rating,desc&explore=genres"));
            _invoker.ExecuteCommand();
        }
        /// <summary>
        /// Clasa pentru incarcarea culorii tematice
        /// </summary>
        public void LoadTheme()
        {
            searchPanel.BackColor = ThemeColor.ChangeBrightness(ThemeColor.primaryColor, 0.5);
            searchLabel.BackColor = ThemeColor.ChangeBrightness(ThemeColor.primaryColor, 0.5);
        }
        /// <summary>
        /// Metoda pentru notificarea observerului la apasarea unei taste
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            _searchBox.Notify();
        }
        /// <summary>
        /// Metoda pentru notificarea observerului la eliberarea unei taste
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            _searchBox.Notify();
        }
        /// <summary>
        /// Metoda apelata automat la apasarea unei linii din tabelul de filme
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Movie_grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Render.RenderDescription(movie_grid.SelectedRows[0].Index);
        }
    }
}
