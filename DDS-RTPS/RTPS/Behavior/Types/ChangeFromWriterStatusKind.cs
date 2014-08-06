
namespace Rtps.Behavior.Types
{
    /// <summary>
    /// Enumeration used to indicate the status of a ChangeFromWriter.
    /// </summary>
    public enum ChangeFromWriterStatusKind
    {
        LOST, 
        MISSING, 
        RECEIVED, 
        UNKNOWN
    }
}
