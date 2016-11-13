using UnityEngine;

namespace Borodar.FarlandSkies.LowPoly
{
    public class GroundToggle : MonoBehaviour
    {
        public MeshRenderer GroundRenderer;
        public GameObject Trees;
        public GameObject Boulders;

        public void OnValueChanged(bool value)
        {
            GroundRenderer.enabled = value;
            Trees.SetActive(value);
            Boulders.SetActive(value);
        }
    }
}