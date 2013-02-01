using FubuMVC.Core.Continuations;
using FubuPersistence;

namespace FubuInAction.Albums
{
	public class AlbumEndpoints
	{
		private readonly IEntityRepository _repository;

		public AlbumEndpoints(IEntityRepository repository)
		{
			_repository = repository;
		}

		public CreateAlbum get_albums_new(CreateAlbum album)
		{
			return album;
		}

		public FubuContinuation post_albums_new(CreateAlbum input)
		{
			var album = new Album
				{
					Artist = input.Artist,
					Name = input.Name
				};

			_repository.Update(album);

			// TODO -- this needs to default to GET
			return FubuContinuation.RedirectTo(album, "GET");
		}

		public Album get_album_Id(Album album)
		{
			return _repository.Find<Album>(album.Id);
		}

		public Album post_album(Album album)
		{
			_repository.Update(album);

			return album;
		}
	}
}