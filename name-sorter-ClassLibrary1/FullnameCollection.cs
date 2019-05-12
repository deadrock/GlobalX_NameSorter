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
    public class FullnameCollection
    {
        List<Fullname> _names = new List<Fullname>();

        /// <param name="path">Path to file to read a list of names from</param>
        public FullnameCollection(string path)
        {
            foreach (string line in File.ReadLines(path))
            {
                _names.Add(new Fullname(line));
            }
        }

        /// <summary>
        ///  Return all the Fullname objects not sorted
        /// </summary>
        public IEnumerable<Fullname> Names { get { return _names; } }

        /// <summary>
        /// Return all the Fullname objects sorted by Lastname, Givennames
        /// </summary>
        public IEnumerable<Fullname> ByLastnameGivenname
        {
            get
            {
                return _names.OrderBy(x => x.Lastname + x.Givennames);
            }
        }
    }
}
