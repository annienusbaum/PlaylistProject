using System;
namespace PlaylistProject.Models
{
    public class Playlist
    {
        public string Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public object SongId { get; internal set; }
        public object PlaylistId { get; internal set; }
    }
}
