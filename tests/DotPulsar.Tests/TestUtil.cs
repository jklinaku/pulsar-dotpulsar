namespace DotPulsar.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class TestUtil
{
    public static string extractTenantAndNameSpaceFromTopic(string topic)
    {
        return $"{ExtractTenantFromTopic(topic)}/{ExtractNamespaceFromTopic(topic)}";
    }
    public static string ExtractTenantFromTopic(string topic)
    {
        if (string.IsNullOrWhiteSpace(topic)) throw new Exception("topic format is not right");

        // Ensure the topic has the correct structure
        const string prefix = "://";
        int schemaIndex = topic.IndexOf(prefix, StringComparison.Ordinal);
        if (schemaIndex == -1) throw new Exception("topic format is not right");

        // Extract the part after "://"
        int startIndex = schemaIndex + prefix.Length;
        int firstSlash = topic.IndexOf('/', startIndex);
        if (firstSlash == -1) throw new Exception("topic format is not right");

        // Extract and return the tenant
        return topic.Substring(startIndex, firstSlash - startIndex);
    }

    public static string ExtractNamespaceFromTopic(string topic)
    {
        if (string.IsNullOrWhiteSpace(topic)) throw new Exception("topic format is not right");

        const string prefix = "://";
        int schemaIndex = topic.IndexOf(prefix, StringComparison.Ordinal);
        if (schemaIndex == -1) throw new Exception("topic format is not right");

        int startIndex = schemaIndex + prefix.Length;
        int firstSlash = topic.IndexOf('/', startIndex);
        if (firstSlash == -1) throw new Exception("topic format is not right");

        // Find the second slash to extract the namespace
        int secondSlash = topic.IndexOf('/', firstSlash + 1);
        if (secondSlash == -1) throw new Exception("topic format is not right");

        return topic.Substring(firstSlash + 1, secondSlash - firstSlash - 1);
    }
}
