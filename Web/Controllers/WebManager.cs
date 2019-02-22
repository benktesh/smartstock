using System;
using System.Collections.Generic;

namespace Web
{
    public interface IWebManager
    {
        String GetValue();
    }

    public class WebManager:IWebManager
    {
        public String GetValue()
        {
            var data = new List<String>();
            Random randm = new Random();
            for (int i = 0; i < randm.Next(2, 12); i++)
            {
                data.Add(randm.Next().ToString());
            }
            return String.Join(' ', data);
        }
    }
}