using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Tarr.UIElements {
    public abstract class UIElement {
        public abstract GameObject Instantiate(Transform parent);
    }
    public enum UIOrientation {
        Horizontal,
        Vertical
    }
}
