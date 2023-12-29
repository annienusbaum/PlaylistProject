using System;
namespace PlaylistProject.Models
{
	public class Song
	{
		public int SongID { get; set; }
		public string Name { get; set; } = string.Empty;
        public string? Artist { get; set; }
		public string Genre { get; set; } = string.Empty;
		public string Video { get; set; } = string.Empty;
		public bool Selected { get; set; } 
    }
}

