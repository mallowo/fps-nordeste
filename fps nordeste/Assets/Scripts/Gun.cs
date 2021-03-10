using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{

    //declaração das variáveis
    public float damage;
    public float fireRate;
    public float spray;
    public float weight;
    public float reloadTime;
    public int type;
    public int maxAmmo;

    public int currentAmmo;
    
    private bool isReloading = false;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;

    private float nextTimeToFire = 0f;

    public Animator animator;

    void Start ()
    {
        //resetar a quantidade de bala
        if (currentAmmo == -1)
            currentAmmo = maxAmmo;
    }

    void OnEnable ()
    {
        isReloading = false;
        animator.SetBool("Reloading", false);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (isReloading)
            return;

        //acionar a função de reload quando não tiver mais munição ou quando a key R for apertada
        if((currentAmmo <= 0) || (Input.GetKeyDown(KeyCode.R)))
        {
            StartCoroutine(Reload());
            return;
        }
        
        //acionar a função de atirar quando o botão for pressionado e o tempo de tiro for coerente
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f/fireRate;
            Shoot();
        }
    }

    //função de reload
    IEnumerator Reload ()
    {
        isReloading = true;
        Debug.Log("Reloading...");

        animator.SetBool("Reloading", true);

        yield return new WaitForSeconds(reloadTime - .25f);
        animator.SetBool("Reloading", false);
                yield return new WaitForSeconds(.25f);


        currentAmmo = maxAmmo;
        isReloading = false;
    }

    //função de atirar
    void Shoot ()
    {
        muzzleFlash.Play();

        currentAmmo--;
        
        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }
}
