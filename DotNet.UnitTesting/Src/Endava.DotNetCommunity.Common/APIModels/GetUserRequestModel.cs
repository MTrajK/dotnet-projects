﻿namespace Endava.DotNetCommunity.Common.APIModels
{
    public class GetUserRequestModel
    {
        public string FileName;

        public GetUserRequestModel(string fileName)
        {
            FileName = fileName;
        }
    }
}
