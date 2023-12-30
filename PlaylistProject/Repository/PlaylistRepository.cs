using System;
using System.Data;
using Dapper;
using Org.BouncyCastle.Utilities;
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

        public int CreatePlaylist(Playlist playlist)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Playlist> GetPlaylist()
        {
            return _connection.Query<Playlist>("SELECT * FROM Playlists");
        }

        public IEnumerable<Playlist> GetPlaylists()
        {
            throw new NotImplementedException();
        }

        public int UpdatePlaylist(int playlistId)
        {
            throw new NotImplementedException();
        }
    }
}

/*
 *         SELECT* FROM Songs WHERE Genre = "guitar";

 * dependancy injection - 
 */
