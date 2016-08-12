using System;
using System.Collections;
using System.Collections.Generic;

namespace Library
{
    public class StandardCatalog : ISaveable, IPersistable
    {
        public void Load()
        {
        }

        public string Save()
        {
            return "Catalog Save";
        }
    }

    public class ExplicitCatalog : ISaveable, IPersistable
    {
        public string Save()
        {
            return "Catalog Save";
        }

        string ISaveable.Save()
        {
            return "ISaveable Save";
        }

        string IPersistable.Save()
        {
            return "IPersistable Save";
        }
    }

    public class EnumerableCatalog : IEnumerable<string>
    {
        public IEnumerator<string> GetEnumerator()
        {
            return null;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}