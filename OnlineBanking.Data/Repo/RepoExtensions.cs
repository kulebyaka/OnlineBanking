﻿using System.Collections.Generic;
using System.Linq;

namespace OnlineBanking.Data.Repo
{
    public static class RepoExtensions
    {
        public static bool TryGetById<T>(this IRepository<T> repo, int id, out T r) where T : class, IEntity
        {
            r = repo.Get().FirstOrDefault(x => x.Id == id);
            return r != null;
        }

        public static T GetById<T>(this IRepository<T> repo, int id) where T : class, IEntity
        {
            if (!repo.TryGetById(id, out var r))
            {
                throw new KeyNotFoundException($"Object of type '{typeof(T).Name}' with the key '{id}' not found");
            }

            return r;
        }
    }
}
