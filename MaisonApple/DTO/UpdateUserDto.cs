﻿namespace DTO
{
    public class UpdateUserDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }

    }
}
