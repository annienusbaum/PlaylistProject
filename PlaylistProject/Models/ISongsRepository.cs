using System;
namespace PlaylistProject.Models
{
	public interface ISongsRepository
	{
        public IEnumerable<Song> GetAllSongs();
		public Song GetSong(int id);
		public void UpdateSong(Song song);
		public void DeleteSong(Song song);
	}
}

//may have to use system.collections.generic;??