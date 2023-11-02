using UnityEngine.UI;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    public GameObject optionPrefab;
    
    public Transform prevCharacter;
    public Transform nextCharacter;
    public Transform SelectedCharcter;
    // Start is called before the first frame update
    void Start()
    {
        foreach(Character2 c in GameManager.instance.characters)
        {
            GameObject option=Instantiate(optionPrefab,transform);
           Button button=option.GetComponent<Button>();
            button.onClick.AddListener(()=>{
                GameManager.instance.SetCharacter(c);
                if(SelectedCharcter !=null)
                {
                    prevCharacter=SelectedCharcter;
                }
                SelectedCharcter=option.transform;
            });
            // Text text=option.GetComponentInChildren<Text>();
            // text.text=c.name;

            // Image image=option.GetComponentInChildren<Image>();
            // image.sprite=c.icon;

        }
    }
    void Update()
    {
        if(SelectedCharcter!=null)
        {
            SelectedCharcter.localScale=Vector3.Lerp(SelectedCharcter.localScale,new Vector3(1.2f,1.2f,1.2f),Time.deltaTime*10);
        }
        if(prevCharacter!=null)
        {
            prevCharacter.localScale=Vector3.Lerp(prevCharacter.localScale,new Vector3(1f,1f,1f),Time.deltaTime*10);
        }
    }

    
}
