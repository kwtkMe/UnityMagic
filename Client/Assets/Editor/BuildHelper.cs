#if UNITY_IPHONE
 
using System.IO;
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;
 
public class BuildHelper
{
    // Add libz.tbd and disable bitcode when building for iOS
    // Thanks to https://github.com/jsmouret/grpc-unity-package/blob/master/example/UnityGrpcClient/Assets/Scripts/Editor/BuildHelper.cs
 
    [PostProcessBuildAttribute(1)]
    public static void OnPostProcessBuild(BuildTarget target, string path)
    {
        if (target == BuildTarget.iOS)
        {
            var projectPath = PBXProject.GetPBXProjectPath(path);
            var project = new PBXProject();
            project.ReadFromString(File.ReadAllText(projectPath));
            var targetGUID = project.TargetGuidByName(PBXProject.GetUnityTargetName());
 
            project.AddFrameworkToProject(targetGUID, "libz.tbd", false);
 
            project.SetBuildProperty(targetGUID, "ENABLE_BITCODE", "NO");
 
            File.WriteAllText(projectPath, project.WriteToString());
        }
    }
}
 
#endif