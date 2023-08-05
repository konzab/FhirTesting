using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using Hl7.Fhir.Serialization;

internal class Program
{
    //  private const string _fhir_Server = "https://fhirdemooneservice.azurewebsites.net";
    private const string _fhir_Server = "https://server.fire.ly/";
    private static void Main(string[] args)
    {
        
        Console.WriteLine("Hello, World!");

        FhirClient client = new FhirClient(_fhir_Server)
        {
            //   = ResourceFormat.Json,
            //  PreferredReturn = Prefer.ReturnRepresentation
        };

        Bundle patientsBundle = client.Search<Patient>(new string[] {"name=test"});

        Console.WriteLine($@"Total Patients : {patientsBundle.Total}");

        foreach (Bundle.EntryComponent entry in patientsBundle.Entry)
        {   
            if(entry.Resource != null) 
            {
                Console.WriteLine($@"{entry.FullUrl}");
                Patient patient = (Patient)entry.Resource;

                if (patient.Name.Count >= 1)
                {
                    Console.WriteLine($@"{patient.Name[0].Family.ToString()}");
                }

                
                
            }
            

        }


        Console.WriteLine("Press any key to continue.....");
        Console.ReadLine();
    }
}
