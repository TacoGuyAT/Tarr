using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Tarr.UIElements {
    public class StackPanel : UIContainer {
        public UIOrientation Orientation;
        public override GameObject Instantiate(Transform parent) {
            var go = GameObject.Instantiate(prefab, parent, false);

            return go;
        }
    }
}
