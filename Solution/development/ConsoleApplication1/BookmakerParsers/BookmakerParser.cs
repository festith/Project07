using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.BookmakerParsers
{
    public abstract class BookmakerParser
    {
        protected NameMapper NameMapper { get; private set; }

        public BookmakerParser()
        {
            NameMapper = new NameMapper();
        }

        public abstract BookmakerMatchStatistic[] ReadBookmakerLine(string pathToFile);
    }
}
