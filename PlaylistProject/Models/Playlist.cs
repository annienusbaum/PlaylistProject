using System;
namespace PlaylistProject.Models
{
	public class Playlist
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string? CreatedAt { get; set; }
		public string ModifiedAt { get; set; } = string.Empty;
        public string SongId { get; set; } = string.Empty;

    }
}
