using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mvcLibrary.Models.Entity;

namespace mvcLibrary.Models.Classes
{
    public class Class1
    {
        public IEnumerable<TblBook> Books { get; set; }
        public IEnumerable<TblAbout> About { get; set; }
    }
    
}