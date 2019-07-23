using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_SharpClassProject2
{
    public class Workouts
    {
        public string Id;
        public string Type;
        public string Name;

        public override string ToString()
        {
            return this.Id + "," +
                   this.Type + "," +
                   this.Name + Environment.NewLine;
        }
    }
}
