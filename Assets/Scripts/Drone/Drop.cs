using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public Controller ControllerScript;
    public Movimento MovimentoScript;
    public GameObject Item;
    public Rigidbody m_rb;

    private int QtdItens;
    // Start is called before the first frame update
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

        m_rb.useGravity = true;
        m_rb.constraints = RigidbodyConstraints.None;
    }
}
