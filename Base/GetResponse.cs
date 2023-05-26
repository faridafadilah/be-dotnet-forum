namespace SpaceWalk.Base
{
  public class GetResponse<T>
  {
    public BaseResponse Meta { get; set; }
    public T Data { get; set; }
  }
}