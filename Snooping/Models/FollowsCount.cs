//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Snooping.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class FollowsCount
    {
        public int UserInfoID { get; set; }
        public int FollowersCount { get; set; }
        public int FollowedCount { get; set; }
    
        public virtual UsersInfo UsersInfo { get; set; }
    }
}
