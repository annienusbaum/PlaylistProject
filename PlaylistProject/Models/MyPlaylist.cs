using System;
namespace PlaylistProject.Models
{
    public class MyPlaylist
    {
        public int Id { get; set; }
        public List<Song> Songs { get; set; }
        public string PlaylistName { get; set; }

    }
}

