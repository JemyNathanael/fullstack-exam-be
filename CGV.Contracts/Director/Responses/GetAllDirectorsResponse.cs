﻿namespace CGV.Contracts.Director.Responses
{
    public class GetAllDirectorsResponse
    {
        public List<DirectorData> DirectorDatas { get; set; } = new List<DirectorData>();
    }

    public class DirectorData
    {
        public Guid DirectorId { get; set; }
        public string DirectorName { get; set; } = null!;
    }
}
