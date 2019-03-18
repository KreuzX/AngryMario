using UnityEngine;

public class CatapultCtrl : Controllable
{
    private Transform catapultTr;
    private Animator catapultAnim;
    private readonly int hashAngle = Animator.StringToHash("AngleChangeValue");
    private readonly int hashFire = Animator.StringToHash("Fire");

    private float spoonRot = 0.0f;

    private float rotSpeed = 1.0f;
    private float spoonRotSpeed = 0.1f;
    private bool isFire = false;

    private void Awake()
    {
        catapultTr = GetComponent<Transform>();
        catapultAnim = GetComponent<Animator>();
    }

    public override void OnCtrl(ButtonType type)
    {
        Debug.Log(catapultTr.rotation.eulerAngles.y);
        switch (type)
        {
            case ButtonType.Left:
                if (catapultTr.rotation.eulerAngles.y <= 45) return;
                catapultTr.Rotate(Vector3.up, -rotSpeed);
                break;

            case ButtonType.Right:
                if (catapultTr.rotation.eulerAngles.y >= 135) return;
                catapultTr.Rotate(Vector3.up, +rotSpeed);
                break;

            case ButtonType.Up:
                if (spoonRot <= 0)
                {
                    spoonRot = 0;
                    return;
                }
                spoonRot -= spoonRotSpeed * Time.deltaTime;
                catapultAnim.SetFloat(hashAngle, spoonRot);
                break;

            case ButtonType.Down:
                isFire = false;
                if (spoonRot >= 1)
                {
                    spoonRot = 1;
                    return;
                }
                spoonRot += spoonRotSpeed * Time.deltaTime;
                catapultAnim.SetFloat(hashAngle, spoonRot);
                break;

            case ButtonType.Shot:
                if (!isFire)
                {
                    isFire = true;
                    catapultAnim.SetTrigger(hashFire);
                    spoonRot = 0.0f;
                    catapultAnim.SetFloat(hashAngle, spoonRot);
                }
                break;
        }
    }
}
