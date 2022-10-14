
using DigiBugzy.Core.Domain.Projects;

namespace DigiBugzy.Core.EventHandlers
{
    /// <summary>
    /// Usercontrol event argument
    /// </summary>
    public class SelectedProjectDocumentChangedEventArgs
    {
        public ProjectDocument SelectedDocument { get; set; }

        public SelectedProjectDocumentChangedEventArgs(ProjectDocument selectedDocument)
        {
            SelectedDocument = selectedDocument;    
        }
    }
}
