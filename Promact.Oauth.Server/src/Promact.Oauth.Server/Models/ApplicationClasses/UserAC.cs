﻿using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace Promact.Oauth.Server.Models.ApplicationClasses
{
    public class UserAc
    {
        [JsonProperty("Id")]
        public string Id { get; set; }

        [Required]
        [StringLength(255)]
        [JsonProperty("FirstName")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(255)]
        [JsonProperty("LastName")]
        public string LastName { get; set; }

        [JsonProperty("IsActive")]
        public bool IsActive { get; set; }

        [JsonProperty("Role")]
        public string Role { get; set; }

        [JsonProperty("NumberOfCasualLeave")]
        public double NumberOfCasualLeave { get; set; }

        [JsonProperty("NumberOfSickLeave")]
        public double NumberOfSickLeave { get; set; }

        [JsonProperty("JoiningDate")]
        public DateTime JoiningDate { get; set; }

        [JsonProperty("SlackUserName")]
        public string SlackUserName { get; set; }

        [JsonProperty("SlackUserId")]
        public string SlackUserId { get; set; }

        [Required]
        [EmailAddress]
        [JsonProperty("Email")]
        public string Email { get; set; }

        [StringLength(255)]
        [JsonProperty("Password")]
        public string Password { get; set; }

        [JsonProperty("UserName")]
        public string UserName { get; set; }

        [JsonProperty("UniqueName")]
        public string UniqueName { get { return FirstName + "-" + Email; } }

        [JsonProperty("RoleName")]
        public string RoleName { get; set; }
    }
}
