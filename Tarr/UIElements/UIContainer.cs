using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarr.UIElements {
    public abstract class UIContainer : UIElement {
        public readonly List<UIElement> Children = new List<UIElement>();
    }
}
