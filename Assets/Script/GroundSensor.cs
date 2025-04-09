using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class GroundSensor : MonoBehaviour
{
    public bool isGrounded;

    private  Rigidbody2D _rigidBody;

    public float jumpDamage = 5;
    private PlayerControl playerScript;

   void Awake()
   {
      _rigidBody = GetComponentInParent<Rigidbody2D>();

     playerScript = GetComponentInParent<PlayerControl>();
   }

   void OnTriggerEnter2D(Collider2D collider) 
   {
      if(collider.gameObject.layer == 3)
      {
         isGrounded  = true;
         Debug.Log(collider.gameObject.name);
         Debug.Log(collider.gameObject.transform.position);
      }
      else if(collider.gameObject.layer == 6)
      {
         _rigidBody.AddForce(Vector2.up * 20, ForceMode2D.Impulse);
         Enemy _enemyScript = collider.gameObject.GetComponent<Enemy>();
         _enemyScript.TakeDamage(jumpDamage);
      }
      else if (collider.gameObject.layer == 10)
      {
         playerScript.Death();
      }
   }

void OnTriggerStay2D(Collider2D collider) 
   {
      if(collider.gameObject.layer == 3)
    {
      isGrounded = true; 
    }
   }
   void OnTriggerExit2D(Collider2D collider) 
   {
     if(collider.gameObject.layer == 3)
    {
      isGrounded = false; 
    }
   }
}
