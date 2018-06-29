using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Identity
{
    public interface IUserSessionRepository<TKey, TUserSession> : IEntityRepository<TKey, TUserSession>
        where TKey : IEquatable<TKey>
        where TUserSession : IUserSession<TKey>
    {
        Task CreateAsync(TUserSession userSession);
        void Create(TUserSession userSession);

        Task<TUserSession> FindByIdAsync(TKey id);
        TUserSession FindById(TKey id);

        Task<TUserSession> FindByKeyAsync(string key);
        TUserSession FindByKey(string key);
    }
}
