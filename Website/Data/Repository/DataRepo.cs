using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Website.Data.Repository
{
    public class DataRepo : IDataRepo
    {
        private ApplicationDbContext _ctx;

        public DataRepo(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
    }
}
