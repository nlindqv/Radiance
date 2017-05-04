using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;
using System.IO;
using UnityEditor.Callbacks;

public static class GenerateAvailableScenesJSON
{
    [PostProcessBuild]
    public static void OnPostprocessBuild(BuildTarget target, string pathToBuiltProject)
    {
        Debug.Log("OnPostprocessBuild executed");
        SceneInfoList sceneinfoList = new SceneInfoList();
        sceneinfoList.List = GetLevelScenes().Select(x => new SceneInfo { Path = x.path }).ToList();
        string jsonObj = UnityEngine.JsonUtility.ToJson(sceneinfoList);
        Debug.Log("scenes retrieved");

        using (StreamWriter writer = new StreamWriter("Assets/Resources/sceneInfoList.txt", false))
        {
            writer.Write(jsonObj);
        }

        Debug.Log("scenes written");
    }

    /// <summary>
    ///  Ger en ordnad lista baserat på namn på alla scener med sökväg i mappen "levels"
    /// </summary>
    /// <returns>Lista med levels sorterade på namn</returns>
    private static List<EditorBuildSettingsScene> GetLevelScenes()
    {
        //hämta alla scener
        List<EditorBuildSettingsScene> sceneList = new List<EditorBuildSettingsScene>();
        foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
            sceneList.Add(scene);
        //lista levels baserat på sökväg
        IEnumerable<EditorBuildSettingsScene> levelScenes = sceneList.Where(x => x.path.Contains("GameScenes/Levels")).OrderBy(x => x.path);
        return levelScenes.ToList();
    }
}
