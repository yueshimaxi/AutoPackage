using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;

public static  class BuildTool
{

    public static string[] FindEnableScene()
    {
        List<string> scenes = new List<string>();
        foreach (var sceneItem in EditorBuildSettings.scenes)
        {
            if (!sceneItem.enabled) continue;
            scenes.Add(sceneItem.path);
            Debug
                .Log($"sceneItem.path:{sceneItem.path}");
        }
        return scenes.ToArray();
    }

    [MenuItem("Build/Build PC")]
    public static void BuildPC()
    {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = FindEnableScene();
        buildPlayerOptions.locationPathName = "PCBuild/PCDemo.exe";
        buildPlayerOptions.target = BuildTarget.StandaloneWindows;
        buildPlayerOptions.options = BuildOptions.None;

        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        //BuildReport report =BuildPipeline.BuildPlayer(FindEnableScene(), Application.dataPath + "/../PCBuild/", BuildTarget.StandaloneWindows, BuildOptions.None);
        BuildSummary summary = report.summary;

        if (summary.result == BuildResult.Succeeded)
        {
            Debug.Log("Build succeeded: " + summary.totalSize + " bytes");
        }

        if (summary.result == BuildResult.Failed)
        {
            Debug.Log("Build failed");
        }
    }


    [MenuItem("Build/Build WebGL")]
    public static void BuildWebGL()
    {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = FindEnableScene();
        buildPlayerOptions.locationPathName = "WebGLBuild/packDemo";
        buildPlayerOptions.target = BuildTarget.WebGL;
        buildPlayerOptions.options = BuildOptions.None;

        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        BuildSummary summary = report.summary;

        if (summary.result == BuildResult.Succeeded)
        {
            Debug.Log("Build succeeded: " + summary.totalSize + " bytes");
        }

        if (summary.result == BuildResult.Failed)
        {
            Debug.Log("Build failed");
        }
    }
}
