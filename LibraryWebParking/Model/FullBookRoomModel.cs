//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibraryWebParking.Model
{
    using System;
    
    public partial class FullBookRoomModel
    {
        public int Id { get; set; }
        public Nullable<int> ClientId { get; set; }
        public Nullable<int> ParkingId { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<decimal> TotalPrice { get; set; }
        public Nullable<bool> CheckedIn { get; set; }
        public string FirstName { get; set; }
        public string LatName { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public int Id1 { get; set; }
        public string ParkingNumber { get; set; }
        public int ParkingTypeId { get; set; }
        public string Title { get; set; }
        public string Desription { get; set; }
        public decimal Price { get; set; }
    }
}
