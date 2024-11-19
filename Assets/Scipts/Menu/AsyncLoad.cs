using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AsyncLoad : MonoBehaviour
{
    [SerializeField] private GameObject _loadPanel;//загрузочная панель
    [SerializeField] private Slider _loadSlider;//слайдер, для отображения прогресса

    public void LoadScene0()//загрузка меню
    {
        _loadPanel.SetActive(true);
        StartCoroutine(LoadSceneAsync(0));
    }

    public void LoadScene1()//загрузка игры
    {
        _loadPanel.SetActive(true);
        StartCoroutine(LoadSceneAsync(1));
    }

    private IEnumerator LoadSceneAsync(int index)//асинхронный метод загрузки
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);
        while (!operation.isDone)
        {
            float progress = operation.progress;
            _loadSlider.value = progress;
            yield return null;
        }
    }
}
