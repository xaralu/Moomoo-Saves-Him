using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider),typeof(Rigidbody))]
public class Move : MonoBehaviour
{
    public float walkSpeed = 5;
    public float runSpeed = 10;
    public KeyCode runKey = KeyCode.LeftShift;

    SpriteRenderer m_SpriteRenderer;
    public Sprite walkRightSprite;
    public Sprite walkLeftSprite;
    public Sprite standRightSprite;

    private Rigidbody rb;

    float rotationY = -90f;
    public float sensitivity = 15f;       
    float oldX = 0.000000001f;
    float oldZ = 0.000000001f;

    float inputX;
    float inputZ;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        m_SpriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }
 
    void Update()
    {
        float speed = Input.GetKey(runKey) ? runSpeed : walkSpeed;

        float inputX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float inputZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;


        if (inputX > 0) {
            m_SpriteRenderer.sprite = walkRightSprite;
        } else if (inputX < 0) {
            m_SpriteRenderer.sprite = walkLeftSprite;
        } else if (inputX == oldX) {
            m_SpriteRenderer.sprite = standRightSprite;
        }

        rb.transform.Translate(inputX, 0, inputZ);
  
        rotationY += Input.GetAxis("Mouse X") * sensitivity;
        transform.localEulerAngles = new Vector3(0, rotationY, 0);

        oldX = inputX;
    }
}
