﻿namespace BasicCrud.Common.Interfaces
{
    public interface ICurrentUserService
    {
        string UserId { get; }

        bool IsAuthenticated { get; }
    }
}
