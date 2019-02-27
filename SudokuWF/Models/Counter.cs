using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuWF.Models
{
    public class Counter
    {
        private int counter;
        public Counter()
        {
            counter = 0;
        }
        public int getCounter()
        {
            return this.counter;
        }
        public void setCounter(int val)
        {
            this.counter = val;
        }

        public void incrementCounter()
        {
            counter = counter + 1;
        }

        public void decrementCounter()
        {
            counter = counter - 1;
        }
    }
}
