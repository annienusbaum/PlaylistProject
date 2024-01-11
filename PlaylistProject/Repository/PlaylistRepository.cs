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

