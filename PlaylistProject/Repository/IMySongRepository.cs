using System;
using PlaylistProject.Models;

namespace PlaylistProject.Repository
{
	public interface IMySongRepository
	{
        public List<Song> GetSongsByGenre(string genre);
    }
}

