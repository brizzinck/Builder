using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Build.Reporting;
using UnityEditor;
using UnityEngine.SceneManagement;

public class Builder : MonoBehaviour
{
    [MenuItem("Windows/build")]
    public static void BuildAPK()
    {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();

        buildPlayerOptions.scenes = new[]
        {
            "Assets/Scenes/MenuScene.unity",
            "Assets/Scenes/GameScene.unity",
            "Assets/Scenes/GameLevelsScene.unity"
        };

        buildPlayerOptions.locationPathName = "builds/Test.apk";
        buildPlayerOptions.target = BuildTarget.Android;
        buildPlayerOptions.options = BuildOptions.None;

        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        BuildSummary summary = report.summary;

        if (summary.result == BuildResult.Succeeded)
        {
            Debug.Log("BUILD IS DONE");
        }

        if (summary.result == BuildResult.Failed)
        {
            Debug.Log("BUILD FAILED");
        }
    }
}