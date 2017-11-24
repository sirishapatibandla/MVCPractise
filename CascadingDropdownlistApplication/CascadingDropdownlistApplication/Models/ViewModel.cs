using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CascadingDropdownlistApplication.Models
{
    public class ViewModel
    {
        public  Address  AddressProperty{ get;set;}
        public List<Country> CountryProperty { get; set; }
        public List<State> StateProperty { get; set; }
        public city CityProperty { get; set; }
    }
}