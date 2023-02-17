/**************************************************************************
 *                                                                        *
 *  File:        WebCrawlerInterface.cs                                   *
 *  Copyright:   (c) 2022, Barbuta Delia Elena                            *
 *  E-mail:      delia-elena.barbuta@student.tuiasi.ro                    *
 *  Description: Interface for the WebCrawler                             *
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

namespace WebCrawler
{
    /// <summary>
    /// Interfata comuna implementarilor de WebCrawler
    /// </summary>
    public interface WebCrawlerInterface
    {
        /// <summary>
        /// Seteaza comanda ce va fi data in executie
        /// </summary>
        /// <param name="command"></param>
        void SetCommand(Command command);
        
        /// <summary>
        /// Porneste executia comenzii alese
        /// </summary>
        void ExecuteCommand();
    }
}
