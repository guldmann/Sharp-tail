

using System;
using System.Runtime.Remoting.Messaging;
using Newtonsoft.Json;

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
        public bool Casesensitiv { get; set; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

    }

    public class RuleColor
    {
        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }
    }

   
}
