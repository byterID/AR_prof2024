using System.Collections;
using TMPro;
using UnityEngine;

public class BattleObserver : MonoBehaviour
{
    public static BattleObserver Instance;//синглтон
    public bool IsBattleStarted;//для обозначения начала боя
    [SerializeField] private TMP_Text _player1ShipsCount, _player2ShipsCount, _winText;//2 счетчика кораблей и победный текст
    [SerializeField] private ShipHead[] _allShips;//все корабли на площадке. Нужно чтобы сделать всех невидимыми после расставления
    [SerializeField] private GameObject _player1Field, _player2Field, _winPanel;//объекты полей игроков для смены ходов и сама панель победы

    private int _player1Ships = 20;//"жизни каждого из игроков"
    private int _player2Ships = 20;

    public int Player1Ships //наблюдает за изменением числа кораблей и выводит сколько осталось, если корабли кончились, выводит уведомление о победе
    {
        get => _player1Ships;
        set
        {
            _player1Ships = value;
            _player1ShipsCount.text = Player1Ships.ToString();
            if(Player1Ships == 0)
            {
                _winPanel.SetActive(true);
                _winText.text = $"Победил {Registration.Instance.Name2}";
            }
        }
    }
    public int Player2Ships //наблюдает за изменением числа кораблей и выводит сколько осталось
    {
        get => _player2Ships;
        set
        {
            _player2Ships = value;
            _player2ShipsCount.text = Player2Ships.ToString();
            if(Player2Ships == 0)
            {
                _winPanel.SetActive(true);
                _winText.text = $"Победил {Registration.Instance.Name1}";
            }
        }
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void StartBattle()//вызывается после расстановки кораблей, начало боя
    {
        IsBattleStarted = true;
        for (int i = 0; i < _allShips.Length; i++)
        {
            _allShips[i].TurnMeshOff();
        }
    }

    public void Player1Move()//смена хода, если игрок промазал
    {
        StartCoroutine(ChangeMoveDelay1());
    }

    public void Player2Move()//смена хода, если игрок промазал
    {
        StartCoroutine(ChangeMoveDelay2());
    }

    private IEnumerator ChangeMoveDelay1()//задержка в секунду(чтобы успел проиграться звук и частицы перед переключением)
    {
        yield return new WaitForSeconds(1);
        _player1Field.SetActive(true);
        _player2Field.SetActive(false);
    }
    private IEnumerator ChangeMoveDelay2()//задержка в секунду(чтобы успел проиграться звук и частицы перед переключением)
    {
        yield return new WaitForSeconds(1);
        _player1Field.SetActive(false);
        _player2Field.SetActive(true);
    }
}
