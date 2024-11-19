using System.Collections;
using TMPro;
using UnityEngine;

public class BattleObserver : MonoBehaviour
{
    public static BattleObserver Instance;//��������
    public bool IsBattleStarted;//��� ����������� ������ ���
    [SerializeField] private TMP_Text _player1ShipsCount, _player2ShipsCount, _winText;//2 �������� �������� � �������� �����
    [SerializeField] private ShipHead[] _allShips;//��� ������� �� ��������. ����� ����� ������� ���� ���������� ����� ������������
    [SerializeField] private GameObject _player1Field, _player2Field, _winPanel;//������� ����� ������� ��� ����� ����� � ���� ������ ������

    private int _player1Ships = 20;//"����� ������� �� �������"
    private int _player2Ships = 20;

    public int Player1Ships //��������� �� ���������� ����� �������� � ������� ������� ��������, ���� ������� ���������, ������� ����������� � ������
    {
        get => _player1Ships;
        set
        {
            _player1Ships = value;
            _player1ShipsCount.text = Player1Ships.ToString();
            if(Player1Ships == 0)
            {
                _winPanel.SetActive(true);
                _winText.text = $"������� {Registration.Instance.Name2}";
            }
        }
    }
    public int Player2Ships //��������� �� ���������� ����� �������� � ������� ������� ��������
    {
        get => _player2Ships;
        set
        {
            _player2Ships = value;
            _player2ShipsCount.text = Player2Ships.ToString();
            if(Player2Ships == 0)
            {
                _winPanel.SetActive(true);
                _winText.text = $"������� {Registration.Instance.Name1}";
            }
        }
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void StartBattle()//���������� ����� ����������� ��������, ������ ���
    {
        IsBattleStarted = true;
        for (int i = 0; i < _allShips.Length; i++)
        {
            _allShips[i].TurnMeshOff();
        }
    }

    public void Player1Move()//����� ����, ���� ����� ��������
    {
        StartCoroutine(ChangeMoveDelay1());
    }

    public void Player2Move()//����� ����, ���� ����� ��������
    {
        StartCoroutine(ChangeMoveDelay2());
    }

    private IEnumerator ChangeMoveDelay1()//�������� � �������(����� ����� ����������� ���� � ������� ����� �������������)
    {
        yield return new WaitForSeconds(1);
        _player1Field.SetActive(true);
        _player2Field.SetActive(false);
    }
    private IEnumerator ChangeMoveDelay2()//�������� � �������(����� ����� ����������� ���� � ������� ����� �������������)
    {
        yield return new WaitForSeconds(1);
        _player1Field.SetActive(false);
        _player2Field.SetActive(true);
    }
}
