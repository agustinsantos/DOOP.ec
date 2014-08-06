
namespace Rtps.Behavior.Types
{
    /// <summary>
    /// Enumeration used to indicate the status of a ChangeForReader.
    /// </summary>
    public enum ChangeForReaderStatusKind
    {
        UNSENT, 
        UNACKNOWLEDGED, 
        REQUESTED,
        ACKNOWLEDGED, 
        UNDERWAY
    }
}
