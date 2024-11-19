using TMPro;
using UnityEngine;

public class InstantiateField : MonoBehaviour
{
    [SerializeField] private GameObject PlayerName;
    [SerializeField] private GameObject _fieldPrefab, _textPrefab;//������� ������ � ������ ��� ���� � ����
    [SerializeField] private Transform _fieldTranform, _lettersTransform, _numbersTransform;//������ ������� ��� �������� ��������� ��������
    private float _fieldLength = 4.5f;//��������� ����
    private char[] _letters = "����������".ToCharArray();//������� ��� ����
    private int _letterIndex;//������ ��� ����
    private int _numberIndex = 1;//������ ��� ��������� ����

    private void Start()//���������� ���� �������
    {
        CreateField();
        CreateLetters();
        CreateNumbers();
    }

    private void CreateField()//�������� ���� �� �����������, ��� �� ������ �������� �������� �� ������
    {
        for (float x = -_fieldLength; x <= _fieldLength; x++)
        {
            for (float z = _fieldLength; z >= -_fieldLength; z--)
            {
                GameObject field = Instantiate(_fieldPrefab, new Vector3(x, 0.05f, z), new Quaternion(-90, 0, 0, 1));
                field.transform.SetParent(_fieldTranform, false);
                field.GetComponent<Cell>().CellSide = PlayerName.name;
            }
        }
    }

    private void CreateLetters()//�������� ����
    {
        for (float x = -_fieldLength; x <= _fieldLength; x++)
        {
            GameObject letter = Instantiate(_textPrefab, new Vector3(x, 5.5f, 0), transform.rotation);
            letter.transform.SetParent(_lettersTransform, false);
            letter.GetComponent<TMP_Text>().text = _letters[_letterIndex].ToString();
            _letterIndex++;
        }
    }
    private void CreateNumbers()//�������� ����
    {
        for (float y = _fieldLength; y >= -_fieldLength; y--)
        {
            GameObject number = Instantiate(_textPrefab, new Vector3(-5.5f, y, 0), transform.rotation);
            number.transform.SetParent(_lettersTransform, false);
            number.GetComponent<TMP_Text>().text = _numberIndex.ToString();
            _numberIndex++;
        }
    }
}
