using System;
using System.Data;
using Dapper;
using PlaylistProject.Models;

namespace PlaylistProject
{
	public class PlaylistRepository : IPlaylistRepository
	{
        private readonly System.Data.IDbConnection _connection;

		public PlaylistRepository(IDbConnection conn)
		{
			_connection = conn;
		}

        public IEnumerable<Playlist> GetPlaylists()
        {
            throw new NotImplementedException();
        }

        public int UpdatePlaylist(int playlistId)
        {
            throw new NotImplementedException();
        }

        public int CreatePlaylist(Playlist playlist)
        {
            throw new NotImplementedException();
        }
    }
}

