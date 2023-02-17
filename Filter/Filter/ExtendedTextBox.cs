using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Filter
{
    public class ExtendedTextBox : TextBox
    {
        List<Subscriber> _subscriberList;
        int _subscriber = 0;
        public ExtendedTextBox() : base()
        {
            _subscriberList = new List<Subscriber> { };
        }
        public void AddSubscriber(Subscriber newSubscriber)
        {
            _subscriberList.Add(newSubscriber);
            _subscriber++;
        }

        public List<Subscriber> GetSubscribers()
        {
            return _subscriberList;
        }

        public void Notify()
        {
            string cautare = Text.ToString();
            for (int i = 0; i < _subscriber; i++)
            {
                _subscriberList[i].Update(cautare);
            }
        }

        public void DeleteSubscriber(Subscriber delSubscriber)
        {
            for (int i = 0; i < _subscriber; i++)
            {
                if (_subscriberList[i] == delSubscriber)
                {
                    _subscriber--;
                    _subscriberList.RemoveAt(i);
                }
            }
        }


    }
}
