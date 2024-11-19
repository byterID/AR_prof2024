using TMPro;
using UnityEngine;

public class Registration : MonoBehaviour
{
    public static Registration Instance;
    [SerializeField] private TMP_InputField _player1Input, _player2Input;//поля для ввода текста
    [SerializeField] private TMP_Text _playerName1, _playerName2, _leaderboardWinText;//отображение имен игроков над полями
    public string Name1, Name2;//переменные для записи

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }

    public void SaveName1()//сохранение первого имени с помощью библиотеки PlayerPrefs
    {
        Name1 = _player1Input.text;
        PlayerPrefs.SetString("name1", Name1);
        PlayerPrefs.Save();
    }

    public void SaveName2()//сохранение второго имени
    {
        Name2 = _player2Input.text;
        PlayerPrefs.SetString("name2", Name2);
        PlayerPrefs.Save();
    }

    public void FillNames()//указание имен игроков
    {
        _playerName1.text = PlayerPrefs.GetString("name1");
        _playerName2.text = PlayerPrefs.GetString("name2");
    }

    public void UpdateWinner()
    {
        _leaderboardWinText.text = PlayerPrefs.GetString("name1");
    }
}
