using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlller : MonoBehaviour
{
    public static PlayerControlller instance;

    public float moveSpeed, runSpeed, gravityMod, jumpPow;
    public CharacterController charCon;

    private Vector3 moveInput;

    public Transform camTrans;

    public float mouseSens;
    public bool invertX;
    public bool invertY;

    public bool canJump, canDoubleJump;
    public Transform groundCheck;
    public LayerMask whatIsGround;

    public Animator animate;

    public GameObject bullet;
    public Transform firePoint;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float yStore = moveInput.y;

        Vector3 vertMove = transform.forward * Input.GetAxisRaw("Vertical");
        Vector3 horzMove = transform.right * Input.GetAxisRaw("Horizontal");

        moveInput = (horzMove + vertMove);
        moveInput.Normalize();
         
        //To Run

        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveInput *= runSpeed;
        }
        else
        {
            moveInput *= moveSpeed; 
        }
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

        //For animation

        animate.SetFloat("MovSpeed", moveInput.magnitude);
        animate.SetBool("onGround", canJump);


        //For Shooting

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(camTrans.position, camTrans.forward, out hit, 50))
            {
                if(Vector3.Distance(camTrans.position,hit.point) > 2){
                    firePoint.LookAt(hit.point);
                }
            }
            else
            {
                firePoint.LookAt(camTrans.position + (camTrans.forward * 50));
            }

            Instantiate(bullet, firePoint.position, firePoint.rotation);
        }
    }
}
