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

    }
}

//classes not enumerable - don't make plural
//a list of type song would be a list of songs. you wouldnt call a class(blueprint
//songs