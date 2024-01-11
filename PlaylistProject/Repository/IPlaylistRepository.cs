using System;
using PlaylistProject.Models;
using ZstdSharp.Unsafe;

namespace PlaylistProject
{
    public interface IPlaylistRepository
    {
        public int UpdatePlaylist(Playlist playlist);
        public int CreatePlaylist(Playlist playlist);
        public int DeletePlaylist(int playlistId);
        public IEnumerable<Playlist> GetPlaylists();

    }

}


