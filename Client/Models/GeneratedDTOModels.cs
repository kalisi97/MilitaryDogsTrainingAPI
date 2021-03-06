//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v13.6.2.0 (NJsonSchema v10.1.23.0 (Newtonsoft.Json v12.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------

#pragma warning disable 108 // Disable "CS0108 '{derivedDto}.ToJson()' hides inherited member '{dtoBase}.ToJson()'. Use the new keyword if hiding was intended."
#pragma warning disable 114 // Disable "CS0114 '{derivedDto}.RaisePropertyChanged(String)' hides inherited member 'dtoBase.RaisePropertyChanged(String)'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword."
#pragma warning disable 472 // Disable "CS0472 The result of the expression is always 'false' since a value of type 'Int32' is never equal to 'null' of type 'Int32?'
#pragma warning disable 1573 // Disable "CS1573 Parameter '...' has no matching param tag in the XML comment for ...
#pragma warning disable 1591 // Disable "CS1591 Missing XML comment for publicly visible type or member ..."

namespace MilitaryDogsTrainingModels
{
    using System = global::System;
    
    

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.23.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class LoginModel 
    {
        [Newtonsoft.Json.JsonProperty("username", Required = Newtonsoft.Json.Required.Always)]
        public string Username { get; set; }
    
        [Newtonsoft.Json.JsonProperty("password", Required = Newtonsoft.Json.Required.Always)]
        public string Password { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.23.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class RegisterInstructorModel 
    {
        [Newtonsoft.Json.JsonProperty("fullName", Required = Newtonsoft.Json.Required.Always)]
        public string FullName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("rank", Required = Newtonsoft.Json.Required.Always)]
        public string Rank { get; set; }
    
        [Newtonsoft.Json.JsonProperty("trainingCourse", Required = Newtonsoft.Json.Required.Always)]
        public string TrainingCourse { get; set; }
    
        [Newtonsoft.Json.JsonProperty("username", Required = Newtonsoft.Json.Required.Always)]
        public string Username { get; set; }
    
        [Newtonsoft.Json.JsonProperty("email", Required = Newtonsoft.Json.Required.Always)]
        public string Email { get; set; }
    
        [Newtonsoft.Json.JsonProperty("password", Required = Newtonsoft.Json.Required.Always)]
        public string Password { get; set; }
    
        [Newtonsoft.Json.JsonProperty("phoneNumber", Required = Newtonsoft.Json.Required.Always)]
        public string PhoneNumber { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.23.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class RegisterModel 
    {
        [Newtonsoft.Json.JsonProperty("username", Required = Newtonsoft.Json.Required.Always)]
        public string Username { get; set; }
    
        [Newtonsoft.Json.JsonProperty("email", Required = Newtonsoft.Json.Required.Always)]
        public string Email { get; set; }
    
        [Newtonsoft.Json.JsonProperty("password", Required = Newtonsoft.Json.Required.Always)]
        public string Password { get; set; }
    
        [Newtonsoft.Json.JsonProperty("phoneNumber", Required = Newtonsoft.Json.Required.Always)]
        public string PhoneNumber { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.23.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class DogDTO 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
        [Newtonsoft.Json.JsonProperty("chipNumber", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ChipNumber { get; set; }
    
        [Newtonsoft.Json.JsonProperty("age", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Age { get; set; }
    
        [Newtonsoft.Json.JsonProperty("breed", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Breed { get; set; }
    
        [Newtonsoft.Json.JsonProperty("gender", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Gender { get; set; }
    
        [Newtonsoft.Json.JsonProperty("trainingCourse", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string TrainingCourse { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.23.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class DogForCreationDTO 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Always)]
        public string Name { get; set; }
    
        [Newtonsoft.Json.JsonProperty("chipNumber", Required = Newtonsoft.Json.Required.Always)]
        public string ChipNumber { get; set; }
    
        [Newtonsoft.Json.JsonProperty("breed", Required = Newtonsoft.Json.Required.Always)]
        public string Breed { get; set; }
    
        [Newtonsoft.Json.JsonProperty("dateOfBirth", Required = Newtonsoft.Json.Required.Always)]
        [Newtonsoft.Json.JsonConverter(typeof(DateFormatConverter))]
        public System.DateTimeOffset DateOfBirth { get; set; }
    
        [Newtonsoft.Json.JsonProperty("gender", Required = Newtonsoft.Json.Required.Always)]
        public string Gender { get; set; }
    
        [Newtonsoft.Json.JsonProperty("trainingCourseId", Required = Newtonsoft.Json.Required.Always)]
        public int TrainingCourseId { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.23.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class DogForUpdateDTO 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Always)]
        public string Name { get; set; }
    
        [Newtonsoft.Json.JsonProperty("chipNumber", Required = Newtonsoft.Json.Required.Always)]
        public string ChipNumber { get; set; }
    
        [Newtonsoft.Json.JsonProperty("breed", Required = Newtonsoft.Json.Required.Always)]
        public string Breed { get; set; }
    
        [Newtonsoft.Json.JsonProperty("dateOfBirth", Required = Newtonsoft.Json.Required.Always)]
        [Newtonsoft.Json.JsonConverter(typeof(DateFormatConverter))]
        public System.DateTimeOffset DateOfBirth { get; set; }
    
        [Newtonsoft.Json.JsonProperty("gender", Required = Newtonsoft.Json.Required.Always)]
        public string Gender { get; set; }
    
        [Newtonsoft.Json.JsonProperty("trainingCourseId", Required = Newtonsoft.Json.Required.Always)]
        public int TrainingCourseId { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.23.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class TaskEngagementDetailsDTO 
    {
        [Newtonsoft.Json.JsonProperty("taskName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string TaskName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("dog", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Dog { get; set; }
    
        [Newtonsoft.Json.JsonProperty("date", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(DateFormatConverter))]
        public System.DateTimeOffset? Date { get; set; }
    
        [Newtonsoft.Json.JsonProperty("evaluation", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? Evaluation { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.23.0 (Newtonsoft.Json v12.0.0.0)")]
    public enum OperationType
    {
        _0 = 0,
    
        _1 = 1,
    
        _2 = 2,
    
        _3 = 3,
    
        _4 = 4,
    
        _5 = 5,
    
        _6 = 6,
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.23.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class TaskEngagementDTO 
    {
        [Newtonsoft.Json.JsonProperty("dog", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Dog { get; set; }
    
        [Newtonsoft.Json.JsonProperty("date", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(DateFormatConverter))]
        public System.DateTimeOffset? Date { get; set; }
    
        [Newtonsoft.Json.JsonProperty("evaluation", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? Evaluation { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.23.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class TaskDTO 
    {
        [Newtonsoft.Json.JsonProperty("date", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(DateFormatConverter))]
        public System.DateTimeOffset Date { get; set; }
    
        [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Status { get; set; }
    
        [Newtonsoft.Json.JsonProperty("taskEngagementDTOs", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<TaskEngagementDTO> TaskEngagementDTOs { get; set; }
    
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Always)]
        public string Name { get; set; }
    
        [Newtonsoft.Json.JsonProperty("location", Required = Newtonsoft.Json.Required.Always)]
        public string Location { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.23.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class TaskForCreationDTO 
    {
        [Newtonsoft.Json.JsonProperty("dogs", Required = Newtonsoft.Json.Required.Always)]
        public System.Collections.Generic.ICollection<DogDTO> Dogs { get; set; } = new System.Collections.ObjectModel.Collection<DogDTO>();
    
        [Newtonsoft.Json.JsonProperty("date", Required = Newtonsoft.Json.Required.Always)]
        [Newtonsoft.Json.JsonConverter(typeof(DateFormatConverter))]
        public System.DateTimeOffset Date { get; set; }
    
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Always)]
        public string Name { get; set; }
    
        [Newtonsoft.Json.JsonProperty("location", Required = Newtonsoft.Json.Required.Always)]
        public string Location { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.23.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class TaskForManipulationDTO 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Always)]
        public string Name { get; set; }
    
        [Newtonsoft.Json.JsonProperty("location", Required = Newtonsoft.Json.Required.Always)]
        public string Location { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.23.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class TrainingCourseDTO 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Always)]
        public string Name { get; set; }
    
        [Newtonsoft.Json.JsonProperty("description", Required = Newtonsoft.Json.Required.Always)]
        public string Description { get; set; }
    
        [Newtonsoft.Json.JsonProperty("duration", Required = Newtonsoft.Json.Required.Always)]
        public int Duration { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.23.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class TrainingCourseToUpdateDTO 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Always)]
        public string Name { get; set; }
    
        [Newtonsoft.Json.JsonProperty("description", Required = Newtonsoft.Json.Required.Always)]
        public string Description { get; set; }
    
        [Newtonsoft.Json.JsonProperty("duration", Required = Newtonsoft.Json.Required.Always)]
        public int Duration { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.23.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class TrainingCourseForCreationDTO 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Always)]
        public string Name { get; set; }
    
      [Newtonsoft.Json.JsonProperty("description", Required = Newtonsoft.Json.Required.Always)]
        public string Description { get; set; }
    
     [Newtonsoft.Json.JsonProperty("duration", Required = Newtonsoft.Json.Required.Always)]
        public int Duration { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.23.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class Task 
    {
        [Newtonsoft.Json.JsonProperty("taskId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int TaskId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Always)]
        public string Name { get; set; }
    
        [Newtonsoft.Json.JsonProperty("date", Required = Newtonsoft.Json.Required.Always)]
        [Newtonsoft.Json.JsonConverter(typeof(DateFormatConverter))]
        public System.DateTimeOffset Date { get; set; }
    
        [Newtonsoft.Json.JsonProperty("taskEngagements", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<TaskEngagement> TaskEngagements { get; set; }
    
        [Newtonsoft.Json.JsonProperty("location", Required = Newtonsoft.Json.Required.Always)]
        public string Location { get; set; }
    
        [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Status { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.23.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class TaskEngagement 
    {
        [Newtonsoft.Json.JsonProperty("dog", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Dog Dog { get; set; }
    
        [Newtonsoft.Json.JsonProperty("dogId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int DogId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("task", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Task Task { get; set; }
    
        [Newtonsoft.Json.JsonProperty("taskId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int TaskId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("date", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(DateFormatConverter))]
        public System.DateTimeOffset? Date { get; set; }
    
        [Newtonsoft.Json.JsonProperty("evaluation", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? Evaluation { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.23.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class Dog 
    {
        [Newtonsoft.Json.JsonProperty("dogId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int DogId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Always)]
        public string Name { get; set; }
    
        [Newtonsoft.Json.JsonProperty("chipNumber", Required = Newtonsoft.Json.Required.Always)]
        public string ChipNumber { get; set; }
    
        [Newtonsoft.Json.JsonProperty("dateOfBirth", Required = Newtonsoft.Json.Required.Always)]
        [Newtonsoft.Json.JsonConverter(typeof(DateFormatConverter))]
        public System.DateTimeOffset DateOfBirth { get; set; }
    
        [Newtonsoft.Json.JsonProperty("breed", Required = Newtonsoft.Json.Required.Always)]
        public string Breed { get; set; }
    
        [Newtonsoft.Json.JsonProperty("gender", Required = Newtonsoft.Json.Required.Always)]
        public string Gender { get; set; }
    
        [Newtonsoft.Json.JsonProperty("trainingCourseId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int TrainingCourseId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("trainingCourse", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public TrainingCourse TrainingCourse { get; set; }
    
        [Newtonsoft.Json.JsonProperty("taskEngagements", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<TaskEngagement> TaskEngagements { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.23.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class TrainingCourse 
    {
        [Newtonsoft.Json.JsonProperty("trainingCourseId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int TrainingCourseId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
        [Newtonsoft.Json.JsonProperty("description", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Description { get; set; }
    
        [Newtonsoft.Json.JsonProperty("duration", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Duration { get; set; }
    
        [Newtonsoft.Json.JsonProperty("instructors", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Instructor> Instructors { get; set; }
    
        [Newtonsoft.Json.JsonProperty("dogs", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Dog> Dogs { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.23.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class Instructor 
    {
        [Newtonsoft.Json.JsonProperty("fullName", Required = Newtonsoft.Json.Required.Always)]
        public string FullName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("rank", Required = Newtonsoft.Json.Required.Always)]
        public string Rank { get; set; }
    
        [Newtonsoft.Json.JsonProperty("trainingCourseId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int TrainingCourseId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("trainingCourse", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public TrainingCourse TrainingCourse { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Id { get; set; }
    
        [Newtonsoft.Json.JsonProperty("userName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string UserName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("normalizedUserName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string NormalizedUserName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("email", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Email { get; set; }
    
        [Newtonsoft.Json.JsonProperty("normalizedEmail", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string NormalizedEmail { get; set; }
    
        [Newtonsoft.Json.JsonProperty("emailConfirmed", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool EmailConfirmed { get; set; }
    
        [Newtonsoft.Json.JsonProperty("passwordHash", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PasswordHash { get; set; }
    
        [Newtonsoft.Json.JsonProperty("securityStamp", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SecurityStamp { get; set; }
    
        [Newtonsoft.Json.JsonProperty("concurrencyStamp", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ConcurrencyStamp { get; set; }
    
        [Newtonsoft.Json.JsonProperty("phoneNumber", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PhoneNumber { get; set; }
    
        [Newtonsoft.Json.JsonProperty("phoneNumberConfirmed", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool PhoneNumberConfirmed { get; set; }
    
        [Newtonsoft.Json.JsonProperty("twoFactorEnabled", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool TwoFactorEnabled { get; set; }
    
        [Newtonsoft.Json.JsonProperty("lockoutEnd", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? LockoutEnd { get; set; }
    
        [Newtonsoft.Json.JsonProperty("lockoutEnabled", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool LockoutEnabled { get; set; }
    
        [Newtonsoft.Json.JsonProperty("accessFailedCount", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int AccessFailedCount { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.23.0 (Newtonsoft.Json v12.0.0.0)")]
    internal class DateFormatConverter : Newtonsoft.Json.Converters.IsoDateTimeConverter
    {
        public DateFormatConverter()
        {
            DateTimeFormat = "yyyy-MM-dd";
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.6.2.0 (NJsonSchema v10.1.23.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class SwaggerException : System.Exception
    {
        public int StatusCode { get; private set; }

        public string Response { get; private set; }

        public System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> Headers { get; private set; }

        public SwaggerException(string message, int statusCode, string response, System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> headers, System.Exception innerException)
            : base(message + "\n\nStatus: " + statusCode + "\nResponse: \n" + ((response == null) ? "(null)" : response.Substring(0, response.Length >= 512 ? 512 : response.Length)), innerException)
        {
            StatusCode = statusCode;
            Response = response; 
            Headers = headers;
        }

        public override string ToString()
        {
            return string.Format("HTTP Response: \n\n{0}\n\n{1}", Response, base.ToString());
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.6.2.0 (NJsonSchema v10.1.23.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class SwaggerException<TResult> : SwaggerException
    {
        public TResult Result { get; private set; }

        public SwaggerException(string message, int statusCode, string response, System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> headers, TResult result, System.Exception innerException)
            : base(message, statusCode, response, headers, innerException)
        {
            Result = result;
        }
    }

}

#pragma warning restore 1591
#pragma warning restore 1573
#pragma warning restore  472
#pragma warning restore  114
#pragma warning restore  108