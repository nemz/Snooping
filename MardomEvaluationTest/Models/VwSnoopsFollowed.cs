//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MardomEvaluationTest.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class VwSnoopsFollowed
    {
        public int SnoopID { get; set; }
        public string Snoop { get; set; }
        public bool Private { get; set; }
        public byte[] ImageBin { get; set; }
        public int UserFollowerID { get; set; }
        public int UserFollowedID { get; set; }
        public System.DateTime DateSnoop { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public byte[] Photo { get; set; }
    }
}
