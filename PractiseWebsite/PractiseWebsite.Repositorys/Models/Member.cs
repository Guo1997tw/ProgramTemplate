﻿using System;
using System.Collections.Generic;

namespace PractiseWebsite.Repositorys.Models;

public partial class Member
{
    public string Id { get; set; } = null!;

    public string? Name { get; set; }

    public string? NickName { get; set; }

    public string? Gender { get; set; }

    public string Account { get; set; } = null!;

    public byte[] PassWord { get; set; } = null!;

    public string? IdentityCard { get; set; }

    public DateTime? Birthdaty { get; set; }

    public string? Address { get; set; }

    public string? AcitveCity { get; set; }

    public string? ActiveArea { get; set; }

    public string? Phone { get; set; }

    public string? HeadShot { get; set; }

    public string? PersonalProfile { get; set; }

    public string Status { get; set; } = null!;

    public string OnlineStatus { get; set; } = null!;

    public DateTime CreationDate { get; set; }

    public DateTime? LastSignIn { get; set; }
}
