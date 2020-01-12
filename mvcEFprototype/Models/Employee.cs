namespace mvcEFprototype.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        [Key]
        public int Id { get; set; }

 
        public string FirstName { get; set; }

    
        public string LastName { get; set; }

        public Nullable<int> Age { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
     
        public string Position { get; set; }

      
        public string Office { get; set; }

        [DataType(DataType.Currency)]
        public Nullable<decimal> Salary { get; set; }

        [DataType(DataType.Upload)]
        public byte[] UploadFile { get; set; }

        public string UploadFilename { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime DOB { get; set; }

    }
}
