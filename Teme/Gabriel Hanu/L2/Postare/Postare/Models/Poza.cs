//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FirstDbModel.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Poza
    {
        public int Id { get; set; }
        public int PostareId { get; set; }
        public string DrumSprePoza { get; set; }
    
        public virtual Postare Postare { get; set; }
    }
}
