public class ClassicCollectibleScript : CollectibleSrcipt
{
    protected override void AlertManagerCollectibleWasPickedUp()
    {
        GetCollectibleManager().CollectibleWasPickedUp(gameObject);
    }
}
