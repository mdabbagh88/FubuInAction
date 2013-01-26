using FubuInAction.Albums;
using FubuMVC.Core.Urls;
using FubuPersistence;
using HtmlTags;
using System.Linq;

namespace FubuInAction
{
    public class HomeEndpoint
    {
        private readonly IEntityRepository _repository;
        private readonly IUrlRegistry _urls;

        public HomeEndpoint(IEntityRepository repository, IUrlRegistry urls)
        {
            _repository = repository;
            _urls = urls;
        }

        public HomeModel Index()
        {
            var tags = _repository.All<Album>().ToList().Select(album => {
                return new LinkTag(album.Artist + " - " + album.Name, _urls.UrlFor(album, "GET"));
            });

            // You'll probably want to do more than this...
            return new HomeModel
            {
                Albums = new TagList(tags)
            };
        } 
    }

    public class HomeModel
    {
        public TagList Albums { get; set; }
    }
}