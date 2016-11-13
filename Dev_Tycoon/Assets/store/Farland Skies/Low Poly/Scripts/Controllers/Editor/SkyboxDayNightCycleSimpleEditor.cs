using Borodar.FarlandSkies.Core.DotParams;
using Borodar.FarlandSkies.Core.ReorderableList;

using UnityEditor;
using UnityEngine;

namespace Borodar.FarlandSkies.LowPoly
{
    [CustomEditor(typeof(SkyboxDayNightCycleSimple))]
    public class SkyboxDayNightCycleSimpleEditor : Editor
    {
        private const float LIST_CONTROLS_PAD = 20f;
        private const float TIME_WIDTH = BaseParamDrawer.TIME_FIELD_WIDHT + LIST_CONTROLS_PAD;

        // Sky
        private SerializedProperty _skyDotParams;
        // Stars
        private SerializedProperty _starsDotParams;
        // Clouds
        private SerializedProperty _cloudsDotParams;

        private bool _showSkyDotParams;
        private bool _showStarsDotParams;
        private bool _showCloudsDotParams;

        private GUIContent _guiContent;
        private GUIContent _skyParamsLabel;
        private GUIContent _starsParamsLabel;
        private GUIContent _cloudsParamsLabel;

        protected void OnEnable()
        {
            _guiContent = new GUIContent();
            _skyParamsLabel = new GUIContent("Sky Dot Params", SkyboxDayNightCycle.SKY_TOOLTIP);
            _starsParamsLabel = new GUIContent("Stars Dot Params", SkyboxDayNightCycle.STARS_TOOLTIP);
            _cloudsParamsLabel = new GUIContent("Clouds Dot Params", SkyboxDayNightCycle.CLOUDS_TOOLTIP);

            _skyDotParams = serializedObject.FindProperty("_skyParamsList").FindPropertyRelative("Params");
            _starsDotParams = serializedObject.FindProperty("_starsParamsList").FindPropertyRelative("Params");
            _cloudsDotParams = serializedObject.FindProperty("_cloudsParamsList").FindPropertyRelative("Params");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            CustomGUILayout();
            serializedObject.ApplyModifiedProperties();
        }

        //---------------------------------------------------------------------
        // Helpers
        //---------------------------------------------------------------------

        private void CustomGUILayout()
        {
            EditorGUILayout.Space();

            // Sky

            EditorGUILayout.BeginVertical("Box");
            EditorGUILayout.LabelField("Sky", EditorStyles.boldLabel);
            EditorGUILayout.EndVertical();

            _showSkyDotParams = EditorGUILayout.Foldout(_showSkyDotParams, _skyParamsLabel);
            EditorGUILayout.Space();
            if (_showSkyDotParams)
            {
                SkyParamsHeader();
                ReorderableListGUI.ListField(_skyDotParams);
            }

            // Stars

            EditorGUILayout.BeginVertical("Box");
            EditorGUILayout.LabelField("Stars", EditorStyles.boldLabel);
            EditorGUILayout.EndVertical();

            _showStarsDotParams = EditorGUILayout.Foldout(_showStarsDotParams, _starsParamsLabel);
            EditorGUILayout.Space();
            if (_showStarsDotParams)
            {
                StarsParamsHeader();
                ReorderableListGUI.ListField(_starsDotParams);
            }

            // Clouds

            EditorGUILayout.BeginVertical("Box");
            EditorGUILayout.LabelField("Clouds", EditorStyles.boldLabel);
            EditorGUILayout.EndVertical();

            _showCloudsDotParams = EditorGUILayout.Foldout(_showCloudsDotParams, _cloudsParamsLabel);
            EditorGUILayout.Space();
            if (_showCloudsDotParams)
            {
                CloudsParamsHeader();
                ReorderableListGUI.ListField(_cloudsDotParams);
            }
        }

        private void SkyParamsHeader()
        {
            var position = GUILayoutUtility.GetRect(_guiContent, ReorderableListStyles.Title);
            if (Event.current.type == EventType.Repaint)
            {
                var baseWidht = position.width;
                // Time
                position.width = TIME_WIDTH;
                _guiContent.text = "Time";
                ReorderableListStyles.Title.Draw(position, _guiContent, false, false, false, false);
                // Top Color
                position.x += position.width;
                position.width = (baseWidht - position.width) / 3f - LIST_CONTROLS_PAD + BaseParamDrawer.H_PAD;
                _guiContent.text = "Top Color";
                ReorderableListStyles.Title.Draw(position, _guiContent, false, false, false, false);
                // Middle Color
                position.x += position.width;
                _guiContent.text = "Middle Color";
                ReorderableListStyles.Title.Draw(position, _guiContent, false, false, false, false);
                // Bottom Color
                position.x += position.width;
                position.width += LIST_CONTROLS_PAD + BaseParamDrawer.H_PAD;
                _guiContent.text = "Bottom Color";
                ReorderableListStyles.Title.Draw(position, _guiContent, false, false, false, false);
            }
            GUILayout.Space(-1);
        }

        private void StarsParamsHeader()
        {
            var position = GUILayoutUtility.GetRect(_guiContent, ReorderableListStyles.Title);
            if (Event.current.type == EventType.Repaint)
            {
                var baseWidht = position.width;
                // Time
                position.width = TIME_WIDTH;
                _guiContent.text = "Time";
                ReorderableListStyles.Title.Draw(position, _guiContent, false, false, false, false);
                // Tint Color
                position.x += position.width;
                position.width = baseWidht - position.width;
                _guiContent.text = "Tint Color";
                ReorderableListStyles.Title.Draw(position, _guiContent, false, false, false, false);
            }
            GUILayout.Space(-1);
        }

        private void CloudsParamsHeader()
        {
            var position = GUILayoutUtility.GetRect(_guiContent, ReorderableListStyles.Title);
            if (Event.current.type == EventType.Repaint)
            {
                var baseWidht = position.width;
                // Time
                position.width = TIME_WIDTH;
                _guiContent.text = "Time";
                ReorderableListStyles.Title.Draw(position, _guiContent, false, false, false, false);
                // Tint Color
                position.x += position.width;
                position.width = baseWidht - position.width;
                _guiContent.text = "Tint Color";
                ReorderableListStyles.Title.Draw(position, _guiContent, false, false, false, false);
            }
            GUILayout.Space(-1);
        }
    }
}