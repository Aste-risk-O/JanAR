using UnityEngine;
using UnityEngine.SceneManagement;

public class LanguageManager : MonoBehaviour
{
    // Сюда впиши ТОЧНОЕ название твоей AR-сцены (где Байтерек)
    public string arSceneName = "1-PlacingObjectAt_LatLngAlt";

    public void SelectLanguage(string lang)
    {
        // Сохраняем выбор ("KZ", "RU" или "EN") в память телефона
        PlayerPrefs.SetString("SelectedLanguage", lang);
        PlayerPrefs.Save();

        Debug.Log("Выбран язык: " + lang);

        // Загружаем следующую сцену
        SceneManager.LoadScene(arSceneName);
    }
}