/**************************************************************************
 *                                                                        *
 *  File:        Form1.cs                                                 *
 *  Copyright:   (c) 2022, Prioteasa Ioana Cristina                       *
 *  E-mail:      ioana-cristina.prioteasa@student.tuiasi.ro               *
 *  Description: Class for rendering the main form of the application and *
 *  the logic behind it.                                                  *
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
using System.Drawing;
using System.Windows.Forms;

namespace ProiectIp
{
    
    /// <summary>
    /// Clasa pentru construirea main form-ului aplicatiei
    /// </summary>
    public partial class Form1 : Form
    {
        private Button _currentButton;
        private Random _random;
        private int _tempIndex;
        private Form _activeForm;

        /// <summary>
        /// Constructorul clasei
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            _random = new Random();
            closeChildBtn.Visible = false;
        }

        /// <summary>
        /// Metoda care returnează o culoare generata aleator pentru tema 
        /// </summary>
        /// <returns>Culoarea corespunzatoarei teme</returns>
        private Color SelectThemeColor()
        {
            int index = _random.Next(ThemeColor.colorList.Count);
            //generam pana vom obtine alta culoare decat cea precedeta
            while(_tempIndex == index)
            {
                index = _random.Next(ThemeColor.colorList.Count);
            }
            
            _tempIndex = index;
            return ColorTranslator.FromHtml(ThemeColor.colorList[index]);

        }

        /// <summary>
        /// Metoda pentru activarea butonului apasat
        /// </summary>
        /// <param name="btnSender">butonul apasat</param>
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if(_currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    _currentButton = (Button)btnSender;
                    _currentButton.BackColor = color;
                    _currentButton.ForeColor = Color.White;
                    _currentButton.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    titlePanel.BackColor = color;
                    logoPanel.BackColor = ThemeColor.ChangeBrightness(color, -0.3);
                    ThemeColor.primaryColor = color;
                    ThemeColor.secondaryColor = ThemeColor.ChangeBrightness(color, -0.3);
                    closeChildBtn.Visible = true;

                }
            }
        }

        /// <summary>
        /// Metoda care dezactiveaza toate butoanele din form
        /// </summary>
        private void DisableButton()
        {
            foreach( Control prevBtn in menuPanel.Controls)
            {
                if(prevBtn.GetType() == typeof(Button))
                {
                    prevBtn.BackColor = Color.FromArgb(69, 54, 67);
                    prevBtn.ForeColor = Color.Lavender;
                    prevBtn.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        /// <summary>
        /// Metoda pentru afisarea unui form copil
        /// </summary>
        /// <param name="btnSender">butonul apasat</param>
        /// <param name="child">form-ul copil ce trebuie deschis</param>
        private void OpenChildForm(Form child, object btnSender)
        {
            if(_activeForm != null)
            {
                _activeForm.Close();
            }
            ActivateButton(btnSender);
            _activeForm = child;
            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            child.Dock = DockStyle.Fill;
            this.desktopPanel.Controls.Add(child);
            this.desktopPanel.Tag = child;
            child.BringToFront();
            child.Show();
            titleLabel.Text = _currentButton.Text.ToUpper();
        }
        /// <summary>
        /// Metoda apelata automat la apasarea butonului comedyBtn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComedyBtn_Click(object sender, EventArgs e)
        {
            Forms.FormComedy f = new Forms.FormComedy();
            OpenChildForm(f, sender);
            f.LoadTheme();

        }
        /// <summary>
        /// Metoda apelata automat la apasarea butonului romanceBtn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RomanceBtn_Click(object sender, EventArgs e)
        {
            Forms.FormRomance f = new Forms.FormRomance();
            OpenChildForm(f, sender);
            f.LoadTheme();

        }
        /// <summary>
        /// Metoda apelata automat la apasarea butonului dramaBtn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DramaBtn_Click(object sender, EventArgs e)
        {
            Forms.FormDrama f = new Forms.FormDrama();
            OpenChildForm(f, sender);
            f.LoadTheme();
        }
        /// <summary>
        /// Metoda apelata automat la apasarea butonului horrorBtn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HorrorBtn_Click(object sender, EventArgs e)
        {
            Forms.FormHorror f = new Forms.FormHorror();
            OpenChildForm(f, sender);
            f.LoadTheme();
        }
        /// <summary>
        /// Metoda apelata automat la apasarea butonului scifiBtn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScifiBtn_Click(object sender, EventArgs e)
        {
            Forms.FormScifi f = new Forms.FormScifi();
            OpenChildForm(f, sender);
            f.LoadTheme();
        }
        /// <summary>
        /// Metoda apelata automat la apasarea butonului de inchidere a form-ului copil, pentru a reveni in HOME
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void CloseChildBtn_Click(object sender, EventArgs e)
        {
            if(_activeForm != null)
            {
                _activeForm.Close();
            }
            Reset();
        }
        /// <summary>
        /// Metoda pentru revenirea interfetei la pagina HOME
        /// </summary>
        private void Reset()
        {
            DisableButton();
            titleLabel.Text = "HOME";
            titlePanel.BackColor = Color.FromArgb(147, 149, 211);
            menuPanel.BackColor = Color.FromArgb(69, 54, 67);
            logoPanel.BackColor = Color.FromArgb(38, 38, 44);
            _currentButton = null;
            closeChildBtn.Visible = false;
        }
        /// <summary>
        /// Metoda pentru afisarea fisierului help
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HelpBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Help.ShowHelp(this, "C:/Users/Gabi/Desktop/Facultate/IP/ProiectIP-versiuni/WebCrawler - v4/HelpFiles/Proiect.chm");
            }
            catch(Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
            }
            
        }

    }
}
