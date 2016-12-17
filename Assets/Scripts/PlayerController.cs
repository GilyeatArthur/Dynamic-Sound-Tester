using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed;

    public Transform transform;

    private AudioSource vSource;
    private AudioSource mSource;
    private AudioSource fSource;
    private AudioSource lSource;

    public LayerMask SongMask;

    private Rigidbody rb;

    //Vector3 vSong = GameObject.FindGameObjectWithTag("Village").transform.position;
    void Start()
    {
        transform = gameObject.GetComponent<Transform>();
        vSource = GameObject.FindGameObjectWithTag("Village").GetComponent<AudioSource>();
        mSource = GameObject.FindGameObjectWithTag("Mountain").GetComponent<AudioSource>();
        fSource = GameObject.FindGameObjectWithTag("Forest").GetComponent<AudioSource>();
        lSource = GameObject.FindGameObjectWithTag("Lake").GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        float curSpeed = Mathf.Abs(speed * Input.GetAxis("Vertical")) + Mathf.Abs(speed * Input.GetAxis("Horizontal"));
        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 0, 1) * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, 0, -1) * speed * Time.deltaTime;
        }

        float villageDistance = Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Village").transform.position) / 10;
        float villageVolume = 1 - villageDistance;
        vSource.volume = villageVolume;

        float mountainDistance = Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Mountain").transform.position) / 10;
        float mountainVolume = 1 - mountainDistance;
        mSource.volume = mountainVolume;

        float forestDistance = Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Forest").transform.position) / 10;
        float forestVolume = 1 - forestDistance;
        fSource.volume = forestVolume;

        float lakeDistance = Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Lake").transform.position) / 10;
        float lakeVolume = 1 - lakeDistance;
        lSource.volume = lakeVolume;


        //GameObject.FindGameObjectWithTag("Village").GetComponent<AudioSource>.audio;


    }

    // Vector3 pos = GameObject.Find("ObjectX").transform.position;

    // Vector3 gObj = GameObject.Find("ObjectX");

    // if (gObj){
    //    pos = gObj.transform.position;
    //}

    //Vector3 vSong = GameObject.FindGameObjectWithTag("Village").transform.position;


}