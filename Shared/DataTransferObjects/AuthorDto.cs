﻿namespace Shared.DataTransferObjects
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public string? FullName { get; set; }

        public DateTime BirthDay { get; set; }

        public bool Gender { get; set; }

    }
}
