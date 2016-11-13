using UnityEngine;

namespace Borodar.FarlandSkies.LowPoly
{
    public class PausetButton : MonoBehaviour
    {
        public void OnClick()
        {
            var sceneManager = SceneManager.Instance;
            sceneManager.PauseTime = !sceneManager.PauseTime;
        }
    }
}