using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public Controller ControllerScript;
    public Movimento MovimentoScript;
    public GameObject Item;
    private Rigidbody m_rb;

    public Material m_DeathMaterial;

    public MeshRenderer m_Renderer;

    private int QtdItens;

    private void Awake()
    {
        m_rb = GetComponent<Rigidbody>();
    }

    public void DropDeath()
    {
        QtdItens = ControllerScript.Itens;
        Destroy(MovimentoScript);
        
        if(QtdItens == 3){
            Instantiate<GameObject>(Item, transform.position - new Vector3(0.0f, 0.0f, 1.0f), transform.rotation); 
            Instantiate<GameObject>(Item, transform.position - new Vector3(1.0f, 0.0f, -1.0f), transform.rotation); 
            Instantiate<GameObject>(Item, transform.position - new Vector3(-1.0f, 0.0f, -1.0f), transform.rotation); 
        }else if(QtdItens == 2){
            Instantiate<GameObject>(Item, transform.position - new Vector3(1.0f, 0.0f, 0.0f), transform.rotation); 
            Instantiate<GameObject>(Item, transform.position - new Vector3(-1.0f, 0.0f, 0.0f), transform.rotation); 
        }else if(QtdItens == 1){
            Instantiate<GameObject>(Item, transform.position, transform.rotation); 
        }

        for(int i = 0; i < m_Renderer.materials.Length; i++)
        {
            m_Renderer.materials[i] = m_DeathMaterial;
        }

        m_rb.useGravity = true;
        m_rb.constraints = RigidbodyConstraints.None;
        m_rb.isKinematic = false;
    }
}
