using Npgsql;
using System;

namespace Practice2Tasks
{
    class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Host=localhost;Database=practice_db;Username=csharp_user;Password=71FCXlel;";
        using (var connection = new NpgsqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                Console.WriteLine("Connection estabilished");

                CreateTable(connection);
                InsertData(connection);
                SelectData(connection);
                CreateProcedure(connection);
                CallProcedure(connection);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка подключения: {ex.Message}");
            }
        }
    }

    static void CreateTable(NpgsqlConnection connection)
    {
        string createTableQuery = @"
            CREATE TABLE IF NOT EXISTS students (
                id SERIAL PRIMARY KEY,
                name VARCHAR(50),
                age INT,
                grade VARCHAR(10)
            );";

        using (var command = new NpgsqlCommand(createTableQuery, connection))
        {
            command.ExecuteNonQuery();
            Console.WriteLine("Table created");
        }
    }

    static void InsertData(NpgsqlConnection connection)
    {
        string insertDataQuery = @"
            INSERT INTO students (name, age, grade) VALUES ('Alex', 18, 'A');
            INSERT INTO students (name, age, grade) VALUES ('Maria', 19, 'B');
            INSERT INTO students (name, age, grade) VALUES ('John', 20, 'C');";

        using (var command = new NpgsqlCommand(insertDataQuery, connection))
        {
            command.ExecuteNonQuery();
            Console.WriteLine("Data fetcehd successfully");
        }
    }

    static void SelectData(NpgsqlConnection connection)
    {
        string selectDataQuery = "SELECT * FROM students;";
        using (var command = new NpgsqlCommand(selectDataQuery, connection))
        {
            using (var reader = command.ExecuteReader())
            {
                Console.WriteLine("Data from 'Students' table: ");
                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["id"]}, Name: {reader["name"]}, Age: {reader["age"]}, Grade: {reader["grade"]}");
                }
            }
        }
    }

    static void CreateProcedure(NpgsqlConnection connection)
    {
        string createFunctionQuery = @"
            CREATE OR REPLACE FUNCTION show_student_ids_and_names()
            RETURNS TABLE(id INT, name VARCHAR) AS $$
            BEGIN
                RETURN QUERY SELECT id, name FROM students;
            END;
            $$ LANGUAGE plpgsql;";

        using (var command = new NpgsqlCommand(createFunctionQuery, connection))
        {
            command.ExecuteNonQuery();
            Console.WriteLine("Procedure created");
        }
    }

    static void CallProcedure(NpgsqlConnection connection)
    {
        string callFunctionQuery = "SELECT * FROM show_student_ids_and_names();";
        using (var command = new NpgsqlCommand(callFunctionQuery, connection))
        {
            using (var reader = command.ExecuteReader())
            {
                Console.WriteLine("Procedure 'show_student_ids_and_names' results:");
                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["id"]}, Name: {reader["name"]}");
                }
            }
        }
    }
}
}