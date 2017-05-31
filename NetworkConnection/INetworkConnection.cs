﻿using System;


namespace NetworkConnection
{
    public interface INetworkConnection
    {
        bool IsConnected { get; }
        string CheckNetworkConnection();

    }
}
