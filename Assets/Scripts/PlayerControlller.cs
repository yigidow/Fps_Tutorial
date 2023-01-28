using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlller : MonoBehaviour
{
    public float moveSpeed, gravityMod, jumpPow;
    public CharacterController charCon;

    private Vector3 moveInput;

    public Transform camTrans;

    public float mouseSens;
    public bool invertX;
    public bool invertY;

    public bool canJump, canDoubleJump;
    public Transform groundCheck;
    public LayerMask whatIsGround;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //moveInput.x = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        //moveInput.z = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        float yStore = moveInput.y;

        Vector3 vertMove = transform.forward * Input.GetAxis("Vertical");
        Vector3 horzMove = transform.right * Input.GetAxis("Horizontal");

        moveInput = (horzMove + vertMove);
        moveInput.Normalize();
        moveInput *= moveSpeed;

        //Gravity
        moveInput.y = yStore;
        moveInput.y += Physics.gravity.y * gravityMod * Time.deltaTime;

        if (charCon.isGrounded)
        {
            moveInput.y = Physics.gravity.y * gravityMod * Time.deltaTime;
        }

        //Jump
        canJump = Physics.OverlapSphere(groundCheck.position, 0.25f, whatIsGround).Length > 0 ;

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            moveInput.y = jumpPow;
            canDoubleJump = true;
        }else if(Input.GetKeyDown(KeyCode.Space) && canDoubleJump)
        {
            moveInput.y = jumpPow;
            canDoubleJump = false;
        }

        charCon.Move(moveInput * Time.deltaTime);

        //camera movement

        Vector2 mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSens;

        if (invertX)
        {
            mouseInput.x = -mouseInput.x;
        }
        if (invertY)
        {
            mouseInput.y = -mouseInput.y;
        }
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + mouseInput.x ,transform.rotation.eulerAngles.z);
        camTrans.rotation = Quaternion.Euler(camTrans.rotation.eulerAngles + new Vector3 (-mouseInput.y,0f,0f));

    }
}
