//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLBaiDoXe.ParkingLotModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vehicle
    {
        public int VehicleID { get; set; }
        public int VehicleTypeID { get; set; }
        public long ParkingCardID { get; set; }
        public System.DateTime TimeStartedParking { get; set; }
        public Nullable<System.DateTime> TimeEndedParking { get; set; }
        public int VehicleState { get; set; }
        public string VehicleImage { get; set; }
        public int Fee { get; set; }
        public int StaffID { get; set; }
    
        public virtual Staff Staff { get; set; }
        public virtual VehicleType VehicleType { get; set; }
    }
}
