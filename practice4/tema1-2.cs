using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

public class Conference
{
    public string ConferenceName { get; set; }
    public List<Event> Events { get; set; }
}

public class Event
{
    public string Title { get; set; }
    public DateTime Start { get; set; }
    [JsonIgnore]
    public int DurationInSeconds { get; set; }
    public Speaker Speaker { get; set; }

    [JsonPropertyName("StartTime")]
    public string StartFormatted
    {
        get => Start.ToString("yyyy-MM-ddTHH:mm:ssZ");
        set => Start = DateTime.Parse(value);
    }

    [JsonPropertyName("DurationInMinutes")]
    public int DurationInMinutes
    {
        get => DurationInSeconds / 60;
        set => DurationInSeconds = value * 60;
    }
}

public class Speaker
{
    public string Name { get; set; }
    public int ExperienceYears { get; set; }
}

class Program
{
    static void Main()
    {
        string json = @"
        {
            ""ConferenceName"": ""Tech Summit 2024"",
            ""Events"": [
                {
                    ""Title"": ""Introduction to Quantum Computing"",
                    ""StartTime"": ""2024-11-10T09:00:00Z"",
                    ""DurationInMinutes"": 90,
                    ""Speaker"": {
                        ""Name"": ""Alice Johnson"",
                        ""ExperienceYears"": 10
                    }
                },
                {
                    ""Title"": ""AI Ethics in Modern World"",
                    ""StartTime"": ""2024-11-11T10:00:00Z"",
                    ""DurationInMinutes"": 60,
                    ""Speaker"": {
                        ""Name"": ""Bob Smith"",
                        ""ExperienceYears"": 5
                    }
                }
            ]
        }";

        // Десеріалізація JSON
        Conference conference = JsonSerializer.Deserialize<Conference>(json);
        Console.WriteLine($"Назва конференції: {conference.ConferenceName}");
        foreach (var ev in conference.Events)
        {
            Console.WriteLine($"\nПодія: {ev.Title}");
            Console.WriteLine($"Початок: {ev.Start}");
            Console.WriteLine($"Тривалість у секундах: {ev.DurationInSeconds}");
            Console.WriteLine($"Доповідач: {ev.Speaker.Name}, Досвід: {ev.Speaker.ExperienceYears} років");
        }
    }
}
