using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiSi.Bot.TaskManager.DB.Entities;
public class ProjectUri
{
    public ProjectUri()
    {
    }

    public ProjectUri(Project project, string title, string uri)
    {
        Project = project;
        Title = title;
        Uri = uri;
    }

    public long Id { get; set; }

    public virtual Project Project { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Uri { get; set; } = null!;
}
