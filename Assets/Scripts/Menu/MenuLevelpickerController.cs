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
        //hämta alla scener
        List<EditorBuildSettingsScene> sceneList = new List<EditorBuildSettingsScene>();
        foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
            sceneList.Add(scene);
        //lista levels baserat på sökväg
        IEnumerable<EditorBuildSettingsScene> levelScenes = sceneList.Where(x => x.path.Contains("GameScenes/Levels")).OrderBy(x => x.path);
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

    /// <summary>
    /// Get the standard level button, the levelpicker button which always exists on the menu
    /// </summary>
    /// <returns>Returns the standard level button</returns>
    private Button GetStandardLevelButton()
    {
        Button[] buttons = GetComponentsInChildren<Button>();
        //hitta standard knapp för levels
        Button levelBtn = buttons.Single(x => x.name == "LevelBtn");
        return levelBtn;
    }

    /// <summary>
    /// Set the leveltext on the standard level button
    /// </summary>
    private void SetLevelForStandardLevelButton()
    {
        Text buttonText;
        //hitta standard knapp för levels
        Button levelBtn = GetStandardLevelButton();
        buttonText = levelBtn.GetComponentInChildren<Text>();
        // sätt leveltext för första standard levelknapp
        buttonText.text = "Level " + (currentPage * 3 + 1).ToString();

    }

    /// <summary>
    /// Method for browsing to the next page
    /// </summary>
    private void NextPage()
    {

        currentPage++;
        UpdatePage();
    }
    /// <summary>
    /// Method for browsing to the previous page
    /// </summary>
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
        //kontrollera om vänstra swipeknappen skall vara aktiv
        CheckToDisableOrEnableLeftSwipe();

        List<EditorBuildSettingsScene> sceneList = GetLevelScenes();
        //förstör alla knappar för levels (utom standardknapp)
        DestroyButtonClones();
        //sätt text på standardlevel knapp
        SetLevelForStandardLevelButton();
        //generera övriga knappar
        GenerateButtons(levelBtn, sceneList);
        //kontrollera om högra swipeknappen skall vara aktiv
        CheckToDisableOrEnableRightSwipe(sceneList);
    }
    /// <summary>
    /// Destroys all levelbuttons except standard (first) level button
    /// </summary>
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
    /// <summary>
    /// Checks current page and identifies if more levels exists that are not listed, disables the right swipe if more levels do not exist
    /// </summary>
    /// <param name="sceneList">List with scenes/levels</param>
    private void CheckToDisableOrEnableRightSwipe(List<EditorBuildSettingsScene> sceneList)
    {
        Button[] buttons = GetComponentsInChildren<Button>();
        Text buttonText;
        Button rightSwipe = buttons.Single(x => x.name == RIGHT_SWIPE_BTN_NAME);
        if ((currentPage + 1) * 3 > sceneList.Count)
        { // det finns inga fler scener/levels som inte har visats, höger swipeknapp skall vara avstängd
            rightSwipe.interactable = false;
            buttonText = rightSwipe.GetComponentInChildren<Text>();
            buttonText.color = Color.gray;
        }
        else { // finns fler levels/scener att visa/välja, höger swipeknapp skall vara aktiv
            rightSwipe.interactable = true;
            buttonText = rightSwipe.GetComponentInChildren<Text>();
            buttonText.color = Color.white;
        }
    }
    /// <summary>
    /// Checks if there are previous pages, if current page == 0, the function will disable left swipe
    /// </summary>
    private void CheckToDisableOrEnableLeftSwipe()
    {
        Button[] buttons = GetComponentsInChildren<Button>();
        Text buttonText;
        Button leftSwipe = buttons.Single(x => x.name == LEFT_SWIPE_BTN_NAME);
        if (currentPage > 0)
        { // vi har föregående sidor, vänsterswipe knapp skall vara aktiv
            leftSwipe.interactable = true;
            buttonText = leftSwipe.GetComponentInChildren<Text>();
            buttonText.color = Color.white;
        }
        else
        { // inga föregående sidor, vänster swipeknapp skall vara inaktiv
            leftSwipe.interactable = false;
            buttonText = leftSwipe.GetComponentInChildren<Text>();
            buttonText.color = Color.gray;
        }
    }
}
#endif