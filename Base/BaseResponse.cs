namespace SpaceWalk.Base
{
  public class BaseResponse
  {
    public int totalPage;

    public int limit;

    public int page;

    public int totalData;
    public int code { get; set; }
    public string message { get; set; }
  }
}