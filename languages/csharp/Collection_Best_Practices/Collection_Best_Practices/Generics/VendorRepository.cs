using System;
using System.Collections.Generic;

namespace Generics
{
    public class VendorRepository
    {
        private List<Vendor> vendors; 
        /// <summary>
        /// Retrieve one vendor.
        /// </summary>
        /// <param name="vendorId">Id of the vendor to retrieve.</param>
        public Vendor Retrieve(int vendorId)
        {
            // Create the instance of the Vendor class
            Vendor vendor = new Vendor();

            // Code that retrieves the defined customer

            // Temporary hard coded values to return 
            if (vendorId == 1)
            {
                vendor.VendorId = 1;
                vendor.CompanyName = "ABC Corp";
                vendor.Email = "abc@abc.com";
            }
            return vendor;
        }

        public IEnumerable<Vendor> Retrieve()
        {
            if (vendors == null)
            {
                vendors = new List<Vendor>();

                vendors.Add(new Vendor()
                { VendorId = 1, CompanyName = "ABC Corp", Email = "abc@abc.com" });
                vendors.Add(new Vendor()
                { VendorId = 2, CompanyName = "XYZ Inc", Email = "xyz@xyz.com" });
            }

            for (int i = 0; i < vendors.Count; i++)
            {
                Console.WriteLine(vendors[i]);
            }

            foreach (var vendor in vendors)
            {
                //Console.WriteLine(vendor);
            }

            return vendors;
        }


        public IEnumerable<Vendor> RetrieveWithIterator()
        {
            this.Retrieve();

            foreach (var vendor in vendors)
            {
                Console.WriteLine($"Vendor Id: {vendor.VendorId}");
                yield return vendor;
            }
        } 

        public T RetrieveValue<T>(string sql, T defaultValue)
        {
            // Call the database to retrieve the value
            // If no value is returned, return the default value
            T value = defaultValue;

            return value;
        }









        /// <summary>
        /// Save data for one vendor.
        /// </summary>
        /// <param name="vendor">Instance of the vendor to save.</param>
        /// <returns></returns>
        public bool Save(Vendor vendor)
        {
            var success = true;

            // Code that saves the vendor

            return success;
        }
    }

}