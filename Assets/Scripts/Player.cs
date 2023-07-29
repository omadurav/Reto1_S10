using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Player : MonoBehaviour
{
    private float speed = 5f;
    private float speedRotation = 20f;
    public bool isDead = false;
    public int countDots;



    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);
        movement.Normalize();
        transform.position = transform.position + movement * speed * Time.deltaTime;

        if (movement != Vector3.zero) transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), speedRotation * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
           
            isDead = true;
            speed = 0;
            StartCoroutine(Reload());

        }
        else if (other.gameObject.CompareTag("Dot"))
        {
            countDots++;
        }
    }

    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(2);
        GameObject.FindObjectOfType<ControlScene>().ReloadCurrentScene();
        
    }
}
