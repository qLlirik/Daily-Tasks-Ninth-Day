using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinthDay.DB
{
    partial class Taxpayers
    {
        public string FullName
        {
            get
            {
                return LastName + ' ' + FirstName + ' ' + Patronymic;
            }
        }
    }
}
