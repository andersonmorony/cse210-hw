using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Develop04
{
    public class Breathing : Activity
    {
        public Breathing(string title, string description) 
            : base(title, description)
        {

        }

        public void Start()
        {
            // Display message
            base.DisplayWelcomeMessage();
               
            DateTime current = DateTime.Now;
            DateTime futureDate = current.AddSeconds(_seconds);



            while (current < futureDate)
            {
                Console.Write("\n Breathe in...");
                base.ShowCountDown(5);
                Console.Write("\n Now Breathe out...");
                base.ShowCountDown(5);

                current = DateTime.Now;

                if(current >= futureDate)
                {
                    base.DisplayEndMessage();
                }
            }
            
            
        }

    }
}
