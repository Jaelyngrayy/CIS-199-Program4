//Grading ID: R5560;
// Prorgam 4
// Due Date: April 18, 2021 (April 20, 2021)
//Course Section: CIS-199-01
//Description: Program has a class for repair properties that are used to make a record of the repairs. 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


class RepairRecord
{
    //Constructor that holds int, string, and bool variables
    //Precondition: 00000 <= zipCode <= 99999
    //              modelYear int
    //              makeAndModel not empty
    //              serial.Length = 10
    //              15 <= length <= 180
    //              name not empty
    //              warranty true or false
    //Postcondition: RepairRecord object has been initialized with the specified zipCode, year, makeandModel, 
    //               serial number, appointmentlength, tehcnician name, and warranty
    public RepairRecord(int zipCode, int year, string makeAndModel, string serial,  int length, string name, bool warranty)
    {
        ServiceLocationZipCode = zipCode; // set the ServiceLocationZipCode property
        ModelYear = year; // set the ModelYear property
        MakeModel = makeAndModel; //set the MakeModel property
        SerialNumber = serial; //set the SerialNumber property
        AppointmentLength = length; //Set the appointmentLength property
        TechnicianName = name; //set the TechnicianName property
        WarrantyCoverage = warranty; //set the WarrantyCovereage property
    }

    private int serviceLocationZipCode; // 00000 - 99999
    private string makeModel; // not blank
    private string serialNumber; //.Length = 10
    private string technicianName; //Not blank
    private int appointmentLength; // 15-180
    private double appointmentHours; //found by dividng AppointmentLength by HOUR(60).
    private bool warrantyCoverage; //initializes warranty coverage. Differnt name than the property  ^^^

    public const int ZIP_LOWER = 00000; //Lower limit of zipcode 
    public const int ZIP_HIGHER = 99999; //upper limit of zipcode
    public const int ZIP_DEFAULT = 40204; //default zip code given if zip is not in the limits above
    public const string MODEL_DEFAULT = "Unknown Make/Model"; //default model if model is blank
    public const string SERIAL_DEFAULT = "A000000000"; //defualt serial number if serial number is not 10 characters long
    public const string TECHNICIAN_DEFAULT = "John Smith";//default technician name if name is blank
    public const int LENGTH_UPPER = 180; //upper limit of appointment length
    public const int LENGTH_LOWER = 15; //lower limit of appointment length
    public const int LENGTH_DEFAULT = 30; //default appointment length if not in the limits above
    public const int FLAT_FEE = 25; //flat fee applied for every repair
    public const double PER_MINUTE = 1.50; //price per minute of repair
    public const int WARRANTY_COVERAGE = 20; //if warranty is true, this is final price of repair
    public const int HOUR = 60; //used to divide appoitnment length by to find how many hours each repair will take

    public int ServiceLocationZipCode
    {
        // Precondition: None
        // Postcondition: The zip code has been returned
        get
        {
            return serviceLocationZipCode;
        }

        // Precondition: 00000 <= value <= 99999
        // Postcondition: serviceLocationZipCode has been set to the specified value
        set
        {
            if (value > ZIP_LOWER && value < ZIP_HIGHER)
                serviceLocationZipCode = value;
            else //when invalid, set to default
                serviceLocationZipCode = ZIP_DEFAULT;
        }
    }

    public string MakeModel
    {
        // Precondition: None
        // Postcondition: The makeModel has been returned
        get
        {
            return makeModel;
        }

        // Precondition: value not blank
        // Postcondition: The makeModel has been set to the specified value
        set
        {
            if (String.IsNullOrWhiteSpace(value)) //invalid
                makeModel = MODEL_DEFAULT;
            else //when valid, set to value
                makeModel = value;
        }
    }

    public string SerialNumber
    {

        // Precondition: None
        // Postcondition: The serial number has been returned
        get
        {
            return serialNumber;
        }

        // Precondition: value.Length = 10
        // Postcondition: The serial number has been set to the specified value
        set
        {
            if (value.Length == 10)
                serialNumber = value;
            else //when invalid, set to default
                serialNumber = SERIAL_DEFAULT;
        }
    }

