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

        public IEnumerable<Playlist> GetPlaylist()
        {
            return _connection.Query<Playlist>("SELECT * FROM Playlists");
        }

    }
}

/*
 * dependancy injection - 
 */
