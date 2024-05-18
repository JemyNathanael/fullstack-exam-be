namespace CGV.Contracts.Region.Response
{
    public class GetAllRegionsResponse
    {
        public List<RegionData> RegionDatas { get; set; } = new List<RegionData>();
    }

    public class RegionData
    {
        public Guid RegionId { get; set; }
        public string RegionName { get; set; } = null!;
    }
}
