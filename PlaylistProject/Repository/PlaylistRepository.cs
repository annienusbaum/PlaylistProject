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

        public int DeletePlaylist(int playlistId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Playlist> GetPlaylist()
        {
            return _connection.Query<Playlist>("SELECT * FROM Playlists");
        }

        public int UpdatePlaylist(Playlist playlist)
        {
            throw new NotImplementedException();
        }

    }
}

/*
 *         SELECT* FROM Songs WHERE Genre = "guitar";

 * dependancy injection - 
 * 
 * 	//see last method DeletePlaylist was added on 12/31/2023. Attempting to
	// implement Delete Functionality once a playlist is saved by the user

// // For line 18, CreatePlaylist method.
//Inserts the new playlist into the Playlist table System System.Data Dapper Org.BouncyCastle.Utilities PlaylistProject.Models PlaylistProject
Add a new folder in Views called MyPlaylist
Create the following mvc views in the MyPlaylist folder
DeleteSuccessful.cshtml
Index.cshtml
 // You will want to use ExecuteScalar to return the Id // See:
//https://www.learndapper.com/dapper-query/selecting-scalar-values#dapper-executescalar throw
new NotImplementedException(); 
 */
