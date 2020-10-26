using System;
using System.Collections.Generic;

namespace Domain
{
    public class Style
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public ICollection<StyleOption> Options { get; set; }
    }
}
