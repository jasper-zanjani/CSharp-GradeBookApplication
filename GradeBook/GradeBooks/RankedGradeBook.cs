using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace GradeBook.GradeBooks
{
  public class RankedGradeBook : BaseGradeBook
  {
    public RankedGradeBook(string name) : base(name)
    {
      Type = Enums.GradeBookType.Ranked;
    }

    public override char GetLetterGrade(double averageGrade)
    {
      //  if (Students.Count < 5)
      //    throw new InvalidOperationException("Not enough students for a letter grade!");

      //  var sortedStudents = Students.OrderByDescending(i => i.AverageGrade);
      //  foreach (var i in sortedStudents)
      //  {
      //    int StudentIndex = Students.IndexOf(i);
      //    if (StudentIndex < Students.Count / 5) { return 'A'; }
      //    else if (StudentIndex < 2 * Students.Count / 5) { return 'B'; }
      //    else if (StudentIndex < 3 * Students.Count / 5) { return 'C'; }
      //    else if (StudentIndex < 4 * Students.Count / 5) { return 'D'; }
      //  }
      //  return 'F';
      //}

      if (Students.Count < 5)
        throw new InvalidOperationException("There must be at least 5 students.");

      //find 20% of total number of students
      var gradeRange = Students.Count / 5;

      //find ranked student grades
      List<double> rankedAvgGrades = new List<double>();
      foreach (var student in Students.OrderByDescending(s => s.AverageGrade))
      {
        rankedAvgGrades.Add(student.AverageGrade);
      }

      //calculate grade ranges
      if (averageGrade > (rankedAvgGrades[gradeRange]))
        return 'A';
      else if (averageGrade > (rankedAvgGrades[gradeRange * 2]))
        return 'B';
      else if (averageGrade > (rankedAvgGrades[gradeRange * 3]))
        return 'C';
      else if (averageGrade > (rankedAvgGrades[gradeRange * 4]))
        return 'D';
      else
        return 'F';
    }
  }
}