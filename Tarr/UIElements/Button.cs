using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Tarr.UIElements {
    public class Button : UIElement {
        private static GameObject prefab;
        public string Text;
        public Action OnClick;
        public override GameObject Instantiate(Transform parent) {
            var go = GameObject.Instantiate(prefab, parent, false);
            
            return go;
        }
    }
}
