using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Achievement.Domain.Entities
{
    public class Achievement
    {
        public string Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public AchievementType Type { get; set; }
        public int Target { get; set; }
        public Reward Reward { get; set; } = new Reward();
        public bool IsActive { get; set; }
        public string TenantId { get; set; } = string.Empty;
    }
}
