using System.ComponentModel.DataAnnotations;

namespace HouseRules.Models;

public class Chore
{
    public int Id { get; set; }
    [Required]
    [MaxLength(100, ErrorMessage = "Chore names must be 100 characters or less")]
    public string Name { get; set; }
    [Range(1,5)]
    public int Difficulty { get; set; }
    [Range(1,14)]
    public int ChoreFrequencyDays { get; set; }
    public List<ChoreAssignment> ChoreAssignments { get; set; }
    public List<ChoreCompletion> ChoreCompletions { get; set; }
    public bool ChoreOverdue
    {
        get
        {
            bool isOverdue = false;

            if (ChoreCompletions != null)
            {
                DateTime today = DateTime.Now;
                var recentCompletionDate = ChoreCompletions.Max(cc => cc.CompletedOn);
                ChoreCompletion mostRecentCompletion = ChoreCompletions.FirstOrDefault(cc => cc.CompletedOn == recentCompletionDate);
                if (recentCompletionDate.AddDays(ChoreFrequencyDays) < today)
                {
                    isOverdue = true;
                }
            }

            return isOverdue;
        }
    }
}