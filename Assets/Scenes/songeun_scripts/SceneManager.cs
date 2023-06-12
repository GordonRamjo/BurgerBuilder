using System.IO;
using UnityEditor;
using UnityEngine;

/*
public class SceneManager : MonoBehaviour
{
    static GameObject container;

    // ---�̱������� ����--- //
    static SceneManager instance;
    
    public static DataManager sceneManager
    {
        get
        {
            if (!instance)
            {
                container = new GameObject();
                container.name = "DataManager";
                instance = container.AddComponent(typeof(SceneManager)) as SceneManager;
                DontDestroyOnLoad(container);
            }
            return sceneManager;
        }
    }

    // --- ���� ������ �����̸� ���� ("���ϴ� �̸�(����).json") --- //
    string GameDataFileName = "BurgerBuilder_PlayData.json";

    // --- ����� Ŭ���� ���� --- //
    public Data data = new Data();


    // �ҷ�����
    public void LoadGameData()
    {
        string filePath = Application.dataPath + "/" + GameDataFileName;
        Debug.Log(filePath);

        // ����� ������ �ִٸ�
        if (File.Exists(filePath))
        {
            // ����� ���� �о���� Json�� Ŭ���� �������� ��ȯ�ؼ� �Ҵ�
            string FromJsonData = File.ReadAllText(filePath);
            data = JsonUtility.FromJson<Data>(FromJsonData);
            print("�ҷ����� �Ϸ�");
        }
    }


    // �����ϱ�
    public void SaveGameData()
    {
        // Ŭ������ Json �������� ��ȯ (true : ������ ���� �ۼ�)
        string ToJsonData = JsonUtility.ToJson(data, true);
        string filePath = Application.dataPath + "/" + GameDataFileName;

        // �̹� ����� ������ �ִٸ� �����, ���ٸ� ���� ���� ����
        File.WriteAllText(filePath, ToJsonData);


        // �ùٸ��� ����ƴ��� Ȯ���ϴ� ��� �ڵ�
        print("���� �Ϸ�");
        for (int i = 0; i < data.isClear.Length; i++)
        {
            print($" Stage {i} ��� ���� ���� : " + data.isClear[i]);
        }

    }

    public void ResetGameData()
    {
        for (int i = 0; i < data.isClear.Length; i++)
        {
            data.isClear[i] = false;
        }
    }
}*/