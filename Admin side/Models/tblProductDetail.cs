//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System.Web;
namespace Admin_side.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
   
    public partial class tblProductDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblProductDetail()
        {
            this.tblCategoryDetails = new HashSet<tblCategoryDetail>();
        }
    
        public int ProductID { get; set; }
         [Required(ErrorMessage = "PRODUCT NAME REQUIRED")]
        public string ProductName { get; set; }
        public string ImageUrl { get; set; }

        public HttpPostedFileBase Imagefile { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblCategoryDetail> tblCategoryDetails { get; set; }
    }
}
