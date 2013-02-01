using System;
using FubuPersistence;

namespace FubuInAction.Albums
{
    public class Album : IEntity
    {
        public Guid Id { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public string Artist { get; set; }
        public string Name { get; set; }
    }
}