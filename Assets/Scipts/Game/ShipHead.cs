using System.Linq;
using UnityEngine;

public class ShipHead : MonoBehaviour
{
    [SerializeField] private MeshRenderer[] _shipTilesRenderer;//��� �������� ��������(��������)
    [SerializeField] private MeshRenderer _mainShipRenderer;//��� ��������� �������
    [SerializeField] private ParticleSystem _fire;//����� ����������� ������� �����

    public void TryTurnMainMeshOn()//���� ��� ������ ���� ����������, ���������� �������� ������ �������
    {
        if (_shipTilesRenderer.All(rend => rend.enabled))
        {
            _mainShipRenderer.enabled = true;
            _fire.Play();
        }    
    }

    public void TurnMeshOff()//����� ����������� ��� ��������� �����������
    {
        for (int i = 0; i < _shipTilesRenderer.Length; i++)
        {
            _shipTilesRenderer[i].enabled = false;
        }
        _mainShipRenderer.enabled = false;
    }
}
