using System;
using System.Text.RegularExpressions;

class GradeCalculator
{
    static void Main(string[] args)
    {
        // Define variables
        int totalCourseUnit = 0;
        int totalCourseUnitPassed = 0;
        int totalWeightPoint = 0;
        string convertedGrade = "";


        Console.WriteLine("How many Course do you want to add:");
        string numberOfCourse = Console.ReadLine();
        int length;
        while (!int.TryParse(numberOfCourse, out length) || length < 1 || length > 100)
        {
            Console.WriteLine("Invalid Input, courses to register must be a number");
            numberOfCourse = Console.ReadLine();
        }


        // Loop through courses
        for (int i = 1; i <= length; i++)
        {

            // Get course name and code
            Console.Write("Enter course name and code: ");
            string courseCode = Console.ReadLine();
            string courseNameCode;
            Regex pattern = new Regex(@"^[A-z]{3}\d{3}$");
            while (!pattern.IsMatch(courseCode) || !(courseCode.Length == 6))
            {
                Console.WriteLine("Invalid Input, course must follow the following pattern MTS101:");
                courseCode = Console.ReadLine();
            }
            courseNameCode = courseCode.ToUpper();

            // Get course unit
            Console.Write("Enter course unit: ");
            string unit = Console.ReadLine();
            int courseUnit;
            while (!int.TryParse(unit, out courseUnit) || courseUnit < 0 || courseUnit > 9)
            {
                Console.WriteLine("Invalid Input, unit can only be 0 to 9");
                unit = Console.ReadLine();
            }

            // Get course score
            Console.Write("Enter course score: ");
            string score = Console.ReadLine();
            int courseScore;
            while (!int.TryParse(score, out courseScore) || courseScore < 0 || courseScore > 100)
            {
                Console.WriteLine("Invalid Input, score can only be 0 to 100");
                score = Console.ReadLine();
            }

            // Calculate grade and grade unit
            string grade = "";
            int gradeUnit = 0;

            if (courseScore >= 70)
            {
                grade = "A";
                gradeUnit = 5;
            }
            else if (courseScore >= 60)
            {
                grade = "B";
                gradeUnit = 4;
            }
            else if (courseScore >= 50)
            {
                grade = "C";
                gradeUnit = 3;
            }
            else if (courseScore >= 45)
            {
                grade = "D";
                gradeUnit = 2;
            }
            else if (courseScore >= 40)
            {
                grade = "E";
                gradeUnit = 1;
            }
            else
            {
                grade = "F";
                gradeUnit = 0;
            }

            // Calculate weight point and remark
            int weightPoint = courseUnit * gradeUnit;
            string remark = "";

            if (gradeUnit == 0)
            {
                remark = "Fail";
            }
            else if (gradeUnit == 5)
            {
                remark = "Excellent";
            }
            else if (gradeUnit == 4)
            {
                remark = "Very Good";
            }
            else if (gradeUnit == 3)
            {
                remark = "Good";
            }
            else
            {
                remark = "Pass";
            }



            // Print course row
            convertedGrade += $"| {courseNameCode,-17} | {courseUnit,-15} | {grade,-6} | {gradeUnit,-9} | {weightPoint,-10} | {remark,-10} |\n";

            // Update totals
            totalCourseUnit += courseUnit;
            if (gradeUnit > 0)
            {
                totalCourseUnitPassed += courseUnit;
            }
            totalWeightPoint += weightPoint;

        }
        // Print table header
        Console.WriteLine("|-------------------|-----------------|--------|-----------|------------|------------|");
        Console.WriteLine("| COURSE & CODE     |COURSE UNIT      | GRADE  | GRADE UNIT| WEIGHT PT. |     REMARK |");
        Console.WriteLine("|-------------------|-----------------|--------|-----------|------------|------------|");
        Console.Write(convertedGrade);

        // Print table footer
        Console.WriteLine("|-------------------|-----------------|--------|-----------|------------|------------|");

        // Print totals
        Console.WriteLine("Total Course Unit Registered is {0}", totalCourseUnit);
        Console.WriteLine("Total Course Unit Passed is {0}", totalCourseUnitPassed);
        Console.WriteLine("Total Weight Point is {0}", totalWeightPoint);

        // Calculate and print GPA
        double gpa = Math.Round((double)totalWeightPoint / totalCourseUnitPassed, 2);
        Console.WriteLine("Your GPA is = {0:f2} to 2 decimal places.", gpa);

    }
}