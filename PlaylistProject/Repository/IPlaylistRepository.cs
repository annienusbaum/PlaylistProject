using System;
using PlaylistProject.Models;

namespace PlaylistProject
{
	public interface IPlaylistRepository
	{
		public IEnumerable<Playlist> GetPlaylists();
		public int UpdatePlaylist(int playlistId);
		public int CreatePlaylist(Playlist playlist);
	}

	//interfaces for each class. reason we have them is for testing
	//good practice to use interfaces with dependancy injection
	//can swap out the class implementations to ensure you don't mess up the code
	//good to have interfaces if your classes have methods 

}

