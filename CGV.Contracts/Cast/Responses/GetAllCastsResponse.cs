namespace CGV.Contracts.Cast.Responses
{
    public class GetAllCastsResponse
    {
        public List<CastData> CastDatas { get; set; } = new List<CastData>();
    }

    public class CastData
    {
        public Guid CastId { get; set; }
        public string CastName { get; set; } = null!;
    }
}
