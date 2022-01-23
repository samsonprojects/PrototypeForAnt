using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Sonol.Api.Helpers
{
    public static class EntryTextExtensions
    {

        public static string  ReturnRegistrationDateAndPlanRef(this List<string> rows)
        {
            var RegistrationDateAndPlanRefText= new StringBuilder();
            var RowCount = 0;
            for(int index = 0; index < rows.Count; index ++)
            {   
                var CurrentEntryTextRow = CleanLine(rows[index]);
                var Line = CurrentEntryTextRow.Split("     ").ToList();
                var CleanedTextListResult = Line.RemoveAll(x=> string.IsNullOrWhiteSpace(x));
                //handles first section
                if(RowCount < 2)
                {
                    RegistrationDateAndPlanRefText.Append(Line[0]+" "); 
                }
                                
                RowCount+= 1;
            }

            return RegistrationDateAndPlanRefText.ToString();

        }

        public static string  ReturnNote(this List<string> rows)
        {
            for(int index = 0; index < rows.Count; index ++)
            {   
                var CurrentEntryTextRow = CleanLine(rows[index]);
                if(CurrentEntryTextRow.ToLower().Contains("note:"))
                {
                    var texts = CurrentEntryTextRow.Split(':').ToList();
                    var noteText = texts[1];
                    return noteText;
                }

            }

            return null;
        }


        public static string  ReturnPropertyDescription(this List<string> rows)
        {
            var propertyDescription= new StringBuilder();
            var rowcount = 0;
            for(int index = 0; index < rows.Count; index ++)
            {   
                var CurrentEntryTextRow = CleanLine(rows[index]);
                
                var line = CurrentEntryTextRow.Split("     ").ToList();
                if(rowcount < 2 && line.Count() > 1)
                {
                    propertyDescription.Append(line[1]+ " "); 
                }
                else if(!CurrentEntryTextRow.ToLower().StartsWith("note"))
                {
                    propertyDescription.Append(line[0] +" ");

                }
                
                rowcount+= 1;
            }

            return propertyDescription.ToString();
        }

        public static string ReturnLeaseTitle(this List<string> rows)
        {
            var LeaseTitle= "";
            var RowCount = 0;
            for(int index = 0; index < rows.Count; index ++)
            {   
                var CurrentEntryTextRow = CleanLine(rows[index]);
                
                var line = CurrentEntryTextRow.Split("     ").ToList();
                if(RowCount == 0)
                {
                    LeaseTitle = line[line.Count-1].Trim();
                }
                
                RowCount+= 1;
            }

            return LeaseTitle;
        }

        public static string CleanLine(this string line)
        {
            if(string.IsNullOrEmpty(line))
            {
                return "";
            }
            return line;
        }


        public static string CleanLeaseAndTermDateRow(this List<string> Line,int row)
        {
            if (Line.Count() > 1 && row == 0)
            {
                return Line[2];
            }
            else if(row == 0)
            {
                return Line[Line.Count -1];
            }
            
            // Regex Reg =  new Regex(@"(\d+)[.](\d+)[.](\d+)");
            // var MatchTry = Reg.Match(Line);
            // if(MatchTry.Success)
            // {

            // }
            return "";
        }
        public static string ReturnDateOfLeaseAndTerm(this List<string> rows)
        {
            var LeaseTitle= new StringBuilder();
             var RowCount = 0;
            for(int index = 0; index < rows.Count; index ++)
            {   
                var CurrentEntryTextRow = CleanLine(rows[index]);
                var Line =  CurrentEntryTextRow.Split("  ").ToList();

                var LeaseTitleList = Line.RemoveAll(x=> string.IsNullOrWhiteSpace(x));
                //handles first section
                if(RowCount < 1 && Line.Count()> 1)
                {
                    var ParsedLeaseTitleLine= "";
                        if(RowCount == 0 && Line.Count == 2)
                        {
                            //get last element in this scenario
                            ParsedLeaseTitleLine = Line[1];
                        }
                        else if (Line.Count() > 1 && RowCount == 0)
                        {
                            ParsedLeaseTitleLine = Line[2];
                        }                        
                        else if(RowCount == 0)
                        {
                            ParsedLeaseTitleLine = Line[Line.Count -1];
                        }
                    LeaseTitle.Append(ParsedLeaseTitleLine +" "); 
                }
                else if(RowCount == 1)
                {   //handles second section¬
                    LeaseTitle.Append(Line[Line.Count - 1] + " ");
                }
                else if(!CurrentEntryTextRow.ToLower().StartsWith("note") && RowCount == 2)
                {
                    
                    LeaseTitle.Append(Line[Line.Count -1].Trim());

                }
                
                RowCount+= 1;
            }

            return LeaseTitle.ToString();
        }


    }
}