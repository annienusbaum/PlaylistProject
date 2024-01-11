using System;
using System.Data;
using System.Data.Common;
using Dapper;
using PlaylistProject.Repository;

namespace PlaylistProject.Models
{
    public class MySongRepository : IMySongRepository
    {
        private readonly IDbConnection _connection;

        public MySongRepository(IDbConnection connection)
        { _connection = connection; }

        public List<Song> GetSongsByGenre(string genre)
        {
            return _connection.Query<Song>("SELECT * FROM Songs WHERE Genre = @Genre", new { Genre = genre }).ToList();
        }

        public int AddSongs(List<MySong> mySongs, int playlistId)
        {//loop through mySongs and insert a new record into the mysongs table
            throw new NotImplementedException();
        }


        public void UpdatePlaylist(Playlist playlist)
        {
            _connection.Execute("UPDATE MySong SET Id = @Id, PlaylistId = @PlaylistId, SongId = @SongId WHERE Id = @Id", new { Id = playlist.Id, ModifiedAt = DateTime.Now });

        }

        public List<Song> GetSongsByPlaylistId(int playlistId)
        {
            throw new NotImplementedException();
        }

        public void DeletePlaylist(int id)
        {
            _connection.Execute("DELETE FROM playlists WHERE Id = @Id", new { Id = id });
        }

        public void DeleteSongFromPlaylist(int playlistId, int songId)
        {
            _connection.Execute("DELETE FROM MySongs WHERE PlaylistId = @PlaylistId AND SongId = @SongId", new { PlaylistId = playlistId, SongId = songId });
        }

    }
}