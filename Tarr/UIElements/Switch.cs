using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Tarr.UIElements {
    public class Switch : UIElement {
        public bool Value;
        public override GameObject Instantiate(Transform parent) {
            var go = GameObject.Instantiate(prefab, parent, false);

            return go;
        }
    }
}
