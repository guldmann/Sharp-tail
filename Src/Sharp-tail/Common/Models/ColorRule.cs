

namespace Common.Models
{
    public class ColorRule
    {
        public string Text { get; set; }
        public RuleColor Backgrount { get; set; }
        public RuleColor ForeGround { get; set; }

    }

    public class RuleColor
    {
        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }
    }
}
