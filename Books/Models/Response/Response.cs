﻿namespace Books.Models.Response
{
    public class Response
    {
        public Response()
        {
            Errors = new List<Error>();
        }
        public bool IsSuccess => Errors == null || !Errors.Any();
        public IEnumerable<Error> Errors { get; set; }
    }
}
