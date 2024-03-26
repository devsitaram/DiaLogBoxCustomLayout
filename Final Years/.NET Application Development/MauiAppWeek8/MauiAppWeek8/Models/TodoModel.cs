using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppWeek8.Models
{
	public class TodoModel
	{
        public int Id { get; set; }
        public string? Task { get; set; }
        public bool IsCompleted { get; set; }
    }
}
