#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine.UI;
using UnityEditor;
/// <summary>
/// To be attached to the panel hosting the levelpicker buttons. Class controls the paging of the levelpicker menu.
/// </summary>
[RequireComponent(typeof(RectTransform))]
public class MenuLevelpickerController : MonoBehaviour
{
    private const string BACK_BTN_NAME = "BackBtn";
    private const string STANDARD_LEVEL_BTN_NAME = "LevelBtn";
    private const string RIGHT_SWIPE_BTN_NAME = "RightSwipeBtn";
    private const string LEFT_SWIPE_BTN_NAME = "LeftSwipeBtn";
    private int currentPage = 0;
    // Use this for initialization
    void Start()
    {
        AddSwipeListners();

        Button[] buttons = GetComponentsInChildren<Button>();
        // stäng ned vänster swipe
        CheckToDisableOrEnableLeftSwipe();
        //hämta standard knapp för levels
        Button levelBtn = GetStandardLevelButton();

        //hämta en lista med levels scener som finns i buildsettings
        List<EditorBuildSettingsScene> sceneList = GetLevelScenes();

        // skapa action/event för level 1 knapp
        levelBtn.onClick.AddListener(delegate { SceneManager.LoadScene(sceneList.First().path); });

        // generera knappar för övriga levels
        GenerateButtons(levelBtn, sceneList);
    }
    /// <summary>
    ///  Ger en ordnad lista baserat på namn på alla scener med sökväg i mappen "levels"
    /// </summary>
    /// <returns>Lista med levels sorterade på namn</returns>
    private List<EditorBuildSettingsScene> GetLevelScenes()
    {
        List<EditorBuildSettingsScene> sceneList = new List<EditorBuildSettingsScene>();
        foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
            sceneList.Add(scene);
        IEnumerable<EditorBuildSettingsScene> levelScenes = sceneList.Cast<EditorBuildSettingsScene>();
        //IEnumerable<EditorBuildSettingsScene> levelScenes = sceneList.Where(x => x.path.Contains("GameScenes/Levels")).OrderBy(x => x.path);
        return levelScenes.ToList();
    }
    /// <summary>
    /// Creates event listners for the swipe buttons
    /// </summary>
    private void AddSwipeListners()
    {
        Button[] buttons = GetComponentsInChildren<Button>();
        Button rightSwipe = buttons.Single(x => x.name == RIGHT_SWIPE_BTN_NAME);
        rightSwipe.onClick.AddListener(delegate { this.NextPage(); });
        Button leftSwipe = buttons.Single(x => x.name == LEFT_SWIPE_BTN_NAME);
        leftSwipe.onClick.AddListener(delegate { this.PreviousPage(); });
    }
    /// <summary>
    /// Generate level buttons (except the standardbutton)
    /// </summary>
    /// <param name="standardLevelBtn"></param>
    /// <param name="sceneList"></param>
    private void GenerateButtons(Button standardLevelBtn, List<EditorBuildSettingsScene> sceneList)
    {
        Text buttonText;
        float lastHeight = standardLevelBtn.transform.position.y;
        //skapa nya knappar för övriga nivåer, hoppa över första knappen som alltid skall finnas på menyn
        for (int i = ((currentPage) * 3 + 1); i < Mathf.Min(new int[] { (currentPage + 1) * 3, sceneList.Count }); i++)
        {
            lastHeight = lastHeight - 40;
            GameObject newButton = Instantiate(standardLevelBtn.gameObject, new Vector3(standardLevelBtn.transform.position.x, lastHeight, standardLevelBtn.transform.position.z), Quaternion.LookRotation(standardLevelBtn.transform.forward));
            newButton.transform.parent = standardLevelBtn.transform.parent;
            standardLevelBtn = newButton.GetComponent<Button>();
            string scenePath = sceneList[i].path;
            //skapa event för knappklick och byta bana
            standardLevelBtn.onClick.AddListener(delegate() { SceneManager.LoadScene(scenePath); });
            buttonText = newButton.GetComponentInChildren<Text>();
            buttonText.text = "Level " + (i + 1).ToString();
        }
    }
    private Button GetStandardLevelButton()
    {
        Button[] buttons = GetComponentsInChildren<Button>();
        //hitta standard knapp för levels
        Button levelBtn = buttons.Single(x => x.name == "LevelBtn");
        return levelBtn;
    }
    private void SetLevelForStandardLevelButton()
    {
        Text buttonText;
        //hitta standard knapp för levels
        Button levelBtn = GetStandardLevelButton();
        buttonText = levelBtn.GetComponentInChildren<Text>();
        // sätt leveltext för första standard levelknapp
        buttonText.text = "Level " + (currentPage * 3 + 1).ToString();

    }
    private void NextPage()
    {

        currentPage++;
        UpdatePage();
    }
    private void PreviousPage()
    {
        currentPage--;
        UpdatePage();
    }
    /// <summary>
    /// Updates current page on levelpicker menu
    /// </summary>
    private void UpdatePage() {
        //hämta standard knapp för levels
        Button levelBtn = GetStandardLevelButton();

        CheckToDisableOrEnableLeftSwipe();

        List<EditorBuildSettingsScene> sceneList = GetLevelScenes();
        //förstör kloner av knappar för levels
        DestroyButtonClones();

        SetLevelForStandardLevelButton();

        GenerateButtons(levelBtn, sceneList);

        CheckToDisableOrEnableRightSwipe(sceneList);
    }
    private void DestroyButtonClones()
    {
        Button[] buttons = GetComponentsInChildren<Button>();
        // radera andra knappar
        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i].name != STANDARD_LEVEL_BTN_NAME && buttons[i].name != BACK_BTN_NAME
                && buttons[i].name != RIGHT_SWIPE_BTN_NAME && buttons[i].name != LEFT_SWIPE_BTN_NAME)
            {
                Destroy(buttons[i].gameObject);
            }
        }
    }
    private void CheckToDisableOrEnableRightSwipe(List<EditorBuildSettingsScene> sceneList)
    {
        Button[] buttons = GetComponentsInChildren<Button>();
        Text buttonText;
        Button rightSwipe = buttons.Single(x => x.name == RIGHT_SWIPE_BTN_NAME);
        if ((currentPage + 1) * 3 > sceneList.Count)
        {
            rightSwipe.interactable = false;
            buttonText = rightSwipe.GetComponentInChildren<Text>();
            buttonText.color = Color.gray;
        }
        else {
            rightSwipe.interactable = true;
            buttonText = rightSwipe.GetComponentInChildren<Text>();
            buttonText.color = Color.white;
        }
    }
    private void CheckToDisableOrEnableLeftSwipe()
    {
        Button[] buttons = GetComponentsInChildren<Button>();
        Text buttonText;
        Button leftSwipe = buttons.Single(x => x.name == LEFT_SWIPE_BTN_NAME);
        if (currentPage > 0)
        {
            leftSwipe.interactable = true;
            buttonText = leftSwipe.GetComponentInChildren<Text>();
            buttonText.color = Color.white;
        }
        else
        {
            leftSwipe.interactable = false;
            buttonText = leftSwipe.GetComponentInChildren<Text>();
            buttonText.color = Color.gray;
        }
    }
}
#endif