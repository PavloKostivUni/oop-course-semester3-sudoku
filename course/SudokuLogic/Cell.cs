using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course.SudokuLogic
{
    public class Cell
    {
        public int value;
        public bool isSystemGenerated;
        public Cell(int value, bool isSystemGenerated) 
        {
            this.value = value;
            this.isSystemGenerated = isSystemGenerated;
        }
    }
}
