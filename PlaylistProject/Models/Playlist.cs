using System;
namespace PlaylistProject.Models
{
    public class Playlist
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public string Genre { get; set; } = string.Empty;
        public DateTime? ModifiedAt { get; set; }
    }
}
