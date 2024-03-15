using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaToDoList.Shared.Enties
{
    public class TaskGoal
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool Important { get; set; }
        public DateTime Date { get; set; }
        public bool Estatus { get; set; }
    }
}
