using UnityEditor;

namespace Borodar.FarlandSkies.LowPoly
{
    [CustomEditor(typeof(SkyboxController))]
    public class SkyboxControllerEditor : Editor
    {
        // Skybox
        private SerializedProperty _skyboxMaterial;
        // Sky
        private SerializedProperty _skyTopColor;
        private SerializedProperty _skyMiddleColor;
        private SerializedProperty _skyBottomColor;
        private SerializedProperty _skyTopExponent;
        private SerializedProperty _skyBottomExponent;
        // Stars
        private SerializedProperty _starsTint;
        private SerializedProperty _starsExtinction;
        private SerializedProperty _starsTwinklingSpeed;
        // Sun
        private SerializedProperty _sunLight;
        private SerializedProperty _sunTint;
        private SerializedProperty _sunSize;
        private SerializedProperty _sunFlare;
        private SerializedProperty _sunFlareBrightness;
        // Moon
        private SerializedProperty _moonLight;
        private SerializedProperty _moonTint;
        private SerializedProperty _moonSize;
        private SerializedProperty _moonFlare;
        private SerializedProperty _moonFlareBrightness;
        // Clouds
        private SerializedProperty _cloudsTint;
        private SerializedProperty _cloudsHeight;
        private SerializedProperty _cloudsRotation;
        // General
        private SerializedProperty _exposure;
        private SerializedProperty _adjustFogColor;
        
        //---------------------------------------------------------------------
        // Public
        //---------------------------------------------------------------------

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            CustomGUILayout();
            serializedObject.ApplyModifiedProperties();
        }

        //---------------------------------------------------------------------
        // Protected
        //---------------------------------------------------------------------

        protected void OnEnable()
        {
            // Skybox
            _skyboxMaterial = serializedObject.FindProperty("SkyboxMaterial");
            // Sky
            _skyTopColor = serializedObject.FindProperty("_topColor");
            _skyMiddleColor = serializedObject.FindProperty("_middleColor");
            _skyBottomColor = serializedObject.FindProperty("_bottomColor");
            _skyTopExponent = serializedObject.FindProperty("_topExponent");
            _skyBottomExponent = serializedObject.FindProperty("_bottomExponent");
            // Stars
            _starsTint = serializedObject.FindProperty("_starsTint");
            _starsExtinction = serializedObject.FindProperty("_starsExtinction");
            _starsTwinklingSpeed = serializedObject.FindProperty("_starsTwinklingSpeed");
            // Sun
            _sunLight = serializedObject.FindProperty("_sunLight");
            _sunTint = serializedObject.FindProperty("_sunTint");
            _sunSize = serializedObject.FindProperty("_sunSize");
            _sunFlare = serializedObject.FindProperty("_sunFlare");
            _sunFlareBrightness = serializedObject.FindProperty("_sunFlareBrightness");
            // Moon
            _moonLight = serializedObject.FindProperty("_moonLight");
            _moonTint = serializedObject.FindProperty("_moonTint");
            _moonSize = serializedObject.FindProperty("_moonSize");
            _moonFlare = serializedObject.FindProperty("_moonFlare");
            _moonFlareBrightness = serializedObject.FindProperty("_moonFlareBrightness");
            // Clouds
            _cloudsTint = serializedObject.FindProperty("_cloudsTint");
            _cloudsHeight = serializedObject.FindProperty("_cloudsHeight");
            _cloudsRotation = serializedObject.FindProperty("_cloudsRotation");
            
            // General
            _exposure = serializedObject.FindProperty("_exposure");
            _adjustFogColor = serializedObject.FindProperty("_adjustFogColor");
        }

        //---------------------------------------------------------------------
        // Helpers
        //---------------------------------------------------------------------

        private void CustomGUILayout()
        {
            // Skybox
            EditorGUILayout.Space();
            EditorGUILayout.PropertyField(_skyboxMaterial);
            EditorGUILayout.Space();

            // Sky
            EditorGUILayout.BeginVertical("Box");
            EditorGUILayout.LabelField("Sky", EditorStyles.boldLabel);
            EditorGUILayout.EndVertical();

            EditorGUILayout.PropertyField(_skyTopColor);
            EditorGUILayout.PropertyField(_skyMiddleColor);
            EditorGUILayout.PropertyField(_skyBottomColor);
            EditorGUILayout.Space();
            EditorGUILayout.PropertyField(_skyTopExponent);
            EditorGUILayout.PropertyField(_skyBottomExponent);
            EditorGUILayout.Space();

            // Stars
            EditorGUILayout.BeginVertical("Box");
            EditorGUILayout.LabelField("Stars", EditorStyles.boldLabel);
            EditorGUILayout.EndVertical();

            EditorGUILayout.PropertyField(_starsTint);
            EditorGUILayout.PropertyField(_starsExtinction);
            EditorGUILayout.PropertyField(_starsTwinklingSpeed);
            EditorGUILayout.Space();

            // Sun
            EditorGUILayout.BeginVertical("Box");
            EditorGUILayout.LabelField("Sun", EditorStyles.boldLabel);
            EditorGUILayout.EndVertical();

            EditorGUILayout.PropertyField(_sunLight);
            EditorGUILayout.PropertyField(_sunTint);
            EditorGUILayout.PropertyField(_sunSize);
            EditorGUILayout.PropertyField(_sunFlare);
            EditorGUILayout.PropertyField(_sunFlareBrightness);
            EditorGUILayout.Space();

            // Moon
            EditorGUILayout.BeginVertical("Box");
            EditorGUILayout.LabelField("Moon", EditorStyles.boldLabel);
            EditorGUILayout.EndVertical();

            EditorGUILayout.PropertyField(_moonLight);
            EditorGUILayout.PropertyField(_moonTint);
            EditorGUILayout.PropertyField(_moonSize);
            EditorGUILayout.PropertyField(_moonFlare);
            EditorGUILayout.PropertyField(_moonFlareBrightness);
            EditorGUILayout.Space();

            // Clouds
            EditorGUILayout.BeginVertical("Box");
            EditorGUILayout.LabelField("Clouds", EditorStyles.boldLabel);
            EditorGUILayout.EndVertical();

            EditorGUILayout.PropertyField(_cloudsTint);
            EditorGUILayout.PropertyField(_cloudsHeight);
            EditorGUILayout.PropertyField(_cloudsRotation);
            EditorGUILayout.Space();

            // General
            EditorGUILayout.BeginVertical("Box");
            EditorGUILayout.LabelField("General", EditorStyles.boldLabel);
            EditorGUILayout.EndVertical();

            EditorGUILayout.PropertyField(_exposure);
            EditorGUILayout.PropertyField(_adjustFogColor);
            EditorGUILayout.Space();
        }
    }
}