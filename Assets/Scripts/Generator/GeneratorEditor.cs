#if UNITY_EDITOR

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LevelGenerator))]
public class GeneratorEditor : Editor
{
    private SerializedProperty _blocks;
    private bool _autoAddBlocks;
    private GameObject[] _blocksResources;
    private SerializedProperty _background;

    private void OnEnable()
    {
        _blocks = serializedObject.FindProperty("blocks");
        _background = serializedObject.FindProperty("background");
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        if(GUILayout.Button("Refresh"))
            ((LevelGenerator)target).RefreshBlocks();
    }
}

#endif