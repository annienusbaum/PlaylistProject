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
            return _connection.ExecuteScalar<int>("INSERT INTO playlists (Name, CreatedAt, ModifiedAt) VALUES (@Name, @CreatedAt, @ModifiedAt)", new { Name = playlist.Name, CreatedAt = playlist.CreatedAt, ModifiedAt = playlist.ModifiedAt });
        }

        public IEnumerable<Playlist> GetPlaylist()
        {
            return _connection.Query<Playlist>("SELECT * FROM Playlists");
        }

        public int UpdatePlaylistId(Playlist playlistId)
        {
            return _connection.ExecuteScalar<int>("UPDATE Playlists SET Name=@Name Where Id = @Id”, new {playlist.Name}", new { Id = playlist.Id, PlaylistId = playlist.PlaylistId, SongId = playlist.SongId });

        }


        public int DeletePlaylist(Playlist playlistId)
        {
            return _connection.Execute("DELETE FROM Playlist WHERE Id = @Id, PlaylistId = @playlistid, SongId = @SongId", new { Id = playlistId.PlaylistId });
        }

        public int UpdatePlaylist(Playlist playlist)
        {
            throw new NotImplementedException();
        }

        public void DeletePlaylist(int playlistId)
        {
            throw new NotImplementedException();
        }
    }
}

/*
 *         SELECT* FROM Songs WHERE Genre = "guitar";

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


"UPDATE MySongs SET Id = @Id, PlaylistId = @playlistid, SongId = @SongId"
 */
