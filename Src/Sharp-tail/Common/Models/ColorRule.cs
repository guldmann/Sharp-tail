

using System;

namespace Common.Models
{
    public class ColorRule
    {
        public ColorRule()
        {
            Id = Guid.NewGuid();
        }

        public string Text { get; set; }
        public RuleColor Background { get; set; }
        public RuleColor ForeGround { get; set; }
        public Guid Id { get; }

    }

    public class RuleColor
    {
        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }
    }
}
