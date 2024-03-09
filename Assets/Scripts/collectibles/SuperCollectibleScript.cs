public class SuperCollectibleScript : CollectibleSrcipt
{
    protected override void AlertManagerCollectibleWasPickedUp()
    {
        GetCollectibleManager().SuperCollectibleWasPickedUp(gameObject);
    }
}
