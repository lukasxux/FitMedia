using System;

namespace TeamsDemoApp.Application.Model
{
    public interface IEntity<Tkey> where Tkey : struct
    {
        Tkey Id { get; }
        Guid Guid { get; }
    }
}