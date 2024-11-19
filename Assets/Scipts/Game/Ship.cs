using UnityEngine;

public class Ship : MonoBehaviour
{
    private bool isDead;//жив ли корабль
    [SerializeField] private ParticleSystem _explosion;//частицы взрыва
    private AudioSource _explosionSound;//звук взрыва

    private void Start()
    {
        _explosionSound = GetComponent<AudioSource>();
    }

    private void OnMouseUpAsButton()//если идет бой и на корабль попали, он взрывается и уменьшает кол-во механической боевой силы
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
