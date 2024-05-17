

namespace CarConnect.Model
{
    public  class Vehicle
    {
        private int vehicleID;
        private string model;
        private string make;
        private DateTime year;
        private string color;
        private string registrationNumber;
        private int availability;
        private double dailyRate;

       
        public Vehicle()
        {
        }

        
        public Vehicle(int vehicleID, string model, string make, DateTime year, string color, string registrationNumber, int availability, double dailyRate)
        {
            this.vehicleID = vehicleID;
            this.model = model;
            this.make = make;
            this.year = year;
            this.color = color;
            this.registrationNumber = registrationNumber;
            this.availability = availability;
            this.dailyRate = dailyRate;
        }

        
        public int VehicleID
        {
            get { return vehicleID; }
            set { vehicleID = value; }
        }

      
        public string Model
        {
            get { return model; }
            set { model = value; }
        }

       
        public string Make
        {
            get { return make; }
            set { make = value; }
        }

        
        public DateTime  Year
        {
            get { return year; }
            set { year = value; }
        }

        
        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        
        public string RegistrationNumber
        {
            get { return registrationNumber; }
            set { registrationNumber = value; }
        }

       
        public int Availability
        {
            get { return availability; }
            set { availability = value; }
        }

       
        public double  DailyRate
        {
            get { return dailyRate; }
            set { dailyRate = value; }
        }

        public override string ToString()
        {
            return $"VehicleID: {VehicleID}, Model: {Model}, Make: {Make}, Year: {Year}, Color: {Color}, RegistrationNumber: {RegistrationNumber}, Availability: {Availability}, DailyRate: {DailyRate:C}";
        }
        //(Availability ? "Available" : "Not Available")
    }
}
