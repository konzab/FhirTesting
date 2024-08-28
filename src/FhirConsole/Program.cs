using FhirConsole.Defaults;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using Hl7.Fhir.Serialization;

/// <summary>
/// Testing FHIR Server Connection and commands
/// </summary>
internal class Program
{
    /// <summary>
    /// Delete Patient
    /// </summary>
    /// <param name="client"></param>
    /// <param name="id"></param>
    public static async System.Threading.Tasks.Task DeletePatient(FhirClient client, string id)
    {
        try
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));

            await client.DeleteAsync($@"Patient/{id}");
        }
        catch (Exception)
        {
            throw;
        }
    }

    /// <summary>
    /// Update Fhir Patient
    /// </summary>
    /// <param name="client">Fhir cLient</param>
    /// <param name="patient">Patient</param>
    public static async System.Threading.Tasks.Task UpdatePatient(FhirClient client, Patient patient)
    {
        try
        {
            patient.Telecom.Add(new ContactPoint()
            {
                System = ContactPoint.ContactPointSystem.Phone,
                Value = "+26771649999",
                Use = ContactPoint.ContactPointUse.Home
            });
            patient.Gender = AdministrativeGender.Unknown;
            await client.UpdateAsync<Patient>(patient);
        }
        catch (Exception)
        {
            throw;
        }
    }

    /// <summary>
    /// Create Create a patient
    /// </summary>
    /// <param name="client">fhir client</param>
    /// <returns></returns>
    private static async System.Threading.Tasks.Task CreatePatient(FhirClient client)
    {
        try
        {
            await System.Threading.Tasks.Task.Run(() =>
            {
                var patient = CreatePatient(client, "Zabula", new List<string>() { "Arthur", "Lisungu" }).Result;
                if (patient != null)
                {
                    Console.WriteLine($@"Created patient : {patient.Id} with name : {patient.Name[0].FamilyElement}");
                }
            });
        }
        catch (Exception)
        {
            throw;
        }
    }

    /// <summary>
    /// Create PAtient
    /// </summary>
    /// <param name="client"></param>
    /// <param name="familyName"></param>
    /// <param name="givenNames"></param>
    /// <returns></returns>
    private static async Task<Patient> CreatePatient(FhirClient client, string familyName, List<string> givenNames)
    {
        try
        {
            Patient? patient;
            Patient toCreate = new Patient()
            {
                Name = new List<HumanName>()
                {
                    new HumanName()
                    {
                        Family = familyName,
                        Given = givenNames,
                    },
                },
                BirthDateElement = new Date(1972, 09, 11)
            };

            patient = await client.CreateAsync<Patient>(toCreate);

            return patient;
        }
        catch (Exception)
        {
            throw;
        }
    }

    /// <summary>
    /// Get Patients
    /// </summary>
    /// <param name="client">Fhir client</param>
    /// <param name="patientCriteria">search criteria</param>
    /// <param name="onlyWithEncounters">optional to get records that have encounters only</param>
    private static async System.Threading.Tasks.Task GetPatients(FhirClient client, string[] patientCriteria, bool onlyWithEncounters = false)
    {
        try
        {
            if (patientCriteria == null || patientCriteria.Length == 0)
                throw new ArgumentNullException("patientCriteria", "Search Criteria is empty");

            await System.Threading.Tasks.Task.Factory.StartNew(() =>
            {
                return client.SearchAsync<Patient>(patientCriteria).Result;     //  Call asynchronous client search
            }).ContinueWith((antecedent) =>
            {
                Bundle? patientsBundle = antecedent.Result;
                if (patientsBundle != null)
                {
                    Console.WriteLine($@"Total Patients : {patientsBundle.Total}");
                    foreach (Bundle.EntryComponent entry in patientsBundle.Entry)
                    {
                        if (entry.Resource != null)
                        {
                            Console.WriteLine($@"{entry.FullUrl}");
                            Patient patient = (Patient)entry.Resource;
                            Console.WriteLine($@"\t{patient.Id.ToString()}");
                            if (patient.Name.Count >= 1)
                            {
                                Console.WriteLine($@"\t{patient.Name[0].Family.ToString()}");
                            }
                            ReadPatientEncounters(client, patient);
                        }
                    }
                }
            });
        }
        catch (Exception)
        {
            throw;
        }
    }

    /// <summary>
    /// Read Patient Encounters
    /// </summary>
    /// <param name="client"></param>
    /// <param name="patient"></param>
    private static async System.Threading.Tasks.Task ReadPatientEncounters(FhirClient client, Patient patient)
    {
        try
        {
            await System.Threading.Tasks.Task.Factory.StartNew(() =>
            {
                return client.SearchAsync<Encounter>(
                                    new string[]
                                    {
                            $@"patient=Patient/{patient.Id}"
                                    }).Result;
            }).ContinueWith((antecedent) =>
            {
                Bundle? encountersBundle = antecedent.Result;
                if (encountersBundle != null)
                {
                    Console.WriteLine($@"\t\tTotal Encounters : {encountersBundle.Total} Entry Count : {encountersBundle.Entry.Count}");
                }
            });
        }
        catch (Exception)
        {
            throw;
        }
    }

    private static async void Main(string[] args)
    {
        try
        {
            //  Initialize a Fhir client
            FhirClient client = new FhirClient(StaticVariables.FHIR_SERVER);

            await CreatePatient(client);

            var patientCriteria = new string[] { "name=John Maverisk" };
            await GetPatients(client, patientCriteria);

            Console.WriteLine("Press any key to continue.....");
            Console.ReadLine();
        }
        catch (Exception)
        {
            throw;
        }
    }
}