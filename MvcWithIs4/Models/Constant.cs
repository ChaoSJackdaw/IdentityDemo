using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWithIs4.Models
{
    public class Constant
    {
        public static string connectString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Is4;
                                                Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;
                                                ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    }
}
