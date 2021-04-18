using Simba;
using TMPro;
using UnityEngine;

namespace Example
{
    public class TextController : SingleInstanceMonoBehaviour
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