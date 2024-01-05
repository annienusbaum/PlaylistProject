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
        {
            throw new NotImplementedException();
            //foreach songs in mysongs conneection.Execute INSERTINTO MySongs WHERE SongId, pass in playlistid (will need to add a new parameter for playlistid
            // will have to be added to the interface as well
        }

        //List<Song> IMySongRepository.GetSongsByPlaylistId(int playlistId)
        //{
        //  {
        //const string Sql = ("INSERT INTO MySongs WHERE Id = @Id, Name = @Name, CreatedAt = @CreatedAt, ModifiedAt = @ModifiedAt", new { Playlist = playlistId });
        //return _connection.ExecuteScalar<Playlist>
        // }
        //}

        public void UpdatePlaylist(Playlist playlist)
        {
            _connection.Execute("UPDATE MySong SET Id = @Id, PlaylistId = @PlaylistId, SongId = @SongId WHERE Id = @Id", new { Id = playlist.Id, PlaylistId = playlist.PlaylistId, SongId = playlist.SongId });


        }

        public List<Song> GetSongsByPlaylistId(int playlistId)
        {
            throw new NotImplementedException();
        }
    }
}