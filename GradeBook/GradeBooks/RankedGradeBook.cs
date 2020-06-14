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

      var averageGradeList = Students.Select(i => i.AverageGrade).ToList();
      averageGradeList.Add(averageGrade);
      var averageGradeArray = averageGradeList.OrderByDescending(i => i).ToArray();
      var index = Array.IndexOf(averageGradeArray,averageGrade);
      var step = averageGradeArray.Length / 5;

      if(index >=0 && index < step){
        return 'A';
      }else if(index <= step*2){
        return 'B';
      }else if(index <= step*3){
        return 'C';
      }else if(index <= step*4){
        return 'D';
      }else if(index <= step*5){
        return 'E';
      }
      return 'F';
    }
  }
}