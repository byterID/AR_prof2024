using TMPro;
using UnityEngine;

public class InstantiateField : MonoBehaviour
{
    [SerializeField] private GameObject PlayerName;
    [SerializeField] private GameObject _fieldPrefab, _textPrefab;//префабы клетки и текста для букв и цифр
    [SerializeField] private Transform _fieldTranform, _lettersTransform, _numbersTransform;//пустые объекты для хранения созданных префабов
    private float _fieldLength = 4.5f;//дистанция поля
    private char[] _letters = "АБВГДЕЖЗИК".ToCharArray();//алфавит для букв
    private int _letterIndex;//индекс для букв
    private int _numberIndex = 1;//индекс для нумерации цифр

    private void Start()//выполнение всех методов
    {
        CreateField();
        CreateLetters();
        CreateNumbers();
    }

    private void CreateField()//создание поля по координатам, так же клетке задается параметр об игроке
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

    private void CreateLetters()//создание букв
    {
        for (float x = -_fieldLength; x <= _fieldLength; x++)
        {
            GameObject letter = Instantiate(_textPrefab, new Vector3(x, 5.5f, 0), transform.rotation);
            letter.transform.SetParent(_lettersTransform, false);
            letter.GetComponent<TMP_Text>().text = _letters[_letterIndex].ToString();
            _letterIndex++;
        }
    }
    private void CreateNumbers()//создание цифр
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
