using Simba;
using UnityEngine;
using UnityEngine.UI;

namespace Simba.Example
{
    public class TextComponent : SimbaComponent
    {
        [SerializeField] private Text textMeshPro;

        public string Text
        {
            get => textMeshPro.text;
            set => textMeshPro.text = value;
        }

        public override void OnAwake()
        {
        }

        public override void OnOnDestroy()
        {
        }
    }
}