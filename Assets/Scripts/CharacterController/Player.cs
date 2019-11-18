using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController2D controller;
    public Joystick joystick;
    [SerializeField] public int test;
    float horizontalMove = 0f;
    public float runSpeed = 25f;
    private Animator anim;
    bool Jump = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (this.anim.GetCurrentAnimatorStateInfo(0).IsTag("Attack")) Debug.Log("Attack");
    }
    private void FixedUpdate()
    {
        //Debug.Log(joystick.Horizontal);
        
        if (joystick.Horizontal >= .2f)
        {
            horizontalMove = runSpeed;
            if (Jump != true)
                anim.SetBool("isRunning", true);
            else anim.SetBool("isRunning", false);

        }
        else if (joystick.Horizontal <= -.2f)
        {
            horizontalMove = -runSpeed;
            if (Jump != true)
                anim.SetBool("isRunning", true);
            else anim.SetBool("isRunning", false);
        }
        else
        {
            horizontalMove = 0;
            anim.SetBool("isRunning", false);
        }

        float verticalMove = joystick.Vertical;
        if (verticalMove >= .5f)
        {
            Jump = true;
        }
        else Jump = false;
        controller.Move(horizontalMove, false, Jump);

    }

    public void Attack()
    {
        
        anim.SetTrigger("Attack");

    }

    public void Damage()
    {
        Heart.heart -= 10f;
    }
}
