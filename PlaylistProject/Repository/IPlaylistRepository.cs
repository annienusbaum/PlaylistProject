using System;
using PlaylistProject.Models;

namespace PlaylistProject
{
	public interface IPlaylistRepository
	{
		public IEnumerable<Playlist> GetPlaylists();
		public int UpdatePlaylist(int playlistId);
		public int CreatePlaylist(Playlist playlist);
		public int DeletePlaylist(Playlist playlist);
	}

	//interfaces for each class. reason we have them is for testing
	//good practice to use interfaces with dependancy injection
	//can swap out the class implementations to ensure you don't mess up the code
	//good to have interfaces if your classes have methods
	//
	//see last method DeletePlaylist was added on 12/31/2023. Attempting to
	// implement Delete Functionality once a playlist is saved by the user

}

