namespace full_structure_db.Common;

public class ApiError
{
    public bool Success { get; set; } = false;
    public string Message { get; set; }
    public object? Details { get; set; }
    public int? Code { get; set; }

    //constructor for reponse Error
    public ApiError(string message, int code, object details = null)
    {
        Message = message;
        Code = code;
        Details = details;
    }
}