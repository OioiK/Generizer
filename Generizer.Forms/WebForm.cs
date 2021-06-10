using Generizer.Forms.Controls;
using System.Collections.Generic;

namespace Generizer.Forms
{
    internal class WebForm
    {
        internal WebForm()
        {
            this.Items = new List<IControl>();
        }

        internal string Name { get; set; }
        internal List<IControl> Items { get; set; }
        internal string Postmessage { get; set; }
    }
}
