﻿using Cimas.Entities.Companies;
using Cimas.Entities.WorkDays;
using Cimas.Сommon.Enums;
using System.Collections.Generic;

namespace Cimas.Entities.Users
{
    public class User : BaseEntity
    {
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string Name { get; set; }
        public Role Role { get; set; }
        public bool IsFired { get; set; }

        public virtual ICollection<WorkDay> WorkDays { get; set; }
    }
}
