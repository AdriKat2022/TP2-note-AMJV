using System.Collections;
using UnityEngine;


public struct PlayerInput
{
    public float horizontalAxis;
    public float verticalAxis;

    public bool braking;
    public bool boostRequest;

    public void LoadPlayerInput()
    {
        horizontalAxis = Input.GetAxis("Horizontal");
        verticalAxis = Input.GetAxis("Vertical");

        braking = Input.GetKey(KeyCode.Z);
        boostRequest = Input.GetKey(KeyCode.LeftShift);
    }
}


public class CarMovement : MonoBehaviour
{
    [Header("Mobility")]
    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private float minSpeed;
    [SerializeField]
    private float accelerationForce;
    [SerializeField]
    private float brakeForce;
    [SerializeField]
    private float turningSpeed;


    [Header("Boost")]
    [SerializeField]
    private float boostMaxspeed;
    [SerializeField]
    private float boostForce;
    [SerializeField]
    private float boostDuration;
    [SerializeField]
    private float boostCooldown;
    [SerializeField]
    private bool canTurnDuringBoost;


    private bool isBoosting;
    private float boostTimer;


    private Rigidbody rb;
    private float currentSpeed;

    private PlayerInput playerInput;



    private void Start()
    {
        TryGetComponent(out rb);

        currentSpeed = 0;

        boostTimer = boostCooldown;
    }


    private void Update()
    {
        playerInput = new PlayerInput();

        playerInput.LoadPlayerInput();

        ChangeVelocity();

        TurnCar();

        Move();

        CheckBoostInput();
    }

    private void CheckBoostInput()
    {
        boostTimer += Time.deltaTime;


        if (!playerInput.boostRequest || isBoosting || boostTimer < boostCooldown)
            return;

        StartCoroutine(Boosting());
    }

    private void TurnCar()
    {
        transform.Rotate(Time.deltaTime * playerInput.horizontalAxis * turningSpeed * Vector3.up);
    }

    private void Move()
    {
        rb.MovePosition(rb.position + currentSpeed * Time.deltaTime * transform.forward);
    }

    private void ChangeVelocity()
    {
        if (playerInput.braking)
            Brake();
        else
            Accelerate();
    }

    private void Accelerate()
    {
        currentSpeed = Mathf.Lerp(currentSpeed, maxSpeed, Time.deltaTime * accelerationForce);
    }
    private void Brake()
    {
        currentSpeed = Mathf.Lerp(currentSpeed, minSpeed, Time.deltaTime * brakeForce);
    }

    private IEnumerator Boosting()
    {
        isBoosting = true;

        float timer = 0;

        Debug.Log("boost !!");

        while (isBoosting)
        {
            timer += Time.deltaTime;
            if(timer > boostDuration)
            {
                isBoosting = false;
                yield break;
            }

            rb.AddForce(transform.forward * boostForce);
            yield return null;
        }
    }

    private void StopBoost() => isBoosting = false;
}
