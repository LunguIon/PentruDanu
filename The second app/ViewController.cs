using System.Text;
using MySql.Data.MySqlClient;
using ObjCRuntime;

namespace The_second_app;

public partial class ViewController : NSViewController
{
    protected ViewController(NativeHandle handle) : base(handle)
    {
        
    }

    // public override void ViewDidLoad()
    // {
    //     base.ViewDidLoad();
    //     
    // }

    public override void ViewDidAppear()
    {
        base.ViewDidAppear();

        if (View.Window != null)
        {
            NSImageView imageView = new NSImageView(View.Window.ContentView.Bounds)
            {
                Image = NSImage.ImageNamed("blue.png"),
                ImageScaling = NSImageScale.AxesIndependently,
                AutoresizingMask = NSViewResizingMask.WidthSizable | NSViewResizingMask.HeightSizable
            };
            imageView.WantsLayer = true;
            imageView.Layer.BackgroundColor = NSColor.Green.CGColor;

            if (View.Window.ContentView.Subviews.Length > 0)
            {
                // Add the image view below the first subview
                View.Window.ContentView.AddSubview(imageView, NSWindowOrderingMode.Below, View.Window.ContentView.Subviews[0]);
            }
            else
            {
                // If there are no other subviews, just add the image view
                View.Window.ContentView.AddSubview(imageView);
            }
        }
    }



    public override NSObject RepresentedObject
    {
        get => base.RepresentedObject;
        set
        {
            base.RepresentedObject = value;

            // Update the view, if already loaded.
        }
    }

    partial void button1(NSButton sender)
    {
        // Use MySqlConnection for MySQL database
        using (var connection = new MySqlConnection("server=127.0.0.1;uid=root;database=lab1"))
        {
            try
            {
                // Open the connection
                connection.Open();

                // SQL query to select all rows from employee table
                string query = "SELECT * FROM employee";

                // Create a MySqlCommand object
                using (var command = new MySqlCommand(query, connection))
                {
                    // Execute the query and obtain a MySqlDataReader object
                    using (var reader = command.ExecuteReader())
                    {
                        // StringBuilder to create a string for the label
                        var stringBuilder = new StringBuilder();

                        // Read each row from the result set
                        while (reader.Read())
                        {
                            // Extract each column value
                            int id = reader.GetInt32("id");
                            string name = reader.GetString("name");
                            string surname = reader.GetString("surname");
                            int age = reader.GetInt32("age");
                            decimal salary = reader.GetDecimal("salary");

                            // Append the row to the StringBuilder
                            stringBuilder.AppendLine($"ID: {id}, Name: {name}, Surname: {surname}, Age: {age}, Salary: {salary}");
                        }

                        // Set the label's value to the concatenated string
                        label1.StringValue = stringBuilder.ToString();
                    }
                }
            }
            catch (Exception e)
            {
                // If an error occurs, display the error message in the label
                label1.StringValue = $"Error: {e.Message}";
            }
        }
        UpdateSalarySum();
        UpdateSmallestAge();
        UpdateBiggestSalary();
    }


    partial void insert(NSButton sender)
    {
        using (var connection = new MySqlConnection("server=127.0.0.1;uid=root;database=lab1"))
        {
            try
            {
                connection.Open();

                // Constructing the INSERT statement using parameters
                string query = "INSERT INTO employee (id, name, surname, age, salary) VALUES (@id, @name, @surname, @age, @salary)";

                using (var command = new MySqlCommand(query, connection))
                {
                    // Assuming your text fields are named idField, nameField, etc. in C#
                    command.Parameters.AddWithValue("@id", id.StringValue);
                    command.Parameters.AddWithValue("@name", name.StringValue);
                    command.Parameters.AddWithValue("@surname", surname.StringValue);
                    command.Parameters.AddWithValue("@age", int.Parse(age.StringValue));
                    command.Parameters.AddWithValue("@salary", decimal.Parse(salary.StringValue));

                    command.ExecuteNonQuery();
                }

                RefreshLabel1();
            }
            catch (Exception e)
            {
                label1.StringValue = $"Error: {e.Message}";
            }
        }
    }

    partial void deleteEmployee(NSButton sender)
    {
        using (var connection = new MySqlConnection("server=127.0.0.1;uid=root;database=lab1"))
        {
            try
            {
                connection.Open();

                // SQL DELETE statement with a parameter for the ID
                string query = "DELETE FROM employee WHERE id = @id";

                using (var command = new MySqlCommand(query, connection))
                {
                    // Assuming your text field for the employee ID is named idField in C#
                    command.Parameters.AddWithValue("@id", employeeToDelete.StringValue);

                    int rowsAffected = command.ExecuteNonQuery();
                
                    if (rowsAffected > 0)
                    {
                        // Record was deleted, now refresh label1
                        RefreshLabel1();
                    }
                    else
                    {
                        // No record was deleted (likely because it wasn't found)
                        label1.StringValue = "No record found with the given ID.";
                    }
                }
            }
            catch (Exception e)
            {
                label1.StringValue = $"Error: {e.Message}";
            }
        }
    }

