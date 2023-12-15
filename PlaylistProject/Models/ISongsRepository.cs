using System;
namespace PlaylistProject.Models
{
	public interface ISongsRepository
	{
        public IEnumerable<Songs> GetAllSongs();
		public Songs GetSong(int id);
		public void UpdateSong(Songs song);

	}
}

//may have to use system.collections.generic;??