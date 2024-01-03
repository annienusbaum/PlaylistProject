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

        public int AddSongs(List<MySong> mySongs)
        {
            throw new NotImplementedException();
        }

        public List<Song> GetSongsByPlaylistId(int playlistId)
        {
            {
                throw new NotImplementedException();
            }
        }
}