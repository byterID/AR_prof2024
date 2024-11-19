using System.Linq;
using UnityEngine;

public class ShipHead : MonoBehaviour
{
    [SerializeField] private MeshRenderer[] _shipTilesRenderer;//меш дочерних объектов(кораблей)
    [SerializeField] private MeshRenderer _mainShipRenderer;//меш основного корабля
    [SerializeField] private ParticleSystem _fire;//после уничтожения корабль горит

    public void TryTurnMainMeshOn()//если все клетки были уничтожены, включается основная модель корабля
    {
        if (_shipTilesRenderer.All(rend => rend.enabled))
        {
            _mainShipRenderer.enabled = true;
            _fire.Play();
        }    
    }

    public void TurnMeshOff()//после расстановки вся видимость отключается
    {
        for (int i = 0; i < _shipTilesRenderer.Length; i++)
        {
            _shipTilesRenderer[i].enabled = false;
        }
        _mainShipRenderer.enabled = false;
    }
}
