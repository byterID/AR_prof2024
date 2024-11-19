using TMPro;
using UnityEngine;

public class Registration : MonoBehaviour
{
    public static Registration Instance;
    [SerializeField] private TMP_InputField _player1Input, _player2Input;//���� ��� ����� ������
    [SerializeField] private TMP_Text _playerName1, _playerName2, _leaderboardWinText;//����������� ���� ������� ��� ������
    public string Name1, Name2;//���������� ��� ������

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }

    public void SaveName1()//���������� ������� ����� � ������� ���������� PlayerPrefs
    {
        Name1 = _player1Input.text;
        PlayerPrefs.SetString("name1", Name1);
        PlayerPrefs.Save();
    }

    public void SaveName2()//���������� ������� �����
    {
        Name2 = _player2Input.text;
        PlayerPrefs.SetString("name2", Name2);
        PlayerPrefs.Save();
    }

    public void FillNames()//�������� ���� �������
    {
        _playerName1.text = PlayerPrefs.GetString("name1");
        _playerName2.text = PlayerPrefs.GetString("name2");
    }

    public void UpdateWinner()
    {
        _leaderboardWinText.text = PlayerPrefs.GetString("name1");
    }
}
