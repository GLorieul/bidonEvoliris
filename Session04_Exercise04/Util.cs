using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session04_Exercise04
{
    class TimeSpan
    {
        public DateTime start { get; set; }
        public DateTime end { get; set; }

        public TimeSpan() { }
        public TimeSpan(DateTime startDate, DateTime endingDate)
        {
            this.start = startDate;
            end = endingDate;
        }
    }

    /// Marks given to students once a training has been completed
    class Mark
    {
        private Nullable<int> _mark;

        public Mark() { _mark = null; }

        public Mark(int mark)
        {
            bool isAValidMark = (mark >= 0) && (mark <= 20);
            this._mark = (isAValidMark ? (int?)mark : null);
        }
    }
}
