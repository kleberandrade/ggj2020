using UnityEngine;

public class Pick : MonoBehaviour
{
    public Controller ControllerScript;
    public Machine MachineScript;
    public Machine EnemyMachineScript;
    public string Nome_Tag;
    public string Place_Tag;
    public int NumPlayer;

    [Header("SFX")]
    public AudioClip m_PickItemAudioClip;
    public AudioClip m_SaveItemAudioClip;
    public AudioClip m_StealItemAudioClip;
    private AudioSource m_AudioSource;

    private void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();

        GameObject[] AUX_Machine;
        AUX_Machine = GameObject.FindGameObjectsWithTag(Nome_Tag);
        MachineScript = AUX_Machine[0].GetComponent<Machine>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Item"))
        {
            if(ControllerScript.Itens < 3)
            {
                Item.m_Count--;
                Destroy(other.gameObject);
                ControllerScript.Itens++;
                GameManager.Instance.m_GearsBars[NumPlayer-1].Pick();
                m_AudioSource.clip = m_PickItemAudioClip;
                m_AudioSource.Play();
            }
        }
        else if(other.CompareTag(Nome_Tag))
        {
            if(ControllerScript.Itens > 0)
            {
                MachineScript.UpdateItens(ControllerScript.Itens);
                for(int i = 0; i < ControllerScript.Itens; i++)
                {
                    GameManager.Instance.m_GearsBars[NumPlayer-1].Push();
                }
                ControllerScript.Itens = 0;
                m_AudioSource.clip = m_SaveItemAudioClip;
                m_AudioSource.Play();
            }
        }
        else if(other.CompareTag("Untagged"))
        {
            return;
        }
        else
        {
            if(ControllerScript.Itens < 3)
            {
                int AUX = ControllerScript.Itens;
                EnemyMachineScript = other.GetComponent<Machine>();

                if (EnemyMachineScript.FurtarItens() > 0)
                {
                    m_AudioSource.clip = m_StealItemAudioClip;
                    m_AudioSource.Play();
                }

                ControllerScript.Itens += EnemyMachineScript.FurtarItens();
                EnemyMachineScript.Itens = 0;

                if(ControllerScript.Itens > 3)
                {
                    EnemyMachineScript.UpdateItens(ControllerScript.Itens -3);
                    ControllerScript.Itens -= ControllerScript.Itens -3;
                }

                AUX = ControllerScript.Itens - AUX;
                for(int i = 0; i < AUX; i++)
                {
                    GameManager.Instance.m_GearsBars[NumPlayer-1].Pick();
                    GameManager.Instance.m_GearsBars[EnemyMachineScript.NumPlayer-1].Pop();
                }
            }
        }
    }
}
