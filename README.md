# FHIR Database Connection Test

This project demonstrates how to connect to a FHIR (Fast Healthcare Interoperability Resources) server and perform basic CRUD operations on patient data using the `Hl7.Fhir` library.

## Features

- **Create Patient**: Adds a new patient to the FHIR server.
- **Update Patient**: Modifies the details of an existing patient.
- **Delete Patient**: Removes a patient from the FHIR server.
- **Get Patients**: Retrieves a list of patients based on search criteria.
- **Read Patient Encounters**: Fetches encounter details associated with a patient.

## Prerequisites

- .NET Core 3.1 or later
- Access to a FHIR server (e.g., HAPI FHIR, Microsoft FHIR Server)

## Setup

1. **Clone the repository**:

    ```bash
    git clone https://github.com/your-username/FhirDatabaseConnectionTest.git
    cd FhirDatabaseConnectionTest
    ```

2. **Install dependencies**:

    The project uses the `Hl7.Fhir` library for interacting with the FHIR server. Ensure you have the necessary NuGet packages installed:

    ```bash
    dotnet add package Hl7.Fhir.R4
    ```

3. **Configure the FHIR Server**:

    Update the FHIR server URL in the `StaticVariables.FHIR_SERVER` variable located in the `StaticVariables` class.

    ```csharp
    public static class StaticVariables
    {
        public static string FHIR_SERVER = "https://your-fhir-server.com";
    }
    ```

## Usage

### Running the Application

To run the application, execute the following command:

```bash
dotnet run
```

The application will connect to the FHIR server and perform the following actions:

- Create a new patient.
- Search for a patient by name.
- Retrieve patient encounters.

### Example Code Snippets

#### Create a Patient

```csharp
await CreatePatient(client);
```

#### Update a Patient

```csharp
await UpdatePatient(client, patient);
```

#### Delete a Patient

```csharp
await DeletePatient(client, patientId);
```

#### Get Patients

```csharp
var patientCriteria = new string[] { "name=John Maverisk" };
await GetPatients(client, patientCriteria);
```

## Contributing

Contributions are welcome! Please fork the repository and submit a pull request with your changes.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Acknowledgments

- [HL7 FHIR](https://hl7.org/fhir/)
- [Hl7.Fhir Library](https://github.com/FirelyTeam/firely-net-sdk)

---

This template provides a clear overview of the project and includes instructions for setup, usage, and contributions. You can adjust the sections according to your specific needs.
