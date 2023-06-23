using System;

namespace Xolit.Api.Repository.Entity.Base
{
    public interface IEntity
    {
        public int Id { get; set; }

        public DateTime DateCreate { get; set; }

        public DateTime? DateUpdate { get; set; }
    }
}
