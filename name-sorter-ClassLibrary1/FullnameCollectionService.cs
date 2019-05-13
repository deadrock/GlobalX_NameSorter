using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace name_sorter_ClassLibrary1
{
    /// <summary>
    /// provides IO and sort services for the FullnameCollection class
    /// </summary>
    public class FullnameCollectionService
    {
        /// <summary>
        /// Create new FullnameCollection with names sorted from supplied FullnameCollection    
        /// </summary>
        /// <param name="fullnameCollection"></param>
        /// <returns>new FullnameCollection</returns>
        public FullnameCollection SortByLastnameGivenname(FullnameCollection fullnameCollection)
        {
            var sortedNames = fullnameCollection.OrderBy(x => x.Lastname + x.Givennames).ToList();
            return new FullnameCollection(sortedNames);
        }

        /// <summary>
        /// Create new FullnameCollection from file.
        /// </summary>
        /// <param name="path">Path to file to read a list of names from</param>
        public FullnameCollection LoadFromFile(string path)
        {
            var names = new List<Fullname>();
            foreach (string line in System.IO.File.ReadLines(path))
            {
                names.Add(new Fullname(line));              
            }
            return new FullnameCollection(names);
        }

        /// <summary>
        /// Write all Fullnames in the supplied FullnameCollection to a Streamwriter
        /// </summary>
        /// <param name="stream">Streamwriter to write all Fullnames to.</param>
        public void WriteToStream(FullnameCollection collection, System.IO.TextWriter stream)
        {
            // get each Fullname and output each to the stream.
            foreach (var name in collection)
            {
                stream.WriteLine(name.ToString());
            }
        }


        /// <summary>
        /// Write all Fullnames in the supplied FullnameCollection to a file.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public void WriteToFile(FullnameCollection collection, string path)
        {
            using (System.IO.StreamWriter outputStream = new System.IO.StreamWriter(path))
            {
                WriteToStream(collection, outputStream);
            }
        }

    }
}
