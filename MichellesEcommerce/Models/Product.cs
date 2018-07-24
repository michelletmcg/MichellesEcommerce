using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; /*using added by coding attribute [Key]*/
using System.Linq;
using System.Web;

namespace MichellesEcommerce.Models
{
    /// <summary>
    /// REpresents a sellable product
    /// </summary>
    public class Product
    {
        //What is the difference between a reference type vs. value type???????????????????????
        
        [Key] //Makes the property the primary key PK
        //If PK property is an integer, it wil be an identity column by default |**IDENTITY COLUMNS AUTO-INCREMENT***
        public int ProductID { get; set; }

        //to make sure in the database that this name is required
        [Required] //by default strings become nvarchar [max] which is 2GB!! TOO LARGE! Just for a name! NO!
        [StringLength(40)] //here we give a maximum string length of 40 characters
        public string Name { get; set; }

        //Price will always automatically be required because it is a value type as opposed to a reference type 
        //primitive types do not allow nulls?
        //reference types allow nulls
        [Range(0, 100000)] //or you can code double.MaxValue
        [DataType(DataType.Currency)] //we set the data type to currency for this property
        public double Price { get; set; }

        ///TODO: add description
        

    }
}