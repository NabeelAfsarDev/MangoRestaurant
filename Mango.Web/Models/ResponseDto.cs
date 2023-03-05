﻿namespace Mango.Web.Models
{
    public class ResponseDto
    {
        public bool IsSucess { get; set; } = true;
        public object Result { get; set; }
        public string DisplayMessage { get; set; } = string.Empty;
        public List<string> ErrorMessages { get; set; }
    }
}