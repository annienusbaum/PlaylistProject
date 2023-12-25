using System;
namespace PlaylistProject.Models
{
	public interface ISongRepository
	{
        public IEnumerable<Song> GetAllSongs();
		public Song GetSong(int id);
		public void UpdateSong(Song song);
		public void DeleteSong(Song song);
	}
}

