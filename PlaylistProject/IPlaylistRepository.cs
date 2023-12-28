using System;
namespace PlaylistProject
{
	public interface IPlaylistRepository
	{
		public IEnumerable<Models.Playlist> GetPlaylist();

	}
}

