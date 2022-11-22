using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Database
{
    public class DBConnectionFactory
    {

        public DBConnectionWrapper GetConnectionWrapper()
        {
            return new DBConnectionWrapper("dbenergy");
        }

    }
}
