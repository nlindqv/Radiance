using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine.UI;
using UnityEditor;
[RequireComponent(typeof(RectTransform))]
public class MenuLevelsLister : MonoBehaviour {
    GameObject foregroundGameObj;
	// Use this for initialization
	void Start () {
        //get foreground component
        RectTransform foreground = GetComponent<RectTransform>();
        // get gameobject for foreground component
        foregroundGameObj = foreground.gameObject;
        //find object with sceneselector component
        Button sceneSelectorBtn = foregroundGameObj.GetComponentInChildren<Button>();
        //skapa en lista med scener som finns i buildsettings
        List<EditorBuildSettingsScene> sceneList = new List<EditorBuildSettingsScene>();
        foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
            sceneList.Add(scene);
        // skapa en ordnad lista baserat på namn på alla scener med sökväg i mappen "levels"
        IEnumerable<EditorBuildSettingsScene> levelScenes = sceneList.Where(x => x.path.Contains("GameScenes/Levels")).OrderBy(x => x.path);
        // knapp för level1
       sceneList = levelScenes.ToList();
       sceneSelectorBtn.onClick.AddListener(delegate { SceneManager.LoadScene(sceneList.First().path); });
       Text buttonText;
       float lastHeight = sceneSelectorBtn.transform.position.y;
        //skapa nya knappar för övriga nivåer
       for (int i=1; i< sceneList.Count; i++){
           lastHeight = lastHeight - 40;
         GameObject newButton =  Instantiate(sceneSelectorBtn.gameObject, new Vector3(sceneSelectorBtn.transform.position.x, lastHeight, sceneSelectorBtn.transform.position.z), Quaternion.LookRotation(sceneSelectorBtn.transform.forward));
         newButton.transform.parent = sceneSelectorBtn.transform.parent;
         sceneSelectorBtn = newButton.GetComponent<Button>();
         string scenePath = sceneList[i].path;
         //skapa event för knappklick och byta bana
         sceneSelectorBtn.onClick.AddListener(delegate() { SceneManager.LoadScene(scenePath); });
         buttonText = newButton.GetComponentInChildren<Text>();
         buttonText.text = "Level " + (i+1).ToString();
       }
	}
	
}
