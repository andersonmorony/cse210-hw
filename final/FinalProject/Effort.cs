using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class Effort
    {
        protected int _effort;
        protected int _effortToUse;

        public Effort()
        {
            DefaultEffort();
        }
        public int GetEffort()
        {
            return _effort;
        }
        public int GetEffortUsed()
        {
            return _effortToUse;
        }
        public void SetEffort()
        {
            _effortToUse -= 1;
        }
        private void DefaultEffort()
        {
            string[] types = { "default", "shiny" };
            Random rnd = new Random();
            int index = rnd.Next(types.Length);

            if (types[index] == "default")
            {
                _effort = 5;
                _effortToUse = 5;
            }
            else
            {
                _effort = 10;
                _effortToUse = 10;
            }
        }
    }
}
