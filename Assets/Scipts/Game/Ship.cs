using UnityEngine;

public class Ship : MonoBehaviour
{
    private bool isDead;//��� �� �������
    [SerializeField] private ParticleSystem _explosion;//������� ������
    private AudioSource _explosionSound;//���� ������

    private void Start()
    {
        _explosionSound = GetComponent<AudioSource>();
    }

    private void OnMouseUpAsButton()//���� ���� ��� � �� ������� ������, �� ���������� � ��������� ���-�� ������������ ������ ����
    {
        if (!isDead && BattleObserver.Instance.IsBattleStarted)
        {
            isDead = true;
            _explosion.Play();
            _explosionSound.Play();

            GetComponent<MeshRenderer>().enabled = true;
            GetComponentInParent<ShipHead>().TryTurnMainMeshOn();

            switch (tag)
            {
                case "Player1":
                    BattleObserver.Instance.Player1Ships--;
                    break;
                case "Player2":
                    BattleObserver.Instance.Player2Ships--;
                    break;
            }
        }
    }
}
