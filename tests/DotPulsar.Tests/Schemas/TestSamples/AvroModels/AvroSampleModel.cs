namespace DotPulsar.Tests.Schemas.TestSamples.AvroModels;

using Avro.Specific;
using System;


public class AvroSampleModel : ISpecificRecord
{
    public static readonly Avro.Schema _SCHEMA = Avro.Schema.Parse(@"
        {
            ""type"": ""record"",
            ""name"": ""AvroSampleModel"",
            ""fields"": [
                { ""name"": ""Name"", ""type"": ""string"" },
                { ""name"": ""Surname"", ""type"": ""string"" },
                { ""name"": ""Age"", ""type"": ""int"" }
            ]
        }");

    public virtual Avro.Schema Schema => _SCHEMA;
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }
    public object Get(int fieldPos)
    {
        return fieldPos switch
        {
            0 => Name,
            1 => Surname,
            2 => Age,
            _ => throw new ArgumentOutOfRangeException(nameof(fieldPos), "Invalid field position")
        };
    }

    public void Put(int fieldPos, object value)
    {
        switch (fieldPos)
        {
            case 0:
                Name = value as string ?? throw new ArgumentException("Name must be a string");
                break;
            case 1:
                Surname = value as string ?? throw new ArgumentException("Name must be a string");
                break;
            case 2:
                Age = value is int intValue ? intValue : throw new ArgumentException("Age must be an int");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(fieldPos), "Invalid field position");
        }
    }
}

