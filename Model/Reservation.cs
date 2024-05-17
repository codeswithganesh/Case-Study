
namespace CarConnect.Model
{
    internal class Reservation
    {
       
            private int reservationID;
            private int customerID;
            private int vehicleID;
            private DateTime startDate;
            private DateTime endDate;
            private double totalCost;
            private string status;

            
            public Reservation()
            {
            }

            
            public Reservation(int reservationID, int customerID, int vehicleID, DateTime startDate, DateTime endDate, double totalCost, string status)
            {
                this.reservationID = reservationID;
                this.customerID = customerID;
                this.vehicleID = vehicleID;
                this.startDate = startDate;
                this.endDate = endDate;
                this.totalCost = totalCost;
                this.status = status;
            }

           
            public int ReservationID
            {
                get { return reservationID; }
                set { reservationID = value; }
            }

          
            public int CustomerID
            {
                get { return customerID; }
                set { customerID = value; }
            }

            
            public int VehicleID
            {
                get { return vehicleID; }
                set { vehicleID = value; }
            }

            
            public DateTime StartDate
            {
                get { return startDate; }
                set { startDate = value; }
            }

            
            public DateTime EndDate
            {
                get { return endDate; }
                set { endDate = value; }
            }

            
            public double TotalCost
            {
                get { return totalCost; }
                set { totalCost = value; }
            }

            
            public string Status
            {
                get { return status; }
                set { status = value; }
            }

            
            public override string ToString()
            {
                return $"ReservationID: {ReservationID}, CustomerID: {CustomerID}, VehicleID: {VehicleID}, StartDate: {StartDate}, EndDate: {EndDate}, TotalCost: {TotalCost}, Status: {Status}";
            }
        }
}
