using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace name_sorter_ClassLibrary1
{
    /// <summary>
    /// Holds a collection of Fullname objects and can return entries (of type Fullname) sorted by Lastname, Givennames
    /// Can be created from a file
    /// </summary>
    public class FullnameCollection : List<Fullname>
    {     
        /// <summary>
        /// Create an empty collection of Fullname
        /// </summary>
        public FullnameCollection()
        {
        }

        /// <summary>
        /// Create new FullnameCollection from List of Fullname
        /// </summary>
        /// <param name="sortedNames"></param>
        public FullnameCollection(List<Fullname> names) : base(names)
        {
        }      
    }
}
