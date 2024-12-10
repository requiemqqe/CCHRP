using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public List<string> Subjects { get; set; }
}

class tema1
{
    static void Main()
    {
        // 1. Створення списку студентів
        List<Student> students = new List<Student>
        {
            new Student { Name = "Alice", Age = 20, Subjects = new List<string> { "Math", "Physics" } },
            new Student { Name = "Bob", Age = 22, Subjects = new List<string> { "History", "Literature" } }
        };

        // 2. Серіалізація списку у JSON файл
        string jsonFilePath = "students.json";
        File.WriteAllText(jsonFilePath, JsonSerializer.Serialize(students));
        Console.WriteLine("Список студентів збережено у JSON файл.");

        // 3. Десеріалізація JSON назад у список об'єктів
        string jsonContent = File.ReadAllText(jsonFilePath);
        List<Student> deserializedStudents = JsonSerializer.Deserialize<List<Student>>(jsonContent);
        Console.WriteLine("\nСписок студентів після десеріалізації:");
        deserializedStudents.ForEach(s =>
            Console.WriteLine($"Ім'я: {s.Name}, Вік: {s.Age}, Предмети: {string.Join(", ", s.Subjects)}"));

        // 4. Операції над списком студентів
        deserializedStudents.Add(new Student { Name = "Charlie", Age = 21, Subjects = new List<string> { "Biology", "Chemistry" } });
        deserializedStudents[0].Age = 23; // Оновлення даних студента

        // 5. Повторна серіалізація та демонстрація
        File.WriteAllText(jsonFilePath, JsonSerializer.Serialize(deserializedStudents));
        Console.WriteLine("\nОновлений список студентів:");
        deserializedStudents.ForEach(s =>
            Console.WriteLine($"Ім'я: {s.Name}, Вік: {s.Age}, Предмети: {string.Join(", ", s.Subjects)}"));
    }
}