    partial void sorted(NSButton sender)
    {
        using (var connection = new MySqlConnection("server=127.0.0.1;uid=root;database=lab1"))
        {
            try
            {
                connection.Open();

                // SQL query to select all employees sorted by surname alphabetically
                string query = "SELECT * FROM employee ORDER BY surname ASC";

                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        var stringBuilder = new StringBuilder();

                        while (reader.Read())
                        {
                            int id = reader.GetInt32("id");
                            string name = reader.GetString("name");
                            string surname = reader.GetString("surname");
                            int age = reader.GetInt32("age");
                            decimal salary = reader.GetDecimal("salary");

                            stringBuilder.AppendLine($"ID: {id}, Name: {name}, Surname: {surname}, Age: {age}, Salary: {salary}");
                        }

                        label1.StringValue = stringBuilder.ToString();
                    }
                }
            }
            catch (Exception e)
            {
                label1.StringValue = $"Error: {e.Message}";
            }
        }
    }


    private void RefreshLabel1()
    {
        using (var connection = new MySqlConnection("server=127.0.0.1;uid=root;database=lab1"))
        {
            try
            {
                // Open the connection
                connection.Open();

                // SQL query to select all rows from employee table
                string query = "SELECT * FROM employee";

                // Create a MySqlCommand object
                using (var command = new MySqlCommand(query, connection))
                {
                    // Execute the query and obtain a MySqlDataReader object
                    using (var reader = command.ExecuteReader())
                    {
                        // StringBuilder to create a string for the label
                        var stringBuilder = new StringBuilder();

                        // Read each row from the result set
                        while (reader.Read())
                        {
                            // Extract each column value
                            int id = reader.GetInt32("id");
                            string name = reader.GetString("name");
                            string surname = reader.GetString("surname");
                            int age = reader.GetInt32("age");
                            decimal salary = reader.GetDecimal("salary");

                            // Append the row to the StringBuilder
                            stringBuilder.AppendLine(
                                $"ID: {id}, Name: {name}, Surname: {surname}, Age: {age}, Salary: {salary}");
                        }

                        // Set the label's value to the concatenated string
                        label1.StringValue = stringBuilder.ToString();
                    }
                }
            }catch (Exception e)
            {
                // If an error occurs, display the error message in the label
                label1.StringValue = $"Error: {e.Message}";
            }
        }
    }
    
    //Method for updating the salary Sum 
    private void UpdateSalarySum()
    {
        using (var connection = new MySqlConnection("server=127.0.0.1;uid=root;database=lab1"))
        {
            try
            {
                connection.Open();
                string query = "SELECT SUM(salary) FROM employee";
                using (var command = new MySqlCommand(query, connection))
                {
                    var result = command.ExecuteScalar();
                    salarySUM.StringValue += result?.ToString() ?? "0";
                }
            }
            catch (Exception e)
            {
                salarySUM.StringValue = $"Error: {e.Message}";
            }
        }
    }

    //Method do find the smallest Age 
    private void UpdateSmallestAge()
    {
        using (var connection = new MySqlConnection("server=127.0.0.1;uid=root;database=lab1"))
        {
            try
            {
                connection.Open();
                string query = "SELECT MIN(age) FROM employee";
                using (var command = new MySqlCommand(query, connection))
                {
                    var result = command.ExecuteScalar();
                    smallestAge.StringValue += result?.ToString() ?? "N/A";
                }
            }
            catch (Exception e)
            {
                smallestAge.StringValue = $"Error: {e.Message}";
            }
        }
    }

    //Method to find the biggest salary 
    private void UpdateBiggestSalary()
    {
        using (var connection = new MySqlConnection("server=127.0.0.1;uid=root;database=lab1"))
        {
            try
            {
                connection.Open();
                string query = "SELECT MAX(salary) FROM employee";
                using (var command = new MySqlCommand(query, connection))
                {
                    var result = command.ExecuteScalar();
                    biggestSalary.StringValue += result?.ToString() ?? "N/A";
                }
            }
            catch (Exception e)
            {
                biggestSalary.StringValue = $"Error: {e.Message}";
            }
        }
    }




    public MySqlConnection connection()
    {
        string connectionString = "server=127.0.0.1;uid=root;database=lab1";
        return new MySqlConnection(connectionString);
    }
    
}