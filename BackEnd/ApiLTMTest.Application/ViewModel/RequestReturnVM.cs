namespace ApiLTMTest.Application.ViewModel
{
    public class RequestReturnVM<TDataType>
    {
        public string MessageTitle { get; set; }

        public string MessageBody { get; set; }

        public bool Success { get; set; }

        public TDataType Data { get; set; }
    }
}
