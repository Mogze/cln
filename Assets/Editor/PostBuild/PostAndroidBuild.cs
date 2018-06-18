using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;

public class PostAndroidBuild
{
    [PostProcessBuildAttribute(1)]
    public static void OnPostprocessBuild(BuildTarget target, string pathToBuiltProject)
    {
        Debug.Log("testing " + pathToBuiltProject);
    }

//    [PostProcessBuildAttribute(0)]
//    public static void ReplaceAndroidManifest(BuildTarget buildTarget, string pathToBuiltProject)
//    {
//        if (buildTarget == BuildTarget.Android)
//        {
//            string manifestPath = "C:/user/~/Temp/StagingArea/AndroidManifest.xml";
//            string customManifestPath = Application.dataPath + "/Plugins/Android/AndroidManifest.xml";
//
//            FileUtil.ReplaceFile(customManifestPath, manifestPath);
//        }
//    }
}