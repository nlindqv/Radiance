using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SceneInfoLoader  {
    public static List<SceneInfo> GetSceneInfo() {
        string resourcePath = "sceneInfoList";
        TextAsset targetFile = Resources.Load<TextAsset>(resourcePath);
        SceneInfoList sceneinfoList = UnityEngine.JsonUtility.FromJson<SceneInfoList>(targetFile.text);

        return sceneinfoList.List;
    }

}
