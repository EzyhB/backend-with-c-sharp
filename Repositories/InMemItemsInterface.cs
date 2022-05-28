using System;
using System.Collections.Generic;
using Catalog.Entities;


namespace Catalog.Repositories
{
    public interface IInMemItemsRepoInterface
    {
        Item GetItem(Guid id);
        IEnumerable<Item> GetItems();
    }
}