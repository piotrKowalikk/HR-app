using HR.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_OpenIDConnect_DotNet.Models
{
    public class PagingViewModel
    {
        public IEnumerable<OfferViewModel> Offers{ get; set; }
        public int TotalPage { get; set; }
    }
}
