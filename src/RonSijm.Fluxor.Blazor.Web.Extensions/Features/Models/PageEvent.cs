namespace RonSijm.Syringe.Models;

public class PageEvent(PageEventType type, Type source)
{
    public PageEventType Type { get; set; } = type;
    public Type Source { get; set; } = source;
}

public enum PageEventType
{
    OnAfterRender,
    FirstTimeOnAfterRender,
    OnInitialized
}