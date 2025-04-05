using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SchoolAdministration.Models;
using System.Reflection;
using Formatting = Newtonsoft.Json.Formatting;

namespace SchoolAdministration;

internal static class SchoolFactory
{
    public static School CreateSchool()
    {
        var currentDirectory = Directory.GetCurrentDirectory();
        var testFilesPath = Path.Combine(currentDirectory, "DemoFiles");
        var schoolPath = Path.Combine(testFilesPath, "school.json");
        var schoolJson = File.ReadAllText(schoolPath);

        var settings = new JsonSerializerSettings
        {
            PreserveReferencesHandling = PreserveReferencesHandling.All,
            ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
            MetadataPropertyHandling = MetadataPropertyHandling.ReadAhead,
            ContractResolver = new PrivateResolver(),
            NullValueHandling = NullValueHandling.Ignore,
            Formatting = Formatting.Indented
        };

        var school = JsonConvert.DeserializeObject<School>(schoolJson, settings);

        return school;
    }
}

public class PrivateResolver : DefaultContractResolver
{
    protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
    {
        // Get all properties and fields (public and non-public)
        var props = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
            .Select(p => base.CreateProperty(p, memberSerialization))
            .Union(
                type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .Select(f => base.CreateProperty(f, memberSerialization))
            )
            .ToList();

        // Force each property to be both readable and writable.
        foreach (var prop in props)
        {
            prop.Writable = true;
            prop.Readable = true;
        }
        return props;
    }
}
