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

//interfaces for each class. reason we have them is for testing

//good practice to use interfaces with dependancy injection
//can swap out the class
//implementations to ensure you don't mess up the code //good to have interfaces
//if your classes have methods
