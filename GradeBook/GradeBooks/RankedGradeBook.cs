using GradeBook.Enums;
using System;
using System.Linq;

namespace GradeBook.GradeBooks
{
  public class RankedGradeBook : BaseGradeBook
  {
    public RankedGradeBook(string name) : base(name)
    {
      Type = GradeBookType.Ranked;
    }

    public override char GetLetterGrade(double averageGrade)
    {
      if(Students.Count < 5) throw new InvalidOperationException();

      var grades = Students.Select(i => i.AverageGrade).OrderByDescending(j =>j).ToArray();
      var threshold = (int)Math.Ceiling(Students.Count * 0.2);

      if(grades[threshold - 1] <=averageGrade){
        return 'A';
      }else if(grades[threshold*2- 1] <=averageGrade){
        return 'B';
      }else if(grades[threshold*3 - 1] <=averageGrade){
        return 'C';
      }else if(grades[threshold*4 - 1] <=averageGrade){
        return 'D';
      }else{
        return 'F';
      }
    }
  }
}