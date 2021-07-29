using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static AudioClip _25kmSound, _50kmSound, _75kmSound, _100kmSound, _200kmSound, citerneSound, creveSound, 
        essenceSound, fastfuriousSound, feuvertSound, finlimiteSound, increvableSound, 
        limiteSound, panneSound, piouSound, prioritaireSound, carglassSound, roulezSound, seeyouagainSound,
        stopSound, victoireSound, zeepartiSound, vroumSound, accidenSound;

    static AudioSource audioSrc;

    void Start()
    {
        _25kmSound = Resources.Load<AudioClip>("25km");
        _50kmSound = Resources.Load<AudioClip>("50km");
        _75kmSound = Resources.Load<AudioClip>("75km");
        _100kmSound = Resources.Load<AudioClip>("100km");
        _200kmSound = Resources.Load<AudioClip>("deja-vu");
        citerneSound = Resources.Load<AudioClip>("citerne");
        creveSound = Resources.Load<AudioClip>("creve"); 
        essenceSound = Resources.Load<AudioClip>("essence");
        fastfuriousSound = Resources.Load<AudioClip>("fastfurious");
        feuvertSound = Resources.Load<AudioClip>("feu-vert");
        finlimiteSound = Resources.Load<AudioClip>("finlimite");
        increvableSound = Resources.Load<AudioClip>("increvable"); 
        limiteSound = Resources.Load<AudioClip>("limite");
        panneSound = Resources.Load<AudioClip>("panne");
        piouSound = Resources.Load<AudioClip>("piou");
        prioritaireSound = Resources.Load<AudioClip>("prioritaire");
        carglassSound = Resources.Load<AudioClip>("pub-carglass-1");
        roulezSound = Resources.Load<AudioClip>("roulez");
        seeyouagainSound = Resources.Load<AudioClip>("seeyouagain");
        stopSound = Resources.Load<AudioClip>("stop");
        victoireSound = Resources.Load<AudioClip>("victoire");
        zeepartiSound = Resources.Load<AudioClip>("vroum");
        vroumSound = Resources.Load<AudioClip>("zeeeparti");
        accidenSound = Resources.Load<AudioClip>("crash");

        audioSrc = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    public static void PlaySoound (string clip)
    {
        switch(clip)
        {
            case "25km":
                audioSrc.PlayOneShot(_25kmSound);
                break;
            case "50km":
                audioSrc.PlayOneShot(_50kmSound);
                break;
            case "75km":
                audioSrc.PlayOneShot(_75kmSound);
                break;
            case "100km":
                audioSrc.PlayOneShot(_100kmSound);
                break;
            case "deja-vu":
                audioSrc.PlayOneShot(_200kmSound);
                break;
            case "citerne":
                audioSrc.PlayOneShot(citerneSound);
                break;
            case "creve":
                audioSrc.PlayOneShot(creveSound);
                break;
            case "essence":
                audioSrc.PlayOneShot(essenceSound);
                break;
            case "fastfurious":
                audioSrc.PlayOneShot(fastfuriousSound);
                break;
            case "feu-vert":
                audioSrc.PlayOneShot(feuvertSound);
                break;
            case "finlimite":
                audioSrc.PlayOneShot(finlimiteSound);
                break;
            case "increvable":
                audioSrc.PlayOneShot(increvableSound);
                break;
            case "limite":
                audioSrc.PlayOneShot(limiteSound);
                break;
            case "panne":
                audioSrc.PlayOneShot(panneSound);
                break;
            case "piou":
                audioSrc.PlayOneShot(piouSound);
                break;
            case "prioritaire":
                audioSrc.PlayOneShot(prioritaireSound);
                break;
            case "pub-carglass-1":
                audioSrc.PlayOneShot(carglassSound);
                break;
            case "roulez":
                audioSrc.PlayOneShot(roulezSound);
                break;
            case "seeyouagain":
                audioSrc.PlayOneShot(seeyouagainSound);
                break;
            case "stop":
                audioSrc.PlayOneShot(stopSound);
                break;
            case "victoire":
                audioSrc.PlayOneShot(victoireSound);
                break;
            case "vroum":
                audioSrc.PlayOneShot(zeepartiSound);
                break;
            case "zeeeparti":
                audioSrc.PlayOneShot(vroumSound);
                break;
            case "crash":
                audioSrc.PlayOneShot(accidenSound);
                break;
            default:
                break;
        }
    }
}
