using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class Animation
    {
        public void ShowAnimation(int seconds)
        {
            DateTime current = DateTime.Now;
            DateTime FutureDate = current.AddSeconds(seconds);
            List<string> charAnimation = new List<string>
            {
                "-",
                "\\",
                "|",
                "/",
                "-",
                "\\",
                "|",
                "/"
            };

            while (current < FutureDate)
            {
                foreach (string item in charAnimation)
                {
                    Console.Write(item);
                    Thread.Sleep(200);
                    Console.Write("\b \b");
                }
                current = DateTime.Now;
            }
        }
    }
}
