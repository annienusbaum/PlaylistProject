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

        public int CreatePlaylist(Playlist playlist)
        {
            return _connection.Execute("INSERT INTO playlists (Name, Genre, CreatedAt, ModifiedAt) VALUES (@Name, @Genre, @CreatedAt, @ModifiedAt)", new { playlist.Name, playlist.Genre, playlist.CreatedAt, playlist.ModifiedAt });
        }
        //maybe have to put a return type on the QuerySingle - try Query<int>
        public IEnumerable<Playlist> GetPlaylists()
        {
            return _connection.Query<Playlist>("SELECT * FROM Playlists");
        }

        public int UpdatePlaylist(Playlist playlist)
        {
            return _connection.ExecuteScalar<int>("UPDATE Playlists SET Name=@Name Where Id=@Id", new { Name = playlist.Name, Id = playlist.Id }); //anonynomous object

        }


        public int DeletePlaylist(int playlistId)
        {
            return _connection.Execute("DELETE FROM Playlists WHERE Id = @Id", new { Id = playlistId });
        }

    }
}

/*

 * dependancy injection - 
 * 
 * 	
// // For line 18, CreatePlaylist method.
//Inserts the new playlist into the Playlist table System System.Data Dapper Org.BouncyCastle.Utilities PlaylistProject.Models PlaylistProject
Add a new folder in Views called MyPlaylist
Create the following mvc views in the MyPlaylist folder
DeleteSuccessful.cshtml
Index.cshtml
 // You will want to use ExecuteScalar to return the Id // See:
//https://www.learndapper.com/dapper-query/selecting-scalar-values#dapper-executescalar throw
new NotImplementedException();
            return _connection.QuerySingle("INSERT INTO playlists (Name, CreatedAt, ModifiedAt) VALUES (@Name, @CreatedAt, @ModifiedAt); SELECT LAST_INSERT_ID();)", new { Name = playlist.Name, CreatedAt = playlist.CreatedAt, ModifiedAt = playlist.ModifiedAt });

return _connection.Query("INSERT INTO playlists (Name, CreatedAt, ModifiedAt) VALUES (@Name, @CreatedAt, @ModifiedAt); SELECT LAST_INSERT_ID();)", new { Name = playlist.Name, CreatedAt = playlist.CreatedAt, ModifiedAt = playlist.ModifiedAt });
SELECT LAST_INSERT_ID() AS id
SELECT LAST_INSERT_ID() AS id
"UPDATE MySongs SET Id = @Id, PlaylistId = @playlistid, SongId = @SongId"
 */
