using System;
using System.Data;
using Dapper;

namespace PlaylistProject.Models
{
	public class SongRepository : ISongRepository
	{
        private readonly IDbConnection _conn;

        public SongRepository(IDbConnection conn)
		{
            _conn = conn;
		}

        public void DeleteSong(Song song)
        {
           _conn.Execute("DELETE FROM songs WHERE songid = @id;", new { id = song.SongID });
        }

        public IEnumerable<Song> GetAllSongs()
        {
            return _conn.Query<Song>("SELECT * FROM Songs;");
        }

        //another method for getallplaylists with the same table and use the samme type
        //SELECT * FROM Playlists

        public Song GetSong(int id)
        {
            return _conn.QuerySingle<Song>("SELECT * FROM SONGS WHERE SongID = @id",
                new { id = id });
        }

        public void UpdateSong(Song song)
        {
            _conn.Execute("UPDATE songs SET Name = @name, Artist = @artist WHERE SongID = @id",
                new { name = song.Name, artist = song.Artist, id = song.SongID });
        }


    }
}

/*
 query name - safe way to pass variable names to sql - dapper helps connect sql for name parameter to match
//After implementing the ISongsRepository interface, the GetAllSongs method that I need
// to give it the implementation for.
//now - need an Idbconnection and give it a value through my constructor
//
//this is deleting the song from three different tables
//
//_conn.Execute("DELETE FROM REVIEWS WHERE ProductID = @id;", new {id = product.ProductID });
_conn.Execute("DELETE FROM Sales WHERE ProductID = @id;", new { id = product.ProductID });
_conn.Execute("DELETE FROM Products WHERE ProductID = @id;", new { id = product.ProductID });
//INSERT PLAYLIST > option to name, assign songs 
*/ 