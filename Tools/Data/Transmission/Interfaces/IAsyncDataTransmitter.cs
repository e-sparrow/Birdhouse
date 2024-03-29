﻿using System.Threading.Tasks;

namespace Birdhouse.Tools.Data.Transmission.Interfaces
{
    public interface IAsyncDataTransmitter<TData>
    {
        bool IsValid();
        
        Task<TData> GetData();
        Task SetData(TData data);
    }
}