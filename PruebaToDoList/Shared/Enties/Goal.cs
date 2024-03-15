using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaToDoList.Shared.Enties
{
    public class Goal
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(80)]
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int NumTask { get; set; }
        public int NumCompleteTask { get; set; }
        public double Progress 
        {
            get
            {
                if (NumTask == 0)
                {
                    return 0;
                }
                return (double)NumCompleteTask / NumTask;
            }
        }

    }
}
