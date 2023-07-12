using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class LanceP : Gold
    {
        public LanceP(string color) : base(color)
        {
            this.Image = (Image)Properties.Resources.ResourceManager.GetObject(this.GetType().Name);
            this.Color = color;
        }
    }
}