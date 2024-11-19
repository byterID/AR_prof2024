using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] private ParticleSystem _miss;//������� ������ �������
    private AudioSource _source;//���� �������� ����
    public string CellSide;

    private void Start()
    {
        _source = GetComponent<AudioSource>();
    }
    private void OnMouseUpAsButton()//������������� ����� � �������, � ��� �� ��������� ����
    {
        if(BattleObserver.Instance.IsBattleStarted)
        {
            _miss.Play();
            _source.Play();
            switch(CellSide)
            {
                case "Player1":
                    BattleObserver.Instance.Player2Move();
                    break;
                case "Player2":
                    BattleObserver.Instance.Player1Move();
                    break;
            }
        }
    }
}
