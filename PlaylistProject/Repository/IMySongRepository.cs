using System;
using PlaylistProject.Models;

namespace PlaylistProject.Repository
{
    public interface IMySongRepository
    {
        public List<Song> GetSongsByGenre(string genre);
        public List<Song> GetSongsByPlaylistId(int playlistId);
        public int AddSongs(List<MySong> mySongs, int playlistId);
        //public void UpdatePlaylist(Playlist playlist);

    }
}

