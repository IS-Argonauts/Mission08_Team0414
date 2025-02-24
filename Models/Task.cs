using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission08_Team0414.Models
{
	public class Task()
	{
		[Key]
		[Required]
		public int TaskId { get; set; }
		public string TaskName { get; set; }
		public string DueDate {  get; set; }
		public int Quadrant {  get; set; }
		public string Category {  get; set; }
		public bool Completed { get; set; }
	}
}
