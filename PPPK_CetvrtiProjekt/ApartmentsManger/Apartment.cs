//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApartmentsManger
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Apartment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Apartment()
        {
            this.UploadedFiles = new HashSet<UploadedFile>();
            this.Rooms = new HashSet<Room>();
        }
    
        public int IDApartment { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage ="Address cannot be longer than 50 chars.")]
        public string Address { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "City cannot be longer than 20 chars.")]
        public string City { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Contact cannot be longer than 50 chars.")]
        public string Contact { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UploadedFile> UploadedFiles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
