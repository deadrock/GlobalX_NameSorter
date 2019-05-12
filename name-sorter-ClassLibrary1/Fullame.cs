using System;
using System.Collections.Generic;
using System.Text;

namespace name_sorter_ClassLibrary1
{
    /// <summary>
    /// Holds a name that has 2 to 4 words in it.
    /// </summary>
    public class Fullname
    {
        /// <summary>
        /// Store of the original string used to create this object
        /// </summary>
        private string originalName;
        
        /// <summary>
        /// store of the parts of the name split up into words.  The last entry is the Lastname and others are all a givenname (of which there may be 1 to 3)
        /// </summary>
        private string[] nameParts = null;

        /// <summary>
        /// Create a Fullname from a string
        /// </summary>
        /// <param name="name">String containing 2 to 4 words with the last considured to be the Lastname and others are all part of Givennames</param>
        public Fullname(string name)
        {
            if ( name == null )
            {
                throw new ArgumentNullException("name must not be null");
            }
            this.originalName = name;  // save as given with any leading trailing spaces and any double spacing.

            // remove any double spacing that may be in the supplied name.
            string name_withoutspaces = name;
            while (name_withoutspaces.Contains("  "))
            {
                name_withoutspaces = name_withoutspaces.Replace("  ", " ");  
            }

            // Trim it to remove leading and trailing spaces and split into array of single names
            nameParts = name_withoutspaces.Trim().Split(" ");
            if( nameParts.Length < 2 )  
            {   // should may 2 names being at least one first name and a last name
                throw new ArgumentOutOfRangeException($"supplied name doed not have a first and last name. [{name}]");
            }
            if (nameParts.Length > 4)
            {   // must not have more that 3 first names
                throw new ArgumentOutOfRangeException($"supplied name has too many first names. [{name}]");
            }
        }
        
        /// <summary>
        /// Return only the Lastname part of the Fullname
        /// </summary>
        public string Lastname { get { return this.nameParts[ this.nameParts.Length -1]; } }
        
        /// <summary>
        /// Return all the names except the Lastname
        /// </summary>
        public string Givennames {
            get {
                var result = nameParts[0];  // will always have at least this first name [0]
                for ( int i = 1; i< nameParts.Length - 1; i++)
                {
                    result += " " + nameParts[i];  // add on the second thirs etc given names.  do not add on the last name.
                }
                return result;
            }
        }

        /// <returns>Returns the original string used to build this Fullname</returns>
        public override string ToString()
        {  
            return this.originalName;
        }
    }
}
