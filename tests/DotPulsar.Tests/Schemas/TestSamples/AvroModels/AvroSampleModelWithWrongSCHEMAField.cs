namespace DotPulsar.Tests.Schemas.TestSamples.AvroModels;

using Avro.Specific;
using System;

public class AvroSampleModelWithWrongSCHEMAField : ISpecificRecord
{
    public static string _SCHEMA = "WRONG!";
    public Avro.Schema Schema => throw new NotImplementedException();

    public object Get(int fieldPos)
    {
        throw new NotImplementedException();
    }

    public void Put(int fieldPos, object fieldValue)
    {
        throw new NotImplementedException();
    }
}

