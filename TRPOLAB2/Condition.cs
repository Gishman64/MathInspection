using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPOLAB2
{
    class Condition
    {
        private Line line;
        private int position;
        private bool isCritical;
        public Condition(Line line, int position, bool critical) {
            this.Line = line;
            this.Position = position;
            this.IsCritical = critical;
        }

        public int Position { get => position; set => position = value; }
        public bool IsCritical { get => isCritical; set => isCritical = value; }
        internal Line Line { get => line; set => line = value; }
    }
}
