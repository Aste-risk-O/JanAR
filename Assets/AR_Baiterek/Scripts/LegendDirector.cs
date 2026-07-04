using UnityEngine;
using TMPro;
using System.Collections;

public class LegendDirector : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text uiText;
    public GameObject textPanel; // Ссылка на панель (фон текста)

    [Header("Audio")]
    public AudioSource musicSource; // Сюда перетащи Audio Source с музыкой

    [Header("Animators")]
    public Animator vinesAnim;
    public Animator birdAnim;
    public Animator eggAnim;

    [Header("Тексты")]
    public string[] textsRU;
    public string[] textsKZ;
    public string[] textsEN;

    private string[] currentTexts;

    public void StartShow()
    {
        // Сюда можно добавить сброс состояний, на всякий случай
        if (textPanel) textPanel.SetActive(false);

        // Перезапуск аниматоров в начало (на случай если они успели убежать)
        if (vinesAnim) vinesAnim.Rebind();
        if (birdAnim) birdAnim.Rebind();
        if (eggAnim) eggAnim.Rebind();

        // 1. Узнаем язык
        string lang = PlayerPrefs.GetString("SelectedLanguage", "RU");
        // ... (твой код выбора языка) ...

        // 2. Запускаем корутину
        StopAllCoroutines(); // Останавливаем старые, если были
        StartCoroutine(ShowSequence());
    }

    IEnumerator ShowSequence()
    {
        // Пауза 1 секунда после появления башни, чтобы осознать величие
        yield return new WaitForSeconds(1.0f);

        // ВКЛЮЧАЕМ МУЗЫКУ
        if (musicSource) musicSource.Play();

        // --- ЭТАП 1: ЛИАНЫ ---
        if (textPanel) textPanel.SetActive(true);
        uiText.text = currentTexts[0];

        if (vinesAnim) vinesAnim.SetTrigger("Grow"); // Запуск роста

        yield return new WaitForSeconds(10.0f); // Читаем 10 секунд

        // --- ЭТАП 2: ПТИЦА ---
        uiText.text = currentTexts[1];
        // Птица уже должна быть видна и парить (Idle), просто меняем текст
        // Или если хочешь анимацию появления - добавь триггер ShowBird
        if (birdAnim) birdAnim.SetTrigger("ShowBird");
        yield return new WaitForSeconds(10.0f);

        // --- ЭТАП 3: ЯЙЦО ---
        uiText.text = currentTexts[2];
        if (eggAnim) eggAnim.SetTrigger("Glow"); // Запуск свечения

        // Текст и музыка остаются до конца
    }
}