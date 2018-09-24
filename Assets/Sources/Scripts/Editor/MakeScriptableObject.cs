using UnityEngine;
using UnityEditor;

public class MakeScriptableObject
{
    [MenuItem("Mogze/Create/AudioDictionary")]
    public static void CreateAudioDictionary()
    {
        AudioDictionary asset = ScriptableObject.CreateInstance<AudioDictionary>();

        AssetDatabase.CreateAsset(asset, "Assets/Resources/AudioDictionary.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
}