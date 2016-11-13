using UnityEditor;

namespace Borodar.FarlandSkies.LowPoly
{
    [CustomEditor(typeof(SkyboxControllerSimple))]
    public class SkyboxControllerSimpleEditor : Editor
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