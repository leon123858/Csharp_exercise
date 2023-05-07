public class Result
{
    public int status { get; set; } = 0;
    public string message { get; set; } = "";

    public Result(int _status, string _msg)
    {
        status = _status;
        message = _msg;
    }
}
