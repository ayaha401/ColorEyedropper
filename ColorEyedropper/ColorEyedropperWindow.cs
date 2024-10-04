using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace AyahaGraphicDevelopTools.ColorEyedropper
{
    public class ColorEyedropperWindow : EditorWindow
    {
        /// <summary>
        /// �X�|�C�g�ł���Color
        /// </summary>
        [SerializeField]
        private List<Color> _pickedColorList = new List<Color>();

        /// <summary>
        /// SerializedObject
        /// </summary>
        private SerializedObject _serializedObject;

        /// <summary>
        /// _pickedColorList��SerializedProperty
        /// </summary>
        private SerializedProperty _pickedColorListProperty;

        /// <summary>
        /// �X�N���[���ʒu
        /// </summary>
        private Vector2 _scrollPos;
        
        /// <summary>
        /// Window���o��
        /// </summary>
        [MenuItem("AyahaGraphicDevelopTools/ColorEyedropper")]
        public static void ShowWindow()
        {
            var window = GetWindow<ColorEyedropperWindow>("ColorEyedropper");
            window.titleContent = new GUIContent("ColorEyedropper");
        }

        private void OnEnable()
        {
            _serializedObject = new SerializedObject(this);
            _pickedColorListProperty = _serializedObject.FindProperty("_pickedColorList");
        }

        private void OnGUI()
        {
            using (new EditorGUILayout.VerticalScope())
            {
                GUILayout.Label("Pick Color");

                _serializedObject.Update();
                DrawColorList();
                _serializedObject.ApplyModifiedProperties();
            }
        }

        /// <summary>
        /// Color��\������
        /// </summary>
        private void DrawColorList()
        {
            _scrollPos = EditorGUILayout.BeginScrollView(_scrollPos);
            EditorGUILayout.PropertyField(_pickedColorListProperty);
            EditorGUILayout.EndScrollView();
        }
    }
}