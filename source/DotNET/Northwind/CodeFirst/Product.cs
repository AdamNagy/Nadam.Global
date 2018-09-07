using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Northwind.CodeFirst
{

    
    public partial class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public Nullable<int> SupplierID { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public string QuantityPerUnit { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public Nullable<short> UnitsInStock { get; set; }
        public Nullable<short> UnitsOnOrder { get; set; }
        public Nullable<short> ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual ICollection<Order_Detail> Order_Details { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}