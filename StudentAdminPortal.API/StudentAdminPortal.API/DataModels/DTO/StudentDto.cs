﻿namespace StudentAdminPortal.API.DataModels.DTO
{
    public class StudentDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public long Mobile { get; set; }
        public string? ProfileImageUrl { get; set; }
        public Guid GenderId { get; set; }

        public GenderDto Gender { get; set; }
        public AddressDto Address { get; set; }
    }
}
