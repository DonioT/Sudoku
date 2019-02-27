using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuWF
{
    public class Cell
    {
        public int column { get; set; }
        public int row { get; set; }
        public int value { get; set; }
        public List<int> validMoves { get; set; }
        public int CountValuesPreviouslyTried { get; set; }
    }
}
