using System;
using System.Data;
using Dapper;

namespace PlaylistProject.Models
{
	public class SongsRepository : ISongsRepository
	{
        private readonly IDbConnection _conn;

        public SongsRepository(IDbConnection conn)
		{
            _conn = conn;
		}

        public IEnumerable<Songs> GetAllSongs()
        {
            return _conn.Query<Songs>("SELECT * FROM Songs;");
        }

        public Songs GetSong(int id)
        {
            return _conn.QuerySingle<Songs>("SELECT * FROM SONGS WHERE SONGID = @id",
                new { id = id });
        }

        public void UpdateSong(Songs song)
        {
            _conn.Execute("UPDATE songs SET SongName = @name, SongArtist = @artist WHERE SongID = @id",
                new { name = song.SongName, artist = song.SongArtist, id = song.SongID });
        }
    }
}

//After implementing the ISongsRepository interface, the GetAllSongs method that I need
// to give it the implementation for.
//now - need an Idbconnection and give it a value through my constructor        