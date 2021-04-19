using Simba;
using TMPro;
using UnityEngine;

namespace Example
{
    public class TextComponent : SimbaComponent
    {
        [SerializeField] private TextMeshProUGUI textMeshPro;

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