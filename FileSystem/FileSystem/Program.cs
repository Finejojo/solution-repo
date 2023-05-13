using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Text.Json.Serialization;
using static System.Net.Mime.MediaTypeNames;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public List<string> Hobbies { get; set; }
}
class Program
{
    
    public static void Main()
    {
        /*
        DirectoryInfo getDir = new DirectoryInfo(".");
        Console.WriteLine("FullName: "+ getDir.FullName);
        Console.WriteLine("Name: " + getDir.Name);
        Console.WriteLine("Paren Folder: "+getDir.Parent);
        //Directory.CreateDirectory(getDir.FullName+"files");
        //Directory.Delete(getDir.FullName + "files");
        
        */
        var nS = new List<Student>();
        Student student = new Student()
        {
            Id = 1,
            Name = "Tobi",
            Age = 28,
            Hobbies = new List<string>()
            {
                "Scholar",
                "Fighting",
                "Eating",
                "Playing"
            }
        };
        var json = JsonConvert.SerializeObject(student);
        //Console.WriteLine(json);
        File.WriteAllText("student.json", json);
        nS.Add(student);
       // var json = JsonConvert.SerializeObject(student);
        //File.WriteAllText("students.json", json);
         student = new Student()
        {
            Id = 2,
            Name = "Caleb",
            Age = 28,
            Hobbies = new List<string>()
            {
                "Praying",
                "Fighting",
                "Eating",
                "Playing"
            }
        };
        nS.Add(student);
        /*
         var json = JsonConvert.SerializeObject(nS);
        File.WriteAllText("students.json", json);
        Console.WriteLine(json);
        */
        
        var jsonFileRead = File.ReadAllText("student.json");
        Console.WriteLine(jsonFileRead[0]);
        //var covertedJson = JsonConvert.DeserializeObject<Student>(jsonFileRead[0]);
        //covertedJson[1].Name = "Oluwatobiloba";
        //var serializedUpdate = JsonConvert.SerializeObject(covertedJson);
        //File.WriteAllText("students.json",serializedUpdate);
        
        /*
        List<Student> students = new List<Student>();
        var readTxt = File.ReadAllLines("students.json");
        var jsonStudent = JsonConvert.DeserializeObject<List<Student>>(readTxt[0]);
        Console.WriteLine(readTxt[0]);
        foreach(var obj in jsonStudent)
        {
            Console.WriteLine(obj.Name+obj.Age+obj.Hobbies);
        }
        */

        /*
        foreach(var txt in readTxt)
        {
            var jsonStudent = JsonConvert.DeserializeObject<Student>(txt);
            students.Add(jsonStudent);
        }
        Console.WriteLine("id: {0} Name: {1} Age: {2}", students[1].Id, students[1].Name, students[1].Age);
        */

    }
}
