using UnityEngine.SceneManagement;
public class NextSceneButton : ObjectController
{    public override void OnPointerClick() {
        SceneManager.LoadScene("MountainMap/Mountain");
    }
}
