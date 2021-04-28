using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MagicHand : MonoBehaviour
{
    public GameObject yellowEne;
    public GameObject orangeEne;
    public GameObject atackCube;
    public GameObject atackBlade;
    public GameObject Player;
    public float cube_speed = 500;

    public int charge_require_count;

    GameObject YellowEne;
    GameObject OrangeEne;
    GameObject AtackCube;

    Vector3 Atackforce;

    bool modeCharge = true;

    protected int charge_count;


    // Update is called once per frame
    void Update()
    {

        if (OVRInput.GetDown(OVRInput.RawButton.A))
        {
            modeCharge = true;

            YellowEne = (GameObject)Instantiate(yellowEne, this.transform.position, Quaternion.identity);
            YellowEne.transform.parent = Player.transform;

        }
        if(OVRInput.GetUp(OVRInput.RawButton.A))
        {
            if (charge_count > charge_require_count)
            {
                Destroy(OrangeEne);

                AtackCube = (GameObject)Instantiate(atackCube, this.transform.position, Quaternion.identity);

                Atackforce = this.gameObject.transform.forward * cube_speed;

                AtackCube.GetComponent<Rigidbody>().AddForce(Atackforce);

            }
            else
            {
                Destroy(YellowEne);
            }
        }

        if (OVRInput.Get(OVRInput.RawButton.A))
        {
            charge_count++;
        }
        else
        {
            charge_count = 0;
        }

        if(modeCharge == true && charge_count > charge_require_count)
        {
            Destroy(YellowEne);
            modeCharge = false;

            OrangeEne = (GameObject)Instantiate(orangeEne, this.transform.position, Quaternion.identity);
            OrangeEne.transform.parent = Player.transform;
        }

    }
}
