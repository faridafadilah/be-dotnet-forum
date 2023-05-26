namespace SpaceWalk.Base
{
    public class GetAllResponse<T>
    {
        public BaseResponse Meta { get; set; }
        public IEnumerable<T> Data { get; set; }

    }
}