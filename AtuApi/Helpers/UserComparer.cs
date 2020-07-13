using AtuApi.Models;
using DataModels.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtuApi.Helpers
{ 
    public class UserComparer : IEqualityComparer<User>
    {
        public bool Equals(User x, User y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(User x)
        {
            return x.Id.GetHashCode();
        }
    }

    public class UserDtoComparer : IEqualityComparer<UserDtoResponse>
    {
        public bool Equals(UserDtoResponse x, UserDtoResponse y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(UserDtoResponse x)
        {
            return x.Id.GetHashCode();
        }
    }
}
