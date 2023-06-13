using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PattyTutorialController : MonoBehaviour
{
    public Patty patty;
    public bool isStart = false;
    public bool isBaking = false;
    private bool is5s = false; //5�ʰ� �������� flag 
    private bool is10s = false; //10�ʰ� �������� flag
    private bool isUI = false; //��Ƽ ���� UI�� �����Ǿ������� ���� flag
    GameObject smokeParticleSys; //���� ��ƼŬ �ý��� ��ü
    private StageManager stageManager; //stageManager
    GameObject pattyUICanvas; //��Ƽ Ÿ�̸� ��ü

    // Patty Material
    public Material[] RareMaterial;
    public Material[] MediumMaterial;
    public Material[] BurnMaterial;
    public PlaceTutorial placeTutorial;
    GuideDialogManager guideDialogManager;

    // Start is called before the first frame update
    void Start()
    {
        guideDialogManager = GameObject.Find("Dialog").GetComponent<GuideDialogManager>();

        patty = new Patty();
        gameObject.GetComponent<MeshRenderer>().materials = RareMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        if (isStart && isBaking)
        {
            if (!isUI) //��Ƽ ���� UI�� �������� �ʾҴٸ�
            {
                GeneratePattyEffect(); //�����ϱ�
                isUI = true;
            }
            else
            {
                //��Ƽ ���� UI�� �̹� �����Ǿ� �ִٸ� �ٽ� Ȱ��ȭ��Ű��
                pattyUICanvas.SetActive(true);
            }

            if (patty.state == Patty.State.Rare)
            {
                // 5�� ��
                this.transform.GetChild(1).GetChild(1).GetComponent<Image>().fillAmount += (Time.deltaTime * 1) / 5; //��Ƽ Ÿ�̸� ä���
                StartCoroutine(After5Second());
            }
            else if (patty.state == Patty.State.Medium)
            {
                // 10�� ��
                StartCoroutine(After10Second());
            }
        }

        if (isStart && !isBaking)
        {
            pattyUICanvas.SetActive(false);
        }
    }
    private void Awake()
    {
        stageManager = GameObject.Find("StageManager").GetComponent<StageManager>();

    }

    //���� ��ƼŬ �ý��۰� ��Ƽ Ÿ�̸� �����ϴ� �Լ�
    void GeneratePattyEffect()
    {
        smokeParticleSys = Instantiate(stageManager.smokeParticleSys, this.transform.position, Quaternion.identity);
        pattyUICanvas = Instantiate(stageManager.pattyUI, new Vector3(this.transform.position.x, this.transform.position.y + 0.15f, this.transform.position.z), Quaternion.Euler(0, 60, 0));
        smokeParticleSys.transform.SetParent(this.transform);
        pattyUICanvas.transform.SetParent(this.transform);
    }

    IEnumerator After5Second()
    {
        yield return new WaitForSeconds(5f);
        if (isBaking && !is5s)
        {
            Debug.Log("After5Second");
            patty.Medium();
            gameObject.GetComponent<MeshRenderer>().materials = MediumMaterial;
            placeTutorial.GetPattyState(PattyState.Medium);
            this.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
            is5s = true;
        }

    }

    IEnumerator After10Second()
    {
        yield return new WaitForSeconds(5f);
        if (isBaking && !is10s)
        {
            Debug.Log("After10Second");
            patty.Burned();
            gameObject.GetComponent<MeshRenderer>().materials = BurnMaterial;
            placeTutorial.GetPattyState(PattyState.Burn);
            guideDialogManager.UpdateGuideDialog();
            this.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
            is10s = true;
        }
    }

}

public enum PattyState
{
    Rare,
    Medium,
    Burn
}