using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AsyncLoad : MonoBehaviour
{
    [SerializeField] private GameObject _loadPanel;//����������� ������
    [SerializeField] private Slider _loadSlider;//�������, ��� ����������� ���������

    public void LoadScene0()//�������� ����
    {
        _loadPanel.SetActive(true);
        StartCoroutine(LoadSceneAsync(0));
    }

    public void LoadScene1()//�������� ����
    {
        _loadPanel.SetActive(true);
        StartCoroutine(LoadSceneAsync(1));
    }

    private IEnumerator LoadSceneAsync(int index)//����������� ����� ��������
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
