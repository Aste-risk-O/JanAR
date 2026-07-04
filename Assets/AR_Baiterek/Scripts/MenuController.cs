using UnityEngine;
using UnityEngine.SceneManagement; // Обязательно для работы со сценами

public class MenuController : MonoBehaviour
{
    // Название твоей сцены с Байтереком (проверь точное имя файла!)
    public string gameSceneName = "1-PlacingObjectAt_LatLngAlt";

    public void StartApp()
    {
        SceneManager.LoadScene(gameSceneName);
    }
}