    public string TechnicianName
    {

        // Precondition: None
        // Postcondition: The technician name has been returned
        get
        {
            return technicianName;
        }

        // Precondition: value is not  blank
        // Postcondition: The technician name has been set to the specified value
        set
        {
            if (string.IsNullOrWhiteSpace(value)) //invalid
                technicianName = TECHNICIAN_DEFAULT;
            else //when valid, set to value
                technicianName = value;
        }
    }

    public int AppointmentLength
    {

        // Precondition: None
        // Postcondition: The appointment length has been returned
        get
        {
            return appointmentLength;
        }

        // Precondition: 15 <= value <= 180
        // Postcondition: the appointment length has been set to the specified value
        set
        {
            if (value >= LENGTH_LOWER && value <= LENGTH_UPPER)
                appointmentLength = value;
            else //when invalid, set to default
                appointmentLength = LENGTH_DEFAULT;
        }
    }
    //Precondition: None
    //Post condition model year has been returned

    //Precondition: None
    //Postcondition: model year has been set to the specified value
    public int ModelYear { get; set; }
    public bool WarrantyCoverage
    {

        // Precondition: None
        // Postcondition: The warranty coverage has been returned
        get
        {
            return warrantyCoverage;
        }

        // Precondition: None
        // Postcondition: The warranty coverage has been set to the specified value
        set
        {
            warrantyCoverage = value;
        }
    }

    public double AppointmentHours
    {

        //Precondition: appointment length divided by 60
        //Postcondition: the appointment hours has been returned
        get
        {
            double appointmentLengthDouble = Convert.ToDouble(appointmentLength);
            appointmentHours = appointmentLengthDouble / HOUR;
            return appointmentHours;
        }
    }

    // Precondition: None
    // Postcondition: cost of repair outputted
    public double CalcCost() //method that calculates cost of the repair by using values
    {
        double cost;
        if (WarrantyCoverage == false)
        {
            cost = FLAT_FEE + (PER_MINUTE * AppointmentLength);
            return cost;
        }
        else //if they have a warranty
        {
            cost = WARRANTY_COVERAGE;
            return cost;
        }
    }

    //Precondition: None
    //Postcondition: a string is returned in desired format
    public override string ToString()
    {
        return "Service Location Zip Code: " + ServiceLocationZipCode + 
            "\nYear: " + ModelYear + 
            "\nMake and Model: " + MakeModel + 
            "\nSerial Number: " + SerialNumber +
            "\nAppointment Length: " + AppointmentLength + 
            "\nAppointment Hours: " + AppointmentHours +
            "\nTechnician Name: " + TechnicianName +  
            "\nWarranty Coverage: " + WarrantyCoverage;
    }

}

class Program
{
    // Precondition: None
    // Postcondition: Outputs Array in desired format with cost 
    public static void OutputRepairRecords(RepairRecord[] records)
    {
        for (int x = 0; x < records.Length; x++)
        {
            WriteLine(records[x].ToString());
            WriteLine("Calculate Cost Output: " + records[x].CalcCost());
            WriteLine("");
        }
    }

    // Precondition: None
    // Postcondition: Creates array and inputs values into it, then runs the OutputRepairRecords method
    static void Main()
    {
        RepairRecord[] Records = new RepairRecord[6];
        Records[0] = new RepairRecord(41051, 2011, "Ford F150", "C493768459", 45, "Bob Jones", false);
        Records[1] = new RepairRecord(40203, 2005, "Toyota Matrix", "C857395785", 60, "Monica Fitzgeral", true);
        Records[2] = new RepairRecord(40202, 2019, "Tesla Model 3", "C583953958", 15, "Bob Jones", false);
        Records[3] = new RepairRecord(40208, 2020, "Mclaren F1", "C968486749", 120, "Mike Lewis", true);
        Records[4] = new RepairRecord(40212, 2500, "Gallifreyan Tardis", "C968857575", 150, "The Doctor", true);
        Records[5] = new RepairRecord(40211, 3600, "Correllian Tie Fighter", "C565756555", 80, "Luke Skywalker", false);
        OutputRepairRecords(Records);

        WriteLine("________________________________________________");
        WriteLine();

        Records[0].ServiceLocationZipCode = 40231;
        Records[1].ModelYear = 2022;
        Records[2].MakeModel = "Toyota Camry";
        Records[3].SerialNumber = "C987654321";
        Records[4].AppointmentLength = 180;
        Records[5].TechnicianName = "Eren Yeager";
        OutputRepairRecords(Records);


    }


}





