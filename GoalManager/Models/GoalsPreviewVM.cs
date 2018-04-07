using System;
using System.Collections.Generic;

namespace GoalManager.Models
{
    public class GoalsPreviewVM
    {
        public GoalsPreviewVM()
        {
        }

        public List<Goal> Todos { get; set; }
        public string Intro { get; set; }
        public string Summary { get; set; }
    }
}
