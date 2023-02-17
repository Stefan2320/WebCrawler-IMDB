/**************************************************************************
 *                                                                        *
 *  File:        ThemeColor.cs                                            *
 *  Copyright:   (c) 2022, Prioteasa Ioana Cristina                       *
 *  E-mail:      ioana-cristina.prioteasa@student.tuiasi.ro               *
 *  Description: Class for monitoring and modifying the colors in the     *
 *  interface.                                                            *
 *                                                                        *
 *                                                                        *
 *  This code and information is provided "as is" without warranty of     *
 *  any kind, either expressed or implied, including but not limited      *
 *  to the implied warranties of merchantability or fitness for a         *
 *  particular purpose. You are free to use this source code in your      *
 *  applications as long as the original copyright notice is included.    *
 *                                                                        *
 **************************************************************************/

using System.Collections.Generic;
using System.Drawing;

namespace ProiectIp
{
    /// <summary>
    /// Clasa pentru stocarea listei de culori si schimbarea luminozitatii acestora, pentru tematica
    /// </summary>
    public static class ThemeColor
    {
        /// <summary>
        /// Variabile publice pentru culoarea secundara si primara
        /// </summary>
        public static Color primaryColor{get; set;}
        public static Color secondaryColor { get; set; }

        /// <summary>
        /// Lista de culori
        /// </summary>
        public static List<string> colorList = new List<string>()
        {"#A2A3BB",
         "#9395D3",
         "#B3B7EE",
         "#6D326D",
         "#DE3C4B",
         "#17B890",
         "#3E885B",
         "#B0E298",
         "#3D3B8E"
        };
        /// <summary>
        /// metoda pentru a schimba luminozitatea culorii
        /// </summary>
        /// <param name="color"> Culoarea a carei luminozitate o schimbam</param>
        /// <param name="correctionFactor">Factorul de corectie, <0 pentru o culoare mai intunecata, >0 pentru o culoare mai luminoasa</param>
        /// <returns>Culoarea modificata</returns>
        public static Color ChangeBrightness(Color color, double correctionFactor)
        {
            double red = color.R;
            double green = color.G;
            double blue = color.B;

            //<0 pentru intunecare
            if(correctionFactor < 0)
            {
                correctionFactor = 1 + correctionFactor;
                red *= correctionFactor;
                green *= correctionFactor;
                blue *= correctionFactor;
            }
            // culoare mai luminoasa
            else
            {
                red = (255 - red) * correctionFactor + red;
                green = (255 - green) * correctionFactor + green;
                blue = (255 - blue) * correctionFactor + blue;
            }
            return Color.FromArgb(color.A, (byte)red, (byte)green, (byte)blue);

        }
    }
}
