using System.Text.Json;

namespace InterviewSolution.Dto
{
    public class ErrorDto
    {
        public int StatusCode { get; set; }

        public string Message { get; set; } = String.Empty;

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
